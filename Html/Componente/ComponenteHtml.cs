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

        protected override void addJs(LstTag<JavaScriptTag> lstJs)
        {
            base.addJs(lstJs);

            lstJs.Add(new JavaScriptTag(typeof(ComponenteHtml), 110));

            if (this.getBooJs())
            {
                lstJs.Add(new JavaScriptTag(this.GetType()));
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