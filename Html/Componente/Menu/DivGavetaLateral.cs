using NetZ.Web.Html.Componente.Menu.Chat;
using NetZ.Web.Server.Arquivo.Css;

namespace NetZ.Web.Html.Componente.Menu
{
    public class DivGavetaLateral : ComponenteHtmlBase
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        protected override void montarLayout()
        {
            base.montarLayout();

            new DivChatUsuario().setPai(this);
        }

        protected override void setCss(CssArquivoBase css)
        {
            base.setCss(css);

            this.addCss(css.setBackgroundColor("rgba(88,178,150,0.75)"));
            this.addCss(css.setBottom(0));
            this.addCss(css.setPadding(20));
            this.addCss(css.setPosition("absolute"));
            this.addCss(css.setRight(0));
            this.addCss(css.setTop(50));
            this.addCss(css.setWidth(300));
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}