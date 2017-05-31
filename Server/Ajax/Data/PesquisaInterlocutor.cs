using DigoFramework;
using NetZ.Persistencia.Web;

namespace NetZ.Web.Server.Ajax.Data
{
    internal class PesquisaInterlocutor : Objeto
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private FiltroWeb[] _arrFil;
        private string _strTblNome;

        public FiltroWeb[] arrFil
        {
            get
            {
                return _arrFil;
            }

            set
            {
                _arrFil = value;
            }
        }

        public string strTblNome
        {
            get
            {
                return _strTblNome;
            }

            set
            {
                _strTblNome = value;
            }
        }

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}