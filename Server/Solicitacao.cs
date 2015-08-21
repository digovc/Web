using System;
using System.Net.Sockets;

namespace NetZ.Web.Server
{
    internal class Solicitacao
    {
        #region CONSTANTES

        #endregion CONSTANTES

        #region ATRIBUTOS

        private NetworkStream _nts;

        private NetworkStream nts
        {
            get
            {
                return _nts;
            }

            set
            {
                _nts = value;
            }
        }

        #endregion ATRIBUTOS

        #region CONSTRUTORES

        internal Solicitacao(NetworkStream nts)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.nts = nts;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion Ações
        }

        #endregion CONSTRUTORES

        #region MÉTODOS

        #endregion MÉTODOS

        #region EVENTOS

        #endregion EVENTOS
    }
}