using DigoFramework;
using NetZ.Persistencia;
using NetZ.Web.Html.Pagina;
using NetZ.Web.Server.Arquivo;
using NetZ.Web.Server.Arquivo.Css;
using NetZ.Web.UiManager;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace NetZ.Web.Server
{
    /// <summary>
    /// Classe principal do servidor WEB e gerencia todas as conexões com os clientes, assim como
    /// processa e responde as solicitações destes.
    /// <para>
    /// A aplicação que fazer uso desta biblioteca não precisa interagir diretamente com esta classe,
    /// implementando sua lógica a partir da class <see cref="AppWebBase"/> e seu método <see cref="AppWebBase.responder(Solicitacao)"/>.
    /// </para>
    /// </summary>
    public abstract class SrvHttpBase : ServerBase
    {
        #region Constantes

        public const string STR_COOKIE_SESSAO = "sessao";

        private const string STR_GET_SCRIPT = "get-script";
        private const string URL_DATA_BASE_FILE_DOWNLOAD = "/data-base-file-download";

        #endregion Constantes

        #region Atributos

        private List<ArquivoEstatico> _lstArqEstatico;
        private UiExportBase _objUiManager;

        private List<ArquivoEstatico> lstArqEstatico
        {
            get
            {
                if (_lstArqEstatico != null)
                {
                    return _lstArqEstatico;
                }

                _lstArqEstatico = new List<ArquivoEstatico>();

                return _lstArqEstatico;
            }
        }

        private UiExportBase objUiManager
        {
            get
            {
                if (_objUiManager != null)
                {
                    return _objUiManager;
                }

                _objUiManager = this.getObjUiManager();

                return _objUiManager;
            }
        }

        #endregion Atributos

        #region Construtores

        protected SrvHttpBase() : base("Servidor HTTP")
        {
        }

        #endregion Construtores

        #region Métodos

        public string getStrPaginaNome(Type cls)
        {
            if (cls == null)
            {
                return null;
            }

            if (!typeof(PaginaHtmlBase).IsAssignableFrom(cls))
            {
                return null;
            }

            return (Utils.simplificar(cls.Name) + ".html");
        }

        /// <summary>
        /// Este método é disparado a acada vez que o cliente fizer uma solicitação de algum recurso
        /// a este WEB server.
        /// </summary>
        /// <param name="objSolicitacao">
        /// Classe que trás todas as informações da solicitação que foi encaminhada pelo servidor.
        /// <para>
        /// Uma das propriedades mais importantes que deve ser verificada é a <see
        /// cref="Solicitacao.dttUltimaModificacao"/>, para evitar que recursos em cache sejam
        /// enviados desnecessariamente para o cliente.
        /// </para>
        /// </param>
        /// <returns></returns>
        public override Resposta responder(Solicitacao objSolicitacao)
        {
            if (objSolicitacao == null)
            {
                return null;
            }

            if (string.IsNullOrEmpty(objSolicitacao.strPaginaCompleta))
            {
                return null;
            }

            if (objSolicitacao.strPaginaCompleta.ToLower().StartsWith("/res/"))
            {
                return this.responderArquivoEstatico(objSolicitacao);
            }

            switch (objSolicitacao.strPagina)
            {
                case URL_DATA_BASE_FILE_DOWNLOAD:
                    return this.responderDbFileDownload(objSolicitacao);
            }

            return null;
        }

        protected void addArquivoEstatico(string dirArquivo)
        {
            if (string.IsNullOrEmpty(dirArquivo))
            {
                return;
            }

            if (!File.Exists(dirArquivo))
            {
                return;
            }

            var arq = new ArquivoEstatico();

            arq.dirCompleto = dirArquivo;

            if (this.lstArqEstatico.Find(a => a.dirCompleto.Equals(dirArquivo)) != null)
            {
                return;
            }

            this.lstArqEstatico.Add(arq);
        }

        protected override int getIntPorta()
        {
            return 80;
        }

        protected virtual UiExportBase getObjUiManager()
        {
            return null;
        }

        protected override void inicializar()
        {
            base.inicializar();

            this.criarDiretorio();

            this.inicializarHtmlEstatico();

            this.inicializarArquivoEstatico();
        }

        protected Resposta responderArquivoEstatico(Solicitacao objSolicitacao, string dirArquivo)
        {
            if (string.IsNullOrWhiteSpace(dirArquivo))
            {
                return null;
            }

            foreach (var arq in this.lstArqEstatico)
            {
                if (arq == null)
                {
                    continue;
                }

                if (string.IsNullOrEmpty(arq.dirWeb))
                {
                    continue;
                }

                if (!arq.dirWeb.ToLower().Equals(dirArquivo.ToLower()))
                {
                    continue;
                }

                return this.responderArquivoEstatico(objSolicitacao, arq);
            }

            return this.responderArquivoEstaticoNaoEncontrado(objSolicitacao);
        }

        private void criarDiretorio()
        {
            if (Directory.Exists("res"))
            {
                return;
            }

            Log.i.info("Criando a pasta de \"resources\" (res).");

            Directory.CreateDirectory("res");
        }

        private ArquivoEstatico getArqJs(string strJsClass)
        {
            if (string.IsNullOrEmpty(strJsClass))
            {
                return null;
            }

            foreach (ArquivoEstatico arq in this.lstArqEstatico)
            {
                if (arq == null)
                {
                    continue;
                }

                if (!strJsClass.ToLower().Equals(Path.GetFileNameWithoutExtension(arq.dirCompleto)))
                {
                    continue;
                }

                return arq;
            }

            return null;
        }

        private void inicializarArquivoEstatico()
        {
            Log.i.info("Inicializando os arquivos estáticos da pasta de \"resources\" (res).");

            var dir = Assembly.GetEntryAssembly().Location;

            dir = Path.GetDirectoryName(dir);

            dir = Path.Combine(dir, "res");

            this.inicializarArquivoEstatico(dir);
        }

        private void inicializarArquivoEstatico(string dir)
        {
            if (!Directory.Exists(dir))
            {
                return;
            }

            foreach (string dir2 in Directory.GetDirectories(dir))
            {
                if (string.IsNullOrEmpty(dir2))
                {
                    continue;
                }

                this.inicializarArquivoEstatico(dir2);
            }

            foreach (string dirArquivo in Directory.GetFiles(dir))
            {
                if (string.IsNullOrEmpty(dirArquivo))
                {
                    continue;
                }

                this.addArquivoEstatico(dirArquivo);
            }
        }

        private void inicializarHtmlEstatico()
        {
            if (this.objUiManager == null)
            {
                return;
            }

            Log.i.info("Exportando páginas estáticas.");

            this.objUiManager.iniciar();
        }

        private Resposta responderArquivoEstatico(Solicitacao objSolicitacao)
        {
            if (objSolicitacao == null)
            {
                return null;
            }

            if (string.IsNullOrEmpty(objSolicitacao.strPagina))
            {
                return null;
            }

            var objResposta = this.responderArquivoEstaticoCss(objSolicitacao);

            if (objResposta != null)
            {
                return objResposta;
            }

            objResposta = this.responderArquivoEstaticoCss(objSolicitacao);

            if (objResposta != null)
            {
                return objResposta;
            }

            if (STR_GET_SCRIPT.Equals(objSolicitacao.getStrGetValue("method")))
            {
                return this.responderArquivoEstaticoGetScript(objSolicitacao);
            }

            return this.responderArquivoEstatico(objSolicitacao, objSolicitacao.strPagina);
        }

        private Resposta responderArquivoEstatico(Solicitacao objSolicitacao, ArquivoEstatico arq)
        {
            if (objSolicitacao == null)
            {
                return null;
            }

            if (arq == null)
            {
                return null;
            }

            return new Resposta(objSolicitacao).addArquivo(arq);
        }

        private Resposta responderArquivoEstaticoCss(Solicitacao objSolicitacao)
        {
            if ((this.objUiManager != null) && this.objUiManager.getBooExportarCss())
            {
                return null;
            }

            if (CssMain.SRC_CSS.Equals(objSolicitacao.strPagina))
            {
                return this.responderArquivoEstatico(objSolicitacao, CssMain.i);
            }

            if (CssPrint.SRC_CSS.Equals(objSolicitacao.strPagina))
            {
                return this.responderArquivoEstatico(objSolicitacao, CssPrint.i);
            }

            return null;
        }

        private Resposta responderArquivoEstaticoGetScript(Solicitacao objSolicitacao)
        {
            if (objSolicitacao == null)
            {
                return this.responderArquivoEstaticoNaoEncontrado(objSolicitacao);
            }

            string strJsClass = objSolicitacao.getStrGetValue("class");

            if (string.IsNullOrEmpty(strJsClass))
            {
                return this.responderArquivoEstaticoNaoEncontrado(objSolicitacao);
            }

            ArquivoEstatico arqJq = this.getArqJs(strJsClass);

            if (arqJq == null)
            {
                return this.responderArquivoEstaticoNaoEncontrado(objSolicitacao);
            }

            return new Resposta(objSolicitacao).addArquivo(arqJq);
        }

        private Resposta responderArquivoEstaticoNaoEncontrado(Solicitacao objSolicitacao)
        {
            Log.i.erro("Arquivo estático ({0}) não encontrado.", objSolicitacao.strPaginaCompleta);

            return new Resposta(objSolicitacao) { intStatus = 404 };
        }

        private Resposta responderDbFileDownload(Solicitacao objSolicitacao)
        {
            if (AppWebBase.i == null)
            {
                return null;
            }

            if (AppWebBase.i.dbe == null)
            {
                return null;
            }

            if (objSolicitacao == null)
            {
                return null;
            }

            if (objSolicitacao.objUsuario == null)
            {
                return null;
            }

            if (!objSolicitacao.objUsuario.booLogado)
            {
                return new Resposta(objSolicitacao).addHtml("Usuário não autorizado."); // TODO: Criar uma página de "sem permissão de acesso ao recurso".
            }

            int intRegistroId = objSolicitacao.getIntGetValue("registro_id");

            if (intRegistroId < 1)
            {
                return null;
            }

            string strTblNome = objSolicitacao.getStrGetValue("tbl_web_nome");

            if (string.IsNullOrEmpty(strTblNome))
            {
                return null;
            }

            TabelaBase tbl = AppWebBase.i.dbe[strTblNome];

            if (tbl == null)
            {
                return null;
            }

            tbl.recuperar(intRegistroId);

            if (!intRegistroId.Equals(tbl.clnIntId.intValor))
            {
                return null;
            }

            var arqDownload = new ArquivoEstatico();

            //arqDownload.arrBteConteudo = (tbl as ITblArquivo).getClnArq().arrBteValor;
            //arqDownload.dttAlteracao = (tbl as ITblArquivo).getClnDttArquivoModificacao().dttValor;
            //arqDownload.strNome = (tbl as ITblArquivo).getClnStrArquivoNome().strValor;

            // TODO: Refazer.

            tbl.liberarThread();

            return this.responderArquivoEstatico(objSolicitacao, arqDownload);
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}