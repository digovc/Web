using System;
using NetZ.Web.Html.Componente.Circulo;

namespace NetZ.Web.Html.Componente.Menu
{
    public class MainMenuItem : ComponenteHtml
    {
        #region Constantes

        private const int INT_HEIGHT = 50;

        #endregion Constantes

        #region Atributos

        private DivCirculo _divIcone;
        private Div _divTitulo;
        private string _strTitulo;

        /// <summary>
        /// Texto que será apresentado para o usuário.
        /// </summary>
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

        private DivCirculo divIcone
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_divIcone != null)
                    {
                        return _divIcone;
                    }

                    _divIcone = new DivCirculo();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _divIcone;
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

        #endregion Atributos

        #region Construtores

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

        protected override void finalizar()
        {
            base.finalizar();

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
                this.divIcone.setPai(this);
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
                this.addCss(css.setCursor("pointer"));
                this.addCss(css.setMinHeight(INT_HEIGHT));

                this.divTitulo.addCss(css.setLineHeight(INT_HEIGHT));

                this.divIcone.addCss(css.setBackgroundColor("blue"));
                this.divIcone.addCss(css.setFloat("left"));
                this.divIcone.addCss(css.setMarginRight(10));
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