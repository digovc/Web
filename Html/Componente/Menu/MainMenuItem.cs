using System;
using NetZ.Web.Html.Design;

namespace NetZ.Web.Html.Componente.Menu
{
    public class MainMenuItem : ComponenteHtml
    {
        #region Constantes

        private const int INT_HEIGHT = 50;

        #endregion Constantes

        #region Atributos

        private Div _divTitulo;
        private Imagem _img;
        private string _strTitulo;

        public string strTitulo
        {
            get
            {
                return _strTitulo;
            }

            set
            {
                _strTitulo = value;
            }
        }

        private Div divTitulo
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_divTitulo != null)
                    {
                        return _divTitulo;
                    }

                    _divTitulo = new Div();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _divTitulo;
            }
        }

        private Imagem img
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_img != null)
                    {
                        return _img;
                    }

                    _img = new Imagem();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _img;
            }
        }

        #endregion Atributos

        #region Construtores

        public MainMenuItem(string strId, string strTitulo)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.strId = strId;
                this.strTitulo = strTitulo;
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
                lstJs.Add(new JavaScriptTag("res/js/Web.TypeScript/html/componente/menu/MainMenuItem.js", 151));
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
                this.divTitulo.strConteudo = this.strTitulo;
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
                this.img.setPai(this);
                this.divTitulo.setPai(this);
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
                this.addCss(css.setBorder(1, "solid", Tema.i.corBorda1Normal));
                this.addCss(css.setCursor("pointer"));
                this.addCss(css.setHeight(INT_HEIGHT));

                this.divTitulo.addCss(css.setLineHeight(INT_HEIGHT));

                this.img.addCss(css.setBackgroundColor("blue"));
                this.img.addCss(css.setBorderRadius(50, "%"));
                this.img.addCss(css.setFloat("left"));
                this.img.addCss(css.setHeight(INT_HEIGHT));
                this.img.addCss(css.setMarginRight(10));
                this.img.addCss(css.setWidth(INT_HEIGHT));
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