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

        private DateTime _dttComunicacaoUltima = DateTime.Now;
        private ServerBase _srv;
        private string _strEndPoint;
        private TcpClient _tcpClient;

        public string strEndPoint
        {
            get
            {
                if (_strEndPoint != null)
                {
                    return _strEndPoint;
                }

                _strEndPoint = ((IPEndPoint)this.tcpClient?.Client.RemoteEndPoint).Address.ToString();

                return _strEndPoint;
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

        /// <summary>
        /// Data e hora em que a última mensagem foi enviada pelo cliente para este servidor.
        /// </summary>
        internal DateTime dttComunicacaoUltima
        {
            get
            {
                return _dttComunicacaoUltima;
            }

            set
            {
                _dttComunicacaoUltima = value;
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

        #endregion Atributos

        #region Construtores

        internal Cliente(TcpClient tcpClient, ServerBase srv) : base(null)
        {
            this.srv = srv;
            this.tcpClient = tcpClient;
        }

        #endregion Construtores

        #region Métodos

        public bool getBooConectado()
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

            if (!this.getBooConectado())
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
            if (!this.getBooConectado())
            {
                return null;
            }

            if (!this.tcpClient.GetStream().DataAvailable)
            {
                return null;
            }

            return new Solicitacao(this);
        }

        private void finalizarTcpClient()
        {
            if (this.tcpClient == null)
            {
                return;
            }

            this.tcpClient.Close();
        }

        private void inicializarStrNome()
        {
            this.strNome = string.Format("{0} ({1})", this.GetType().Name, this.strEndPoint);
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

                this.dttComunicacaoUltima = DateTime.Now;

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

            if ((DateTime.Now - this.dttComunicacaoUltima).TotalSeconds > 45)
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