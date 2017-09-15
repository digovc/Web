using NetZ.Web.Server.Arquivo.Css;

namespace NetZ.Web.Html.Componente.Menu.Contexto
{
    public class MenuContexto : ComponenteHtmlBase
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        protected override void inicializar()
        {
            base.inicializar();

            this.strConteudo = "_conteudo";
            this.strId = "_id";

            this.addAtt("oncontextmenu", "return false");
        }

        protected override void setCss(CssArquivoBase css)
        {
            base.setCss(css);

            this.addCss(css.setBackgroundColor("grey"));
            this.addCss(css.setBoxShadow(0, 0, 10, 0, AppWebBase.i.objTema.corSombra));
            this.addCss(css.setDisplay("none"));
            this.addCss(css.setMaxHeight(250));
            this.addCss(css.setOverflowY("auto"));
            this.addCss(css.setPosition("absolute"));
            this.addCss(css.setWidth(275));
            this.addCss(css.setZIndex(1000));
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}