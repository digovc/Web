using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using DigoFramework;
using NetZ.Web.Html;

namespace NetZ.Web.Server
{
    /// <summary>
    /// Classe que será utilizada para responder uma solicitação enviada por um cliente por uma
    /// conexão HTTP. Esta classe contém métodos e propriedades relevantes para construção da resposta.
    /// </summary>
    public class Resposta : SistemaBase.Objeto
    {
        #region Constantes

        private const string STR_CHARSET_NONE = "_charset_none";

        public enum EnmEncoding
        {
            _8859,
            ANSI,
            ASCII,
            NONE,
            NUMB,
            UTF_16,
            UTF_8,
        }

        #endregion Constantes

        #region Atributos

        private byte[] _arrBteResposta;
        private DateTime _dttUltimaModificacao = DateTime.Now;
        private EnmContentType _enmContentType = EnmContentType.TXT_TEXT_PLAIN;
        private EnmEncoding _enmEncoding = EnmEncoding.UTF_8;
        private int _intStatus;
        private List<Cookie> _lstObjCookie;
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
        public void addCookie(Cookie objCookie)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (objCookie == null)
                {
                    return;
                }

                if (string.IsNullOrEmpty(objCookie.strNome))
                {
                    return;
                }

                if (string.IsNullOrEmpty(objCookie.strValor))
                {
                    return;
                }

                if (objCookie.dttValidade < DateTime.Now)
                {
                    return;
                }

                this.lstObjCookie.Add(objCookie);
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

                this.enmContentType = EnmContentType.HTML_TEXT_HTML;
                this.enmEncoding = EnmEncoding.UTF_8;
                this.mmsConteudo.Write(Encoding.UTF8.GetBytes(strHtml), 0, Encoding.UTF8.GetByteCount(strHtml));
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
        public void addHtml(PaginaHtml pagHtml)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (pagHtml == null)
                {
                    return;
                }

                this.addHtml(pagHtml.toHtml());
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
        /// </summary>
        /// <param name="url">
        /// Nova URL que será acessada pelo browser do usuário assim que essa resposta for enviada.
        /// </param>
        public void redirecionar(string url)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (string.IsNullOrEmpty(url))
                {
                    return;
                }

                this.intStatus = 302;
                this.strRedirecionamento = url;
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

                if (!string.IsNullOrEmpty(objSolicitacao.getStrCookieValor(Server.STR_COOKIE_SESSAO_ID_NOME)))
                {
                    return;
                }

                strSessaoId = "_dtt_agora+_solicitacao_id";

                strSessaoId = strSessaoId.Replace("_dtt_agora", DateTime.Now.ToString());
                strSessaoId = strSessaoId.Replace("_solicitacao_id", this.objSolicitacao.intObjetoId.ToString());

                strSessaoId = Utils.getStrMd5(strSessaoId);

                objCookieSessaoId = new Cookie(Server.STR_COOKIE_SESSAO_ID_NOME, strSessaoId);
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
                        this.enmEncoding = EnmEncoding.NONE;
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

                mmsResposta = new MemoryStream();

                mmsResposta.Write(Encoding.UTF8.GetBytes(strHeader), 0, Encoding.UTF8.GetByteCount(strHeader));

                if (!200.Equals(this.intStatus))
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

                    case EnmEncoding.NONE:
                        return STR_CHARSET_NONE;

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

            StringBuilder stbResultado;

            #endregion Variáveis

            #region Ações

            try
            {
                this.addCookieSessaoId();

                if (302.Equals(this.intStatus)) // Redirecionamento.
                {
                    return this.getStrHeaderRedirecionamento();
                }

                stbResultado = new StringBuilder();

                stbResultado.AppendLine(this.getStrHeaderStatus());
                stbResultado.AppendLine(this.getStrHeaderData("Date", DateTime.Now));
                stbResultado.AppendLine(this.getStrServer());
                stbResultado.AppendLine(this.getStrSetCookie());
                stbResultado.AppendLine(this.getStrHeaderData("Last-Modified", this.dttUltimaModificacao));
                //stbResultado.AppendLine("Connection: keep-alive");
                stbResultado.AppendLine(this.getStrHeaderContentType());
                stbResultado.AppendLine(this.getStrHeaderContentLength());

                stbResultado.Replace((Environment.NewLine + Environment.NewLine), Environment.NewLine);

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
                strResultado = strResultado.Replace(("; charset=" + STR_CHARSET_NONE), null);

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

        private string getStrHeaderLocation()
        {
            #region Variáveis

            string strResultado;

            #endregion Variáveis

            #region Ações

            try
            {
                strResultado = "Location: _location_value";

                strResultado = strResultado.Replace("_location_value", (!string.IsNullOrEmpty(this.strRedirecionamento)) ? this.strRedirecionamento : "/");

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

        private string getStrHeaderRedirecionamento()
        {
            #region Variáveis

            StringBuilder stbResultado;

            #endregion Variáveis

            #region Ações

            try
            {
                stbResultado = new StringBuilder();

                stbResultado.AppendLine(this.getStrHeaderStatus());
                stbResultado.AppendLine(this.getStrHeaderLocation());
                stbResultado.AppendLine(this.getStrSetCookie());

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
                    this.intStatus = 304;
                    return strResultado.Replace("_status_code", "304 Not Modified");
                }

                switch (this.intStatus)
                {
                    case 302:
                        return strResultado.Replace("_status_code", "302 Found");

                    case 404:
                        return strResultado.Replace("_status_code", "404 Not Found");

                    default:
                        this.intStatus = 200;
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

        private string getStrServer()
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

        private string getStrSetCookie()
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

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}