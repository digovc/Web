using DigoFramework.Json;
using System.Collections.Generic;
using System.Net.Sockets;

namespace NetZ.Web.Server.WebSocket
{
    public abstract class ServerWsBase : ServerBase
    {
        #region Constantes

        private const string STR_METODO_WELCOME = "WELCOME";

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

        protected ServerWsBase(string strNome) : base(strNome)
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

        internal virtual void processarOnMensagemLocal(ClienteWs objClienteWs, string jsnInterlocutor)
        {
            if (objClienteWs == null)
            {
                return;
            }

            if (!this.lstObjClienteWs.Contains(objClienteWs))
            {
                return;
            }

            if (string.IsNullOrEmpty(jsnInterlocutor))
            {
                return;
            }

            Interlocutor objInterlocutor = Json.i.fromJson<Interlocutor>(jsnInterlocutor);

            if (objInterlocutor == null)
            {
                return;
            }

            if (string.IsNullOrEmpty(objInterlocutor.strMetodo))
            {
                return;
            }

            this.processarOnMensagem(objClienteWs, objInterlocutor);
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

        protected virtual bool processarOnMensagem(ClienteWs objClienteWs, Interlocutor objInterlocutor)
        {
            if (objInterlocutor == null)
            {
                return false;
            }

            switch (objInterlocutor.strMetodo)
            {
                case STR_METODO_WELCOME:
                    this.processarOnMensagemWelcome(objClienteWs, objInterlocutor);
                    return true;
            }

            return false;
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

        private void processarOnMensagemWelcome(ClienteWs objClienteWs, Interlocutor objInterlocutor)
        {
            if (objClienteWs == null)
            {
                return;
            }

            objInterlocutor.strMetodo = STR_METODO_WELCOME;

            objClienteWs.enviar(objInterlocutor);
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}