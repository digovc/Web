using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

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

        public const string STR_COOKIE_SESSAO_ID_NOME = "sessao_id";

        #endregion Constantes

        #region Atributos

        private static Server _i;
        private EnmStatus _enmStatus = EnmStatus.PARADO;
        private long _lngClienteRespondido;
        private List<ArquivoEstatico> _lstArqEstatico;
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

        private List<ArquivoEstatico> lstArqEstatico
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_lstArqEstatico != null)
                    {
                        return _lstArqEstatico;
                    }

                    _lstArqEstatico = new List<ArquivoEstatico>();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _lstArqEstatico;
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

        internal Resposta responderArquivoEstatico(Solicitacao objSolicitacao)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (objSolicitacao == null)
                {
                    return null;
                }

                if (string.IsNullOrEmpty(objSolicitacao.strPagina))
                {
                    return null;
                }

                foreach (ArquivoEstatico arq in this.lstArqEstatico)
                {
                    if (arq == null)
                    {
                        continue;
                    }

                    if (string.IsNullOrEmpty(arq.dirWeb))
                    {
                        continue;
                    }

                    if (!arq.dirWeb.Equals(objSolicitacao.strPagina))
                    {
                        continue;
                    }

                    return this.responderArquivoEstatico(objSolicitacao, arq);
                }

                return this.responderArquivoEstaticoNaoEncontrado(objSolicitacao);
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

        protected override void inicializar()
        {
            base.inicializar();

            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                ConfigWeb.i.inicializar();
                this.criarDiretorio();
                this.inicializarArquivoEstatico("res");
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

                objCliente = new Cliente(tcpClient);

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

        private void criarDiretorio()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (Directory.Exists("res"))
                {
                    return;
                }

                Directory.CreateDirectory("res");
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

        private void inicializarArquivoEstatico(string dir)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (!Directory.Exists(dir))
                {
                    return;
                }

                foreach (string dir2 in Directory.GetDirectories(dir))
                {
                    if (string.IsNullOrEmpty(dir2))
                    {
                        continue;
                    }

                    this.inicializarArquivoEstatico(dir2);
                }

                foreach (string dirArquivo in Directory.GetFiles(dir))
                {
                    if (string.IsNullOrEmpty(dirArquivo))
                    {
                        continue;
                    }

                    this.inicializarArquivoEstaticoArquivo(dirArquivo);
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

        private void inicializarArquivoEstaticoArquivo(string dirArquivo)
        {
            #region Variáveis

            ArquivoEstatico arq;

            #endregion Variáveis

            #region Ações

            try
            {
                if (string.IsNullOrEmpty(dirArquivo))
                {
                    return;
                }

                if (!File.Exists(dirArquivo))
                {
                    return;
                }

                arq = new ArquivoEstatico();

                arq.dirCompleto = dirArquivo.ToLower();

                this.lstArqEstatico.Add(arq);
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
                Thread.Sleep(2);
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

        private Resposta responderArquivoEstatico(Solicitacao objSolicitacao, ArquivoEstatico arq)
        {
            #region Variáveis

            Resposta objResposta;

            #endregion Variáveis

            #region Ações

            try
            {
                if (objSolicitacao == null)
                {
                    return null;
                }

                if (arq == null)
                {
                    return null;
                }

                if (!File.Exists(arq.dirCompleto))
                {
                    return this.responderArquivoEstaticoNaoEncontrado(objSolicitacao);
                }

                objResposta = new Resposta(objSolicitacao);

                objResposta.addArquivo(arq);

                return objResposta;
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

        private Resposta responderArquivoEstaticoNaoEncontrado(Solicitacao objSolicitacao)
        {
            #region Variáveis

            Resposta objResposta;

            #endregion Variáveis

            #region Ações

            try
            {
                objResposta = new Resposta(objSolicitacao);

                objResposta.intStatus = 404;

                return objResposta;
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