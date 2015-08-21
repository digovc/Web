using System;
using System.Net.Sockets;
using System.Threading;

namespace NetZ.Web.Server
{
    internal class Cliente : Servico
    {
        #region CONSTANTES

        #endregion CONSTANTES

        #region ATRIBUTOS

        private Solicitacao _objSolicitacao;
        private TcpClient _tcpClient;

        private Solicitacao objSolicitacao
        {
            get
            {
                return _objSolicitacao;
            }

            set
            {
                _objSolicitacao = value;
            }
        }

        private TcpClient tcpClient
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

        #endregion ATRIBUTOS

        #region CONSTRUTORES

        internal Cliente(TcpClient tcpClient)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.tcpClient = tcpClient;
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

        #endregion CONSTRUTORES

        #region MÉTODOS

        protected override void servico()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (this.tcpClient == null)
                {
                    return;
                }

                this.processarSolicitacao();
                this.responder();
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

        private void carregarSolicitacao()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (this.tcpClient == null)
                {
                    return;
                }

                if (!this.tcpClient.Connected)
                {
                    return;
                }

                if (!(this.tcpClient.GetStream() == null))
                {
                    return;
                }

                if (!(this.tcpClient.GetStream().DataAvailable))
                {
                    return;
                }

                if (!(this.tcpClient.GetStream().DataAvailable))
                {
                    return;
                }

                this.objSolicitacao = new Solicitacao(this.tcpClient.GetStream());
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

        private void processarSolicitacao()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                for (int i = 0; i < 60; i++)
                {
                    this.carregarSolicitacao();
                    Thread.Sleep(1000);
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

        private void responder()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (!this.validarSolicitacao())
                {
                    return;
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

        private bool validarSolicitacao()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (this.objSolicitacao == null)
                {
                    return false;
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

            return true;
        }

        #endregion MÉTODOS

        #region EVENTOS

        #endregion EVENTOS
    }
}