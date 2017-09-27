using DigoFramework.Json;
using NetZ.Persistencia;
using NetZ.Persistencia.Web;
using NetZ.Web.DataBase;
using NetZ.Web.DataBase.Tabela;
using NetZ.Web.Html.Componente.Janela.Cadastro;
using NetZ.Web.Html.Componente.Janela.Consulta;
using NetZ.Web.Html.Componente.Table;
using System;
using System.Data;
using System.Reflection;
using System.Security;

namespace NetZ.Web.Server.Ajax.Data
{
    public abstract class SrvAjaxDbeBase : SrvAjaxBase
    {
        #region Constantes

        public const string STR_METODO_ABRIR_CADASTRO = "ABRIR_CADASTRO";
        public const string STR_METODO_ABRIR_CADASTRO_FILTRO_CONTEUDO = "ABRIR_CADASTRO_FILTRO_CONTEUDO";
        public const string STR_METODO_ABRIR_CONSULTA = "ABRIR_CONSULTA";
        public const string STR_METODO_ADICIONAR = "ADICIONAR";
        public const string STR_METODO_APAGAR = "APAGAR";
        public const string STR_METODO_CARREGAR_TBL_WEB = "CARREGAR_TBL_WEB";
        public const string STR_METODO_FILTRO = "FILTRO";
        public const string STR_METODO_PESQUISAR_COMBO_BOX = "PESQUISAR_COMBO_BOX";
        public const string STR_METODO_PESQUISAR_TABLE = "PESQUISAR_TABLE";
        public const string STR_METODO_RECUPERAR = "RECUPERAR";
        public const string STR_METODO_SALVAR = "SALVAR";
        public const string STR_METODO_SALVAR_DOMINIO = "SALVAR_DOMINIO";
        public const string STR_METODO_TABELA_FAVORITO_ADD = "TABELA_FAVORITO_ADD";
        public const string STR_METODO_TABELA_FAVORITO_PESQUISAR = "TABELA_FAVORITO_PESQUISAR";
        public const string STR_METODO_TABELA_FAVORITO_VERIFICAR = "TABELA_FAVORITO_VERIFICAR";
        public const string STR_METODO_TAG_ABRIR_JANELA = "TAG_ABRIR_JANELA";
        public const string STR_METODO_TAG_SALVAR = "TAG_SALVAR";

        private const string STR_METODO_PESQUISAR = "STR_METODO_PESQUISAR";

        #endregion Constantes

        #region Atributos

        private DbeWebBase _dbe;

        private DbeWebBase dbe
        {
            get
            {
                if (_dbe != null)
                {
                    return _dbe;
                }

                _dbe = this.getDbe();

                return _dbe;
            }
        }

        #endregion Atributos

        #region Construtores

        protected SrvAjaxDbeBase() : base("Servidor de dados")
        {
        }

        #endregion Construtores

        #region Métodos

        protected abstract DbeWebBase getDbe();

        protected override int getIntPorta()
        {
            return 8081;
        }

        protected override bool responder(Solicitacao objSolicitacao, Interlocutor objInterlocutor)
        {
            if (base.responder(objSolicitacao, objInterlocutor))
            {
                return true;
            }

            switch (objInterlocutor.strMetodo)
            {
                case STR_METODO_APAGAR:
                    this.apagarRegistro(objSolicitacao, objInterlocutor);
                    return true;

                case STR_METODO_ABRIR_CADASTRO:
                case STR_METODO_ABRIR_CADASTRO_FILTRO_CONTEUDO:
                case STR_METODO_TAG_ABRIR_JANELA:
                    this.abrirCadastro(objSolicitacao, objInterlocutor);
                    return true;

                case STR_METODO_ABRIR_CONSULTA:
                    this.abrirConsulta(objSolicitacao, objInterlocutor);
                    return true;

                case STR_METODO_CARREGAR_TBL_WEB:
                    this.carregarTbl(objSolicitacao, objInterlocutor);
                    return true;

                case STR_METODO_PESQUISAR:
                    this.pesquisar(objSolicitacao, objInterlocutor);
                    return true;

                case STR_METODO_PESQUISAR_TABLE:
                case STR_METODO_PESQUISAR_COMBO_BOX:
                    this.pesquisarOld(objSolicitacao, objInterlocutor);
                    return true;

                case STR_METODO_RECUPERAR:
                    this.recuperarRegistro(objSolicitacao, objInterlocutor);
                    return true;

                case STR_METODO_SALVAR:
                    this.salvarRegistro(objSolicitacao, objInterlocutor);
                    return true;

                case STR_METODO_SALVAR_DOMINIO:
                    this.salvarDominio(objSolicitacao, objInterlocutor);
                    return true;

                case STR_METODO_TABELA_FAVORITO_ADD:
                    this.favoritarTabela(objSolicitacao, objInterlocutor);
                    return true;

                case STR_METODO_TABELA_FAVORITO_PESQUISAR:
                    this.pesquisarFavorito(objSolicitacao, objInterlocutor);
                    return true;

                case STR_METODO_TABELA_FAVORITO_VERIFICAR:
                    this.verificarFavorito(objSolicitacao, objInterlocutor);
                    return true;

                case STR_METODO_TAG_SALVAR:
                    this.salvarTag(objSolicitacao, objInterlocutor);
                    return true;

                default:
                    return false;
            }
        }

        protected virtual bool validarAbrirCadastro(Solicitacao objSolicitacao, Interlocutor objInterlocutor, TabelaWeb tblWeb, TabelaBase tbl)
        {
            return true;
        }

        protected virtual bool validarAbrirConsulta(Solicitacao objSolicitacao, Interlocutor objInterlocutor, TabelaWeb tblWeb, TabelaBase tbl)
        {
            return true;
        }

        protected virtual bool validarPesquisar(Solicitacao objSolicitacao, Interlocutor objInterlocutor, TabelaWeb tblWeb, TabelaBase tbl)
        {
            return true;
        }

        protected virtual bool validarSalvarRegistro(Solicitacao objSolicitacao, Interlocutor objInterlocutor, TabelaWeb tblWeb, TabelaBase tbl)
        {
            return true;
        }

        private void abrirCadastro(Solicitacao objSolicitacao, Interlocutor objInterlocutor)
        {
            if (objInterlocutor.objData == null)
            {
                return;
            }

            TabelaWeb tblWeb = Json.i.fromJson<TabelaWeb>(objInterlocutor.objData.ToString());

            switch (objInterlocutor.strMetodo)
            {
                case STR_METODO_ABRIR_CADASTRO:
                    this.abrirCadastro(objSolicitacao, objInterlocutor, tblWeb);
                    return;

                case STR_METODO_ABRIR_CADASTRO_FILTRO_CONTEUDO:
                    this.abrirCadastroFiltroConteudo(objSolicitacao, objInterlocutor, tblWeb);
                    return;

                case STR_METODO_TAG_ABRIR_JANELA:
                    this.abrirJnlTag(objSolicitacao, objInterlocutor, tblWeb);
                    return;
            }
        }

        private void abrirCadastro(Solicitacao objSolicitacao, Interlocutor objInterlocutor, TabelaWeb tblWeb)
        {
            if (tblWeb == null)
            {
                return;
            }

            if (string.IsNullOrEmpty(tblWeb.strNome))
            {
                return;
            }

            TabelaBase tbl = this.dbe[tblWeb.strNome];

            if (tbl == null)
            {
                return;
            }

            tbl = tbl.tblPrincipal;

            if (!this.validarAbrirCadastro(objSolicitacao, objInterlocutor, tblWeb, tbl))
            {
                return;
            }

            if (tbl.clsJnlCadastro == null)
            {
                return;
            }

            JnlCadastro jnlCadastro = ((JnlCadastro)Activator.CreateInstance(tbl.clsJnlCadastro));

            jnlCadastro.tbl = tbl;
            jnlCadastro.tblWeb = tblWeb;

            try
            {
                objInterlocutor.objData = jnlCadastro.toHtml();
            }
            finally
            {
                tbl.liberarThread();
            }
        }

        private void abrirCadastroFiltroConteudo(Solicitacao objSolicitacao, Interlocutor objInterlocutor, TabelaWeb tblWebFiltro)
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

            try
            {
                objInterlocutor.objData = frm.toHtml();
            }
            finally
            {
                TblFiltro.i.liberarThread();
            }
        }

        private void abrirConsulta(Solicitacao objSolicitacao, Interlocutor objInterlocutor)
        {
            if (objInterlocutor.objData == null)
            {
                return;
            }

            TabelaWeb tblWeb = Json.i.fromJson<TabelaWeb>(objInterlocutor.objData.ToString());

            this.abrirConsulta(objInterlocutor, objSolicitacao, tblWeb);
        }

        private void abrirConsulta(Interlocutor objInterlocutor, Solicitacao objSolicitacao, TabelaWeb tblWeb)
        {
            if (tblWeb == null)
            {
                return;
            }

            if (string.IsNullOrEmpty(tblWeb.strNome))
            {
                return;
            }

            TabelaBase tbl = this.dbe[tblWeb.strNome];

            if (tbl == null)
            {
                return;
            }

            if (!this.validarAbrirConsulta(objSolicitacao, objInterlocutor, tblWeb, tbl))
            {
                return;
            }

            objInterlocutor.objData = new JnlConsulta(tbl).toHtml();
        }

        private void abrirJnlTag(Solicitacao objSolicitacao, Interlocutor objInterlocutor, TabelaWeb tblWeb)
        {
            if (tblWeb == null)
            {
                return;
            }

            if (string.IsNullOrEmpty(tblWeb.strNome))
            {
                return;
            }

            TabelaBase tbl = this.dbe[tblWeb.strNome];

            if (tbl == null)
            {
                return;
            }

            tbl = tbl.tblPrincipal;

            JnlTag jnlTag = new JnlTag();

            jnlTag.tbl = tbl;
            jnlTag.tblWeb = tblWeb;

            objInterlocutor.objData = jnlTag.toHtml();
        }

        private void apagarRegistro(Solicitacao objSolicitacao, Interlocutor objInterlocutor)
        {
        }

        private void carregarTbl(Solicitacao objSolicitacao, Interlocutor objInterlocutor)
        {
            TabelaBase tbl = this.dbe[objInterlocutor.objData.ToString()];

            if (tbl == null)
            {
                return;
            }

            objInterlocutor.objData = Json.i.toJson(tbl.tblWeb);
        }

        private void favoritarTabela(Solicitacao objSolicitacao, Interlocutor objInterlocutor)
        {
            if (objSolicitacao.objUsuario == null)
            {
                return;
            }

            if (!objSolicitacao.objUsuario.booLogado)
            {
                return;
            }

            if (objInterlocutor.objData == null)
            {
                return;
            }

            TabelaBase tbl = this.dbe[objInterlocutor.objData.ToString()];

            if (tbl == null)
            {
                return;
            }

            TblFavorito.i.favoritar(objSolicitacao, objInterlocutor, tbl);
        }

        private void pesquisar(Solicitacao objSolicitacao, Interlocutor objInterlocutor)
        {
            var objPesquisa = objInterlocutor.getObjJson<PesquisaInterlocutor>();

            if (objPesquisa == null)
            {
                throw new NullReferenceException();
            }

            if (string.IsNullOrEmpty(objPesquisa.sqlTabelaNome))
            {
                throw new NullReferenceException();
            }

            var tbl = this.dbe[objPesquisa.sqlTabelaNome];

            if (tbl == null)
            {
                throw new Exception("Tabela não encontrada.");
            }

            // TODO: Validar permissão de acesso a esses dados.

            objInterlocutor.addJson(tbl.pesquisar(objPesquisa.arrFil) ?? null);
        }

        private void pesquisarComboBox(Interlocutor objInterlocutor, TabelaBase tbl, TabelaWeb tblWeb, DataTable tblData)
        {
            objInterlocutor.objData = tblWeb.getJson(tbl, tblData);
        }

        private void pesquisarFavorito(Solicitacao objSolicitacao, Interlocutor objInterlocutor)
        {
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

            TblFavorito.i.pesquisarFavorito(objSolicitacao.objUsuario.intId, objInterlocutor);
        }

        private void pesquisarOld(Solicitacao objSolicitacao, Interlocutor objInterlocutor, TabelaWeb tblWeb)
        {
            if (tblWeb == null)
            {
                return;
            }

            var tbl = this.dbe[tblWeb.strNome];

            if (tbl == null)
            {
                throw new Exception(string.Format("Tabela \"{0}\" não encontrada.", tblWeb.strNome));
            }

            if (!this.validarPesquisar(objSolicitacao, objInterlocutor, tblWeb, tbl))
            {
                return;
            }

            var tblData = tbl.viwPrincipal.pesquisar(tblWeb);

            if (tblData == null)
            {
                return;
            }

            if (tblData.Rows.Count < 1)
            {
                objInterlocutor.objData = STR_RESULTADO_VAZIO;
                return;
            }

            if (STR_METODO_PESQUISAR_TABLE.Equals(objInterlocutor.strMetodo))
            {
                this.pesquisarTable(objInterlocutor, tbl, tblWeb, tblData);
                return;
            }

            this.pesquisarComboBox(objInterlocutor, tbl, tblWeb, tblData);
        }

        private void pesquisarOld(Solicitacao objSolicitacao, Interlocutor objInterlocutor)
        {
            if (string.IsNullOrEmpty(objInterlocutor.objData.ToString()))
            {
                return;
            }

            var tblWeb = Json.i.fromJson<TabelaWeb>(objInterlocutor.objData.ToString());

            this.pesquisarOld(objSolicitacao, objInterlocutor, tblWeb);
        }

        private void pesquisarTable(Interlocutor objInterlocutor, TabelaBase tbl, TabelaWeb tblWeb, DataTable tblData)
        {
            var tagTable = new TableHtml();

            tagTable.tbl = tbl.viwPrincipal;
            tagTable.tblData = tblData;

            objInterlocutor.objData = tagTable.toHtml();
        }

        private void recuperarRegistro(Solicitacao objSolicitacao, Interlocutor objInterlocutor)
        {
        }

        private void salvarDominio(Solicitacao objSolicitacao, Interlocutor objInterlocutor)
        {
            if (string.IsNullOrEmpty(objInterlocutor.objData.ToString()))
            {
                return;
            }

            if (string.IsNullOrEmpty(objInterlocutor.strClazz))
            {
                return;
            }

            TabelaBase tbl = this.dbe.getTblPorDominio(objInterlocutor.strClazz);

            if (tbl == null)
            {
                objInterlocutor.strErro = string.Format("Não foi encontrado uma tabela relacionada ao domínio {0}.", objInterlocutor.strClazz);
                return;
            }

            MethodInfo objMethodInfo = typeof(Json).GetMethod("fromJson");
            MethodInfo objMethodInfoGeneric = objMethodInfo.MakeGenericMethod(tbl.clsDominio);

            DominioBase objDominio = (DominioBase)objMethodInfoGeneric.Invoke(Json.i, new object[] { objInterlocutor.objData });

            if (objDominio == null)
            {
                objInterlocutor.strErro = string.Format("Erro ao tentar instanciar o domínio {0}.", objInterlocutor.strClazz);
                return;
            }

            if (tbl.salvar(objDominio).intId > 0)
            {
                objInterlocutor.objData = "Registro salvo com sucesso.";
            }
            else
            {
                objInterlocutor.strErro = "Erro ao salvar o registro.";
            }
        }

        private void salvarRegistro(Solicitacao objSolicitacao, Interlocutor objInterlocutor)
        {
            if (objInterlocutor.objData == null)
            {
                return;
            }

            var tblWeb = Json.i.fromJson<TabelaWeb>(objInterlocutor.objData.ToString());

            this.salvarRegistro(objSolicitacao, objInterlocutor, tblWeb);

            objInterlocutor.objData = Json.i.toJson(tblWeb);
        }

        private void salvarRegistro(Solicitacao objSolicitacao, Interlocutor objInterlocutor, TabelaWeb tblWeb)
        {
            if (objSolicitacao == null)
            {
                throw new NullReferenceException();
            }

            if (objSolicitacao.objUsuario == null)
            {
                throw new NullReferenceException();
            }

            if (!objSolicitacao.objUsuario.booLogado)
            {
                throw new SecurityException();
            }

            if (objSolicitacao.objUsuario.intId < 1)
            {
                throw new SecurityException();
            }

            if (tblWeb == null)
            {
                throw new NullReferenceException();
            }

            if (tblWeb.arrCln == null)
            {
                throw new NullReferenceException();
            }

            var tbl = this.dbe[tblWeb.strNome];

            if (tbl == null)
            {
                throw new NullReferenceException();
            }

            if (!this.validarSalvarRegistro(objSolicitacao, objInterlocutor, tblWeb, tbl))
            {
                return;
            }

            // TODO: Reavaliar a necessidade de carregar os valores destas colunas.
            tblWeb.getCln(tbl.clnDttAlteracao.sqlNome).dttValor = DateTime.Now;
            tblWeb.getCln(tbl.clnIntUsuarioAlteracaoId.sqlNome).intValor = objSolicitacao.objUsuario.intId;

            if (0.Equals(tblWeb.getCln(tbl.clnIntId.sqlNome).intValor))
            {
                tblWeb.getCln(tbl.clnDttCadastro.sqlNome).dttValor = DateTime.Now;
                tblWeb.getCln(tbl.clnIntUsuarioCadastroId.sqlNome).intValor = objSolicitacao.objUsuario.intId;
            }

            tbl.salvarWeb(tblWeb);

            tbl.liberarThread();
        }

        private void salvarTag(Solicitacao objSolicitacao, Interlocutor objInterlocutor)
        {
            if (objSolicitacao.objUsuario == null)
            {
                return;
            }

            if (!objSolicitacao.objUsuario.booLogado)
            {
                return;
            }

            if (objInterlocutor.objData == null)
            {
                return;
            }

            TabelaWeb tblWeb = Json.i.fromJson<TabelaWeb>(objInterlocutor.objData.ToString());

            if (tblWeb == null)
            {
                return;
            }

            if (string.IsNullOrEmpty(tblWeb.strNome))
            {
                return;
            }

            TabelaBase tbl = this.dbe[tblWeb.strNome];

            if (tbl == null)
            {
                return;
            }

            tbl.salvarTag(tblWeb.clnIntId.intValor, tblWeb.getCln(tbl.clnStrTag.sqlNome).strValor);
        }

        private void verificarFavorito(Solicitacao objSolicitacao, Interlocutor objInterlocutor)
        {
            if (objInterlocutor.objData == null)
            {
                return;
            }

            if (objSolicitacao.objUsuario == null)
            {
                return;
            }

            if (objSolicitacao.objUsuario.intId < 1)
            {
                return;
            }

            TabelaBase tbl = this.dbe[objInterlocutor.objData.ToString()];

            if (tbl == null)
            {
                return;
            }

            objInterlocutor.objData = TblFavorito.i.verificarFavorito(objSolicitacao.objUsuario.intId, tbl.sqlNome);
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}