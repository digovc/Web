using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;

namespace NetZ.Web.Server
{
    /// <summary>
    /// Classe principal do servidor WEB e gerencia todas as conexões com os clientes, assim como
    /// processa e responde as solicitações destes.
    /// <para>
    /// A aplicação que fazer uso desta biblioteca não precisa interagir diretamente com esta
    /// classe, implementando sua lógica a partir da class <see cref="AppWeb"/> e seu método <see cref="AppWeb.responder(Solicitacao)"/>.
    /// </para>
    /// </summary>
    public class Server : Servico
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

        private static Server _i;
        private EnmStatus _enmStatus = EnmStatus.PARADO;
        private long _lngClienteRespondido;
        private List<Cliente> _lstObjCliente;
        private TcpListener _tcpListener;

        public static Server i
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_i != null)
                    {
                        return _i;
                    }

                    _i = new Server();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _i;
            }
        }

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
        public long lngClienteRespondido
        {
            get
            {
                return _lngClienteRespondido;
            }

            set
            {
                _lngClienteRespondido = value;
            }
        }

        private List<Cliente> lstObjCliente
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_lstObjCliente != null)
                    {
                        return _lstObjCliente;
                    }

                    _lstObjCliente = new List<Cliente>();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _lstObjCliente;
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

                    _tcpListener = new TcpListener(IPAddress.Any, ConfigWeb.i.intPorta);
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

        private Server() : base("WEB Server")
        {
        }

        #endregion Construtores

        #region Métodos

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

                objCliente = new Cliente(tcpClient);

                this.lstObjCliente.Add(objCliente);

                objCliente.iniciar();
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