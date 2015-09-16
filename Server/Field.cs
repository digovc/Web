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
        private string _strField;
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

            set
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    _decValor = value;

                    this.strValor = Convert.ToString(_decValor);
                }
                catch
                {
                    this.strValor = null;
                }
                finally
                {
                }

                #endregion Ações
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
                catch
                {
                    return DateTime.MinValue;
                }
                finally
                {
                }

                #endregion Ações

                return _dttValor;
            }

            set
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    _dttValor = value;

                    this.strValor = _dttValor.ToString();
                }
                catch
                {
                    this.strValor = null;
                }
                finally
                {
                }

                #endregion Ações
            }
        }

        /// <summary>
        /// Indica o tipo deste "field" (campo).
        /// </summary>
        public EnmTipo enmTipo
        {
            get
            {
                return _enmTipo;
            }

            set
            {
                _enmTipo = value;
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

            set
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    _intValor = value;

                    this.decValor = _intValor;
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
        }

        /// <summary>
        /// Valor deste "field" (campo).
        /// </summary>
        public string strValor
        {
            get
            {
                return _strValor;
            }

            set
            {
                _strValor = value;
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

        private string strField
        {
            get
            {
                return _strField;
            }

            set
            {
                _strField = value;
            }
        }

        #endregion Atributos

        #region Construtores

        internal Field(string strHeader)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.strField = strHeader;
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

        internal void processar()
        {
            #region Variáveis

            string[] arrStr;

            #endregion Variáveis

            #region Ações

            try
            {
                if (string.IsNullOrEmpty(this.strField))
                {
                    return;
                }

                arrStr = this.strField.Split(":".ToCharArray());

                if (arrStr == null)
                {
                    return;
                }

                if (arrStr.Length < 2)
                {
                    return;
                }

                this.processarStrValor();

                this.processarEnmTipo(arrStr[0]);
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

        private void processarEnmTipo(string strTipo)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.enmTipo = EnmTipo.DESCONHECIDO;

                if (string.IsNullOrEmpty(strTipo))
                {
                    return;
                }

                switch (strTipo.ToLower())
                {
                    case "accept":
                        this.enmTipo = EnmTipo.ACCEPT;
                        return;

                    case "accept-charset":
                        this.enmTipo = EnmTipo.ACCEPT_CHARSET;
                        return;

                    case "accept-datetime":
                        this.enmTipo = EnmTipo.ACCEPT_DATETIME;
                        return;

                    case "accept-encoding":
                        this.enmTipo = EnmTipo.ACCEPT_ENCODING;
                        return;

                    case "accept-language":
                        this.enmTipo = EnmTipo.ACCEPT_LANGUAGE;
                        return;

                    case "authorization":
                        this.enmTipo = EnmTipo.AUTHORIZATION;
                        return;

                    case "cache-control":
                        this.enmTipo = EnmTipo.CACHE_CONTROL;
                        return;

                    case "connection":
                        this.enmTipo = EnmTipo.CONNECTION;
                        return;

                    case "content-length":
                        this.enmTipo = EnmTipo.CONTENT_LENGTH;
                        return;

                    case "content-md5":
                        this.enmTipo = EnmTipo.CONTENT_MD5;
                        return;

                    case "content-type":
                        this.enmTipo = EnmTipo.CONTENT_TYPE;
                        return;

                    case "cookie":
                        this.enmTipo = EnmTipo.COOKIE;
                        return;

                    case "date":
                        this.enmTipo = EnmTipo.DATE;
                        return;

                    case "desconhecido":
                        this.enmTipo = EnmTipo.DESCONHECIDO;
                        return;

                    case "expect":
                        this.enmTipo = EnmTipo.EXPECT;
                        return;

                    case "from":
                        this.enmTipo = EnmTipo.FROM;
                        return;

                    case "host":
                        this.enmTipo = EnmTipo.HOST;
                        return;

                    case "if-match":
                        this.enmTipo = EnmTipo.IF_MATCH;
                        return;

                    case "if-modified-since":
                        this.setEnmTipoIfModifiedSince();
                        return;

                    case "if-none-match":
                        this.enmTipo = EnmTipo.IF_NONE_MATCH;
                        return;

                    case "if-range":
                        this.enmTipo = EnmTipo.IF_RANGE;
                        return;

                    case "if-unmodified-since":
                        this.enmTipo = EnmTipo.IF_UNMODIFIED_SINCE;
                        return;

                    case "max-forwards":
                        this.enmTipo = EnmTipo.MAX_FORWARDS;
                        return;

                    case "none":
                        this.enmTipo = EnmTipo.NONE;
                        return;

                    case "origin":
                        this.enmTipo = EnmTipo.ORIGIN;
                        return;

                    case "pragma":
                        this.enmTipo = EnmTipo.PRAGMA;
                        return;

                    case "proxy-authorization":
                        this.enmTipo = EnmTipo.PROXY_AUTHORIZATION;
                        return;

                    case "range":
                        this.enmTipo = EnmTipo.RANGE;
                        return;

                    case "referer":
                        this.enmTipo = EnmTipo.REFERER;
                        return;

                    case "te":
                        this.enmTipo = EnmTipo.TE;
                        return;

                    case "upgrade":
                        this.enmTipo = EnmTipo.UPGRADE;
                        return;

                    case "user-agent":
                        this.enmTipo = EnmTipo.USER_AGENT;
                        return;

                    case "via":
                        this.enmTipo = EnmTipo.VIA;
                        return;

                    case "warning":
                        this.enmTipo = EnmTipo.WARNING;
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

        private void processarStrValor()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (string.IsNullOrEmpty(this.strField))
                {
                    return;
                }

                this.strValor = this.strField.Substring((this.strField.IndexOf(":") + 2), (this.strField.Length - this.strField.IndexOf(":") - 2));
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

        private void setEnmTipoIfModifiedSince()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.enmTipo = EnmTipo.IF_MODIFIED_SINCE;

                if (this.objSolicitacao == null)
                {
                    return;
                }

                this.objSolicitacao.dttUltimaModificacao = Convert.ToDateTime(this.strValor);
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