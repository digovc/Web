using System;

namespace NetZ.Web.Html
{
    public class Div : Tag
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        #endregion Atributos

        #region Construtores

        public Div() : base("div")
        {
        }

        #endregion Construtores

        #region Métodos

        protected override void addJs(LstTag<JavaScriptTag> lstJs)
        {
            base.addJs(lstJs);

            lstJs.Add(new JavaScriptTag(typeof(Div), 109));
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}