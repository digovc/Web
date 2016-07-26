using System;
using System.Data;
using System.Reflection;
using DigoFramework.Json;
using NetZ.Persistencia;
using NetZ.Persistencia.Web;
using NetZ.Web.Html.Componente.Grid;
using NetZ.Web.Html.Componente.Janela.Cadastro;
using NetZ.Web.Html.Componente.Janela.Consulta;

namespace NetZ.Web.Server.Ajax
{
    public abstract class ServerAjaxDb : ServerAjax
    {
        #region Constantes

        public const string STR_METODO_ABRIR_CADASTRO = "ABRIR_CADASTRO";
        public const string STR_METODO_ABRIR_CADASTRO_FILTRO_CONTEUDO = "ABRIR_CADASTRO_FILTRO_CONTEUDO";
        public const string STR_METODO_ABRIR_CONSULTA = "ABRIR_CONSULTA";
        public const string STR_METODO_ABRIR_JANELA_TAG = "ABRIR_JANELA_TAG";
        public const string STR_METODO_ADICIONAR = "ADICIONAR";
        public const string STR_METODO_APAGAR = "APAGAR";
        public const string STR_METODO_CARREGAR_TBL_WEB = "CARREGAR_TBL_WEB";
        public const string STR_METODO_FILTRO = "FILTRO";
        public const string STR_METODO_PESQUISAR_COMBO_BOX = "PESQUISAR_COMBO_BOX";
        public const string STR_METODO_PESQUISAR_GRID = "PESQUISAR_GRID";
        public const string STR_METODO_RECUPERAR = "RECUPERAR";
        public const string STR_METODO_SALVAR = "SALVAR";
        public const string STR_METODO_SALVAR_DOMINIO = "SALVAR_DOMINIO";

        #endregion Constantes

        #region Atributos

        #endregion Atributos

        #region Construtores

        protected ServerAjaxDb(string strNome) : base(strNome)
        {
        }

        #endregion Construtores

        #region Métodos

        public override Resposta responder(Solicitacao objSolicitacao)
        {
            InterlocutorAjaxDb objInterlocutorAjaxDb = null;

            try
            {
                if (objSolicitacao == null)
                {
                    return null;
                }

                if (string.IsNullOrEmpty(objSolicitacao.jsn))
                {
                    return null;
                }

                objInterlocutorAjaxDb = Json.i.fromJson<InterlocutorAjaxDb>(objSolicitacao.jsn);

                if (objInterlocutorAjaxDb == null)
                {
                    return null;
                }

                this.responder(objSolicitacao, objInterlocutorAjaxDb);

                Resposta objResposta = new Resposta(objSolicitacao);

                objResposta.addJson(objInterlocutorAjaxDb);

                this.addAcessControl(objResposta, objSolicitacao);

                return objResposta;
            }
            catch (Exception ex)
            {
                return this.responderErro(objSolicitacao, ex, objInterlocutorAjaxDb);
            }
            finally
            {
            }
        }

        protected override int getIntPort()
        {
            return ConfigWeb.i.intServerAjaxDbPorta;
        }

        protected virtual bool responder(Solicitacao objSolicitacao, InterlocutorAjaxDb objInterlocutorAjaxDb)
        {
            if (objInterlocutorAjaxDb == null)
            {
                return false;
            }

            switch (objInterlocutorAjaxDb.strMetodo)
            {
                case STR_METODO_APAGAR:
                    this.apagarRegistro(objSolicitacao, objInterlocutorAjaxDb);
                    return true;

                case STR_METODO_ABRIR_CADASTRO:
                case STR_METODO_ABRIR_CADASTRO_FILTRO_CONTEUDO:
                case STR_METODO_ABRIR_JANELA_TAG:
                    this.abrirCadastro(objSolicitacao, objInterlocutorAjaxDb);
                    return true;

                case STR_METODO_ABRIR_CONSULTA:
                    this.abrirConsulta(objSolicitacao, objInterlocutorAjaxDb);
                    return true;

                case STR_METODO_CARREGAR_TBL_WEB:
                    this.carregarTbl(objSolicitacao, objInterlocutorAjaxDb);
                    return true;

                case STR_METODO_PESQUISAR_GRID:
                case STR_METODO_PESQUISAR_COMBO_BOX:
                    this.pesquisar(objSolicitacao, objInterlocutorAjaxDb);
                    return true;

                case STR_METODO_RECUPERAR:
                    this.recuperarRegistro(objSolicitacao, objInterlocutorAjaxDb);
                    return true;

                case STR_METODO_SALVAR:
                    this.salvarRegistro(objSolicitacao, objInterlocutorAjaxDb);
                    return true;

                case STR_METODO_SALVAR_DOMINIO:
                    this.salvarDominio(objSolicitacao, objInterlocutorAjaxDb);
                    return true;
            }

            return false;
        }

        private void salvarDominio(Solicitacao objSolicitacao, InterlocutorAjaxDb objInterlocutorAjaxDb)
        {
            if (string.IsNullOrEmpty(objInterlocutorAjaxDb.strData))
            {
                return;
            }

            if (string.IsNullOrEmpty(objInterlocutorAjaxDb.strJsonTipo))
            {
                return;
            }

            Tabela tbl = AppWeb.i.getTblPorDominio(objInterlocutorAjaxDb.strJsonTipo);

            if (tbl == null)
            {
                objInterlocutorAjaxDb.strErro = string.Format("Não foi encontrado uma tabela relacionada ao domínio {0}.", objInterlocutorAjaxDb.strJsonTipo);
                return;
            }

            MethodInfo objMethodInfo = typeof(Json).GetMethod("fromJson");
            MethodInfo objMethodInfoGeneric = objMethodInfo.MakeGenericMethod(tbl.clsDominio);

            Persistencia.Dominio objDominio = (Persistencia.Dominio)objMethodInfoGeneric.Invoke(Json.i, new object[] { objInterlocutorAjaxDb.strData });

            int intId = tbl.salvar(objDominio);

            if (intId > 0)
            {
                objInterlocutorAjaxDb.strData = "Registro salvo com sucesso.";
            }
            else
            {
                objInterlocutorAjaxDb.strErro = "Erro ao salvar o registro.";
            }
        }

        private void abrirCadastro(Solicitacao objSolicitacao, InterlocutorAjaxDb objInterlocutorAjaxDb)
        {
            if (string.IsNullOrEmpty(objInterlocutorAjaxDb.strData))
            {
                return;
            }

            TabelaWeb tblWeb = Json.i.fromJson<TabelaWeb>(objInterlocutorAjaxDb.strData);

            switch (objInterlocutorAjaxDb.strMetodo)
            {
                case STR_METODO_ABRIR_CADASTRO:
                    this.abrirCadastro(objInterlocutorAjaxDb, objSolicitacao, tblWeb);
                    return;

                case STR_METODO_ABRIR_CADASTRO_FILTRO_CONTEUDO:
                    this.abrirCadastroFiltroConteudo(objInterlocutorAjaxDb, objSolicitacao, tblWeb);
                    return;

                case STR_METODO_ABRIR_JANELA_TAG:
                    this.abrirJnlTag(objInterlocutorAjaxDb, objSolicitacao, tblWeb);
                    return;
            }
        }

        private void abrirCadastro(InterlocutorAjaxDb objInterlocutorAjaxDb, Solicitacao objSolicitacao, TabelaWeb tblWeb)
        {
            if (tblWeb == null)
            {
                return;
            }

            if (string.IsNullOrEmpty(tblWeb.strNome))
            {
                return;
            }

            Tabela tbl = AppWeb.i.getTbl(tblWeb.strNome);

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

            objInterlocutorAjaxDb.strData = jnlCadastro.toHtml();
        }

        private void abrirCadastroFiltroConteudo(InterlocutorAjaxDb objInterlocutorAjaxDb, Solicitacao objSolicitacao, TabelaWeb tblWebFiltro)
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

            objInterlocutorAjaxDb.strData = frm.toHtml();
        }

        private void abrirConsulta(Solicitacao objSolicitacao, InterlocutorAjaxDb objInterlocutorAjaxDb)
        {
            if (string.IsNullOrEmpty(objInterlocutorAjaxDb.strData))
            {
                return;
            }

            TabelaWeb tblWeb = Json.i.fromJson<TabelaWeb>(objInterlocutorAjaxDb.strData);

            this.abrirConsulta(objInterlocutorAjaxDb, objSolicitacao, tblWeb);
        }

        private void abrirConsulta(InterlocutorAjaxDb objInterlocutorAjaxDb, Solicitacao objSolicitacao, TabelaWeb tblWeb)
        {
            if (tblWeb == null)
            {
                return;
            }

            if (string.IsNullOrEmpty(tblWeb.strNome))
            {
                return;
            }

            Tabela tbl = AppWeb.i.getTbl(tblWeb.strNome);

            if (tbl == null)
            {
                return;
            }

            objInterlocutorAjaxDb.strData = new JnlConsulta(tbl).toHtml();
        }

        private void abrirJnlTag(InterlocutorAjaxDb objInterlocutorAjaxDb, Solicitacao objSolicitacao, TabelaWeb tblWeb)
        {
            if (tblWeb == null)
            {
                return;
            }

            if (string.IsNullOrEmpty(tblWeb.strNome))
            {
                return;
            }

            Tabela tbl = AppWeb.i.getTbl(tblWeb.strNome);

            if (tbl == null)
            {
                return;
            }

            tbl = tbl.tblPrincipal;

            JnlTag jnlTag = new JnlTag();

            jnlTag.tbl = tbl;
            jnlTag.tblWeb = tblWeb;

            objInterlocutorAjaxDb.strData = jnlTag.toHtml();
        }

        private void apagarRegistro(Solicitacao objSolicitacao, InterlocutorAjaxDb objInterlocutorAjaxDb)
        {
        }

        private void carregarTbl(Solicitacao objSolicitacao, InterlocutorAjaxDb objInterlocutorAjaxDb)
        {
            Tabela tbl = AppWeb.i.getTbl(objInterlocutorAjaxDb.strData);

            if (tbl == null)
            {
                return;
            }

            objInterlocutorAjaxDb.strData = Json.i.toJson(tbl.tblWeb);
        }

        private void pesquisar(Solicitacao objSolicitacao, InterlocutorAjaxDb objInterlocutorAjaxDb)
        {
            if (string.IsNullOrEmpty(objInterlocutorAjaxDb.strData))
            {
                return;
            }

            TabelaWeb tblWeb = Json.i.fromJson<TabelaWeb>(objInterlocutorAjaxDb.strData);

            this.pesquisar(objSolicitacao, objInterlocutorAjaxDb, tblWeb);
        }

        private void pesquisar(Solicitacao objSolicitacao, InterlocutorAjaxDb objInterlocutorAjaxDb, TabelaWeb tblWeb)
        {
            if (tblWeb == null)
            {
                return;
            }

            Tabela tbl = AppWeb.i.getTbl(tblWeb);

            if (tbl == null)
            {
                return;
            }

            DataTable tblData = tbl.viwPrincipal.pesquisar(tblWeb);

            if (tblData == null)
            {
                return;
            }

            if (STR_METODO_PESQUISAR_GRID.Equals(objInterlocutorAjaxDb.strMetodo))
            {
                this.pesquisarGrid(objInterlocutorAjaxDb, tbl, tblWeb, tblData);
                return;
            }

            this.pesquisarComboBox(objInterlocutorAjaxDb, tbl, tblWeb, tblData);
        }

        private void pesquisarComboBox(InterlocutorAjaxDb objInterlocutorAjaxDb, Tabela tbl, TabelaWeb tblWeb, DataTable tblData)
        {
            objInterlocutorAjaxDb.strData = tblWeb.getJson(tbl, tblData);
        }

        private void pesquisarGrid(InterlocutorAjaxDb objInterlocutorAjaxDb, Tabela tbl, TabelaWeb tblWeb, DataTable tblData)
        {
            GridHtml tagGrid = new GridHtml();

            tagGrid.tbl = tbl.viwPrincipal;
            tagGrid.tblData = tblData;

            objInterlocutorAjaxDb.strData = tagGrid.toHtml();
        }

        private void recuperarRegistro(Solicitacao objSolicitacao, InterlocutorAjaxDb objInterlocutorAjaxDb)
        {
        }

        private Resposta responderErro(Solicitacao objSolicitacao, Exception ex, InterlocutorAjaxDb objInterlocutorAjaxDb)
        {
            if (objSolicitacao == null)
            {
                return null;
            }

            string strErro = "Erro desconhecido.";

            if (ex != null)
            {
                strErro = ex.Message;
            }

            if (objInterlocutorAjaxDb == null)
            {
                objInterlocutorAjaxDb = new InterlocutorAjaxDb();
            }

            objInterlocutorAjaxDb.strErro = strErro;

            Resposta objResposta = new Resposta(objSolicitacao);

            objResposta.addJson(objInterlocutorAjaxDb);

            this.addAcessControl(objResposta, objSolicitacao);

            return objResposta;
        }

        private void salvarRegistro(Solicitacao objSolicitacao, InterlocutorAjaxDb objInterlocutorAjaxDb)
        {
            if (string.IsNullOrEmpty(objInterlocutorAjaxDb.strData))
            {
                return;
            }

            TabelaWeb tblWeb = Json.i.fromJson<TabelaWeb>(objInterlocutorAjaxDb.strData);

            this.salvarRegistro(objSolicitacao, tblWeb);

            objInterlocutorAjaxDb.strData = Json.i.toJson(tblWeb);
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

            Tabela tbl = AppWeb.i.getTbl(tblWeb);

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