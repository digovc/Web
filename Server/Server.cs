using System;
using System.Net.Sockets;

namespace NetZ.Web.Server
{
    public class Server : Servico
    {
        #region CONSTANTES

        public enum EnmStatus
        {
            LIGADO,
            PARADO,
        }

        #endregion CONSTANTES

        #region ATRIBUTOS

        private int _intPorta = 80;

        private TcpListener _tcpListener;

        private int intPorta
        {
            get
            {
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
                return _tcpListener;
            }

            set
            {
                _tcpListener = value;
            }
        }


        private EnmStatus _enmStatus = EnmStatus.PARADO;
        private EnmStatus enmStatus
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


        private Clientes _lstObjCliente;
        private Clientes lstObjCliente
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

                    _lstObjCliente = new Clientes();
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

        #endregion ATRIBUTOS

        #region CONSTRUTORES

        #endregion CONSTRUTORES

        #region MÉTODOS

        protected override void inicializar()
        {
            base.inicializar();


            #region Variáveis
            #endregion Variáveis

            #region Ações
            try
            {
                this.enmStatus = EnmStatus.LIGADO;
            }
            catch (Exception e)
            {
                throw e;
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
                while (this.booParar)
                {
                    this.loop();
                }
            }
            catch (Exception e)
            {
                throw e;
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
            catch (Exception e)
            {
                throw e;
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
                if (this.tcpListener.Pending())
                {
                    return;
                }

                this.addCliente(this.tcpListener.AcceptTcpClient());
            }
            catch (Exception e)
            {
                throw e;
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
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
            }
            #endregion Ações
        }

        #endregion MÉTODOS

        #region EVENTOS

        #endregion EVENTOS
    }
}