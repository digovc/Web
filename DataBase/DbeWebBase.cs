using NetZ.Persistencia;
using NetZ.Web.DataBase.Tabela;
using System.Collections.Generic;

namespace NetZ.Web.DataBase
{
    public abstract class DbeWebBase : DbePostgreSqlBase
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        protected override void inicializarLstTbl(List<TabelaBase> lstTbl)
        {
            base.inicializarLstTbl(lstTbl);

            lstTbl.Add(TblFiltro.i);
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}