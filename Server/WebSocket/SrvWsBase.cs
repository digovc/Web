using System;
using System.Collections.Generic;
using System.Net.Sockets;

namespace NetZ.Web.Server.WebSocket
{
    public abstract class SrvWsBase : ServerBase
    {
        #region Constantes

        private const string STR_METODO_WELCOME = "metodo_welcome";

        #endregion Constantes

        #region Atributos

        private List<ClienteWs> _lstObjClienteWs;

        public List<ClienteWs> lstObjClienteWs
        {
            get
            {
                lock (this)
                {
                    if (_lstObjClienteWs != null)
                    {
                        return _lstObjClienteWs;
                    }

                    _lstObjClienteWs = new List<ClienteWs>();

                    return _lstObjClienteWs;
                }
            }
        }

        #endregion Atributos

        #region Construtores

        protected SrvWsBase(string strNome) : base(strNome)
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

            this.processarOnClienteWsAdd(objClienteWs);
        }

        internal void removerObjClienteWs(ClienteWs objClienteWs)
        {
            if (objClienteWs == null)
            {
                return;
            }

            if (!this.lstObjClienteWs.Contains(objClienteWs))
            {
                return;
            }

            this.lstObjClienteWs.Remove(objClienteWs);
        }

        protected override int getIntPorta()
        {
            return 443;
        }

        protected override Cliente getObjCliente(TcpClient tcpClient)
        {
            return new ClienteWs(tcpClient, this);
        }

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

        protected virtual void processarOnClienteWsAdd(ClienteWs objClienteWs)
        {
            this.onClienteWsAdd?.Invoke(this, objClienteWs);
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

        #endregion Métodos

        #region Eventos

        public event EventHandler<ClienteWs> onClienteWsAdd;

        #endregion Eventos
    }
}