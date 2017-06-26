using NetZ.Web.Html;
using NetZ.Web.Html.Componente;

namespace NetZ.Web.Html.Componente.Grid.Coluna
{
    internal abstract class DivGridColunaBase : ComponenteHtml
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

            lstJs.Add(new JavaScriptTag(typeof(DivGridColunaBase)));
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}