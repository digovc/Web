using NetZ.Web.Server.Arquivo.Css;

namespace NetZ.Web.Html.Componente
{
    public class LimiteFloat : ComponenteHtml
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        protected override void setCss(CssArquivo tagCss)
        {
            base.setCss(tagCss);

            this.addCss(tagCss.setClearBoth());
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}