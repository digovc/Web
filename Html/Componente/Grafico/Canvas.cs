namespace NetZ.Web.Html.Componente.Grafico
{
    public class Canvas : ComponenteHtml
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        #endregion Atributos

        #region Construtores

        public Canvas()
        {
            this.strNome = "canvas";
        }

        #endregion Construtores

        #region Métodos

        protected override void addJs(LstTag<JavaScriptTag> lstJs)
        {
            base.addJs(lstJs);

            lstJs.Add(new JavaScriptTag(typeof(Canvas), 111));
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}