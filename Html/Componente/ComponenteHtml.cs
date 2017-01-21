namespace NetZ.Web.Html.Componente
{
    public abstract class ComponenteHtml : Div
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

            lstJsDebug.Add(new JavaScriptTag(typeof(ComponenteHtml), 110));

            if (this.getBooJs())
            {
                lstJsDebug.Add(new JavaScriptTag(this.GetType()));
            }
        }

        protected virtual bool getBooJs()
        {
            return false;
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}