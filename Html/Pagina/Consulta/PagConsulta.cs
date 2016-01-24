using System;
using NetZ.Persistencia;
using NetZ.Web.Html.Componente.Botao.Acao;
using NetZ.Web.Html.Componente.Grid;
using NetZ.Web.Html.Componente.Painel;

namespace NetZ.Web.Html.Pagina.Consulta
{
    public sealed class PagConsulta : PaginaHtml
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private BotaoAcao _btnAcao;
        private GridHtml _grdDados;
        private PainelFiltro _pnlFiltro;
        private Tabela _tbl;

        private BotaoAcao btnAcao
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_btnAcao != null)
                    {
                        return _btnAcao;
                    }

                    _btnAcao = new BotaoAcao();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _btnAcao;
            }
        }

        private GridHtml grdDados
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_grdDados != null)
                    {
                        return _grdDados;
                    }

                    _grdDados = new GridHtml();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _grdDados;
            }
        }

        private PainelFiltro pnlFiltro
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_pnlFiltro != null)
                    {
                        return _pnlFiltro;
                    }

                    _pnlFiltro = new PainelFiltro();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _pnlFiltro;
            }
        }

        private Tabela tbl
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


        private Div _divGrid;
        private Div divGrid
        {
            get
            {
                #region Variáveis
                #endregion Variáveis

                #region Ações
                try
                {
                    if (_divGrid != null)
                    {
                        return _divGrid;
                    }

                    _divGrid = new Div();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }
                #endregion Ações

                return _divGrid;
            }
        }

        #endregion Atributos

        #region Construtores

        public PagConsulta(Tabela tbl) : base("Consula")
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.tbl = tbl;
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

        #endregion Construtores

        #region Métodos

        protected override void addJs(LstTag<JavaScriptTag> lstJs)
        {
            base.addJs(lstJs);

            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                lstJs.Add(new JavaScriptTag(typeof(PagConsulta), 103));

                lstJs.Add(new JavaScriptTag("res/js/Web.TypeScript/persistencia/TabelaWeb.js"));
                lstJs.Add(new JavaScriptTag("res/js/Web.TypeScript/persistencia/FiltroWeb.js"));
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

        protected override void inicializar()
        {
            base.inicializar();

            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.tagBody.addAtt(new Atributo("tblWeb", this.tbl.strNomeSql));

                this.btnAcao.strId = "btnAcao";

                this.divGrid.strId = "divGrid";
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
                this.pnlFiltro.setPai(this);
                this.divGrid.setPai(this);
                this.btnAcao.setPai(this);
                //this.grdDados.setPai(this.divConteudo);
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

        protected override void setCss(CssTag css)
        {
            base.setCss(css);

            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.addCss(css.setBackgroundColor(AppWeb.i.objTema.corTelaFundo));

                this.btnAcao.addCss(css.setBottom(25));
                this.btnAcao.addCss(css.setRight(50));

                this.divGrid.addCss(css.setBottom(0));
                this.divGrid.addCss(css.setLeft(0));
                this.divGrid.addCss(css.setOverflow("scroll"));
                this.divGrid.addCss(css.setPosition("absolute"));
                this.divGrid.addCss(css.setRight(0));
                this.divGrid.addCss(css.setTop(150));
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