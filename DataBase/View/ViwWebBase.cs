using NetZ.Persistencia;

namespace NetZ.Web.DataBase.View
{
    public abstract class ViwWebBase : ViewBase
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        #endregion Atributos

        #region Construtores

        public ViwWebBase(string strNome) : base(strNome, AppWebBase.i.dbe)
        {
        }

        #endregion Construtores

        #region Métodos

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}