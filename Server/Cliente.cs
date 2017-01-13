using DigoFramework.Service;
using NetZ.Web.Html.Pagina;
using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace NetZ.Web.Server
{
    public class Cliente : ServiceBase
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private DateTime _dttUltimaMensagemRecebida;
        private ServerBase _srv;
        private TcpClient _tcpClient;

        /// <summary>
        /// Data e hora em que a última mensagem foi enviada pelo cliente para este servidor.
        /// </summary>
        internal DateTime dttUltimaMensagemRecebida
        {
            get
            {
                return _dttUltimaMensagemRecebida;
            }

            set
            {
                _dttUltimaMensagemRecebida = value;
            }
        }

        protected ServerBase srv
        {
            get
            {
                return _srv;
            }

            set
            {
                _srv = value;
            }
        }

        protected TcpClient tcpClient
        {
            get
            {
                return _tcpClient;
            }

            set
            {
                _tcpClient = value;
            }
        }

        #endregion Atributos

        #region Construtores

        internal Cliente(TcpClient tcpClient, ServerBase srv) : base(null)
        {
            this.srv = srv;
            this.tcpClient = tcpClient;
        }

        #endregion Construtores

        #region Métodos

        protected void enviar(byte[] arrBteData)
        {
            if (arrBteData == null)
            {
                return;
            }

            if (arrBteData.Length < 1)
            {
                return;
            }

            if (!this.tcpClient.Connected)
            {
                return;
            }

            if (!this.tcpClient.GetStream().CanWrite)
            {
                return;
            }

            this.tcpClient.GetStream().Write(arrBteData, 0, arrBteData.Length);
        }

        protected override void finalizar()
        {
            base.finalizar();

            this.finalizarTcpClient();
        }

        protected override void inicializar()
        {
            base.inicializar();

            this.inicializarStrNome();
        }

        protected virtual void responder(Solicitacao objSolicitacao)
        {
            try
            {
                if (!this.validar(objSolicitacao))
                {
                    return;
                }

                Resposta objResposta = this.srv.responder(objSolicitacao);

                if (!this.validar(objResposta))
                {
                    return;
                }

                this.responder(objResposta);
            }
            catch (Exception ex)
            {
                this.responderErro(objSolicitacao, ex);
            }
        }

        protected void responder(Resposta objResposta)
        {
            if (objResposta == null)
            {
                // TODO: Quando a resposta estiver null enviar uma mensagem de erro no servidor.
                return;
            }

            this.enviar(objResposta.arrBteResposta);
        }

        protected override void servico()
        {
            if (this.tcpClient == null)
            {
                return;
            }

            Solicitacao objSolicitacao;

            while (this.tcpClient.Connected)
            {
                objSolicitacao = this.carregarSolicitacao();

                if (objSolicitacao == null)
                {
                    Thread.Sleep(10); // TODO: Parar esse processo depois de um tempo excessivo.
                    continue;
                }

                this.responder(objSolicitacao);
            }
        }

        protected virtual bool validar(Solicitacao objSolicitacao)
        {
            if (objSolicitacao == null)
            {
                return false;
            }

            if (Solicitacao.EnmMetodo.DESCONHECIDO.Equals(objSolicitacao.enmMetodo))
            {
                return false;
            }

            return true;
        }

        private Solicitacao carregarSolicitacao()
        {
            if (this.tcpClient == null)
            {
                return null;
            }

            if (!this.tcpClient.Connected)
            {
                return null;
            }

            if (!this.tcpClient.GetStream().DataAvailable)
            {
                return null;
            }

            if (!this.tcpClient.GetStream().CanRead)
            {
                return null;
            }

            this.dttUltimaMensagemRecebida = DateTime.Now;

            return new Solicitacao(this.tcpClient.GetStream());
        }

        private void finalizarTcpClient()
        {
            if (this.tcpClient == null)
            {
                return;
            }

            this.tcpClient.Close();
            this.tcpClient.Dispose();
        }

        private void inicializarStrNome()
        {
            this.strNome = string.Format("{0} ({1})", this.GetType().Name, ((IPEndPoint)tcpClient.Client.RemoteEndPoint).Address.ToString());
        }

        private void responderErro(Solicitacao objSolicitacao, Exception ex)
        {
            Resposta objResposta = new Resposta(objSolicitacao);

            objResposta.addHtml(new PagError(ex));
            objResposta.intStatus = Resposta.INT_STATUS_CODE_500_INTERNAL_ERROR;

            this.responder(objResposta);
        }

        private bool validar(Resposta objResposta)
        {
            if (objResposta == null)
            {
                return false;
            }

            return true;
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}