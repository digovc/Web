using DigoFramework;
using NetZ.Web.DataBase.Dominio;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Web;

namespace NetZ.Web.Server
{
    /// <summary>
    /// Classe que abstrae cada solicitação que foi encaminhada pelo cliente e precisa ser respondida.
    /// <para>
    /// Esta solicitação deve ser verificada em <see cref="AppWebBase.responder(Solicitacao)"/>, para
    /// que seja construída a resposta adequeda aguardada pelo cliente.
    /// </para>
    /// <para>
    /// Um dos pontos mais cruciais do sistema para ser estável, consumir poucos recursos é a
    /// verificação da propriedade <see cref="dttUltimaModificacao"/> da instância de cada
    /// solicitação, para garantir que recursos que não forão alterados não sejam processados, nem
    /// enviados para o cliente.
    /// </para>
    /// <para>
    /// Quando esta solicitação se tratar de recursos estáticos, que deverão estar todos presentes na
    /// pasta "res", dentro da localidade onde está rodando este servidor WEB serão tratador automaticamente.
    /// </para>
    /// </summary>
    public class Solicitacao : Objeto
    {
        #region Constantes

        /// <summary>
        /// Métodos que são implementados por este servidor.
        /// </summary>
        public enum EnmMetodo
        {
            DESCONHECIDO,
            GET,
            NONE,
            OPTIONS,
            POST,
        }

        private const string STR_BODY_DIVISION = "\r\n\r\n";

        #endregion Constantes

        #region Atributos

        private byte[] _arrBteConteudo;
        private byte[] _arrBteMsgCliente;
        private decimal _decHttpVersao;
        private Dictionary<string, string> _dicPost;
        private DateTime _dttUltimaModificacao = DateTime.MinValue;
        private EnmMetodo _enmMetodo = EnmMetodo.NONE;
        private FormData _frmData;
        private string _jsn;
        private List<Cookie> _lstObjCookie;
        private List<Field> _lstObjField;
        private NetworkStream _nts;
        private Cliente _objCliente;
        private SslStream _objSslStream;
        private UsuarioDominio _objUsuario;
        private string _strConteudo;
        private string _strHeaderLinhaCabecalho;
        private string _strHost;
        private string _strMsgCliente;
        private string _strPagina;
        private string _strPaginaCompleta;
        private string _strSessao;

        /// <summary>
        /// Indica a data e hora da última modificação do recurso que está salvo em cache do lado do
        /// cliente no cache.
        /// <para>
        /// Esta data será comparada com a data presente em <see
        /// cref="Resposta.dttUltimaModificacao"/>, e no caso deste recurso ainda não ter sido
        /// alterado, ele não necessita de ser enviado para o cliente. Economizando assim recursos
        /// valiosos de rede e processamento. Tornando o sistema mais rápido e robusto.
        /// </para>
        /// </summary>
        public DateTime dttUltimaModificacao
        {
            get
            {
                if (_dttUltimaModificacao != DateTime.MinValue)
                {
                    return _dttUltimaModificacao;
                }

                _dttUltimaModificacao = this.getDttUltimaModificacao();

                return _dttUltimaModificacao;
            }
        }

        /// <summary>
        /// Indica o método que o cliente utilizou e aguarda a resposta.
        /// </summary>
        public EnmMetodo enmMetodo
        {
            get
            {
                if (_enmMetodo != EnmMetodo.NONE)
                {
                    return _enmMetodo;
                }

                _enmMetodo = this.getEnmMetodo();

                return _enmMetodo;
            }
        }

        public FormData frmData
        {
            get
            {
                if (_frmData != null)
                {
                    return _frmData;
                }

                _frmData = this.getFrmData();

                return _frmData;
            }
        }

        /// <summary>
        /// Caso esta solicitação esteja utilizando o método POST e o tipo de dados seja JSON,
        /// retorna o valor do objeto passado no corpo da solicitação.
        /// </summary>
        public string jsn
        {
            get
            {
                if (_jsn != null)
                {
                    return _jsn;
                }

                _jsn = this.getJsn();

                return _jsn;
            }
        }

        public List<Cookie> lstObjCookie
        {
            get
            {
                if (_lstObjCookie != null)
                {
                    return _lstObjCookie;
                }

                _lstObjCookie = this.getLstObjCookie();

                return _lstObjCookie;
            }
        }

        public Cliente objCliente
        {
            get
            {
                return _objCliente;
            }

            private set
            {
                _objCliente = value;
            }
        }

        /// <summary>
        /// Usuário referênte a esta solicitação.
        /// </summary>
        public UsuarioDominio objUsuario
        {
            get
            {
                if (_objUsuario != null)
                {
                    return _objUsuario;
                }

                _objUsuario = this.getObjUsuario();

                return _objUsuario;
            }
        }

        /// <summary>
        /// Texto contendo o conteúdo desta solicitação. O conteúdo é a parte final da solicitação,
        /// logo após os valores dos fields do head dessa.
        /// </summary>
        public string strConteudo
        {
            get
            {
                if (_strConteudo != null)
                {
                    return _strConteudo;
                }

                _strConteudo = this.getStrConteudo();

                return _strConteudo;
            }
        }

        /// <summary>
        /// Retorna a primeira linha do header, contendo o seu cabeçalho.
        /// </summary>
        public string strHeaderLinhaCabecalho
        {
            get
            {
                if (_strHeaderLinhaCabecalho != null)
                {
                    return _strHeaderLinhaCabecalho;
                }

                _strHeaderLinhaCabecalho = this.getStrHeaderLinhaCabecalho();

                return _strHeaderLinhaCabecalho;
            }
        }

        /// <summary>
        /// Indica o endereço completo que o usuário está acessando.
        /// </summary>
        public string strHost
        {
            get
            {
                if (_strHost != null)
                {
                    return _strHost;
                }

                _strHost = this.getStrHost();

                return _strHost;
            }
        }

        /// <summary>
        /// Página solicitada pelo usuário.
        /// </summary>
        public string strPagina
        {
            get
            {
                if (_strPagina != null)
                {
                    return _strPagina;
                }

                _strPagina = this.getStrPagina();

                return _strPagina;
            }
        }

        /// <summary>
        /// Página que foi solicitada pelo cliente contendo os possíveis parâmetros GET.
        /// </summary>
        public string strPaginaCompleta
        {
            get
            {
                if (_strPaginaCompleta != null)
                {
                    return _strPaginaCompleta;
                }

                _strPaginaCompleta = this.getStrPaginaCompleta();

                return _strPaginaCompleta;
            }
        }

        /// <summary>
        /// Código único que identifica o cliente. Todas as solicitações enviadas pelo cliente
        /// através de um mesmo browser terão o mesmo valor.
        /// <para>
        /// Este valor é salvo no browser do cliente através de um cookie com o nome de <see cref="SrvHttpBase.STR_COOKIE_SESSAO"/>.
        /// </para>
        /// <para>Esse cookie fica salvo no browser do cliente durante 8 (oito) horas.</para>
        /// </summary>
        public string strSessao
        {
            get
            {
                if (_strSessao != null)
                {
                    return _strSessao;
                }

                _strSessao = this.getStrCookieValor(SrvHttpBase.STR_COOKIE_SESSAO);

                return _strSessao;
            }
        }

        internal byte[] arrBteMsgCliente
        {
            get
            {
                if (_arrBteMsgCliente != null)
                {
                    return _arrBteMsgCliente;
                }

                _arrBteMsgCliente = this.getArrBteMsgCliente();

                return _arrBteMsgCliente;
            }
        }

        private byte[] arrBteConteudo
        {
            get
            {
                if (_arrBteConteudo != null)
                {
                    return _arrBteConteudo;
                }

                _arrBteConteudo = this.getArrBteConteudo();

                return _arrBteConteudo;
            }
        }

        private decimal decHttpVersao
        {
            get
            {
                if (_decHttpVersao > 0)
                {
                    return _decHttpVersao;
                }

                _decHttpVersao = this.getDecHttpVersao();

                return _decHttpVersao;
            }
        }

        private Dictionary<string, string> dicPost
        {
            get
            {
                if (_dicPost != null)
                {
                    return _dicPost;
                }

                _dicPost = this.getDicPost();

                return _dicPost;
            }
        }

        private List<Field> lstObjField
        {
            get
            {
                if (_lstObjField != null)
                {
                    return _lstObjField;
                }

                _lstObjField = this.getLstObjField();

                return _lstObjField;
            }
        }

        private NetworkStream nts
        {
            get
            {
                if (_nts != null)
                {
                    return _nts;
                }

                _nts = this.objCliente?.tcpClient?.GetStream();

                return _nts;
            }
        }

        private SslStream objSslStream
        {
            get
            {
                if (_objSslStream != null)
                {
                    return _objSslStream;
                }

                _objSslStream = new SslStream(this.objCliente?.tcpClient?.GetStream());

                return _objSslStream;
            }
        }

        private string strMsgCliente
        {
            get
            {
                if (_strMsgCliente != null)
                {
                    return _strMsgCliente;
                }

                _strMsgCliente = this.getStrMsgCliente();

                return _strMsgCliente;
            }
        }

        #endregion Atributos

        #region Construtores

        internal Solicitacao(Cliente objCliente)
        {
            this.objCliente = objCliente;
        }

        #endregion Construtores

        #region Métodos

        public bool getBooGetValue(string strGetParam)
        {
            return Utils.getBoo(this.getStrGetValue(strGetParam));
        }

        public decimal getDecGetValue(string strGetParam)
        {
            decimal.TryParse(this.getStrGetValue(strGetParam), out decimal decValueResultado);

            return decValueResultado;
        }

        /// <summary>
        /// Retorna o valor do parâmetro GET caso esteja presente na URL solicitada ou null caso não encontre.
        /// </summary>
        public DateTime getDttGetValue(string strGetParam)
        {
            string strResultado = this.getStrGetValue(strGetParam);

            if (string.IsNullOrEmpty(strResultado))
            {
                return DateTime.MinValue;
            }

            return Convert.ToDateTime(strResultado);
        }

        public int getIntGetValue(string strGetParam)
        {
            return (int)this.getDecGetValue(strGetParam);
        }

        /// <summary>
        /// Retorna o valor do cookie que contém o nome indicado em <paramref name="strCookieNome"/>.
        /// <para>Caso não haja nenhum cookie com este nome retorna null.</para>
        /// </summary>
        /// <param name="strCookieNome"></param>
        /// <returns>Valor do cookie que contém o nome indicado em <paramref name="strCookieNome"/>.</returns>
        public string getStrCookieValor(string strCookieNome)
        {
            if (string.IsNullOrEmpty(strCookieNome))
            {
                return null;
            }

            if (this.lstObjCookie == null)
            {
                return null;
            }

            if (this.lstObjCookie.Count < 1)
            {
                return null;
            }

            foreach (var objCookie in this.lstObjCookie)
            {
                if (objCookie == null)
                {
                    continue;
                }

                if (!strCookieNome.Equals(objCookie.strNome))
                {
                    continue;
                }

                return objCookie.strValor;
            }

            return null;
        }

        /// <summary>
        /// Retorna o valor do parâmetro GET caso esteja presente na URL solicitada ou null caso não encontre.
        /// </summary>
        public string getStrGetValue(string strGetParam)
        {
            if (string.IsNullOrEmpty(strGetParam))
            {
                return null;
            }

            string urlPagina = this.strPaginaCompleta;

            if (string.IsNullOrEmpty(urlPagina))
            {
                return null;
            }

            if (urlPagina.StartsWith("/"))
            {
                urlPagina = "http://localhost" + urlPagina;
            }

            var uri = new Uri(urlPagina);

            return HttpUtility.ParseQueryString(uri.Query).Get(strGetParam);
        }

        /// <summary>
        /// Retorna o valor da linha do cabeçalho que tenha o nome indicado no parâmetro.
        /// </summary>
        /// <param name="strHeaderNome">Nome do header que se espera o nome.</param>
        /// <returns>Retorna o valor do header, caso seja encontrado.</returns>
        public string getStrHeaderValor(string strHeaderNome)
        {
            if (string.IsNullOrEmpty(strHeaderNome))
            {
                return null;
            }

            if (this.lstObjField == null)
            {
                return null;
            }

            if (this.lstObjField.Count < 1)
            {
                return null;
            }

            foreach (Field objField in this.lstObjField)
            {
                if (objField == null)
                {
                    continue;
                }

                if (string.IsNullOrEmpty(objField.strHeaderLinha))
                {
                    continue;
                }

                if (!objField.strHeaderLinha.ToLower().StartsWith(strHeaderNome.ToLower()))
                {
                    continue;
                }

                return objField.strValor;
            }

            return null;
        }

        public string getStrPostValue(string strPostParam)
        {
            if (string.IsNullOrWhiteSpace(strPostParam))
            {
                return null;
            }

            if (this.dicPost == null)
            {
                return null;
            }

            string strResultado = null;

            this.dicPost.TryGetValue(strPostParam, out strResultado);

            return strResultado;
        }

        internal bool validar()
        {
            if (this.enmMetodo.Equals(EnmMetodo.DESCONHECIDO))
            {
                return false;
            }

            return true;
        }

        private byte[] getArrBteConteudo()
        {
            if (this.arrBteMsgCliente == null)
            {
                return null;
            }

            if (this.arrBteMsgCliente.Length < 1)
            {
                return null;
            }

            int intIndexOf = Utils.indexOf(this.arrBteMsgCliente, Encoding.UTF8.GetBytes(STR_BODY_DIVISION));

            intIndexOf += 4;

            if (intIndexOf >= this.arrBteMsgCliente.Length)
            {
                return null;
            }

            return this.arrBteMsgCliente.Skip(intIndexOf).Take(this.arrBteMsgCliente.Length - intIndexOf).ToArray();
        }

        private byte[] getArrBteMsgCliente()
        {
            if (this.nts != null)
            {
                return this.getArrBteMsgClienteNts();
            }

            if (this.objSslStream != null)
            {
                return this.getArrBteMsgClienteObjSslStream();
            }

            return null;
        }

        private bool getArrBteMsgClienteCompleto(MemoryStream mmsMsgClienteParcial)
        {
            if (mmsMsgClienteParcial == null)
            {
                return false;
            }

            if (mmsMsgClienteParcial.Length < 1)
            {
                return false;
            }

            var strMsgClienteParcial = Encoding.UTF8.GetString(mmsMsgClienteParcial.ToArray());

            if (string.IsNullOrEmpty(strMsgClienteParcial))
            {
                return false;
            }

            if (!strMsgClienteParcial.ToLower().StartsWith("post"))
            {
                return true;
            }

            if (!strMsgClienteParcial.ToLower().Contains("content-length"))
            {
                return true;
            }

            var intContentLength = this.getIntMsgClienteContentLength(strMsgClienteParcial);

            var intContentLengthRecebido = this.getIntMsgClienteContentLengthRecebido(mmsMsgClienteParcial);

            if (intContentLength.Equals(intContentLengthRecebido))
            {
                return true;
            }

            return false;
        }

        private byte[] getArrBteMsgClienteNts()
        {
            if (!this.nts.CanRead)
            {
                return null;
            }

            var arrBte = new byte[1024000];
            var intQuantidade = 0;
            var mmsMsgCliente = new MemoryStream();

            do
            {
                if (!this.nts.DataAvailable)
                {
                    Thread.Sleep(50);
                    continue;
                }

                intQuantidade = this.nts.Read(arrBte, 0, arrBte.Length);

                mmsMsgCliente.Write(arrBte, 0, intQuantidade);
            }
            while (!this.getArrBteMsgClienteCompleto(mmsMsgCliente));

            return mmsMsgCliente.ToArray();
        }

        private byte[] getArrBteMsgClienteObjSslStream()
        {
            byte[] buffer = new byte[2048];
            int bytes = -1;

            this.objSslStream.AuthenticateAsServer(new X509Certificate("certificado.pfx", "123"));

            bytes = this.objSslStream.Read(buffer, 0, buffer.Length);

            Console.WriteLine(Encoding.ASCII.GetString(buffer, 0, bytes));

            return buffer;
        }

        private decimal getDecHttpVersao()
        {
            if (string.IsNullOrEmpty(this.strHeaderLinhaCabecalho))
            {
                return 0;
            }

            string[] arrStr = this.strHeaderLinhaCabecalho.Split(" ".ToCharArray());

            if (arrStr == null)
            {
                return 0;
            }

            if (arrStr.Length < 3)
            {
                return 0;
            }

            return Convert.ToDecimal(arrStr[2].ToLower().Replace("http/", null), CultureInfo.CreateSpecificCulture("en-USA"));
        }

        private Dictionary<string, string> getDicPost()
        {
            if (!EnmMetodo.POST.Equals(this.enmMetodo))
            {
                return null;
            }

            if (string.IsNullOrEmpty(this.strConteudo))
            {
                return null;
            }

            string[] arrStrKeyValue = this.strConteudo.Split("&".ToCharArray());

            if (arrStrKeyValue == null)
            {
                return null;
            }

            var dicResultado = new Dictionary<string, string>();

            foreach (string strKeyValue in arrStrKeyValue)
            {
                this.getDicPost(dicResultado, strKeyValue);
            }

            return dicResultado;
        }

        private void getDicPost(Dictionary<string, string> dicResultado, string strKeyValue)
        {
            if (string.IsNullOrEmpty(strKeyValue))
            {
                return;
            }

            strKeyValue = HttpUtility.UrlDecode(strKeyValue);

            var intIndex = strKeyValue.IndexOf("=");

            if (intIndex < 0)
            {
                return;
            }

            var strKey = strKeyValue.Substring(0, intIndex);
            var strValue = strKeyValue.Substring(++intIndex, (strKeyValue.Length - intIndex));

            dicResultado.Add(strKey, strValue);
        }

        private DateTime getDttUltimaModificacao()
        {
            if (this.lstObjField == null)
            {
                return DateTime.MinValue;
            }

            foreach (Field objField in this.lstObjField)
            {
                if (objField == null)
                {
                    continue;
                }

                if (!Field.EnmTipo.IF_MODIFIED_SINCE.Equals(objField.enmTipo))
                {
                    continue;
                }

                return objField.dttValor;
            }

            return DateTime.MinValue;
        }

        private EnmMetodo getEnmMetodo()
        {
            if (string.IsNullOrEmpty(this.strHeaderLinhaCabecalho))
            {
                return EnmMetodo.DESCONHECIDO;
            }

            if (this.strHeaderLinhaCabecalho.ToLower().Contains("get"))
            {
                return EnmMetodo.GET;
            }

            if (this.strHeaderLinhaCabecalho.ToLower().Contains("post"))
            {
                return EnmMetodo.POST;
            }

            if (this.strHeaderLinhaCabecalho.ToLower().Contains("options"))
            {
                return EnmMetodo.OPTIONS;
            }

            return EnmMetodo.DESCONHECIDO;
        }

        private FormData getFrmData()
        {
            string strContentType = this.getStrHeaderValor("Content-Type");

            if (string.IsNullOrEmpty(strContentType))
            {
                return null;
            }

            if (!strContentType.ToLower().Contains("multipart/form-data"))
            {
                return null;
            }

            if (this.arrBteConteudo == null)
            {
                return null;
            }

            return new FormData(this.arrBteConteudo);
        }

        private int getIntMsgClienteContentLength(string strMsgClienteParcial)
        {
            var intIndexOfStart = strMsgClienteParcial.ToLower().IndexOf("content-length: ");

            if (intIndexOfStart < 0)
            {
                return 0;
            }

            intIndexOfStart += "content-length: ".Length;

            var intIndexOfEnd = strMsgClienteParcial.IndexOf(Environment.NewLine, intIndexOfStart);

            if (intIndexOfEnd < 0)
            {
                return 0;
            }

            var intResultado = 0;

            int.TryParse(strMsgClienteParcial.Substring(intIndexOfStart, (intIndexOfEnd - intIndexOfStart)), out intResultado);

            return intResultado;
        }

        private int getIntMsgClienteContentLengthRecebido(MemoryStream mmsMsgClienteParcial)
        {
            var intIndexOfStart = Utils.indexOf(mmsMsgClienteParcial.ToArray(), Encoding.UTF8.GetBytes(STR_BODY_DIVISION));

            if (intIndexOfStart < 0)
            {
                return 0;
            }

            intIndexOfStart += 4;

            return (int)(mmsMsgClienteParcial.Length - intIndexOfStart);
        }

        private string getJsn()
        {
            if (!EnmMetodo.POST.Equals(this.enmMetodo))
            {
                return null;
            }

            if (this.lstObjField == null)
            {
                return null;
            }

            if (this.lstObjField.Count < 1)
            {
                return null;
            }

            return this.lstObjField[this.lstObjField.Count - 1].strHeaderLinha;
        }

        private List<Cookie> getLstObjCookie()
        {
            var lstObjCookieResultado = new List<Cookie>();

            foreach (var objField in this.lstObjField)
            {
                this.getLstObjCookie(lstObjCookieResultado, objField);
            }

            return lstObjCookieResultado;
        }

        private void getLstObjCookie(List<Cookie> lstObjCookie, Field objField)
        {
            if (lstObjCookie == null)
            {
                return;
            }

            if (objField == null)
            {
                return;
            }

            if (!Field.EnmTipo.COOKIE.Equals(objField.enmTipo))
            {
                return;
            }

            if (string.IsNullOrEmpty(objField.strValor))
            {
                return;
            }

            var arrStrCookie = objField.strValor.Split(';');

            foreach (var strCookie in arrStrCookie)
            {
                this.getLstObjCookie(lstObjCookie, strCookie);
            }
        }

        private void getLstObjCookie(List<Cookie> lstObjCookie, string strCookie)
        {
            if (string.IsNullOrWhiteSpace(strCookie))
            {
                return;
            }

            if (strCookie.IndexOf('=') < 0)
            {
                return;
            }

            var arrStrValor = strCookie.Split('=');

            if (arrStrValor.Length < 2)
            {
                return;
            }

            lstObjCookie.Add(new Cookie(arrStrValor[0], arrStrValor[1]));
        }

        private List<Field> getLstObjField()
        {
            if (string.IsNullOrEmpty(this.strMsgCliente))
            {
                return null;
            }

            var arrStrLinha = this.strMsgCliente.Split((new string[] { "\r\n", "\n" }), StringSplitOptions.None);

            if (arrStrLinha == null)
            {
                return null;
            }

            if (arrStrLinha.Length < 1)
            {
                return null;
            }

            var lstObjFieldResultado = new List<Field>();

            foreach (string strlinha in arrStrLinha)
            {
                this.getLstObjField(lstObjFieldResultado, strlinha);
            }

            return lstObjFieldResultado;
        }

        private void getLstObjField(List<Field> lstObjField, string strLinha)
        {
            if (string.IsNullOrEmpty(strLinha))
            {
                return;
            }

            var objFieldHeader = new Field();

            objFieldHeader.objSolicitacao = this;
            objFieldHeader.strHeaderLinha = strLinha;

            lstObjField.Add(objFieldHeader);
        }

        private UsuarioDominio getObjUsuario()
        {
            if (string.IsNullOrEmpty(this.strSessao))
            {
                return null;
            }

            return AppWebBase.i.getObjUsuario(this.strSessao);
        }

        private string getStrConteudo()
        {
            if (this.arrBteConteudo == null)
            {
                return null;
            }

            return Encoding.UTF8.GetString(this.arrBteConteudo);
        }

        private string getStrHeaderLinhaCabecalho()
        {
            if (this.lstObjField == null)
            {
                return null;
            }

            if (this.lstObjField.Count < 1)
            {
                return null;
            }

            return this.lstObjField[0].strHeaderLinha;
        }

        private string getStrHost()
        {
            foreach (Field objField in this.lstObjField)
            {
                if (objField == null)
                {
                    continue;
                }

                if (!Field.EnmTipo.HOST.Equals(objField.enmTipo))
                {
                    continue;
                }

                return objField.strValor;
            }

            return null;
        }

        private string getStrMsgCliente()
        {
            if (this.arrBteMsgCliente == null)
            {
                return null;
            }

            if (this.arrBteMsgCliente.Length < 1)
            {
                return null;
            }

            return Encoding.UTF8.GetString(this.arrBteMsgCliente);
        }

        private string getStrPagina()
        {
            if (string.IsNullOrEmpty(this.strPaginaCompleta))
            {
                return null;
            }

            if (this.strPaginaCompleta.IndexOf("?") < 0)
            {
                return this.strPaginaCompleta;
            }

            return this.strPaginaCompleta.Split('?')[0];
        }

        private string getStrPaginaCompleta()
        {
            if (string.IsNullOrEmpty(this.strHeaderLinhaCabecalho))
            {
                return null;
            }

            string[] arrStr = this.strHeaderLinhaCabecalho.Split(" ".ToCharArray());

            if (arrStr == null)
            {
                return null;
            }

            if (arrStr.Length < 2)
            {
                return null;
            }

            return arrStr[1];
        }

        private void processarHeaderCookie(Field objFieldHeader)
        {
            if (objFieldHeader == null)
            {
                return;
            }

            if (string.IsNullOrEmpty(objFieldHeader.strValor))
            {
                return;
            }

            if (objFieldHeader.strValor.IndexOf('=') < 0)
            {
                return;
            }

            if (objFieldHeader.strValor.Split('=').Length < 2)
            {
                return;
            }

            Cookie objCookie = new Cookie(objFieldHeader.strValor.Split('=')[0], objFieldHeader.strValor.Split('=')[1]);

            this.lstObjCookie.Add(objCookie);
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}