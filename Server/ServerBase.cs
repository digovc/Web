using DigoFramework.Servico;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace NetZ.Web.Server
{
    public abstract class ServerBase : ServicoBase
    {
        #region Constantes

        /// <summary>
        /// Tipo enumerado com todos as condições possíveis para este serviço.
        /// </summary>
        public enum EnmStatus
        {
            LIGADO,
            PARADO,
        }

        #endregion Constantes

        #region Atributos

        private EnmStatus _enmStatus = EnmStatus.PARADO;
        private long _intClienteRespondido;
        private int _intPorta;
        private TcpListener _tcpListener;

        /// <summary>
        /// Indica o status atual do servidor.
        /// </summary>
        public EnmStatus enmStatus
        {
            get
            {
                return _enmStatus;
            }

            set
            {
                _enmStatus = value;
            }
        }

        /// <summary>
        /// Número de clientes que foi respondido. Este valor é contabilizado apenas quando o
        /// processo estiver totalmente concluído e a conxão com o cliente fechada.
        /// </summary>
        public long intClienteRespondido
        {
            get
            {
                return _intClienteRespondido;
            }

            private set
            {
                _intClienteRespondido = value;
            }
        }

        /// <summary>
        /// Porta que este serviço TCP irá escutar.
        /// </summary>
        public int intPorta
        {
            get
            {
                if (_intPorta > 0)
                {
                    return _intPorta;
                }

                _intPorta = this.getIntPorta();

                return _intPorta;
            }

            set
            {
                _intPorta = value;
            }
        }

        private TcpListener tcpListener
        {
            get
            {
                if (_tcpListener != null)
                {
                    return _tcpListener;
                }

                _tcpListener = new TcpListener(IPAddress.Any, this.intPorta);

                return _tcpListener;
            }
        }

        #endregion Atributos

        #region Construtores

        protected ServerBase(string strNome) : base(strNome)
        {
        }

        #endregion Construtores

        #region Métodos

        /// <summary>
        /// Este método é disparado a cada nova solicitação do cliente recebida.
        /// </summary>
        /// <param name="objSolicitacao">
        /// Objeto que encapsula a solicitação que foi enviada pelo usuário.
        /// </param>
        /// <returns>Retorna o objeto contendo a responsta para o cliente.</returns>
        public abstract Resposta responder(Solicitacao objSolicitacao);

        protected abstract int getIntPorta();

        protected virtual Cliente getObjCliente(TcpClient tcpClient)
        {
            return new Cliente(tcpClient, this);
        }

        protected override void inicializar()
        {
            base.inicializar();

            this.tcpListener.Start();

            this.enmStatus = EnmStatus.LIGADO;
        }

        protected override void servico()
        {
            while (!this.booParar)
            {
                this.loop();

                Thread.Sleep(1);
            }
        }

        private void addCliente(TcpClient tcpClient)
        {
            if (tcpClient == null)
            {
                return;
            }

            tcpClient.NoDelay = true;

            Cliente objCliente = this.getObjCliente(tcpClient);

            objCliente.iniciar();

            Thread.Sleep(1);
        }

        private void loop()
        {
            this.validarAddCliente();
        }

        private void validarAddCliente()
        {
            if (!this.tcpListener.Pending())
            {
                return;
            }

            this.addCliente(this.tcpListener.AcceptTcpClient());
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}