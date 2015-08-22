using System;

namespace NetZ.Web.Server
{
    /// <summary>
    /// Representa os "fields" (campos) que podem contem em um cabeçalho vindo na solicitação do cliente.
    /// </summary>
    internal class Field
    {
        #region Constantes

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

        private EnmTipo _enmTipo = EnmTipo.NONE;
        private string _strField;
        private string _strValor;

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

        private string strValor
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

        #endregion Atributos

        #region Construtores

        public Field(string strHeader)
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

                this.processarEnmTipo(arrStr[0]);
                this.processarStrValor();
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

                    case "if-modified_since":
                        this.enmTipo = EnmTipo.IF_MODIFIED_SINCE;
                        return;

                    case "if-none_match":
                        this.enmTipo = EnmTipo.IF_NONE_MATCH;
                        return;

                    case "if-range":
                        this.enmTipo = EnmTipo.IF_RANGE;
                        return;

                    case "if-unmodified_since":
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

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}