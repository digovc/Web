using DigoFramework.Json;
using NetZ.Web.DataBase.Dominio;
using NetZ.Web.DataBase.Tabela;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;

namespace NetZ.Web.Server.WebSocket
{
    public class ClienteWs : Cliente
    {
        #region Constantes

        private const string STR_METODO_WELCOME = "metodo_welcome";

        #endregion Constantes

        #region Atributos

        private bool _booConectado;
        private bool _booHandshake;
        private UsuarioDominio _objUsuario;
        private ServerWsBase _srvWs;
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

        protected ServerWsBase srvWs
        {
            get
            {
                return _srvWs;
            }

            set
            {
                if (_srvWs == value)
                {
                    return;
                }

                _srvWs = value;

                this.setSrvWs(_srvWs);
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

        private List<byte> _lstBteCache;

        private List<byte> lstBteCache
        {
            get
            {
                return _lstBteCache;
            }
            set
            {
                _lstBteCache = value;
            }
        }

        #endregion Atributos

        #region Construtores

        public ClienteWs(TcpClient tcpClient, ServerWsBase srvWs) : base(tcpClient, srvWs)
        {
            this.srvWs = srvWs;
        }

        #endregion Construtores

        #region Métodos

        /// <summary>
        /// Envia uma mensagem contendo a estrutura do interlocutor em JSON para este cliente.
        /// </summary>
        /// <param name="objInterlocutor">
        /// Interlocutor que será serializado e enviado para este cliente.
        /// </param>
        public void enviar(Interlocutor objInterlocutor)
        {
            if (objInterlocutor == null)
            {
                return;
            }

            this.enviar(Json.i.toJson(objInterlocutor));
        }

        protected override void finalizar()
        {
            base.finalizar();

            this.finalizarSrv();
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

        protected virtual bool processarMensagem(byte[] arrBteData)
        {
            return false;
        }

        protected virtual bool processarMensagem(Interlocutor objInterlocutor)
        {
            switch (objInterlocutor.strMetodo)
            {
                case STR_METODO_WELCOME:
                    this.processarMensagemWelcome(objInterlocutor);
                    return true;
            }

            return false;
        }

        protected virtual bool processarMensagem(string strMensagem)
        {
            return false;
        }

        protected override void responder(Solicitacao objSolicitacao)
        {
            // base.responder();

            if (!this.validar(objSolicitacao))
            {
                return;
            }

            this.processarMensagem(objSolicitacao);
        }

        protected override bool validar(Solicitacao objSolicitacao)
        {
            // base.validar(objSolicitacao);

            if (objSolicitacao == null)
            {
                return false;
            }

            return true;
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

        private void finalizarSrv()
        {
            if (this.srvWs == null)
            {
                return;
            }

            this.srvWs.removerObjClienteWs(this);
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

            List<byte> lstBteData = new List<byte>();

            if (this.lstBteCache != null && this.lstBteCache.Count > 0)
            {
                lstBteData.AddRange(this.lstBteCache);
            }

            lstBteData.AddRange(objSolicitacao.arrBteMsgCliente);

            Frame fme = new Frame(lstBteData.ToArray());

            this.lstBteCache = new List<byte>(fme.processarDadosIn());

            switch (fme.enmTipo)
            {
                case Frame.EnmTipo.BINARY:
                    this.processarMensagemByte(fme);
                    return;

                case Frame.EnmTipo.TEXT:
                    this.processarMensagemText(fme);
                    return;

                case Frame.EnmTipo.CLOSE:
                    this.processarMensagemClose();
                    return;
            }
        }

        private void processarMensagemByte(Frame fme)
        {
            if (fme.arrBteMensagem == null)
            {
                return;
            }

            if (fme.arrBteMensagem.Length < 1)
            {
                return;
            }

            this.processarMensagem(fme.arrBteMensagem);
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
            if (string.IsNullOrEmpty(fme.strMensagem))
            {
                return;
            }

            Interlocutor objInterlocutor = null;

            try
            {
                objInterlocutor = Json.i.fromJson<Interlocutor>(fme.strMensagem);
            }
            catch (Exception)
            {
                this.processarMensagem(fme.strMensagem);
            }

            if (objInterlocutor == null)
            {
                return;
            }

            if (string.IsNullOrEmpty(objInterlocutor.strMetodo))
            {
                return;
            }

            this.processarMensagem(objInterlocutor);
        }

        protected virtual void processarMensagemWelcome(Interlocutor objInterlocutor)
        {
            objInterlocutor.strMetodo = STR_METODO_WELCOME;

            this.enviar(objInterlocutor);
        }

        private void setSrvWs(ServerWsBase srvWs)
        {
            if (srvWs == null)
            {
                return;
            }

            srvWs.addObjClienteWs(this);
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}