using NetZ.Web.Html.Componente;

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

        protected override bool getBooJs()
        {
            return true;
        }

        protected override void inicializar()
        {
            base.inicializar();

            this.strId = "_div_grid_conteudo_id";
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}