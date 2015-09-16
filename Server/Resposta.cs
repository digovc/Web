using System;
using System.Text;

namespace NetZ.Web.Server
{
    /// <summary>
    /// Classe que será utilizada para responder uma solicitação enviada por um cliente por uma
    /// conexão HTTP. Esta classe contém métodos e propriedades relevantes para construção da resposta.
    /// </summary>
    public class Resposta
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private byte[] _arrBteResposta;
        private DateTime _dttUltimaModificacao = DateTime.Now;
        private int _intStatus;
        private Solicitacao _objSolicitacao;
        private string _strConteudo;

        /// <summary>
        /// Data em que o conteúdo desta mensagem foi modificada pela última vez.
        /// <para>
        /// A indicação desta propriedade é importante pois ela será comparada com a data da versão
        /// deste conteúdo no navegador, sendo que se este recurso não tiver sido alterado ele não
        /// será enviado ao cliente, fazendo com que o mesmo utilize a versão que ele tem em cache,
        /// agilizando assim o processo e não consumindo recursos de rede e processamento.
        /// </para>
        /// </summary>
        public DateTime dttUltimaModificacao
        {
            get
            {
                return _dttUltimaModificacao;
            }

            set
            {
                _dttUltimaModificacao = value;
            }
        }

        internal byte[] arrBteResposta
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_arrBteResposta != null)
                    {
                        return _arrBteResposta;
                    }

                    _arrBteResposta = this.getArrBteResposta();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _arrBteResposta;
            }
        }

        private int intStatus
        {
            get
            {
                return _intStatus;
            }

            set
            {
                _intStatus = value;
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

        private string strConteudo
        {
            get
            {
                return _strConteudo;
            }

            set
            {
                _strConteudo = value;
            }
        }

        #endregion Atributos

        #region Construtores

        public Resposta(Solicitacao objSolicitacao)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.objSolicitacao = objSolicitacao;
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

        /// <summary>
        /// Adiciona código HTML para a resposta que será encaminhada para o cliente quando o
        /// processamento da solicitação for finalizada.
        /// </summary>
        /// <param name="strHtml">Código HTML que deve ser enviada para o cliente.</param>
        public void addHtml(string strHtml)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (string.IsNullOrEmpty(strHtml))
                {
                    return;
                }

                if (string.IsNullOrEmpty(this.strConteudo))
                {
                    this.strConteudo = string.Empty;
                }

                this.strConteudo += strHtml;
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

        private byte[] getArrBteResposta()
        {
            #region Variáveis

            string strResposta;

            #endregion Variáveis

            #region Ações

            try
            {
                strResposta = string.Empty;

                strResposta += this.getStrHeader();

                if (!200.Equals(this.intStatus))
                {
                    return Encoding.UTF8.GetBytes(strResposta);
                }

                strResposta += Environment.NewLine;
                strResposta += Environment.NewLine;
                strResposta += this.strConteudo;

                return Encoding.UTF8.GetBytes(strResposta);
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

        private string getStrHeader()
        {
            #region Variáveis

            string strHeader;

            #endregion Variáveis

            #region Ações

            try
            {
                strHeader = string.Empty;

                strHeader += this.getStrHeaderStatus();
                strHeader += Environment.NewLine;
                strHeader += this.getStrHeaderData("Date", DateTime.Now);
                strHeader += Environment.NewLine;
                strHeader += this.getStrServer();
                strHeader += Environment.NewLine;
                strHeader += this.getStrHeaderData("Last-Modified", this.dttUltimaModificacao);
                strHeader += Environment.NewLine;
                strHeader += "Connection: keep-alive";
                strHeader += Environment.NewLine;
                strHeader += this.getStrHeaderContentLength();

                return strHeader;
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

        private string getStrHeaderContentLength()
        {
            #region Variáveis

            string strResultado;

            #endregion Variáveis

            #region Ações

            try
            {
                if (string.IsNullOrEmpty(this.strConteudo))
                {
                    return null;
                }

                strResultado = "Content-Length: _content_length";
                strResultado = strResultado.Replace("_content_length", this.strConteudo.Length.ToString());

                return strResultado;
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

        private string getStrHeaderData(string strFieldNome, DateTime dtt)
        {
            #region Variáveis

            string strResultado;

            #endregion Variáveis

            #region Ações

            try
            {
                if (string.IsNullOrEmpty(strFieldNome))
                {
                    strFieldNome = "Date";
                }

                strResultado = "_str_date_nome: _date_valor";

                strResultado = strResultado.Replace("_str_date_nome", strFieldNome);
                strResultado = strResultado.Replace("_date_valor", dtt.ToString("ddd,' 'dd' 'MMM' 'yyyy' 'HH':'mm':'ss' 'K"));
                strResultado = strResultado.Replace("_date_valor", dtt.ToUniversalTime().ToString("r"));

                return strResultado;
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

        private string getStrHeaderStatus()
        {
            #region Variáveis

            string strResultado;

            #endregion Variáveis

            #region Ações

            try
            {
                strResultado = "HTTP/1.1 _status_code";

                if (this.dttUltimaModificacao <= this.objSolicitacao.dttUltimaModificacao)
                {
                    this.intStatus = 304;
                    return strResultado.Replace("_status_code", "304 Not Modified");
                }

                this.intStatus = 200;
                return strResultado.Replace("_status_code", "200 OK");
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

        private string getStrServer()
        {
            #region Variáveis

            string strResultado;

            #endregion Variáveis

            #region Ações

            try
            {
                strResultado = "Server: _server_nome";
                strResultado = strResultado.Replace("_server_nome", AppWeb.i.strNomeExibicao);

                return strResultado;
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