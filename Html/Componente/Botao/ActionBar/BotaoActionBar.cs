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

        protected override void addJs(LstTag<JavaScriptTag> lstJs)
        {
            base.addJs(lstJs);

            lstJs.Add(new JavaScriptTag(typeof(BotaoActionBar), 114));
        }

        protected override void setCss(CssArquivo css)
        {
            base.setCss(css);

            this.addCss(css.setBackgroundColor(AppWebBase.i.objTema.corTema));
        }

        protected override void setCssHeight(CssArquivo css)
        {
            this.addCss(css.setHeight(50));
        }

        protected override void setCssWidth(CssArquivo css)
        {
            this.addCss(css.setWidth(50));
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}