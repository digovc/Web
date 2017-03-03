namespace NetZ.Web.Html.Componente.Campo
{
    public class CampoRadioButton : CampoHtml
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        protected override void addJs(LstTag<JavaScriptTag> lstJsDebug)
        {
            base.addJs(lstJsDebug);

            lstJsDebug.Add(new JavaScriptTag(typeof(CampoRadioButton), 130));
        }

        protected override Input.EnmTipo getEnmTipo()
        {
            return Input.EnmTipo.RADIO;
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}