using System;

namespace NetZ.Web.Server
{
    /// <summary>
    /// Representa os "fields" (campos) que podem contem em um cabeçalho vindo na solicitação do cliente.
    /// </summary>
    internal class Field
    {
        #region Constantes

        /// <summary>
        /// Tipo enumerado com todos os tipos que um field (campo) de um request ou response pode conter.
        /// </summary>
        public enum EnmTipo
        {
            ACCEPT,
            ACCEPT_CHARSET,
            ACCEPT_DATETIME,
            ACCEPT_ENCODING,
            ACCEPT_LANGUAGE,
            AUTHORIZATION,
            CACHE_CONTROL,
            CONNECTION,
            CONTENT_LENGTH,
            CONTENT_MD5,
            CONTENT_TYPE,
            COOKIE,
            DATE,
            DESCONHECIDO,
            EXPECT,
            FROM,
            HOST,
            IF_MATCH,
            IF_MODIFIED_SINCE,
            IF_NONE_MATCH,
            IF_RANGE,
            IF_UNMODIFIED_SINCE,
            MAX_FORWARDS,
            NONE,
            ORIGIN,
            PRAGMA,
            PROXY_AUTHORIZATION,
            RANGE,
            REFERER,
            TE,
            UPGRADE,
            USER_AGENT,
            VIA,
            WARNING,
        }

        #endregion Constantes

        #region Atributos

        private decimal _decValor;
        private DateTime _dttValor;
        private EnmTipo _enmTipo = EnmTipo.NONE;
        private int _intValor;
        private Solicitacao _objSolicitacao;
        private string _strHeaderLinha;
        private string _strValor;

        /// <summary>
        /// Valor deste "field" (campo).
        /// </summary>
        public decimal decValor
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    _decValor = Convert.ToDecimal(this.strValor);
                }
                catch
                {
                    return 0;
                }
                finally
                {
                }

                #endregion Ações

                return _decValor;
            }
        }

        /// <summary>
        /// Valor deste "field" (campo).
        /// </summary>
        public DateTime dttValor
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    _dttValor = Convert.ToDateTime(this.strValor);
                }
                catch (Exception)
                {                    
                    return DateTime.MinValue;
                }
                finally
                {
                }

                #endregion Ações

                return _dttValor;
            }
        }

        /// <summary>
        /// Indica o tipo deste "field" (campo).
        /// </summary>
        public EnmTipo enmTipo
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (!EnmTipo.NONE.Equals(_enmTipo))
                    {
                        return _enmTipo;
                    }

                    _enmTipo = this.getEnmTipo();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _enmTipo;
            }
        }

        /// <summary>
        /// Valor deste "field" (campo).
        /// </summary>
        public int intValor
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    _intValor = (int)this.decValor;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _intValor;
            }
        }

        /// <summary>
        /// Valor deste "field" (campo).
        /// </summary>
        public string strValor
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_strValor != null)
                    {
                        return _strValor;
                    }

                    _strValor = this.getStrValor();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _strValor;
            }
        }

        internal Solicitacao objSolicitacao
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

        internal string strHeaderLinha
        {
            get
            {
                return _strHeaderLinha;
            }

            set
            {
                _strHeaderLinha = value;
            }
        }

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        private EnmTipo getEnmTipo()
        {
            #region Variáveis

            string[] arrStr;
            string strTipo;

            #endregion Variáveis

            #region Ações

            try
            {
                if (string.IsNullOrEmpty(this.strHeaderLinha))
                {
                    return EnmTipo.DESCONHECIDO;
                }

                arrStr = this.strHeaderLinha.Split(":".ToCharArray());

                if (arrStr == null)
                {
                    return EnmTipo.DESCONHECIDO;
                }

                if (arrStr.Length < 2)
                {
                    return EnmTipo.DESCONHECIDO;
                }

                strTipo = arrStr[0];

                if (string.IsNullOrEmpty(strTipo))
                {
                    return EnmTipo.DESCONHECIDO;
                }

                switch (strTipo.ToLower())
                {
                    case "accept":
                        return EnmTipo.ACCEPT;

                    case "accept-charset":
                        return EnmTipo.ACCEPT_CHARSET;

                    case "accept-datetime":
                        return EnmTipo.ACCEPT_DATETIME;

                    case "accept-encoding":
                        return EnmTipo.ACCEPT_ENCODING;

                    case "accept-language":
                        return EnmTipo.ACCEPT_LANGUAGE;

                    case "authorization":
                        return EnmTipo.AUTHORIZATION;

                    case "cache-control":
                        return EnmTipo.CACHE_CONTROL;

                    case "connection":
                        return EnmTipo.CONNECTION;

                    case "content-length":
                        return EnmTipo.CONTENT_LENGTH;

                    case "content-md5":
                        return EnmTipo.CONTENT_MD5;

                    case "content-type":
                        return EnmTipo.CONTENT_TYPE;

                    case "cookie":
                        return EnmTipo.COOKIE;

                    case "date":
                        return EnmTipo.DATE;

                    case "desconhecido":
                        return EnmTipo.DESCONHECIDO;

                    case "expect":
                        return EnmTipo.EXPECT;

                    case "from":
                        return EnmTipo.FROM;

                    case "host":
                        return EnmTipo.HOST;

                    case "if-match":
                        return EnmTipo.IF_MATCH;

                    case "if-modified-since":
                        return EnmTipo.IF_MODIFIED_SINCE;

                    case "if-none-match":
                        return EnmTipo.IF_NONE_MATCH;

                    case "if-range":
                        return EnmTipo.IF_RANGE;

                    case "if-unmodified-since":
                        return EnmTipo.IF_UNMODIFIED_SINCE;

                    case "max-forwards":
                        return EnmTipo.MAX_FORWARDS;

                    case "none":
                        return EnmTipo.NONE;

                    case "origin":
                        return EnmTipo.ORIGIN;

                    case "pragma":
                        return EnmTipo.PRAGMA;

                    case "proxy-authorization":
                        return EnmTipo.PROXY_AUTHORIZATION;

                    case "range":
                        return EnmTipo.RANGE;

                    case "referer":
                        return EnmTipo.REFERER;

                    case "te":
                        return EnmTipo.TE;

                    case "upgrade":
                        return EnmTipo.UPGRADE;

                    case "user-agent":
                        return EnmTipo.USER_AGENT;

                    case "via":
                        return EnmTipo.VIA;

                    case "warning":
                        return EnmTipo.WARNING;
                }

                return EnmTipo.DESCONHECIDO;
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

        private string getStrValor()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (string.IsNullOrEmpty(this.strHeaderLinha))
                {
                    return null;
                }

                return this.strHeaderLinha.Substring((this.strHeaderLinha.IndexOf(":") + 2), (this.strHeaderLinha.Length - this.strHeaderLinha.IndexOf(":") - 2));
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