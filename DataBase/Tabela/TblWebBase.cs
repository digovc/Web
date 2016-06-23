namespace NetZ.Web.DataBase.Tabela
{
    public abstract class TblWebBase : Persistencia.Tabela
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        #endregion Atributos

        #region Construtores

        public TblWebBase(string strNome) : base(AppWeb.i.objDbPrincipal, strNome)
        {
        }

        #endregion Construtores

        #region Métodos

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}