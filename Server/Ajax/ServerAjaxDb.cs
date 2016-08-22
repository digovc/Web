using System;
using System.Data;
using System.Reflection;
using DigoFramework.Json;
using NetZ.Persistencia;
using NetZ.Persistencia.Interface;
using NetZ.Persistencia.Web;
using NetZ.Web.DataBase.Tabela;
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
            Resposta objResposta = base.responder(objSolicitacao);

            if (objResposta != null)
            {
                return objResposta;
            }

            Interlocutor objInterlocutor = null;

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

                objInterlocutor = Json.i.fromJson<Interlocutor>(objSolicitacao.jsn);

                if (objInterlocutor == null)
                {
                    return null;
                }

                this.responder(objSolicitacao, objInterlocutor);

                objResposta = new Resposta(objSolicitacao);

                objResposta.addJson(objInterlocutor);

                this.addAcessControl(objResposta);

                return objResposta;
            }
            catch (Exception ex)
            {
                return this.responderErro(objSolicitacao, ex, objInterlocutor);
            }
            finally
            {
            }
        }

        protected virtual bool validarSalvarRegistro(Solicitacao objSolicitacao, Interlocutor objInterlocutor, TabelaWeb tblWeb, Tabela tbl)
        {
            return true;
        }

        protected override int getIntPort()
        {
            return ConfigWeb.i.intServerAjaxDbPorta;
        }

        protected virtual bool responder(Solicitacao objSolicitacao, Interlocutor objInterlocutor)
        {
            if (objInterlocutor == null)
            {
                return false;
            }

            switch (objInterlocutor.strMetodo)
            {
                case STR_METODO_APAGAR:
                    this.apagarRegistro(objSolicitacao, objInterlocutor);
                    return true;

                case STR_METODO_ABRIR_CADASTRO:
                case STR_METODO_ABRIR_CADASTRO_FILTRO_CONTEUDO:
                case STR_METODO_ABRIR_JANELA_TAG:
                    this.abrirCadastro(objSolicitacao, objInterlocutor);
                    return true;

                case STR_METODO_ABRIR_CONSULTA:
                    this.abrirConsulta(objSolicitacao, objInterlocutor);
                    return true;

                case STR_METODO_CARREGAR_TBL_WEB:
                    this.carregarTbl(objSolicitacao, objInterlocutor);
                    return true;

                case STR_METODO_PESQUISAR_GRID:
                case STR_METODO_PESQUISAR_COMBO_BOX:
                    this.pesquisar(objSolicitacao, objInterlocutor);
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
            }

            return false;
        }

        protected virtual bool validarAbrirCadastro(Solicitacao objSolicitacao, Interlocutor objInterlocutor, TabelaWeb tblWeb, Tabela tbl)
        {
            return true;
        }

        protected virtual bool validarAbrirConsulta(Solicitacao objSolicitacao, Interlocutor objInterlocutor, TabelaWeb tblWeb, Tabela tbl)
        {
            return true;
        }

        protected virtual bool validarPesquisar(Solicitacao objSolicitacao, Interlocutor objInterlocutor, TabelaWeb tblWeb, Tabela tbl)
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

                case STR_METODO_ABRIR_JANELA_TAG:
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

            Tabela tbl = AppWeb.i.getTbl(tblWeb.strNome);

            if (tbl == null)
            {
                return;
            }

            if (!this.validarAbrirCadastro(objSolicitacao, objInterlocutor, tblWeb, tbl))
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

            try
            {
                objInterlocutor.objData = jnlCadastro.toHtml();
            }
            finally
            {
                tbl.liberar();
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
                TblFiltro.i.liberar();
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

            Tabela tbl = AppWeb.i.getTbl(tblWeb.strNome);

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

            Tabela tbl = AppWeb.i.getTbl(tblWeb.strNome);

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
            Tabela tbl = AppWeb.i.getTbl(objInterlocutor.objData.ToString());

            if (tbl == null)
            {
                return;
            }

            objInterlocutor.objData = Json.i.toJson(tbl.tblWeb);
        }

        private void pesquisar(Solicitacao objSolicitacao, Interlocutor objInterlocutor)
        {
            if (string.IsNullOrEmpty(objInterlocutor.objData.ToString()))
            {
                return;
            }

            TabelaWeb tblWeb = Json.i.fromJson<TabelaWeb>(objInterlocutor.objData.ToString());

            this.pesquisar(objSolicitacao, objInterlocutor, tblWeb);
        }

        private void pesquisar(Solicitacao objSolicitacao, Interlocutor objInterlocutor, TabelaWeb tblWeb)
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

            if (!this.validarPesquisar(objSolicitacao, objInterlocutor, tblWeb, tbl))
            {
                return;
            }

            DataTable tblData = tbl.viwPrincipal.pesquisar(tblWeb);

            if (tblData == null)
            {
                return;
            }

            if (tblData.Rows.Count < 1)
            {
                objInterlocutor.objData = STR_RESULTADO_VAZIO;
                return;
            }

            if (STR_METODO_PESQUISAR_GRID.Equals(objInterlocutor.strMetodo))
            {
                this.pesquisarGrid(objInterlocutor, tbl, tblWeb, tblData);
                return;
            }

            this.pesquisarComboBox(objInterlocutor, tbl, tblWeb, tblData);
        }

        private void pesquisarComboBox(Interlocutor objInterlocutor, Tabela tbl, TabelaWeb tblWeb, DataTable tblData)
        {
            objInterlocutor.objData = tblWeb.getJson(tbl, tblData);
        }

        private void pesquisarGrid(Interlocutor objInterlocutor, Tabela tbl, TabelaWeb tblWeb, DataTable tblData)
        {
            GridHtml tagGrid = new GridHtml();

            tagGrid.tbl = tbl.viwPrincipal;
            tagGrid.tblData = tblData;

            objInterlocutor.objData = tagGrid.toHtml();
        }

        private void recuperarRegistro(Solicitacao objSolicitacao, Interlocutor objInterlocutor)
        {
        }

        private Resposta responderErro(Solicitacao objSolicitacao, Exception ex, Interlocutor objInterlocutor)
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

            if (objInterlocutor == null)
            {
                objInterlocutor = new Interlocutor();
            }

            objInterlocutor.strErro = strErro;

            Resposta objResposta = new Resposta(objSolicitacao);

            objResposta.addJson(objInterlocutor);

            this.addAcessControl(objResposta);

            return objResposta;
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

            Tabela tbl = AppWeb.i.getTblPorDominio(objInterlocutor.strClazz);

            if (tbl == null)
            {
                objInterlocutor.strErro = string.Format("Não foi encontrado uma tabela relacionada ao domínio {0}.", objInterlocutor.strClazz);
                return;
            }

            MethodInfo objMethodInfo = typeof(Json).GetMethod("fromJson");
            MethodInfo objMethodInfoGeneric = objMethodInfo.MakeGenericMethod(tbl.clsDominio);

            Dominio objDominio = (Dominio)objMethodInfoGeneric.Invoke(Json.i, new object[] { objInterlocutor.objData });

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

            TabelaWeb tblWeb = Json.i.fromJson<TabelaWeb>(objInterlocutor.objData.ToString());

            this.salvarRegistro(objSolicitacao, objInterlocutor, tblWeb);

            objInterlocutor.objData = Json.i.toJson(tblWeb);
        }

        private void salvarRegistro(Solicitacao objSolicitacao, Interlocutor objInterlocutor, TabelaWeb tblWeb)
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

            if (!this.validarSalvarRegistro(objSolicitacao, objInterlocutor, tblWeb, tbl))
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

            this.carregarArquivoUpload(objSolicitacao, objInterlocutor, tblWeb, tbl);

            tbl.salvarWeb(tblWeb);
        }

        private void carregarArquivoUpload(Solicitacao objSolicitacao, Interlocutor objInterlocutor, TabelaWeb tblWeb, Tabela tbl)
        {
            if (!(tbl is ITblArquivo))
            {
                return;
            }

            if (DateTime.MinValue.Equals(tblWeb.dttUpload))
            {
                return;
            }

            objSolicitacao.objUsuario.carregarArquivo(objSolicitacao, objInterlocutor, tblWeb, tbl);
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}