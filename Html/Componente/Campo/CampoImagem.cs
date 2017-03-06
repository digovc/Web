﻿namespace NetZ.Web.Html.Componente.Campo
{
    public class CampoImagem : CampoHtml
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

            lstJs.Add(new JavaScriptTag(typeof(CampoImagem), 130));
        }

        protected override Input.EnmTipo getEnmTipo()
        {
            return Input.EnmTipo.IMAGE;
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}