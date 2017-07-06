using NetZ.Web.Server.Arquivo.Css;

namespace NetZ.Web.Html.Componente.Botao.ActionBar
{
    public class BotaoActionBar : BotaoHtml
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

            this.addCss(css.setBackgroundColor(AppWebBase.i.objTema.corTema));
            this.addCss(css.setBackgroundPosition("center"));
            this.addCss(css.setBackgroundRepeat("no-repeat"));
            this.addCss(css.setBackgroundSize("35px"));
        }

        protected override void setCssHeight(CssArquivoBase css)
        {
            this.addCss(css.setHeight(50));
        }

        protected override void setCssWidth(CssArquivoBase css)
        {
            this.addCss(css.setWidth(50));
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}