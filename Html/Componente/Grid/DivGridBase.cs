using NetZ.Web.Server.Arquivo.Css;

namespace NetZ.Web.Html.Componente.Grid
{
    public abstract class DivGridBase : ComponenteHtml
    {
        #region Constantes

        internal const string STR_GRID_ID = "_div_grid_id";

        #endregion Constantes

        #region Atributos

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        protected override void inicializar()
        {
            base.inicializar();

            this.strId = STR_GRID_ID;
        }

        protected override void montarLayout()
        {
            base.montarLayout();

            new DivGridCabecalho().setPai(this);
            new DivGridConteudo().setPai(this);
            new DivGridRodape().setPai(this);
        }

        protected override void setCss(CssArquivoBase css)
        {
            base.setCss(css);

            this.addCss(css.setBackgroundColor("rgba(255,255,255,.15)"));
            this.addCss(css.setBorderRadius(5));
            this.addCss(css.setDisplay("none"));
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}