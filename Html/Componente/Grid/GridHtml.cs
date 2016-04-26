using System;
using System.Data;
using NetZ.Persistencia;
using NetZ.Web.Html.Componente.Botao.Mini;
using NetZ.Web.Server.Arquivo.Css;

namespace NetZ.Web.Html.Componente.Grid
{
    public class GridHtml : ComponenteHtml
    {
        #region Constantes

        internal const decimal INT_LINHA_TAMANHO = 35;

        #endregion Constantes

        #region Atributos

        private BotaoAdicionarMini _btnAdicionar;
        private Tag _tagTable;
        private Tag _tagTbody;
        private Tag _tagTfoot;
        private Tag _tagThead;
        private Tag _tagTrHead;
        private Tabela _tbl;
        private DataTable _tblData;

        /// <summary>
        /// Tabela que este grid irá representar.
        /// </summary>
        public Tabela tbl
        {
            get
            {
                return _tbl;
            }

            set
            {
                _tbl = value;
            }
        }

        /// <summary>
        /// Tabela que guarda os dados deste grid.
        /// </summary>
        public DataTable tblData
        {
            get
            {
                return _tblData;
            }

            set
            {
                _tblData = value;
            }
        }

        private BotaoAdicionarMini btnAdicionar
        {
            get
            {
                if (_btnAdicionar != null)
                {
                    return _btnAdicionar;
                }

                _btnAdicionar = new BotaoAdicionarMini();

                return _btnAdicionar;
            }
        }

        private Tag tagTable
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_tagTable != null)
                    {
                        return _tagTable;
                    }

                    _tagTable = new Tag("table");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _tagTable;
            }
        }

        private Tag tagTbody
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_tagTbody != null)
                    {
                        return _tagTbody;
                    }

                    _tagTbody = new Tag("tbody");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _tagTbody;
            }
        }

        private Tag tagTfoot
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_tagTfoot != null)
                    {
                        return _tagTfoot;
                    }

                    _tagTfoot = new Tag("tfoot");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _tagTfoot;
            }
        }

        private Tag tagThead
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_tagThead != null)
                    {
                        return _tagThead;
                    }

                    _tagThead = new Tag("thead");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _tagThead;
            }
        }

        private Tag tagTrHead
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_tagTrHead != null)
                    {
                        return _tagTrHead;
                    }

                    _tagTrHead = new Tag("tr");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _tagTrHead;
            }
        }

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        protected override void atualizarStrId()
        {
            base.atualizarStrId();

            if (string.IsNullOrEmpty(this.strId))
            {
                return;
            }

            this.btnAdicionar.strId = (this.strId + "_btnAdicionar");
            this.tagTable.strId = (this.strId + "_table");
            this.tagTbody.strId = (this.strId + "_tbody");
        }

        protected override void inicializar()
        {
            base.inicializar();

            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (this.tbl == null)
                {
                    return;
                }

                this.strId = ("tagGridHtml_" + this.tbl.strNomeSql);

                this.addAtt("tbl_web_nome", this.tbl.strNomeSql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion Ações
        }

        protected override void montarLayout()
        {
            base.montarLayout();

            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.tagTable.setPai(this);
                this.tagThead.setPai(this.tagTable);
                this.tagTrHead.setPai(this.tagThead);
                this.tagTbody.setPai(this.tagTable);
                this.tagTfoot.setPai(this.tagTable);

                this.btnAdicionar.setPai(this);

                this.montarLayoutHead();
                this.montarLayoutTbody();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion Ações
        }

        protected override void setCss(CssArquivo css)
        {
            base.setCss(css);

            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                //this.addCss(css.setBackgroundColor(AppWeb.i.objTema.corFundo1));
                //this.addCss(css.setHeight(600));
                //this.addCss(css.setOverflow("scroll"));
                //this.addCss(css.setPadding(10));
                //this.addCss(css.setWidth(600));

                this.tagTable.addCss(css.addCss("border-spacing", "0"));
                this.tagTable.addCss(css.setBackgroundColor("white"));
                //this.tagTable.addCss(css.setBorder(1, "solid", AppWeb.i.objTema.corBorda));
                this.tagTable.addCss(css.setBoxShadow(0, 2, 2, 0, AppWeb.i.objTema.corBorda));
                this.tagTable.addCss(css.setCenter());

                this.tagTrHead.addCss(css.setHeight(INT_LINHA_TAMANHO));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion Ações
        }

        private void montarLayoutHead()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (this.tbl == null)
                {
                    return;
                }

                foreach (Coluna cln in this.tbl.lstClnConsulta)
                {
                    this.montarLayoutHead(cln);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion Ações
        }

        private void montarLayoutHead(Coluna cln)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (cln == null)
                {
                    return;
                }

                new GridHead(cln).setPai(this.tagTrHead);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion Ações
        }

        private void montarLayoutTbody()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (this.tbl == null)
                {
                    return;
                }

                if (this.tblData == null)
                {
                    return;
                }

                foreach (DataRow row in this.tblData.Rows)
                {
                    this.montarLayoutTbody(row);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion Ações
        }

        private void montarLayoutTbody(DataRow row)
        {
            #region Variáveis

            GridRow tagGridRow;

            #endregion Variáveis

            #region Ações

            try
            {
                if (row == null)
                {
                    return;
                }

                tagGridRow = new GridRow();

                tagGridRow.row = row;
                tagGridRow.tbl = tbl;

                tagGridRow.setPai(this.tagTbody);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion Ações
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}