using NetZ.Web.Server.Arquivo.Css;

namespace NetZ.Web.Html.Componente.Mobile
{
    public abstract class TileBase : ComponenteHtml
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        protected override void addJsDebug(LstTag<JavaScriptTag> lstJsDebug)
        {
            base.addJsDebug(lstJsDebug);

            lstJsDebug.Add(new JavaScriptTag(typeof(TileBase), 111));
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}