namespace NetZ.Web.Html
{
    public class Imagem : Tag
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        #endregion Atributos

        #region Construtores

        public Imagem() : base("img")
        {
        }

        #endregion Construtores

        #region Métodos

        protected override void addJs(LstTag<JavaScriptTag> lstJs)
        {
            base.addJs(lstJs);

            lstJs.Add(new JavaScriptTag(typeof(Imagem)));
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}