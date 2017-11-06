namespace NetZ.Web.Html.Componente.Markdown
{
    public class DivMarkdown : ComponenteHtmlBase
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        protected override void addCss(LstTag<CssTag> lstCss)
        {
            base.addCss(lstCss);

            lstCss.Add(new CssTag(AppWebBase.DIR_CSS + "github-markdown.css"));
        }

        protected override void addJsLib(LstTag<JavaScriptTag> lstJsLib)
        {
            base.addJsLib(lstJsLib);

            lstJsLib.Add(new JavaScriptTag(AppWebBase.DIR_JS_LIB + "marked.min.js"));
        }

        protected override void inicializar()
        {
            base.inicializar();

            this.addClass("markdown-body");
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}