﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using DigoFramework;
using DigoFramework.Json;
using NetZ.Web.Html;

namespace NetZ.Web.Server
{
    /// <summary>
    /// Classe que será utilizada para responder uma solicitação enviada por um cliente por uma
    /// conexão HTTP. Esta classe contém métodos e propriedades relevantes para construção da resposta.
    /// </summary>
    public class Resposta
    {
        #region Constantes

        public enum EnmEncoding
        {
            _8859,
            ANSI,
            ASCII,
            NUMB,
            UTF_16,
            UTF_8,
        }

        /// <summary>
        /// Tudo certo.
        /// </summary>
        public const int INT_STATUS_CODE_200_OK = 200;

        /// <summary>
        /// Tudo certo, mas não há conteúdo para retornar.
        /// </summary>
        public const int INT_STATUS_CODE_204_NO_CONTENT = 204;

        /// <summary>
        /// Redirecionamento para outra localização.
        /// </summary>
        public const int INT_STATUS_CODE_302_FOUND = 302;

        /// <summary>
        /// Conteúdo não alterado. Utilizar a cópia do cache.
        /// </summary>
        public const int INT_STATUS_CODE_304_NOT_MODIFIED = 304;

        /// <summary>
        /// Conteúdo não encontrado.
        /// </summary>
        public const int INT_STATUS_CODE_404_NOT_FOUND = 404;

        /// <summary>
        /// O recurso solicitado pelo cliente ainda não está implementado.
        /// </summary>
        public const int INT_STATUS_CODE_501_NOT_IMPLEMENTED = 501;

        #endregion Constantes

        #region Atributos

        private byte[] _arrBteResposta;
        private DateTime _dttUltimaModificacao = DateTime.Now;
        private EnmContentType _enmContentType = EnmContentType.TXT_TEXT_PLAIN;
        private EnmEncoding _enmEncoding = EnmEncoding.UTF_8;
        private int _intStatus = INT_STATUS_CODE_200_OK;
        private List<Cookie> _lstObjCookie;
        private List<string> _lstStrHeaderDiverso;
        private MemoryStream _mmsConteudo;
        private Solicitacao _objSolicitacao;
        private string _strRedirecionamento;

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

        public EnmContentType enmContentType
        {
            get
            {
                return _enmContentType;
            }

            set
            {
                _enmContentType = value;
            }
        }

        public EnmEncoding enmEncoding
        {
            get
            {
                return _enmEncoding;
            }

            set
            {
                _enmEncoding = value;
            }
        }

        /// <summary>
        /// Solicitação que deu origem a esta resposta.
        /// </summary>
        public Solicitacao objSolicitacao
        {
            get
            {
                return _objSolicitacao;
            }

            private set
            {
                _objSolicitacao = value;
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

        internal int intStatus
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

        private List<Cookie> lstObjCookie
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_lstObjCookie != null)
                    {
                        return _lstObjCookie;
                    }

                    _lstObjCookie = new List<Cookie>();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _lstObjCookie;
            }
        }

        private List<string> lstStrHeaderDiverso
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_lstStrHeaderDiverso != null)
                    {
                        return _lstStrHeaderDiverso;
                    }

                    _lstStrHeaderDiverso = new List<string>();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _lstStrHeaderDiverso;
            }
        }

        private MemoryStream mmsConteudo
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_mmsConteudo != null)
                    {
                        return _mmsConteudo;
                    }

                    _mmsConteudo = new MemoryStream();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _mmsConteudo;
            }
        }

        private string strRedirecionamento
        {
            get
            {
                return _strRedirecionamento;
            }

            set
            {
                _strRedirecionamento = value;
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
        /// Adiciona um cookie para ser armazenado no browser do cliente.
        /// </summary>
        /// <returns>Retorna esta mesma instância.</returns>
        public Resposta addCookie(Cookie objCookie)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (objCookie == null)
                {
                    return this;
                }

                if (string.IsNullOrEmpty(objCookie.strNome))
                {
                    return this;
                }

                if (string.IsNullOrEmpty(objCookie.strValor))
                {
                    return this;
                }

                if (objCookie.dttValidade < DateTime.Now)
                {
                    return this;
                }

                this.lstObjCookie.Add(objCookie);

                return this;
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

        /// <summary>
        /// Adiciona valores para o header da resposta.
        /// <para>
        /// Estes valores serão adicionado ao final do cabeçallho da resposta apenas se o código do
        /// status for 200 (OK).
        /// </para>
        /// </summary>
        /// <param name="strNome">Nome do header que será adicionado.</param>
        /// <param name="strValor">Valor do header que será adicionado.</param>
        public void addHeader(string strNome, string strValor)
        {
            #region Variáveis

            string strHeader;

            #endregion Variáveis

            #region Ações

            try
            {
                if (string.IsNullOrEmpty(strNome))
                {
                    return;
                }

                if (string.IsNullOrEmpty(strValor))
                {
                    return;
                }

                strHeader = "_header_nome: _header_valor";

                strHeader = strHeader.Replace("_header_nome", strNome);
                strHeader = strHeader.Replace("_header_valor", strValor);

                if (this.lstStrHeaderDiverso.Contains(strHeader))
                {
                    return;
                }

                this.lstStrHeaderDiverso.Add(strHeader);
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

        /// <summary>
        /// Adiciona código HTML para a resposta que será encaminhada para o cliente quando o
        /// processamento da solicitação for finalizada.
        /// </summary>
        /// <param name="strHtml">Código HTML que deve ser enviada para o cliente.</param>
        /// <returns>Retorna esta mesma instância.</returns>
        public Resposta addHtml(string strHtml)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (string.IsNullOrEmpty(strHtml))
                {
                    return this;
                }

                this.enmContentType = EnmContentType.HTML_TEXT_HTML;
                this.enmEncoding = EnmEncoding.UTF_8;

                this.addStrConteudo(strHtml);

                return this;
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

        /// <summary>
        /// Adiciona o conteúdo em html da <see cref="PaginaHtml"/> para a resposta.
        /// </summary>
        /// <param name="pagHtml">Página que se deseja responder para o usuário.</param>
        /// <returns>Retorna esta mesma instância.</returns>
        public Resposta addHtml(PaginaHtml pagHtml)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (pagHtml == null)
                {
                    return this;
                }

                this.addHtml(pagHtml.toHtml());

                return this;
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

        /// <summary>
        /// Adiciona a instância do objeto passado como parâmetro no formato de JSON para ser
        /// enviado para o cliente na resposta.
        /// <para>
        /// Este método também atualizará o tipo da resposta para JSON, para informar o browser do
        /// que se trata a resposta.
        /// </para>
        /// </summary>
        /// <param name="obj">
        /// Objeto que será serializado no formato JSON para ser enviado para o cliente.
        /// </param>
        /// <returns>Retorna esta mesma instância.</returns>
        public Resposta addJson(object obj)
        {
            #region Variáveis

            string jsn;

            #endregion Variáveis

            #region Ações

            try
            {
                if (obj == null)
                {
                    return this;
                }

                jsn = Json.i.toJson(obj);

                if (string.IsNullOrEmpty(jsn))
                {
                    return this;
                }

                this.enmContentType = EnmContentType.JSON_APPLICATION_JSON;
                this.enmEncoding = EnmEncoding.UTF_8;

                this.addStrConteudo(jsn);

                return this;
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

        /// <summary>
        /// Redireciona o browser do usuário para a página contida em param name="url".
        /// <para>
        /// Após chamar este método, todo e qualquer conteúdo que tiver sido adicionado a esta
        /// resposta será desprezada.
        /// </para>
        /// <para>
        /// O prefixo "http://" deve ser informado caso o redirecionamento seja para outro site.
        /// </para>
        /// </summary>
        /// <param name="url">
        /// Nova URL que será acessada pelo browser do usuário assim que essa resposta for enviada.
        /// </param>
        /// <returns>Retorna esta mesma instância.</returns>
        public Resposta redirecionar(string url)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (string.IsNullOrEmpty(url))
                {
                    return this;
                }

                this.intStatus = INT_STATUS_CODE_302_FOUND;
                this.strRedirecionamento = url;

                return this;
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

        internal void addArquivo(ArquivoEstatico arq)
        {
            #region Variáveis

            byte[] arrBte;

            #endregion Variáveis

            #region Ações

            try
            {
                if (arq == null)
                {
                    return;
                }

                if (!File.Exists(arq.dirCompleto))
                {
                    return;
                }

                this.dttUltimaModificacao = arq.dttUltimaModificacao;
                this.atualizarEnmContentType(arq);

                if (this.objSolicitacao.dttUltimaModificacao.ToString().Equals(this.dttUltimaModificacao.ToString()))
                {
                    return;
                }

                arrBte = File.ReadAllBytes(arq.dirCompleto);

                this.mmsConteudo.Write(arrBte, 0, arrBte.Length);
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

        private void addCookieSessaoId()
        {
            #region Variáveis

            Cookie objCookieSessaoId;
            string strSessaoId;

            #endregion Variáveis

            #region Ações

            try
            {
                if (this.objSolicitacao == null)
                {
                    return;
                }

                if (!string.IsNullOrEmpty(objSolicitacao.getStrCookieValor(ServerHttp.STR_COOKIE_SESSAO_ID_NOME)))
                {
                    return;
                }

                strSessaoId = "_dtt_agora+_solicitacao_id";

                strSessaoId = strSessaoId.Replace("_dtt_agora", DateTime.Now.ToString());
                strSessaoId = strSessaoId.Replace("_solicitacao_id", this.objSolicitacao.intObjetoId.ToString());

                strSessaoId = Utils.getStrMd5(strSessaoId);

                objCookieSessaoId = new Cookie(ServerHttp.STR_COOKIE_SESSAO_ID_NOME, strSessaoId);
                objCookieSessaoId.dttValidade = DateTime.Now.AddHours(8);

                this.addCookie(objCookieSessaoId);
                this.addUsr(objCookieSessaoId);
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

        private void addStrConteudo(string strConteudo)
        {
            #region Variáveis

            byte[] arrBte;

            #endregion Variáveis

            #region Ações

            try
            {
                if (string.IsNullOrEmpty(strConteudo))
                {
                    return;
                }

                arrBte = Encoding.UTF8.GetBytes(strConteudo);

                this.mmsConteudo.Write(arrBte, 0, arrBte.Length);
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

        private void addUsr(Cookie objCookieSessaoId)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (objCookieSessaoId == null)
                {
                    return;
                }

                if (string.IsNullOrEmpty(objCookieSessaoId.strValor))
                {
                    return;
                }

                AppWeb.i.addUsr(new Usuario(objCookieSessaoId.strValor));
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

        private void atualizarEnmContentType(ArquivoEstatico arq)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (arq == null)
                {
                    this.enmContentType = EnmContentType.TXT_TEXT_PLAIN;
                    return;
                }

                if (string.IsNullOrEmpty(arq.dirCompleto))
                {
                    this.enmContentType = EnmContentType.TXT_TEXT_PLAIN;
                    return;
                }

                if (string.IsNullOrEmpty(Path.GetExtension(arq.dirCompleto)))
                {
                    this.enmContentType = EnmContentType.TXT_TEXT_PLAIN;
                    return;
                }

                switch (Path.GetExtension(arq.dirCompleto).ToLower())
                {
                    case ".js":
                        this.enmContentType = EnmContentType.JS_APPLICATION_JAVASCRIPT;
                        return;

                    case ".css":
                        this.enmContentType = EnmContentType.CSS_TEXT_CSS;
                        return;

                    case ".htm":
                    case ".html":
                        this.enmContentType = EnmContentType.HTML_TEXT_HTML;
                        return;

                    case ".exe":
                        this.enmContentType = EnmContentType.EXE_APPLICATION_X_MSDOWNLOAD;
                        return;

                    case ".dll":
                        this.enmContentType = EnmContentType.EXE_APPLICATION_X_MSDOWNLOAD;
                        return;

                    case ".pdf":
                        this.enmContentType = EnmContentType.PDF_APPLICATION_PDF;
                        return;

                    case ".png":
                        this.enmContentType = EnmContentType.PNG_IMAGE_PNG;
                        return;

                    case ".bmp":
                        this.enmContentType = EnmContentType.BMP_IMAGE_BMP;
                        return;

                    case ".tif":
                        this.enmContentType = EnmContentType.TIFF_IMAGE_TIFF;
                        return;

                    case ".jpg":
                        this.enmContentType = EnmContentType.JPEG_JPG_IMAGE_JPEG;
                        return;

                    case ".mp4":
                        this.enmContentType = EnmContentType.MP4_VIDEO_MP4;
                        return;

                    case ".ico":
                        this.enmContentType = EnmContentType.ICO_IMAGE_X_ICON;
                        //this.enmEncoding = EnmEncoding.NONE;
                        return;

                    default:
                        this.enmContentType = EnmContentType.TXT_TEXT_PLAIN;
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

        private byte[] getArrBteResposta()
        {
            #region Variáveis

            MemoryStream mmsResposta;
            string strHeader;

            #endregion Variáveis

            #region Ações

            try
            {
                strHeader = this.getStrHeader();
                strHeader = strHeader.Replace((Environment.NewLine + Environment.NewLine), Environment.NewLine);

                mmsResposta = new MemoryStream();

                mmsResposta.Write(Encoding.UTF8.GetBytes(strHeader), 0, Encoding.UTF8.GetByteCount(strHeader));

                if (!INT_STATUS_CODE_200_OK.Equals(this.intStatus))
                {
                    return mmsResposta.ToArray();
                }

                mmsResposta.Write(Encoding.UTF8.GetBytes(Environment.NewLine), 0, Encoding.UTF8.GetByteCount(Environment.NewLine));
                mmsResposta.Write(this.mmsConteudo.ToArray(), 0, (int)this.mmsConteudo.Length);

                return mmsResposta.ToArray();
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

        private string getStrEnmEncoding()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                switch (this.enmEncoding)
                {
                    case EnmEncoding._8859:
                        return "8859";

                    case EnmEncoding.ANSI:
                        return "ANSI";

                    case EnmEncoding.ASCII:
                        return "ASCII";

                    case EnmEncoding.NUMB:
                        return "Numb";

                    case EnmEncoding.UTF_16:
                        return "UTF-16";

                    default:
                        return "UTF-8";
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

        private string getStrHeader()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.addCookieSessaoId();

                switch (this.intStatus)
                {
                    case INT_STATUS_CODE_204_NO_CONTENT:
                    case INT_STATUS_CODE_501_NOT_IMPLEMENTED:
                        return this.getStrHeaderBasico();

                    case INT_STATUS_CODE_302_FOUND:
                        return this.getStrHeader302();

                    default:
                        return this.getStrHeader200();
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

        private string getStrHeader200()
        {
            #region Variáveis

            StringBuilder stbResultado;

            #endregion Variáveis

            #region Ações

            try
            {
                stbResultado = new StringBuilder();

                stbResultado.AppendLine(this.getStrHeaderStatus());
                stbResultado.AppendLine(this.getStrHeaderData("Date", DateTime.Now));
                stbResultado.AppendLine(this.getStrHeaderServer());
                stbResultado.AppendLine(this.getStrHeaderSetCookie());
                stbResultado.AppendLine(this.getStrHeaderData("Last-Modified", this.dttUltimaModificacao));
                stbResultado.AppendLine(this.getStrHeaderContentType());
                stbResultado.AppendLine(this.getStrHeaderContentLength());
                stbResultado.AppendLine(this.getStrHeaderDiverso());

                return stbResultado.ToString();
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

        private string getStrHeader302()
        {
            #region Variáveis

            StringBuilder stbResultado;

            #endregion Variáveis

            #region Ações

            try
            {
                stbResultado = new StringBuilder();

                stbResultado.AppendLine(this.getStrHeaderStatus());
                stbResultado.AppendLine(this.getStrHeaderServer());
                stbResultado.AppendLine(this.getStrHeaderSetCookie());
                stbResultado.AppendLine(this.getStrHeaderLocation());

                return stbResultado.ToString();
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

        private string getStrHeaderBasico()
        {
            #region Variáveis

            StringBuilder stbResultado;

            #endregion Variáveis

            #region Ações

            try
            {
                stbResultado = new StringBuilder();

                stbResultado.AppendLine(this.getStrHeaderStatus());
                stbResultado.AppendLine(this.getStrHeaderServer());
                stbResultado.AppendLine(this.getStrHeaderSetCookie());

                return stbResultado.ToString();
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
                if (this.mmsConteudo.Length < 1)
                {
                    return null;
                }

                strResultado = "Content-Length: _content_length";
                strResultado = strResultado.Replace("_content_length", this.mmsConteudo.Length.ToString());

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

        private string getStrHeaderContentType()
        {
            #region Variáveis

            string strResultado;

            #endregion Variáveis

            #region Ações

            try
            {
                strResultado = "Content-Type: _content_type; charset=_char_set";

                strResultado = strResultado.Replace("_content_type", EnmContentTypeManager.getStrEnmContentType(this.enmContentType));
                strResultado = strResultado.Replace("_char_set", this.getStrEnmEncoding());

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
                    return null;
                }

                strResultado = "_str_date_nome: _date_valor";

                strResultado = strResultado.Replace("_str_date_nome", strFieldNome);
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

        private string getStrHeaderDiverso()
        {
            #region Variáveis

            StringBuilder stbResultado;

            #endregion Variáveis

            #region Ações

            try
            {
                stbResultado = new StringBuilder();

                foreach (string strHeaderDiverso in this.lstStrHeaderDiverso)
                {
                    if (string.IsNullOrEmpty(strHeaderDiverso))
                    {
                        continue;
                    }

                    stbResultado.AppendLine(strHeaderDiverso);
                }

                return stbResultado.ToString();
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

        private string getStrHeaderLocation()
        {
            #region Variáveis

            string strResultado;

            #endregion Variáveis

            #region Ações

            try
            {
                strResultado = "Location: _location";
                strResultado = strResultado.Replace("_location", !string.IsNullOrEmpty(this.strRedirecionamento) ? this.strRedirecionamento : "/");

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

        private string getStrHeaderServer()
        {
            #region Variáveis

            string strResultado;

            #endregion Variáveis

            #region Ações

            try
            {
                //strResultado = "Server: _server_nome";
                //strResultado = strResultado.Replace("_server_nome", AppWeb.i.strNomeExibicao);

                //return strResultado;

                return "Server: NetZ.Web Server";
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

        private string getStrHeaderSetCookie()
        {
            #region Variáveis

            StringBuilder stbResultado;

            #endregion Variáveis

            #region Ações

            try
            {
                stbResultado = new StringBuilder();

                foreach (Cookie objCookie in this.lstObjCookie)
                {
                    if (objCookie == null)
                    {
                        continue;
                    }

                    stbResultado.AppendLine(objCookie.getStrFormatado());
                }

                return (stbResultado.Length > 5) ? stbResultado.ToString() : null;
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

                if (this.dttUltimaModificacao.ToString().Equals(this.objSolicitacao.dttUltimaModificacao.ToString()))
                {
                    this.intStatus = INT_STATUS_CODE_304_NOT_MODIFIED;
                    return strResultado.Replace("_status_code", "304 Not Modified");
                }

                switch (this.intStatus)
                {
                    case INT_STATUS_CODE_204_NO_CONTENT:
                        return strResultado.Replace("_status_code", "204 No Content");

                    case INT_STATUS_CODE_302_FOUND:
                        return strResultado.Replace("_status_code", "302 Found");

                    case INT_STATUS_CODE_404_NOT_FOUND:
                        return strResultado.Replace("_status_code", "404 Not Found");

                    case INT_STATUS_CODE_501_NOT_IMPLEMENTED:
                        return strResultado.Replace("_status_code", "501 Not Implemented");

                    default:
                        this.intStatus = INT_STATUS_CODE_200_OK;
                        return strResultado.Replace("_status_code", "200 OK");
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