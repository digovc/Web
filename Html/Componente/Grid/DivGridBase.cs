using NetZ.Web.Html.Componente.Grid.Coluna;
using NetZ.Web.Server.Arquivo.Css;

namespace NetZ.Web.Html.Componente.Grid
{
    public abstract class DivGridBase : ComponenteHtml
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        protected override void addLayoutFixo(JavaScriptTag tagJs)
        {
            base.addLayoutFixo(tagJs);

            tagJs.addLayoutFixo(typeof(DivGridCabecalho));
            tagJs.addLayoutFixo(typeof(DivGridConteudo));
            tagJs.addLayoutFixo(typeof(DivGridRodape));

            tagJs.addLayoutFixo(typeof(DivGridLinha));

            tagJs.addLayoutFixo(typeof(DivGridColunaCabecalho));
            tagJs.addLayoutFixo(typeof(DivGridColunaSumario));
        }

        protected override bool getBooJs()
        {
            return true;
        }

        protected override void inicializar()
        {
            base.inicializar();

            this.strId = "_div_grid_consulta_id";
        }

        protected override void setCss(CssArquivoBase css)
        {
            base.setCss(css);

            this.addCss(css.setDisplay("none"));
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}