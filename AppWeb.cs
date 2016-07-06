using System;
using System.Collections.Generic;
using System.Data;
using DigoFramework.Json;
using NetZ.Persistencia;
using NetZ.Persistencia.Web;
using NetZ.SistemaBase;
using NetZ.Web.DataBase;
using NetZ.Web.DataBase.Tabela;
using NetZ.Web.Html.Componente.Grid;
using NetZ.Web.Html.Componente.Janela.Cadastro;
using NetZ.Web.Html.Componente.Janela.Consulta;
using NetZ.Web.Server;

namespace NetZ.Web
{
    /// <summary>
    /// Classe mais importante para a utilização desta biblioteca. Ele que faz a ligação de toda a
    /// lógica interna do servidor WEB e os clientes que consomem os recursos deste.
    /// <para>
    /// Essa classe deve ser herdada por uma classe do desenvolvedor que represente a sua própria aplicação.
    /// </para>
    /// <para>
    /// Para interceptar e construir as páginas da aplicação WEB, esta classe que herda desta,
    /// obrigatóriamente terá de implementar o método <see cref="responder(Solicitacao)"/>, sendo
    /// capaz através disto, construir as respostas adequadas para os clientes e suas solicitações.
    /// </para>
    /// </summary>
    public abstract class AppWeb : App
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private static AppWeb _i;

        private bool _booMostrarGrade;
        private List<Usuario> _lstObjUsuario;
        private List<Tabela> _lstTbl;
        private Persistencia.DataBase _objDbPrincipal;
        private object _objLstObjUsuarioLock;

        public new static AppWeb i
        {
            get
            {
                return _i;
            }

            set
            {
                if (_i != null)
                {
                    return;
                }

                _i = value;
            }
        }

        /// <summary>
        /// Caso esta propriedade seja marcada como true, todas as tags geradas serão marcadas
        /// automaticamente para mostrar uma borda para que fique visível o tamanho de gasto por
        /// todas elas.
        /// <para>Utilize esta função para facilitar a montagem da tela.</para>
        /// <para>
        /// Lembre-se de considerar que a borda que será apresentada consome 1px nos quatro lados do
        /// componente, o que pode "estourar" o layout.
        /// </para>
        /// </summary>
        public bool booMostrarGrade
        {
            get
            {
                return _booMostrarGrade;
            }

            set
            {
                _booMostrarGrade = value;
            }
        }

        public Persistencia.DataBase objDbPrincipal
        {
            get
            {
                if (_objDbPrincipal != null)
                {
                    return _objDbPrincipal;
                }

                _objDbPrincipal = this.getObjDbPrincipal();

                return _objDbPrincipal;
            }
        }

        internal List<Usuario> lstObjUsuario
        {
            get
            {
                if (_lstObjUsuario != null)
                {
                    return _lstObjUsuario;
                }

                _lstObjUsuario = new List<Usuario>();

                return _lstObjUsuario;
            }
        }

        private List<Tabela> lstTbl
        {
            get
            {
                if (_lstTbl != null)
                {
                    return _lstTbl;
                }

                _lstTbl = new List<Tabela>();

                return _lstTbl;
            }
        }

        private object objLstObjUsuarioLock
        {
            get
            {
                if (_objLstObjUsuarioLock != null)
                {
                    return _objLstObjUsuarioLock;
                }

                _objLstObjUsuarioLock = new object();

                return _objLstObjUsuarioLock;
            }
        }

        #endregion Atributos

        #region Construtores

        protected AppWeb(string strNome)
        {
            i = this;

            this.strNome = strNome;

            this.inicializarLstTbl(this.lstTbl);
        }

        #endregion Construtores

        #region Métodos

        /// <summary>
        /// Pesquisa na lista de tabelas da aplicação a que corresponde a <paramref name="tblWeb"/>,
        /// segundo o nome dessa.
        /// </summary>
        /// <param name="tblWeb">Tabela web que se pretende encontar a correlativa do lado do servidor.</param>
        /// <returns>Retorna a tabela correlativa à tabela web passada por parâmetro.</returns>
        public Tabela getTbl(TabelaWeb tblWeb)
        {
            if (tblWeb == null)
            {
                return null;
            }

            if (string.IsNullOrEmpty(tblWeb.strNome))
            {
                return null;
            }

            return this.getTbl(tblWeb.strNome);
        }

        /// <summary>
        /// Pesquisa na lista de tabelas da aplicação e retorna a tabela que corresponde a este nome
        /// passado por parâmetro.
        /// </summary>
        /// <param name="strTblNome">Nome da tabela que se pretende encontrar.</param>
        /// <returns>Retorna a tabela que corresponde a este nome passado por parâmetro.</returns>
        public Tabela getTbl(string strTblNome)
        {
            if (string.IsNullOrEmpty(strTblNome))
            {
                return null;
            }

            if (this.lstTbl == null)
            {
                return null;
            }

            foreach (Tabela tbl in this.lstTbl)
            {
                Tabela tblResultado = this.getTbl(strTblNome, tbl);

                if (tblResultado == null)
                {
                    continue;
                }

                return tblResultado;
            }

            return null;
        }

        /// <summary>
        /// Inicializa a aplicação e o servidor WEB em sí, juntamente com os demais componentes que
        /// ficarão disponíveis para servir esta aplicação para os cliente.
        /// <para>
        /// Estes serviços levarão em consideração as configurações presentes em <seealso cref="ConfigWeb"/>.
        /// </para>
        /// <para>
        /// O servidor der solicitações AJAX do banco de dados <see cref="ServerAjaxDb"/> também será
        /// inicializado, caso a configuração <seealso cref="ConfigWeb.booServerAjaxDbAtivar"/>
        /// esteja marcada.
        /// </para>
        /// </summary>
        public void inicializarServidor()
        {
            ServerHttp.i.iniciar();

            if (ConfigWeb.i.booServerAjaxDbAtivar)
            {
                ServerAjaxDb.i.iniciar();
            }
        }

        /// <summary>
        /// Para o servidor imediatamente.
        /// </summary>
        public void pararServidor()
        {
            ServerHttp.i.parar();
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
        public abstract Resposta responder(Solicitacao objSolicitacao);

        /// <summary>
        /// Este método é disparado para todas as solicitações que são encaminhadas para o servidor
        /// <see cref="ServerAjaxDb"/>. Estas solicitações estão diretamente ligadas às ações
        /// relativas ao banco de dados como recuperar dados, salvar registros, etc.
        /// <para>Essas solicitação são enviadas por AJAX para o servidor de forma assíncrona.</para>
        /// </summary>
        /// <param name="objSolicitacaoAjaxDb">
        /// Solicitação contendo as informações da operação aguardada pelo usuário.
        /// </param>
        /// <returns>Retorna a resposta que será processada pelo browser do cliente.</returns>
        public void responderAjaxDb(Solicitacao objSolicitacao, SolicitacaoAjaxDb objSolicitacaoAjaxDb)
        {
            if (objSolicitacaoAjaxDb == null)
            {
                return;
            }

            switch (objSolicitacaoAjaxDb.enmMetodo)
            {
                case SolicitacaoAjaxDb.EnmMetodo.APAGAR:
                    this.apagarRegistro(objSolicitacao, objSolicitacaoAjaxDb);
                    return;

                case SolicitacaoAjaxDb.EnmMetodo.ABRIR_CADASTRO:
                case SolicitacaoAjaxDb.EnmMetodo.ABRIR_CADASTRO_FILTRO_CONTEUDO:
                    this.abrirCadastro(objSolicitacao, objSolicitacaoAjaxDb);
                    return;

                case SolicitacaoAjaxDb.EnmMetodo.ABRIR_CONSULTA:
                    this.abrirConsulta(objSolicitacao, objSolicitacaoAjaxDb);
                    return;

                case SolicitacaoAjaxDb.EnmMetodo.CARREGAR_TBL_WEB:
                    this.carregarTbl(objSolicitacao, objSolicitacaoAjaxDb);
                    return;

                case SolicitacaoAjaxDb.EnmMetodo.PESQUISAR_GRID:
                case SolicitacaoAjaxDb.EnmMetodo.PESQUISAR_COMBO_BOX:
                    this.pesquisar(objSolicitacao, objSolicitacaoAjaxDb);
                    return;

                case SolicitacaoAjaxDb.EnmMetodo.RECUPERAR:
                    this.recuperarRegistro(objSolicitacao, objSolicitacaoAjaxDb);
                    return;

                case SolicitacaoAjaxDb.EnmMetodo.SALVAR:
                    this.salvarRegistro(objSolicitacao, objSolicitacaoAjaxDb);
                    return;
            }
        }

        private void carregarTbl(Solicitacao objSolicitacao, SolicitacaoAjaxDb objSolicitacaoAjaxDb)
        {
            Tabela tbl = this.getTbl(objSolicitacaoAjaxDb.strData);

            if (tbl == null)
            {
                return;
            }

            objSolicitacaoAjaxDb.strData = Json.i.toJson(tbl.tblWeb);
        }

        /// <summary>
        /// Adiciona um usuário para a lista de usuários.
        /// </summary>
        internal void addObjUsuario(Usuario objUsuario)
        {
            if (objUsuario == null)
            {
                return;
            }

            if (this.lstObjUsuario.Contains(objUsuario))
            {
                return;
            }

            // TODO: Eliminar os usuários mais antigos.
            this.lstObjUsuario.Add(objUsuario);
        }

        /// <summary>
        /// Busca o usuário que pertence a <param name="strSessaoId"/>.
        /// </summary>
        internal Usuario getObjUsuario(string strSessaoId)
        {
            lock (this.objLstObjUsuarioLock)
            {
                if (string.IsNullOrEmpty(strSessaoId))
                {
                    return null;
                }

                foreach (Usuario objUsuario in this.lstObjUsuario)
                {
                    if (objUsuario == null)
                    {
                        continue;
                    }

                    if (string.IsNullOrEmpty(objUsuario.strSessaoId))
                    {
                        continue;
                    }

                    if (!objUsuario.strSessaoId.Equals(strSessaoId))
                    {
                        continue;
                    }

                    return objUsuario;
                }

                Usuario objUsuarioNovo = new Usuario(strSessaoId);

                this.addObjUsuario(objUsuarioNovo);

                return objUsuarioNovo;
            }
        }

        protected abstract Persistencia.DataBase getObjDbPrincipal();

        /// <summary>
        /// Este método deve inicializar a lista com todas as tabelas que têm interação (adicionar,
        /// alterar, pesquisar) com o usuário.
        /// </summary>
        /// <param name="lstTbl"></param>
        protected virtual void inicializarLstTbl(List<Tabela> lstTbl)
        {
            lstTbl.Add(TblFiltro.i);
            lstTbl.Add(TblFiltroItem.i);
        }

        private void abrirCadastro(Solicitacao objSolicitacao, SolicitacaoAjaxDb objSolicitacaoAjaxDb)
        {
            if (string.IsNullOrEmpty(objSolicitacaoAjaxDb.strData))
            {
                return;
            }

            TabelaWeb tblWeb = Json.i.fromJson<TabelaWeb>(objSolicitacaoAjaxDb.strData);

            if (SolicitacaoAjaxDb.EnmMetodo.ABRIR_CADASTRO.Equals(objSolicitacaoAjaxDb.enmMetodo))
            {
                this.abrirCadastro(objSolicitacaoAjaxDb, objSolicitacao, tblWeb);
                return;
            }

            this.abrirCadastroFiltroConteudo(objSolicitacaoAjaxDb, objSolicitacao, tblWeb);
        }

        private void abrirCadastro(SolicitacaoAjaxDb objSolicitacaoAjaxDb, Solicitacao objSolicitacao, TabelaWeb tblWeb)
        {
            if (tblWeb == null)
            {
                return;
            }

            if (string.IsNullOrEmpty(tblWeb.strNome))
            {
                return;
            }

            Tabela tbl = this.getTbl(tblWeb.strNome);

            if (tbl == null)
            {
                return;
            }

            tbl = tbl.tblPrincipal;

            if (tbl.clsJnlCadastro == null)
            {
                return;
            }

            JnlCadastro jnlCadastro = ((JnlCadastro)Activator.CreateInstance(tbl.clsJnlCadastro));

            jnlCadastro.tbl = tbl;
            jnlCadastro.tblWeb = tblWeb;

            objSolicitacaoAjaxDb.strData = jnlCadastro.toHtml();
        }

        private void abrirCadastroFiltroConteudo(SolicitacaoAjaxDb objSolicitacaoAjaxDb, Solicitacao objSolicitacao, TabelaWeb tblWebFiltro)
        {
            if (tblWebFiltro == null)
            {
                return;
            }

            if (tblWebFiltro.arrFil == null)
            {
                return;
            }

            if (tblWebFiltro.arrFil.Length < 1)
            {
                return;
            }

            if (tblWebFiltro.arrFil[0].objValor == null)
            {
                return;
            }

            int intFiltroId = Convert.ToInt32(tblWebFiltro.arrFil[0].objValor);

            if (intFiltroId < 1)
            {
                return;
            }

            FrmFiltroConteudo frm = new FrmFiltroConteudo();

            frm.intFiltroId = intFiltroId;

            objSolicitacaoAjaxDb.strData = frm.toHtml();
        }

        private void abrirConsulta(Solicitacao objSolicitacao, SolicitacaoAjaxDb objSolicitacaoAjaxDb)
        {
            if (string.IsNullOrEmpty(objSolicitacaoAjaxDb.strData))
            {
                return;
            }

            TabelaWeb tblWeb = Json.i.fromJson<TabelaWeb>(objSolicitacaoAjaxDb.strData);

            this.abrirConsulta(objSolicitacaoAjaxDb, objSolicitacao, tblWeb);
        }

        private void abrirConsulta(SolicitacaoAjaxDb objSolicitacaoAjaxDb, Solicitacao objSolicitacao, TabelaWeb tblWeb)
        {
            if (tblWeb == null)
            {
                return;
            }

            if (string.IsNullOrEmpty(tblWeb.strNome))
            {
                return;
            }

            Tabela tbl = this.getTbl(tblWeb.strNome);

            if (tbl == null)
            {
                return;
            }

            objSolicitacaoAjaxDb.strData = new JnlConsulta(tbl).toHtml();
        }

        private void apagarRegistro(Solicitacao objSolicitacao, SolicitacaoAjaxDb objSolicitacaoAjaxDb)
        {
        }

        private Tabela getTbl(string strTblNome, Tabela tbl)
        {
            if (tbl.strNomeSql.ToLower().Equals(strTblNome.ToLower()))
            {
                return tbl;
            }

            foreach (View viw in tbl.lstViw)
            {
                if (!viw.strNomeSql.ToLower().Equals(strTblNome.ToLower()))
                {
                    continue;
                }

                return viw;
            }

            return null;
        }

        private void pesquisar(Solicitacao objSolicitacao, SolicitacaoAjaxDb objSolicitacaoAjaxDb)
        {
            if (string.IsNullOrEmpty(objSolicitacaoAjaxDb.strData))
            {
                return;
            }

            TabelaWeb tblWeb = Json.i.fromJson<TabelaWeb>(objSolicitacaoAjaxDb.strData);

            this.pesquisar(objSolicitacao, objSolicitacaoAjaxDb, tblWeb);
        }

        private void pesquisar(Solicitacao objSolicitacao, SolicitacaoAjaxDb objSolicitacaoAjaxDb, TabelaWeb tblWeb)
        {
            if (tblWeb == null)
            {
                return;
            }

            Tabela tbl = this.getTbl(tblWeb);

            if (tbl == null)
            {
                return;
            }

            DataTable tblData = tbl.viwPrincipal.pesquisar(tblWeb);

            if (tblData == null)
            {
                return;
            }

            if (SolicitacaoAjaxDb.EnmMetodo.PESQUISAR_GRID.Equals(objSolicitacaoAjaxDb.enmMetodo))
            {
                this.pesquisarGrid(objSolicitacaoAjaxDb, tbl, tblWeb, tblData);
                return;
            }

            this.pesquisarComboBox(objSolicitacaoAjaxDb, tbl, tblWeb, tblData);
        }

        private void pesquisarComboBox(SolicitacaoAjaxDb objSolicitacaoAjaxDb, Tabela tbl, TabelaWeb tblWeb, DataTable tblData)
        {
            objSolicitacaoAjaxDb.strData = tblWeb.getJson(tbl, tblData);
        }

        private void pesquisarGrid(SolicitacaoAjaxDb objSolicitacaoAjaxDb, Tabela tbl, TabelaWeb tblWeb, DataTable tblData)
        {
            GridHtml tagGrid = new GridHtml();

            tagGrid.tbl = tbl.viwPrincipal;
            tagGrid.tblData = tblData;

            objSolicitacaoAjaxDb.strData = tagGrid.toHtml();
        }

        private void recuperarRegistro(Solicitacao objSolicitacao, SolicitacaoAjaxDb objSolicitacaoAjaxDb)
        {
        }

        private void salvarRegistro(Solicitacao objSolicitacao, SolicitacaoAjaxDb objSolicitacaoAjaxDb)
        {
            if (string.IsNullOrEmpty(objSolicitacaoAjaxDb.strData))
            {
                return;
            }

            TabelaWeb tblWeb = Json.i.fromJson<TabelaWeb>(objSolicitacaoAjaxDb.strData);

            this.salvarRegistro(objSolicitacao, tblWeb);

            objSolicitacaoAjaxDb.strData = Json.i.toJson(tblWeb);
        }

        private void salvarRegistro(Solicitacao objSolicitacao, TabelaWeb tblWeb)
        {
            if (objSolicitacao == null)
            {
                return;
            }

            if (objSolicitacao.objUsuario == null)
            {
                return;
            }

            if (!objSolicitacao.objUsuario.booLogado)
            {
                return;
            }

            if (objSolicitacao.objUsuario.intId < 1)
            {
                return;
            }

            if (tblWeb == null)
            {
                return;
            }

            if (tblWeb.arrClnWeb == null)
            {
                return;
            }

            Tabela tbl = this.getTbl(tblWeb);

            if (tbl == null)
            {
                return;
            }

            tblWeb.getClnWeb(tbl.clnDttAlteracao.strNomeSql).dttValor = DateTime.Now;
            tblWeb.getClnWeb(tbl.clnIntUsuarioAlteracaoId.strNomeSql).intValor = objSolicitacao.objUsuario.intId;

            if (0.Equals(tblWeb.getClnWeb(tbl.clnIntId.strNomeSql).intValor))
            {
                tblWeb.getClnWeb(tbl.clnDttCadastro.strNomeSql).dttValor = DateTime.Now;
                tblWeb.getClnWeb(tbl.clnIntUsuarioCadastroId.strNomeSql).intValor = objSolicitacao.objUsuario.intId;
            }

            tbl.salvarWeb(tblWeb);
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}