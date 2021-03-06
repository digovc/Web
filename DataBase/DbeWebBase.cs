﻿using NetZ.Persistencia;
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

            lstTbl.Add(TblFavorito.i);
            lstTbl.Add(TblFiltro.i);
            lstTbl.Add(TblFiltroItem.i);
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}