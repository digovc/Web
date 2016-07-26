using System.Collections.Generic;
using System.Net.Sockets;

namespace NetZ.Web.Server.WebSocket
{
    public abstract class ServerWs : ServerBase
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private List<ClienteWs> _lstObjClienteWs;

        protected List<ClienteWs> lstObjClienteWs
        {
            get
            {
                if (_lstObjClienteWs != null)
                {
                    return _lstObjClienteWs;
                }

                _lstObjClienteWs = new List<ClienteWs>();

                return _lstObjClienteWs;
            }
        }

        #endregion Atributos

        #region Construtores

        protected ServerWs(string strNome) : base(strNome)
        {
        }

        #endregion Construtores

        #region Métodos

        public override Resposta responder(Solicitacao objSolicitacao)
        {
            // A solicitação e resposta é sempre processada pela classe ClienteWs.
            return null;
        }

        internal void addObjClienteWs(ClienteWs objClienteWs)
        {
            if (objClienteWs == null)
            {
                return;
            }

            if (this.lstObjClienteWs.Contains(objClienteWs))
            {
                return;
            }

            this.lstObjClienteWs.Add(objClienteWs);
        }

        protected override int getIntPort()
        {
            return ConfigWeb.i.intServerWsPorta;
        }

        protected override Cliente getObjCliente(TcpClient tcpClient)
        {
            return new ClienteWs(tcpClient, this);
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}