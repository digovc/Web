using NetZ.Web.Html.Componente.Grid.Coluna;

namespace NetZ.Web.Html.Componente.Grid
{
    internal class DivGridLinha : ComponenteHtml
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

            tagJs.addLayoutFixo(typeof(DivGridColunaLinha));
        }

        protected override void inicializar()
        {
            base.inicializar();

            this.strId = "_div_id";
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}