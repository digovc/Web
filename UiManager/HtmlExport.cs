using System;

namespace Web.UiManager
{
    /// <summary>
    /// Indica se a classe será exportada.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class HtmlExport : Attribute
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private int _intVersao;

        public int intVersao
        {
            get
            {
                return _intVersao;
            }

            set
            {
                _intVersao = value;
            }
        }

        #endregion Atributos

        #region Construtores

        public HtmlExport(int intVersao)
        {
            this.intVersao = intVersao;
        }

        #endregion Construtores

        #region Métodos

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}