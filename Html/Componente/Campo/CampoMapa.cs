﻿namespace NetZ.Web.Html.Componente.Campo
{
    public class CampoMapa : CampoMedia
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

            lstJsDebug.Add(new JavaScriptTag(typeof(CampoMapa), 132));
        }

        protected override Input.EnmTipo getEnmTipo()
        {
            return Input.EnmTipo.HIDDEN;
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}