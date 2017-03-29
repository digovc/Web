using NetZ.Web.Server.Arquivo.Css;

namespace NetZ.Web.Html.Componente.Painel
{
    public class PainelAtalho : PainelHtml
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

            this.addCss(css.setBackgroundColor(AppWebBase.i.objTema.corFundo));
            this.addCss(css.setBorderBottom(1, "solid", AppWebBase.i.objTema.corBorda));
            this.addCss(css.setHeight(70));
            this.addCss(css.setPadding(5));
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}