using NetZ.Web.Html.Componente;

namespace NetZ.Web.Html.Activity
{
    public abstract class ActivityBase : ComponenteHtml
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

            lstJs.Add(new JavaScriptTag(typeof(ActivityBase), 111));
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}