using System;
using NetZ.Web.Server.Arquivo.Css;

namespace NetZ.Web.Html.Componente.Menu
{
    public abstract class Menu : ComponenteHtml
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private Div _divGaveta;
        private Div _divGavetaContainer;
        private Div _divPesquisa;
        private Input _txtPesquisa;

        protected Div divGaveta
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_divGaveta != null)
                    {
                        return _divGaveta;
                    }

                    _divGaveta = new Div();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _divGaveta;
            }
        }

        private Div divGavetaContainer
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_divGavetaContainer != null)
                    {
                        return _divGavetaContainer;
                    }

                    _divGavetaContainer = new Div();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _divGavetaContainer;
            }
        }

        private Div divPesquisa
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_divPesquisa != null)
                    {
                        return _divPesquisa;
                    }

                    _divPesquisa = new Div();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _divPesquisa;
            }
        }

        private Input txtPesquisa
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_txtPesquisa != null)
                    {
                        return _txtPesquisa;
                    }

                    _txtPesquisa = new Input();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _txtPesquisa;
            }
        }

        #endregion Atributos

        #region Construtores

        protected Menu(string strId)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.strId = strId;
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
                lstJs.Add(new JavaScriptTag(typeof(Menu), 150));
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
                this.divGaveta.strId = "divGaveta";

                this.txtPesquisa.strId = "txtPesquisa";
                this.txtPesquisa.strPlaceHolder = "Digite para pesquisar";
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
                this.divPesquisa.setPai(this);
                this.txtPesquisa.setPai(this.divPesquisa);
                this.divGavetaContainer.setPai(this);
                this.divGaveta.setPai(this.divGavetaContainer);
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
                this.divGaveta.addCss(css.setBackgroundColor("rgba(88, 178, 150, 0.95)"));
                this.divGaveta.addCss(css.setBorderRadius(0, 0, 5, 5));
                this.divGaveta.addCss(css.setBoxShadow(0, 9, 15, -3, "rgb(100, 100, 100)"));
                this.divGaveta.addCss(css.setCenter());
                this.divGaveta.addCss(css.setColor("white"));
                this.divGaveta.addCss(css.setDisplay("none"));
                this.divGaveta.addCss(css.setMaxHeight(500));
                this.divGaveta.addCss(css.setOverflowX("hidden"));
                this.divGaveta.addCss(css.setOverflowY("auto"));
                this.divGaveta.addCss(css.setPaddingBottom(10));
                this.divGaveta.addCss(css.setPaddingLeft(20));
                this.divGaveta.addCss(css.setPaddingRight(20));
                this.divGaveta.addCss(css.setPaddingTop(10));
                this.divGaveta.addCss(css.setWidth(450));
                this.divGaveta.addCss(css.setZIndex(10));

                this.divGavetaContainer.addCss(css.setPosition("absolute"));
                this.divGavetaContainer.addCss(css.setTop(50));
                this.divGavetaContainer.addCss(css.setWidth(100, "%"));

                this.divPesquisa.addCss(css.setPosition("absolute"));
                this.divPesquisa.addCss(css.setTop(0));
                this.divPesquisa.addCss(css.setWidth(100, "%"));

                this.txtPesquisa.addCss(css.setBorder(0));
                this.txtPesquisa.addCss(css.setBorderRadius(5, 5, 5, 5));
                this.txtPesquisa.addCss(css.setCenter());
                this.txtPesquisa.addCss(css.setDisplay("block"));
                this.txtPesquisa.addCss(css.setFontSize(20));
                this.txtPesquisa.addCss(css.setHeight(20));
                this.txtPesquisa.addCss(css.setPadding(5));
                this.txtPesquisa.addCss(css.setPosition("relative"));
                this.txtPesquisa.addCss(css.setTop(10));
                this.txtPesquisa.addCss(css.setWidth(450));
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