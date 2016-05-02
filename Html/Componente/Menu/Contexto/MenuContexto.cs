using NetZ.Web.Server.Arquivo.Css;

namespace NetZ.Web.Html.Componente.Menu.Contexto
{
    public class MenuContexto : ComponenteHtml
    {
        #region Constantes

        #endregion Constantes

        #region Atributos



        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        protected override void setCss(CssArquivo css)
        {
            base.setCss(css);

            this.addCss(css.setBackgroundColor(AppWeb.i.objTema.corTelaFundo));
            this.addCss(css.setBoxShadow(0, 0, 10, 0, AppWeb.i.objTema.corBorda));
            this.addCss(css.setPosition("absolute"));
            this.addCss(css.setWidth(200));
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}