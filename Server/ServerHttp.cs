using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Reflection;

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
    public class ServerHttp : ServerBase
    {
        #region Constantes

        public const string STR_COOKIE_SESSAO_ID_NOME = "sessao_id";

        #endregion Constantes

        #region Atributos

        private static ServerHttp _i;
        private List<ArquivoEstatico> _lstArqEstatico;

        public static ServerHttp i
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

                    _i = new ServerHttp();
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

        #endregion Atributos

        #region Construtores

        private ServerHttp() : base("Server HTTP")
        {
        }

        #endregion Construtores

        #region Métodos

        internal override Resposta responder(Solicitacao objSolicitacao)
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

                if (objSolicitacao.strPagina.StartsWith("/res"))
                {
                    return this.responderArquivoEstatico(objSolicitacao);
                }

                return AppWeb.i.responder(objSolicitacao);
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

        protected override int getIntPort()
        {
            return ConfigWeb.i.intPorta;
        }

        protected override void inicializar()
        {
            base.inicializar();

            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.criarDiretorio();
                this.inicializarArquivoEstatico();
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

        private void inicializarArquivoEstatico()
        {
            #region Variáveis

            string dir;

            #endregion Variáveis

            #region Ações

            try
            {
                dir = Assembly.GetEntryAssembly().Location;

                if (string.IsNullOrEmpty(dir))
                {
                    return;
                }

                dir = Path.GetDirectoryName(dir);

                if (string.IsNullOrEmpty(dir))
                {
                    return;
                }

                dir = dir + "\\res";

                this.inicializarArquivoEstatico(dir);
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

        private Resposta responderArquivoEstatico(Solicitacao objSolicitacao)
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

                    if (!arq.dirWeb.ToLower().Equals(objSolicitacao.strPagina.ToLower()))
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
            return new Resposta(objSolicitacao) { intStatus = 404 };
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}