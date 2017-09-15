using NetZ.Web.Server.Arquivo.Css;

namespace NetZ.Web.Html.Componente
{
    public class Card : ComponenteHtmlBase
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        protected override void setCss(CssArquivoBase css)
        {
            base.setCss(css);

            this.addCss(css.setBorderRadius(2));
            this.addCss(css.setBoxShadow(0, 2, 2, 0, "rgba(0,0,0,.5)"));
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}