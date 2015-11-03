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

        private DateTime _dttUltimaMensagemRecebida;
        private Solicitacao _objSolicitacao;
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

        internal Cliente(TcpClient tcpClient) : base("Cliente")
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

                //this.dttUltimaMensagemRecebida = DateTime.Now;

                // Analisar a possibilidade de responder mais de uma solicitação por conexão.
                //while (this.tcpClient.Connected && (this.dttUltimaMensagemRecebida > DateTime.Now.AddSeconds(-10)))
                //{
                //this.processarSolicitacao();
                //this.responder();
                //}

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

                this.dttUltimaMensagemRecebida = DateTime.Now;
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
                Thread.Sleep(250);

                this.objSolicitacao = null;

                while (true)
                {
                    this.carregarSolicitacao();

                    if (this.objSolicitacao != null)
                    {
                        return;
                    }

                    if (!this.tcpClient.Connected)
                    {
                        return;
                    }
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

                if (!this.tcpClient.Connected)
                {
                    return;
                }

                this.objSolicitacao.processar();

                if (!this.validarSolicitacao())
                {
                    return;
                }

                if ((!string.IsNullOrEmpty(this.objSolicitacao.strPagina)) && (this.objSolicitacao.strPagina.StartsWith("/res")))
                {
                    objResposta = Server.i.responderArquivoEstatico(this.objSolicitacao);
                }
                else
                {
                    objResposta = AppWeb.i.responder(this.objSolicitacao);
                }

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
                    // TODO: Quando a resposta estiver null enviar uma mensagem de erro no servidor.
                    return;
                }

                if (objResposta.arrBteResposta == null)
                {
                    return;
                }

                if (objResposta.arrBteResposta.Length < 1)
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