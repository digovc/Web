namespace NetZ.Web.Html.Componente.Grid
{
    internal class DivGridConteudo : ComponenteHtml
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

            tagJs.addLayoutFixo(typeof(DivGridLinha));
        }

        protected override void inicializar()
        {
            base.inicializar();

            this.strId = (DivGridBase.STR_GRID_ID + "_" + this.GetType().Name);
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}