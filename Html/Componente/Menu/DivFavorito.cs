using System;
using NetZ.Web.Server.Arquivo.Css;

namespace NetZ.Web.Html.Componente.Menu
{
    public class DivFavorito : ComponenteHtml
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private Div _divContainer;

        private Div divContainer
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_divContainer != null)
                    {
                        return _divContainer;
                    }

                    _divContainer = new Div();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _divContainer;
            }
        }

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        protected override void montarLayout()
        {
            base.montarLayout();

            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.divContainer.setPai(this);

                this.montarLayoutItem();
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
                this.addCss(css.setHeight(100, "%"));
                this.addCss(css.setPosition("absolute"));
                this.addCss(css.setWidth(100, "%"));
                this.addCss(css.setZIndex(-1));

                this.divContainer.addCss(css.setBottom(0));
                this.divContainer.addCss(css.setCenter());
                this.divContainer.addCss(css.setHeight(380));
                this.divContainer.addCss(css.setLeft(0));
                this.divContainer.addCss(css.setPosition("absolute"));
                this.divContainer.addCss(css.setRight(0));
                this.divContainer.addCss(css.setTop(0));
                this.divContainer.addCss(css.setWidth(380));
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

        private void montarLayoutItem()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                for (int i = 0; i < 9; i++)
                {
                    new DivFavoritoItem().setPai(this.divContainer);
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

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}