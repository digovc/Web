using System;
using System.Net.Sockets;
using System.Threading;

namespace NetZ.Web.Server
{
    internal class Cliente : Servico
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

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

        #endregion Atributos

        #region Construtores

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

        #endregion Construtores

        #region Métodos

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
                this.tcpClient.Close();

                Server.i.lngClienteRespondido++;
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

                if (this.tcpClient.GetStream() == null)
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

                    if (this.objSolicitacao != null)
                    {
                        return;
                    }

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

            Resposta objResposta;

            #endregion Variáveis

            #region Ações

            try
            {
                if (this.objSolicitacao == null)
                {
                    return;
                }

                this.objSolicitacao.processar();

                if (!this.validarSolicitacao())
                {
                    return;
                }

                objResposta = AppWeb.i.responder(this.objSolicitacao);

                if (!this.validar(objResposta))
                {
                    return;
                }

                this.responder(objResposta);
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

        private void responder(Resposta objResposta)
        {
            #region Variáveis
            #endregion Variáveis

            #region Ações
            try
            {
                if (objResposta == null)
                {
                    return;
                }

                if (!this.tcpClient.GetStream().CanWrite)
                {
                    return;
                }

                this.tcpClient.GetStream().Write(objResposta.arrBteResposta, 0, objResposta.arrBteResposta.Length);

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

        private bool validar(Resposta objResposta)
        {

            #region Variáveis
            #endregion Variáveis

            #region Ações
            try
            {
                if (objResposta == null)
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

                if (Solicitacao.EnmMetodo.DESCONHECIDO.Equals(this.objSolicitacao))
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

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}