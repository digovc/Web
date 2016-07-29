using System;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using DigoFramework.Json;
using NetZ.Web.DataBase.Dominio;
using NetZ.Web.DataBase.Tabela;

namespace NetZ.Web.Server.WebSocket
{
    public class ClienteWs : Cliente
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private bool _booConectado;
        private bool _booHandshake;
        private UsuarioDominio _objUsuario;
        private string _strSecWebSocketAccept;
        private string _strSecWebSocketKey;
        private string _strSessaoId;

        public bool booConectado
        {
            get
            {
                _booConectado = this.getBooConectado();

                return _booConectado;
            }
        }

        public UsuarioDominio objUsuario
        {
            get
            {
                if (_objUsuario != null)
                {
                    return _objUsuario;
                }

                _objUsuario = this.getObjUsuario();

                return _objUsuario;
            }
        }

        protected string strSessaoId
        {
            get
            {
                return _strSessaoId;
            }

            private set
            {
                _strSessaoId = value;
            }
        }

        private bool booHandshake
        {
            get
            {
                return _booHandshake;
            }

            set
            {
                _booHandshake = value;
            }
        }

        private string strSecWebSocketAccept
        {
            get
            {
                if (_strSecWebSocketAccept != null)
                {
                    return _strSecWebSocketAccept;
                }

                _strSecWebSocketAccept = this.getStrSecWebSocketAccept();
                return _strSecWebSocketAccept;
            }
        }

        private string strSecWebSocketKey
        {
            get
            {
                return _strSecWebSocketKey;
            }

            set
            {
                _strSecWebSocketKey = value;
            }
        }

        #endregion Atributos

        #region Construtores

        public ClienteWs(TcpClient tcpClient, ServerWs srv) : base(tcpClient, srv)
        {
        }

        #endregion Construtores

        #region Métodos

        /// <summary>
        /// Envia uma mensagem contendo a estrutura do interlocutor em JSON para este cliente.
        /// </summary>
        /// <param name="objInterlocutor">Interlocutor que será serializado e enviado para este cliente.</param>
        public void enviar(Interlocutor objInterlocutor)
        {
            if (objInterlocutor == null)
            {
                return;
            }

            this.enviar(Json.i.toJson(objInterlocutor));
        }

        private void enviar(string strMensagem)
        {
            if (string.IsNullOrEmpty(strMensagem))
            {
                return;
            }

            Frame fme = new Frame(Encoding.UTF8.GetBytes(strMensagem));

            fme.processarDadosOut();

            this.enviar(fme.arrBteDataOut);
        }

        protected override void atualizarSrv()
        {
            base.atualizarSrv();

            if (this.srv == null)
            {
                return;
            }

                    (this.srv as ServerWs).addObjClienteWs(this);
        }

        /// <summary>
        /// Mensagem recebida quando este cliente solicita o fechamento da conexão.
        /// </summary>
        protected virtual void onMensagemClose()
        {
        }

        /// <summary>
        /// Método disparado quando este cliente se conecta ao servidor.
        /// </summary>
        /// <param name="objSolicitacao">Solicitação que foi enviada pelo cliente.</param>
        protected virtual void onMensagemConnect(Solicitacao objSolicitacao)
        {
        }

        protected override void responder(Solicitacao objSolicitacao)
        {
            //base.responder();

            if (!this.validar(objSolicitacao))
            {
                return;
            }

            this.processarMensagem(objSolicitacao);
        }

        protected override bool validar(Solicitacao objSolicitacao)
        {
            //base.validar(objSolicitacao);

            if (objSolicitacao == null)
            {
                return false;
            }

            return true;
        }

        private bool getBooConectado()
        {
            if (this.tcpClient == null)
            {
                return false;
            }

            return this.tcpClient.Connected;
        }

        private UsuarioDominio getObjUsuario()
        {
            if (TblUsuarioBase.i == null)
            {
                return null;
            }

            return TblUsuarioBase.i.getObjUsuario(this.strSessaoId);
        }

        private string getStrSecWebSocketAccept()
        {
            if (string.IsNullOrEmpty(this.strSecWebSocketKey))
            {
                return null;
            }

            string strResultado = (this.strSecWebSocketKey + "258EAFA5-E914-47DA-95CA-C5AB0DC85B11");

            return Convert.ToBase64String(SHA1.Create().ComputeHash(Encoding.UTF8.GetBytes(strResultado)));
        }

        private void processarMensagem(Solicitacao objSolicitacao)
        {
            if (!this.booHandshake)
            {
                this.processarMensagemHandshake(objSolicitacao);
                return;
            }

            if (objSolicitacao.arrBteMsgCliente == null)
            {
                return;
            }

            if (objSolicitacao.arrBteMsgCliente.Length < 1)
            {
                return;
            }

            Frame fme = new Frame(objSolicitacao.arrBteMsgCliente);

            fme.processarDadosIn();

            switch (fme.enmTipo)
            {
                case Frame.EnmTipo.TEXT:
                    this.processarMensagemText(fme);
                    return;

                case Frame.EnmTipo.CLOSE:
                    this.processarMensagemClose();
                    return;
            }
        }

        private void processarMensagemClose()
        {
            this.onMensagemClose();

            if (!this.tcpClient.Connected)
            {
                return;
            }

            this.tcpClient.Close();
            this.tcpClient.Dispose();
            this.parar();
        }

        private void processarMensagemHandshake(Solicitacao objSolicitacao)
        {
            if (string.IsNullOrEmpty(objSolicitacao.strSessaoId))
            {
                return;
            }

            if (!"websocket".Equals(objSolicitacao.getStrHeaderValor("Upgrade")))
            {
                return;
            }

            this.strSecWebSocketKey = objSolicitacao.getStrHeaderValor("Sec-WebSocket-Key");

            if (string.IsNullOrEmpty(this.strSecWebSocketKey))
            {
                return;
            }

            this.strSessaoId = objSolicitacao.strSessaoId;

            Resposta objResposta = new Resposta(objSolicitacao);

            objResposta.intStatus = Resposta.INT_STATUS_CODE_101_SWITCHING_PROTOCOLS;

            objResposta.addHeader("Sec-WebSocket-Accept", this.strSecWebSocketAccept);

            this.responder(objResposta);

            this.booHandshake = true;

            this.onMensagemConnect(objSolicitacao);
        }

        private void processarMensagemText(Frame fme)
        {
            if (fme == null)
            {
                return;
            }

            if (string.IsNullOrEmpty(fme.strMensagem))
            {
                return;
            }

            this.processarOnMensagem(fme.strMensagem);
        }

        private void processarOnMensagem(string strMensagem)
        {
            if (this.srv == null)
            {
                return;
            }

            if (!(this.srv is ServerWs))
            {
                return;
            }

            (this.srv as ServerWs).processarOnMensagemLocal(this, strMensagem);
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}