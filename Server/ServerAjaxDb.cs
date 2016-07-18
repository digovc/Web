using System;
using System.Data;
using DigoFramework.Json;
using NetZ.Persistencia;
using NetZ.Persistencia.Web;
using NetZ.Web.Html.Componente.Grid;
using NetZ.Web.Html.Componente.Janela.Cadastro;
using NetZ.Web.Html.Componente.Janela.Consulta;

namespace NetZ.Web.Server
{
    public abstract class ServerAjaxDb : ServerAjax
    {
        #region Constantes

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
            SolicitacaoAjaxDb objSolicitacaoAjaxDb = null;

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

                objSolicitacaoAjaxDb = Json.i.fromJson<SolicitacaoAjaxDb>(objSolicitacao.jsn);

                if (objSolicitacaoAjaxDb == null)
                {
                    return null;
                }

                this.responderAjaxDb(objSolicitacao, objSolicitacaoAjaxDb);

                Resposta objResposta = new Resposta(objSolicitacao);

                objResposta.addJson(objSolicitacaoAjaxDb);

                this.addAcessControl(objResposta, objSolicitacao);

                return objResposta;
            }
            catch (Exception ex)
            {
                return this.responderErro(objSolicitacao, ex, objSolicitacaoAjaxDb);
            }
            finally {
            }
        }

        private Resposta responderErro(Solicitacao objSolicitacao, Exception ex, SolicitacaoAjaxDb objSolicitacaoAjaxDb)
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

            if (objSolicitacaoAjaxDb == null)
            {
                objSolicitacaoAjaxDb = new SolicitacaoAjaxDb();
            }

            objSolicitacaoAjaxDb.strErro = strErro;

            Resposta objResposta = new Resposta(objSolicitacao);

            objResposta.addJson(objSolicitacaoAjaxDb);

            this.addAcessControl(objResposta, objSolicitacao);

            return objResposta;
        }

        protected override int getIntPort()
        {
            return ConfigWeb.i.intServerAjaxDbPorta;
        }

        private void abrirCadastro(Solicitacao objSolicitacao, SolicitacaoAjaxDb objSolicitacaoAjaxDb)
        {
            if (string.IsNullOrEmpty(objSolicitacaoAjaxDb.strData))
            {
                return;
            }

            TabelaWeb tblWeb = Json.i.fromJson<TabelaWeb>(objSolicitacaoAjaxDb.strData);

            switch (objSolicitacaoAjaxDb.enmMetodo)
            {
                case SolicitacaoAjaxDb.EnmMetodo.ABRIR_CADASTRO:
                    this.abrirCadastro(objSolicitacaoAjaxDb, objSolicitacao, tblWeb);
                    return;

                case SolicitacaoAjaxDb.EnmMetodo.ABRIR_CADASTRO_FILTRO_CONTEUDO:
                    this.abrirCadastroFiltroConteudo(objSolicitacaoAjaxDb, objSolicitacao, tblWeb);
                    return;

                case SolicitacaoAjaxDb.EnmMetodo.ABRIR_JANELA_TAG:
                    this.abrirJnlTag(objSolicitacaoAjaxDb, objSolicitacao, tblWeb);
                    return;
            }
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

            Tabela tbl = AppWeb.i.getTbl(tblWeb.strNome);

            if (tbl == null)
            {
                return;
            }

            objSolicitacaoAjaxDb.strData = new JnlConsulta(tbl).toHtml();
        }

        private void abrirJnlTag(SolicitacaoAjaxDb objSolicitacaoAjaxDb, Solicitacao objSolicitacao, TabelaWeb tblWeb)
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

            objSolicitacaoAjaxDb.strData = jnlTag.toHtml();
        }

        private void apagarRegistro(Solicitacao objSolicitacao, SolicitacaoAjaxDb objSolicitacaoAjaxDb)
        {
        }

        private void carregarTbl(Solicitacao objSolicitacao, SolicitacaoAjaxDb objSolicitacaoAjaxDb)
        {
            Tabela tbl = AppWeb.i.getTbl(objSolicitacaoAjaxDb.strData);

            if (tbl == null)
            {
                return;
            }

            objSolicitacaoAjaxDb.strData = Json.i.toJson(tbl.tblWeb);
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

        private void responderAjaxDb(Solicitacao objSolicitacao, SolicitacaoAjaxDb objSolicitacaoAjaxDb)
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
                case SolicitacaoAjaxDb.EnmMetodo.ABRIR_JANELA_TAG:
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