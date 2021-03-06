﻿using DigoFramework;
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

        private const string STR_METODO_ERRO = "STR_METODO_ERRO";
        private const string STR_METODO_PING = "ping";
        private const string STR_METODO_PONG = "pong";
        private const string STR_METODO_WELCOME = "STR_METODO_WELCOME";

        #endregion Constantes

        #region Atributos

        private bool _booHandshake;
        private List<byte> _lstBteCache;
        private UsuarioDominio _objUsuario;
        private SrvWsBase _srvWs;
        private string _strSecWebSocketAccept;
        private string _strSecWebSocketKey;
        private string _strSessao;

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

        protected SrvWsBase srvWs
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

        protected string strSessao
        {
            get
            {
                return _strSessao;
            }

            private set
            {
                _strSessao = value;
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

        public ClienteWs(TcpClient tcpClient, SrvWsBase srvWs) : base(tcpClient, srvWs)
        {
            this.srvWs = srvWs;
        }

        #endregion Construtores

        #region Métodos

        /// <summary>
        /// Atalho para <see cref="enviar(Interlocutor)"/>
        /// </summary>
        /// <param name="strMetodo">Método que está sendo executado.</param>
        /// <param name="objData">Data que será enviada junto do JSON para o cliente.</param>
        public void enviar(string strMetodo, object objData = null)
        {
            if (string.IsNullOrEmpty(strMetodo))
            {
                return;
            }

            this.enviar(new Interlocutor(strMetodo, objData));
        }

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
                case STR_METODO_PING:
                    this.processarMensagemPing();
                    return true;

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

        protected virtual void processarMensagemWelcome(Interlocutor objInterlocutor)
        {
            objInterlocutor.strMetodo = STR_METODO_WELCOME;

            this.enviar(objInterlocutor);

            this.srvWs.processarMensagemWelcome(this, objInterlocutor);
        }

        protected override void responder(Solicitacao objSolicitacao)
        {
            // base.responder();

            try
            {
                this.processarMensagem(objSolicitacao);
            }
            catch (Exception ex)
            {
                this.responderErro(objSolicitacao, ex);
            }
        }

        protected override void responderErro(Solicitacao objSolicitacao, Exception ex)
        {
            // base.responderErro(objSolicitacao, ex);

            if (ex == null)
            {
                return;
            }

            string strStack = ex.StackTrace;

            if (!string.IsNullOrEmpty(strStack))
            {
                strStack = strStack.Replace(Environment.NewLine, "<br/>");
            }

            this.enviar(new Interlocutor(STR_METODO_ERRO, string.Format("{0}<br/><br/><br/><br/><br/>{1}", ex.Message, strStack)));

            Log.i.erro(ex);
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

        private UsuarioDominio getObjUsuario()
        {
            if (TblUsuarioBase.i == null)
            {
                return null;
            }

            return TblUsuarioBase.i.getObjUsuario(this.strSessao);
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

            var lstBteData = new List<byte>();

            if (this.lstBteCache != null && this.lstBteCache.Count > 0)
            {
                lstBteData.AddRange(this.lstBteCache);
            }

            lstBteData.AddRange(objSolicitacao.arrBteMsgCliente);

            this.processarMensagem(lstBteData);
            this.processarMensagem(this.lstBteCache);
        }

        private void processarMensagem(List<byte> lstBteData)
        {
            if (lstBteData == null)
            {
                return;
            }

            if (lstBteData.Count < 1)
            {
                return;
            }

            var fme = new Frame(lstBteData.ToArray());

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

            this.strSessao = objSolicitacao.strSessao;

            if (string.IsNullOrEmpty(this.strSessao))
            {
                this.strSessao = Utils.getStrToken(32, DateTime.Now, this.intObjetoId);
            }

            Resposta objResposta = new Resposta(objSolicitacao);

            objResposta.intStatus = Resposta.INT_STATUS_CODE_101_SWITCHING_PROTOCOLS;

            objResposta.addHeader("Sec-WebSocket-Accept", this.strSecWebSocketAccept);

            this.responder(objResposta);

            this.booHandshake = true;

            this.onMensagemConnect(objSolicitacao);
        }

        private void processarMensagemPing()
        {
            this.enviar(new Interlocutor(STR_METODO_PONG));
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

            if (this.srvWs.processarMensagem(this, objInterlocutor))
            {
                return;
            }

            this.processarMensagem(objInterlocutor);
        }

        private void setSrvWs(SrvWsBase srvWs)
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