using System;
using System.Net.Sockets;
using System.Threading;

namespace NetZ.Web.Server
{
    public class Cliente : Servico
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
                if (_srv == value)
                {
                    return;
                }

                _srv = value;

                this.atualizarSrv();
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

        internal Cliente(TcpClient tcpClient, ServerBase srv) : base("Cliente")
        {
            this.srv = srv;
            this.tcpClient = tcpClient;
        }

        #endregion Construtores

        #region Métodos

        protected virtual void atualizarSrv()
        {
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

            if (!this.tcpClient.GetStream().CanWrite)
            {
                return;
            }

            this.tcpClient.GetStream().Write(arrBteData, 0, arrBteData.Length);
        }

        protected virtual void responder(Solicitacao objSolicitacao)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

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

                if (Resposta.INT_STATUS_CODE_302_FOUND.Equals(objResposta.intStatus))
                {
                    this.tcpClient.Close();
                }
            }
            catch (Exception ex)
            {
                // TODO: Enviar os eventuais erros para o cliente.
                throw ex;
            }
            finally
            {
            }

            #endregion Ações
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
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
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
                        Thread.Sleep(1); // TODO: Parar esse processo depois de um tempo excessivo.
                        continue;
                    }

                    this.responder(objSolicitacao);
                }

                this.tcpClient.Close();
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

        protected virtual bool validar(Solicitacao objSolicitacao)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (objSolicitacao == null)
                {
                    return false;
                }

                if (Solicitacao.EnmMetodo.DESCONHECIDO.Equals(objSolicitacao.enmMetodo))
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

        private Solicitacao carregarSolicitacao()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (this.tcpClient == null)
                {
                    return null;
                }

                if (!this.tcpClient.Connected)
                {
                    return null;
                }

                if (this.tcpClient.GetStream() == null)
                {
                    return null;
                }

                if (!(this.tcpClient.GetStream().DataAvailable))
                {
                    return null;
                }

                this.dttUltimaMensagemRecebida = DateTime.Now;

                return new Solicitacao(this.tcpClient.GetStream());
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

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}