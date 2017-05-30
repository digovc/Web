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

        private bool _booExportarSempre;
        private int _intVersao;

        public bool booExportarSempre
        {
            get
            {
                return _booExportarSempre;
            }

            private set
            {
                _booExportarSempre = value;
            }
        }

        public int intVersao
        {
            get
            {
                return _intVersao;
            }

            private set
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

        public HtmlExport(bool booExportarSempre)
        {
            this.booExportarSempre = booExportarSempre;
        }

        #endregion Construtores

        #region Métodos

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}