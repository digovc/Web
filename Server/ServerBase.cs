using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace NetZ.Web.Server
{
    public abstract class ServerBase : Servico
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

        private TcpListener tcpListener
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_tcpListener != null)
                    {
                        return _tcpListener;
                    }

                    _tcpListener = new TcpListener(IPAddress.Any, this.getIntPort());
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

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
        internal abstract Resposta responder(Solicitacao objSolicitacao);

        protected abstract int getIntPort();

        protected override void inicializar()
        {
            base.inicializar();

            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.tcpListener.Start();
                this.enmStatus = EnmStatus.LIGADO;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion Ações
        }

        protected override void servico()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                while (!this.booParar)
                {
                    this.loop();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion Ações
        }

        private void addCliente(TcpClient tcpClient)
        {
            #region Variáveis

            Cliente objCliente;

            #endregion Variáveis

            #region Ações

            try
            {
                if (tcpClient == null)
                {
                    return;
                }

                tcpClient.NoDelay = true;

                objCliente = new Cliente(tcpClient, this);

                objCliente.iniciar();

                Thread.Sleep(1);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion Ações
        }

        private void loop()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.verificarAddCliente();
                Thread.Sleep(10);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion Ações
        }

        private void verificarAddCliente()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (!this.tcpListener.Pending())
                {
                    return;
                }

                this.addCliente(this.tcpListener.AcceptTcpClient());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion Ações
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}