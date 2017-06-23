using DigoFramework;
using DigoFramework.Arquivo;
using DigoFramework.Json;
using NetZ.Web.DataBase.Dominio;
using NetZ.Web.Html.Pagina;
using NetZ.Web.Server.Arquivo;
using System;
using System.Collections.Generic;
using System.IO;
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
        /// Switching Protocols (WebSocket).
        /// </summary>
        public const int INT_STATUS_CODE_101_SWITCHING_PROTOCOLS = 101;

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
        /// Ocorreu um erro no servidor.
        /// </summary>
        public const int INT_STATUS_CODE_500_INTERNAL_ERROR = 500;

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
                if (_arrBteResposta != null)
                {
                    return _arrBteResposta;
                }

                _arrBteResposta = this.getArrBteResposta();

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
                if (_lstObjCookie != null)
                {
                    return _lstObjCookie;
                }

                _lstObjCookie = new List<Cookie>();

                return _lstObjCookie;
            }
        }

        private List<string> lstStrHeaderDiverso
        {
            get
            {
                if (_lstStrHeaderDiverso != null)
                {
                    return _lstStrHeaderDiverso;
                }

                _lstStrHeaderDiverso = new List<string>();

                return _lstStrHeaderDiverso;
            }
        }

        private MemoryStream mmsConteudo
        {
            get
            {
                return _mmsConteudo;
            }

            set
            {
                _mmsConteudo = value;
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
            this.objSolicitacao = objSolicitacao;
        }

        #endregion Construtores

        #region Métodos

        /// <summary>
        /// Adiciona um cookie para ser armazenado no browser do cliente.
        /// </summary>
        /// <returns>Retorna esta mesma instância.</returns>
        public Resposta addCookie(Cookie objCookie)
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
            if (string.IsNullOrEmpty(strNome))
            {
                return;
            }

            if (string.IsNullOrEmpty(strValor))
            {
                return;
            }

            string strHeader = "_header_nome: _header_valor";

            strHeader = strHeader.Replace("_header_nome", strNome);
            strHeader = strHeader.Replace("_header_valor", strValor);

            if (this.lstStrHeaderDiverso.Contains(strHeader))
            {
                return;
            }

            this.lstStrHeaderDiverso.Add(strHeader);
        }

        /// <summary>
        /// Adiciona código HTML para a resposta que será encaminhada para o cliente quando o
        /// processamento da solicitação for finalizada.
        /// </summary>
        /// <param name="strHtml">Código HTML que deve ser enviada para o cliente.</param>
        /// <returns>Retorna esta mesma instância.</returns>
        public Resposta addHtml(string strHtml)
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

        /// <summary>
        /// Adiciona o conteúdo em html da <see cref="PaginaHtml"/> para a resposta.
        /// </summary>
        /// <param name="pagHtml">Página que se deseja responder para o usuário.</param>
        /// <returns>Retorna esta mesma instância.</returns>
        public Resposta addHtml(PaginaHtml pagHtml)
        {
            if (pagHtml == null)
            {
                return this;
            }

            this.addHtml(pagHtml.toHtml());

            return this;
        }

        /// <summary>
        /// Adiciona a instância do objeto passado como parâmetro no formato de JSON para ser enviado
        /// para o cliente na resposta.
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
            if (obj == null)
            {
                return this;
            }

            string jsn = Json.i.toJson(obj);

            if (string.IsNullOrEmpty(jsn))
            {
                return this;
            }

            this.enmContentType = EnmContentType.JSON_APPLICATION_JSON;
            this.enmEncoding = EnmEncoding.UTF_8;

            this.addStrConteudo(jsn);

            return this;
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
            if (string.IsNullOrEmpty(url))
            {
                return this;
            }

            this.intStatus = INT_STATUS_CODE_302_FOUND;
            this.strRedirecionamento = url;

            return this;
        }

        internal Resposta addArquivo(ArquivoEstatico arq)
        {
            if (arq == null)
            {
                return this;
            }

            this.dttUltimaModificacao = arq.dttAlteracao;
            this.atualizarEnmContentType(arq);

            if (this.objSolicitacao.dttUltimaModificacao.ToString().Equals(this.dttUltimaModificacao.ToString()))
            {
                return this;
            }

            if (arq.arrBteConteudo == null)
            {
                return this;
            }

            if (arq.arrBteConteudo.Length < 1)
            {
                return this;
            }

            this.mmsConteudo = new MemoryStream();

            this.mmsConteudo.Write(arq.arrBteConteudo, 0, arq.arrBteConteudo.Length);

            return this;
        }

        private void addCookieSessao()
        {
            if (this.objSolicitacao == null)
            {
                return;
            }

            if (!string.IsNullOrEmpty(objSolicitacao.getStrCookieValor(SrvHttpBase.STR_COOKIE_SESSAO)))
            {
                return;
            }

            var strSessao = Utils.getStrToken(32, DateTime.Now, this.objSolicitacao.intObjetoId);

            var objCookieSessao = new Cookie(SrvHttpBase.STR_COOKIE_SESSAO, strSessao);

            objCookieSessao.dttValidade = DateTime.Now.AddHours(8);

            this.addCookie(objCookieSessao);
            this.addObjUsuario(objCookieSessao);
        }

        private void addObjUsuario(Cookie objCookieSessao)
        {
            if (objCookieSessao == null)
            {
                return;
            }

            if (string.IsNullOrEmpty(objCookieSessao.strValor))
            {
                return;
            }

            AppWebBase.i.addObjUsuario(new UsuarioDominio() { strSessao = objCookieSessao.strValor });
        }

        private void addStrConteudo(string strConteudo)
        {
            if (string.IsNullOrEmpty(strConteudo))
            {
                return;
            }

            byte[] arrBte = Encoding.UTF8.GetBytes(strConteudo);

            this.mmsConteudo = new MemoryStream();

            this.mmsConteudo.Write(arrBte, 0, arrBte.Length);
        }

        private void atualizarEnmContentType(ArquivoEstatico arq)
        {
            if (arq == null)
            {
                this.enmContentType = EnmContentType.TXT_TEXT_PLAIN;
                return;
            }

            this.enmContentType = arq.enmContentType;
        }

        private byte[] getArrBteResposta()
        {
            string strHeader = this.getStrHeader();

            if (string.IsNullOrEmpty(strHeader))
            {
                return null;
            }

            strHeader = strHeader.Replace(Environment.NewLine + Environment.NewLine, Environment.NewLine);

            MemoryStream mmsResposta = new MemoryStream();

            mmsResposta.Write(Encoding.UTF8.GetBytes(strHeader), 0, Encoding.UTF8.GetByteCount(strHeader));
            mmsResposta.Write(Encoding.UTF8.GetBytes(Environment.NewLine), 0, Encoding.UTF8.GetByteCount(Environment.NewLine));

            if (this.mmsConteudo == null)
            {
                return mmsResposta.ToArray();
            }

            mmsResposta.Write(this.mmsConteudo.ToArray(), 0, (int)this.mmsConteudo.Length);

            return mmsResposta.ToArray();
        }

        private string getStrEnmEncoding()
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

        private string getStrHeader()
        {
            this.addCookieSessao();

            switch (this.intStatus)
            {
                case INT_STATUS_CODE_101_SWITCHING_PROTOCOLS:
                    return this.getStrHeader101();

                case INT_STATUS_CODE_204_NO_CONTENT:
                case INT_STATUS_CODE_501_NOT_IMPLEMENTED:
                    return this.getStrHeaderDefault();

                case INT_STATUS_CODE_302_FOUND:
                    return this.getStrHeader302();

                case INT_STATUS_CODE_404_NOT_FOUND:
                case INT_STATUS_CODE_500_INTERNAL_ERROR:
                    return this.getStrHeader404_500();

                default:
                    return this.getStrHeader200();
            }
        }

        private string getStrHeader101()
        {
            StringBuilder stbResultado = new StringBuilder();

            stbResultado.AppendLine(this.getStrHeaderStatus());
            stbResultado.AppendLine("Upgrade: websocket");
            stbResultado.AppendLine("Connection: Upgrade");
            stbResultado.AppendLine(this.getStrHeaderDiverso());

            return stbResultado.ToString();
        }

        private string getStrHeader200()
        {
            StringBuilder stbResultado = new StringBuilder();

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

        private string getStrHeader302()
        {
            StringBuilder stbResultado = new StringBuilder();

            stbResultado.AppendLine(this.getStrHeaderStatus());
            stbResultado.AppendLine(this.getStrHeaderServer());
            stbResultado.AppendLine(this.getStrHeaderSetCookie());
            stbResultado.AppendLine(this.getStrHeaderLocation());

            return stbResultado.ToString();
        }

        private string getStrHeader404_500()
        {
            StringBuilder stbResultado = new StringBuilder();

            stbResultado.AppendLine(this.getStrHeaderStatus());
            stbResultado.AppendLine(this.getStrHeaderData("Date", DateTime.Now));
            stbResultado.AppendLine(this.getStrHeaderServer());
            stbResultado.AppendLine(this.getStrHeaderSetCookie());
            stbResultado.AppendLine(this.getStrHeaderContentType());
            stbResultado.AppendLine(this.getStrHeaderContentLength());

            return stbResultado.ToString();
        }

        private string getStrHeaderContentLength()
        {
            if (this.mmsConteudo == null)
            {
                return "Content-Length: 0";
            }

            string strResultado = "Content-Length: _content_length";
            strResultado = strResultado.Replace("_content_length", this.mmsConteudo.Length.ToString());

            return strResultado;
        }

        private string getStrHeaderContentType()
        {
            string strResultado = "Content-Type: _content_type; charset=_char_set";

            strResultado = strResultado.Replace("_content_type", EnmContentTypeManager.getStrContentType(this.enmContentType));
            strResultado = strResultado.Replace("_char_set", this.getStrEnmEncoding());

            return strResultado;
        }

        private string getStrHeaderData(string strFieldNome, DateTime dtt)
        {
            if (string.IsNullOrEmpty(strFieldNome))
            {
                return null;
            }

            string strResultado = "_str_date_nome: _date_valor";

            strResultado = strResultado.Replace("_str_date_nome", strFieldNome);
            strResultado = strResultado.Replace("_date_valor", dtt.ToUniversalTime().ToString("r"));

            return strResultado;
        }

        private string getStrHeaderDefault()
        {
            StringBuilder stbResultado = new StringBuilder();

            stbResultado.AppendLine(this.getStrHeaderStatus());
            stbResultado.AppendLine(this.getStrHeaderServer());
            stbResultado.AppendLine(this.getStrHeaderSetCookie());

            return stbResultado.ToString();
        }

        private string getStrHeaderDiverso()
        {
            StringBuilder stbResultado = new StringBuilder();

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

        private string getStrHeaderLocation()
        {
            string strResultado = "Location: _location";
            strResultado = strResultado.Replace("_location", !string.IsNullOrEmpty(this.strRedirecionamento) ? this.strRedirecionamento : "/");

            return strResultado;
        }

        private string getStrHeaderServer()
        {
            return "Server: NetZ.Web Server";
        }

        private string getStrHeaderSetCookie()
        {
            StringBuilder stbResultado = new StringBuilder();

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

        private string getStrHeaderStatus()
        {
            string strResultado = "HTTP/1.1 _status_code";

            if (this.dttUltimaModificacao.ToString().Equals(this.objSolicitacao.dttUltimaModificacao.ToString()))
            {
                this.intStatus = INT_STATUS_CODE_304_NOT_MODIFIED;
                return strResultado.Replace("_status_code", "304 Not Modified");
            }

            switch (this.intStatus)
            {
                case INT_STATUS_CODE_101_SWITCHING_PROTOCOLS:
                    return strResultado.Replace("_status_code", "101 Switching Protocols");

                case INT_STATUS_CODE_204_NO_CONTENT:
                    return strResultado.Replace("_status_code", "204 No Content");

                case INT_STATUS_CODE_302_FOUND:
                    return strResultado.Replace("_status_code", "302 Found");

                case INT_STATUS_CODE_404_NOT_FOUND:
                    return strResultado.Replace("_status_code", "404 Not Found");

                case INT_STATUS_CODE_500_INTERNAL_ERROR:
                    return strResultado.Replace("_status_code", "500 Internal Error");

                case INT_STATUS_CODE_501_NOT_IMPLEMENTED:
                    return strResultado.Replace("_status_code", "501 Not Implemented");

                default:
                    this.intStatus = INT_STATUS_CODE_200_OK;
                    return strResultado.Replace("_status_code", "200 OK");
            }
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}