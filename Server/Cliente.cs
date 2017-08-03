using DigoFramework;
using DigoFramework.Servico;
using NetZ.Web.Html.Pagina;
using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace NetZ.Web.Server
{
    public class Cliente : ServicoBase
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private bool _booConectado;
        private DateTime _dttUltimaMensagemRecebida = DateTime.Now;
        private ServerBase _srv;
        private TcpClient _tcpClient;

        public bool booConectado
        {
            get
            {
                _booConectado = this.getBooConectado();

                return _booConectado;
            }
        }

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

        public TcpClient tcpClient
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

            if (!this.booConectado)
            {
                return;
            }

            try
            {
                this.tcpClient.GetStream().Write(arrBteData, 0, arrBteData.Length);
            }
            catch (Exception ex)
            {
                new Erro(string.Format("Erro ao tentar enviar dados para o \"{0}\".", this.strNome), ex);
            }
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
                if (!objSolicitacao.validar())
                {
                    return;
                }

                this.responder(this.srv.responder(objSolicitacao));
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
                // TODO: Quando a resposta estiver null enviar uma mensagem 404 para o cliente.
                return;
            }

            this.enviar(objResposta.arrBteResposta);
        }

        protected virtual void responderErro(Solicitacao objSolicitacao, Exception ex)
        {
            if (ex == null)
            {
                return;
            }

            var objResposta = new Resposta(objSolicitacao);

            objResposta.addHtml(new PagError(ex));

            objResposta.intStatus = Resposta.INT_STATUS_CODE_500_INTERNAL_ERROR;

            this.responder(objResposta);

            Log.i.erro(ex);
        }

        protected override void servico()
        {
            if (this.tcpClient == null)
            {
                return;
            }

            this.loop();
        }

        private Solicitacao carregarSolicitacao()
        {
            if (!this.booConectado)
            {
                return null;
            }

            if (!this.tcpClient.GetStream().DataAvailable)
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
        }

        private bool getBooConectado()
        {
            if (this.tcpClient == null)
            {
                return false;
            }

            if (this.tcpClient.GetStream() == null)
            {
                return false;
            }

            if (!this.tcpClient.GetStream().CanRead)
            {
                return false;
            }

            if (!this.tcpClient.GetStream().CanWrite)
            {
                return false;
            }

            return this.tcpClient.Connected;
        }

        private void inicializarStrNome()
        {
            this.strNome = string.Format("{0} ({1})", this.GetType().Name, ((IPEndPoint)tcpClient.Client.RemoteEndPoint).Address.ToString());
        }

        private void loop()
        {
            do
            {
                var objSolicitacao = this.carregarSolicitacao();

                if (objSolicitacao == null)
                {
                    Thread.Sleep(10);
                    continue;
                }

                this.responder(objSolicitacao);
            }
            while (this.validarContinuar());
        }

        private bool validarContinuar()
        {
            if (this.booParar)
            {
                return false;
            }

            if (!this.tcpClient.Connected)
            {
                return false;
            }

            if ((DateTime.Now - this.dttUltimaMensagemRecebida).Seconds > 45)
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