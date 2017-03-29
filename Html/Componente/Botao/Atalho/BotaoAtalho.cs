using NetZ.Web.Server.Arquivo.Css;

namespace NetZ.Web.Html.Componente.Botao.Atalho
{
    public class BotaoAtalho : BotaoHtml
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

            lstJs.Add(new JavaScriptTag(typeof(BotaoAtalho), 120));
        }

        protected override void setCss(CssArquivoBase css)
        {
            base.setCss(css);

            this.addCss(css.setBackgroundColor("#AFAFAF"));
            this.addCss(css.setHeight(70));
            this.addCss(css.setWidth(70));
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}