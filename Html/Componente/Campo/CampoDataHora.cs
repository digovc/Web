﻿using System;

namespace NetZ.Web.Html.Componente.Campo
{
    public class CampoDataHora : CampoHtmlBase
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        protected override Input.EnmTipo getEnmTipo()
        {
            return Input.EnmTipo.DATETIME;
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}