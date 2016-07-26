using System;
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

        protected ClienteWs getObjClienteWs(int intUsuarioId)
        {
            if (intUsuarioId < 1)
            {
                return null;
            }

            foreach (ClienteWs objClienteWs in this.lstObjClienteWs)
            {
                ClienteWs objClienteWs2 = this.getObjClienteWs(objClienteWs, intUsuarioId);

                if (objClienteWs2 != null)
                {
                    return objClienteWs2;
                }
            }

            return null;
        }

        private ClienteWs getObjClienteWs(ClienteWs objClienteWs, int intUsuarioId)
        {
            if (objClienteWs == null)
            {
                return null;
            }

            if (!objClienteWs.booConectado)
            {
                return null;
            }

            if (objClienteWs.objUsuario == null)
            {
                return null;
            }

            if (!objClienteWs.objUsuario.intId.Equals(intUsuarioId))
            {
                return null;
            }

            return objClienteWs;
        }

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