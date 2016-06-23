using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetZ.Persistencia;

namespace NetZ.Web.DataBase.View
{
    public abstract class ViwWebBase : Persistencia.View
    {

        #region Constantes
        #endregion Constantes

        #region Atributos
        #endregion Atributos

        #region Construtores

        public ViwWebBase(string strNome) : base(AppWeb.i.objDbPrincipal, strNome)
        {
        }

        #endregion Construtores

        #region Métodos
        #endregion Métodos

        #region Eventos
        #endregion Eventos
    }
}
