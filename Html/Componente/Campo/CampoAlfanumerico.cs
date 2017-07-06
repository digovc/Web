﻿using System;

namespace NetZ.Web.Html.Componente.Campo
{
    /// <summary>
    /// Campo para a inserção de valores de qualquer espécie, como letras, números e até mesmo pontuação.
    /// </summary>
    public class CampoAlfanumerico : CampoHtml
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
            return Input.EnmTipo.TEXT;
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}