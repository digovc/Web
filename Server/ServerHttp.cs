using System.Collections.Generic;
using System.IO;
using System.Reflection;
using NetZ.Persistencia;
using NetZ.Persistencia.Interface;
using NetZ.Web.Server.Arquivo;
using NetZ.Web.Server.Arquivo.Css;

namespace NetZ.Web.Server
{
    /// <summary>
    /// Classe principal do servidor WEB e gerencia todas as conexões com os clientes, assim como
    /// processa e responde as solicitações destes.
    /// <para>
    /// A aplicação que fazer uso desta biblioteca não precisa interagir diretamente com esta classe,
    /// implementando sua lógica a partir da class <see cref="AppWeb"/> e seu método <see cref="AppWeb.responder(Solicitacao)"/>.
    /// </para>
    /// </summary>
    public abstract class ServerHttp : ServerBase
    {
        #region Constantes

        public const string STR_COOKIE_SESSAO_ID_NOME = "sessao_id";
        private const string STR_GET_SCRIPT = "get-script";
        private const string URL_DATA_BASE_FILE_DOWNLOAD = "/data-base-file-download";

        #endregion Constantes

        #region Atributos

        private List<ArquivoEstatico> _lstArqEstatico;

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

        #endregion Atributos

        #region Construtores

        protected ServerHttp(string strNome) : base(strNome)
        {
        }

        #endregion Construtores

        #region Métodos

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

        protected override int getIntPort()
        {
            return ConfigWeb.i.intServerHttpPorta;
        }

        protected override void inicializar()
        {
            base.inicializar();

            this.criarDiretorio();
            this.inicializarArquivoEstatico();
        }

        private void criarDiretorio()
        {
            if (Directory.Exists("res"))
            {
                return;
            }

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
            string dir = Assembly.GetEntryAssembly().Location;

            if (string.IsNullOrEmpty(dir))
            {
                return;
            }

            dir = Path.GetDirectoryName(dir);

            if (string.IsNullOrEmpty(dir))
            {
                return;
            }

            dir = dir + "\\res";

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

                this.inicializarArquivoEstaticoArquivo(dirArquivo);
            }
        }

        private void inicializarArquivoEstaticoArquivo(string dirArquivo)
        {
            if (string.IsNullOrEmpty(dirArquivo))
            {
                return;
            }

            if (!File.Exists(dirArquivo))
            {
                return;
            }

            ArquivoEstatico arq = new ArquivoEstatico();

            arq.dirCompleto = dirArquivo.ToLower();

            this.lstArqEstatico.Add(arq);
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

            if (CssMain.STR_CSS_SRC.Equals(objSolicitacao.strPagina))
            {
                return this.responderArquivoEstatico(objSolicitacao, CssMain.i);
            }

            if (CssPrint.STR_CSS_SRC.Equals(objSolicitacao.strPagina))
            {
                return this.responderArquivoEstatico(objSolicitacao, CssPrint.i);
            }

            if (STR_GET_SCRIPT.Equals(objSolicitacao.getStrGetValue("method")))
            {
                return this.responderArquivoEstaticoGetScript(objSolicitacao);
            }

            foreach (ArquivoEstatico arq in this.lstArqEstatico)
            {
                if (arq == null)
                {
                    continue;
                }

                if (string.IsNullOrEmpty(arq.dirWeb))
                {
                    continue;
                }

                if (!File.Exists(arq.dirCompleto))
                {
                    continue;
                }

                if (!arq.dirWeb.ToLower().Equals(objSolicitacao.strPagina.ToLower()))
                {
                    continue;
                }

                return this.responderArquivoEstatico(objSolicitacao, arq);
            }

            return this.responderArquivoEstaticoNaoEncontrado(objSolicitacao);
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

            Resposta objResposta = new Resposta(objSolicitacao);

            objResposta.addArquivo(arq);

            return objResposta;
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
            return new Resposta(objSolicitacao) { intStatus = 404 };
        }

        private Resposta responderDbFileDownload(Solicitacao objSolicitacao)
        {
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

            Tabela tbl = AppWeb.i.getTbl(strTblNome);

            if (tbl == null)
            {
                return null;
            }

            if (!(tbl is ITblArquivo))
            {
                return null;
            }

            tbl.recuperar(intRegistroId);

            if (!intRegistroId.Equals(tbl.clnIntId.intValor))
            {
                return null;
            }

            if ((tbl as ITblArquivo).getClnArq().arrBteValor == null)
            {
                return null;
            }

            if ((tbl as ITblArquivo).getClnArq().arrBteValor.Length < 1)
            {
                return null;
            }

            ArquivoEstatico arqDownload = new ArquivoEstatico();

            arqDownload.arrBteConteudo = (tbl as ITblArquivo).getClnArq().arrBteValor;
            arqDownload.dttUltimaModificacao = (tbl as ITblArquivo).getClnDttArquivoModificacao().dttValor;
            arqDownload.strNome = (tbl as ITblArquivo).getClnStrArquivoNome().strValor;

            tbl.liberar();

            return this.responderArquivoEstatico(objSolicitacao, arqDownload);
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}