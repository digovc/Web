using DigoFramework;
using NetZ.Persistencia.Web;

namespace NetZ.Web.Server.Ajax.Dbe
{
    public class PesquisaInterlocutor : Objeto
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private FiltroWeb[] _arrFil;
        private string _sqlTabelaNome;

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

        public string sqlTabelaNome
        {
            get
            {
                return _sqlTabelaNome;
            }

            set
            {
                _sqlTabelaNome = value;
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