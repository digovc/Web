using System;
using NetZ.Web.Html.Design;

namespace NetZ.Web.Html.Componente.Menu
{
    public abstract class MainMenu : ComponenteHtml
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        protected override void setCss(CssTag css)
        {
            base.setCss(css);

            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.addCss(css.setBackgroundColor(Tema.i.corFundo2Normal));
                this.addCss(css.setBorderRight(1, "solid", Tema.i.corBorda2Normal));
                this.addCss(css.setBottom(0));
                this.addCss(css.setPadding(10));
                this.addCss(css.setPaddingTop(20));
                this.addCss(css.setPosition("absolute"));
                this.addCss(css.setTop(50));
                this.addCss(css.setWidth(250));
                this.addCss(css.setZIndex(-1));
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