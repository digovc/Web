using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Web;
using NetZ.SistemaBase;

namespace NetZ.Web.Server
{
    /// <summary>
    /// Classe que abstrae cada solicitação que foi encaminhada pelo cliente e precisa ser respondida.
    /// <para>
    /// Esta solicitação deve ser verificada em <see cref="AppWeb.responder(Solicitacao)"/>, para
    /// que seja construída a resposta adequeda aguardada pelo cliente.
    /// </para>
    /// <para>
    /// Um dos pontos mais cruciais do sistema para ser estável, consumir poucos recursos é a
    /// verificação da propriedade <see cref="dttUltimaModificacao"/> da instância de cada
    /// solicitação, para garantir que recursos que não forão alterados não sejam processados, nem
    /// enviados para o cliente.
    /// </para>
    /// <para>
    /// Quando esta solicitação se tratar de recursos estáticos, que deverão estar todos presentes
    /// na pasta "res", dentro da localidade onde está rodando este servidor WEB serão tratador automaticamente.
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
            POST,
        }

        #endregion Constantes

        #region Atributos

        private decimal _decHttpVersao;
        private Dictionary<string, string> _dicPost;
        private DateTime _dttUltimaModificacao = DateTime.MinValue;
        private EnmMetodo _enmMetodo = EnmMetodo.NONE;
        private string _jsn;
        private List<Cookie> _lstObjCookie;
        private List<Field> _lstObjField;
        private NetworkStream _nts;
        private string _strConteudo;
        private string _strHeaderLinhaCabecalho;
        private string _strHost;
        private string _strMsgCliente;
        private string _strPagina;
        private string _strSessaoId;
        private Usuario _usr;

        /// <summary>
        /// Caso esta seja uma solicitação do tipo POST, este retorna os valores dos parâmetros
        /// passados na solicitação.
        /// </summary>
        public Dictionary<string, string> dicPost
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_dicPost != null)
                    {
                        return _dicPost;
                    }

                    _dicPost = this.getDicPost();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _dicPost;
            }
        }

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
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_dttUltimaModificacao != DateTime.MinValue)
                    {
                        return _dttUltimaModificacao;
                    }

                    _dttUltimaModificacao = this.getDttUltimaModificacao();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

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
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_enmMetodo != EnmMetodo.NONE)
                    {
                        return _enmMetodo;
                    }

                    _enmMetodo = this.getEnmMetodo();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _enmMetodo;
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
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_jsn != null)
                    {
                        return _jsn;
                    }

                    _jsn = this.getJsn();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _jsn;
            }
        }

        public List<Cookie> lstObjCookie
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

                    _lstObjCookie = this.getLstObjCookie();
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

        /// <summary>
        /// Texto contendo o conteúdo desta solicitação. O conteúdo é a parte final da solicitação,
        /// logo após os valores dos fields do head dessa.
        /// </summary>
        public string strConteudo
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_strConteudo != null)
                    {
                        return _strConteudo;
                    }

                    _strConteudo = this.getStrConteudo();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

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
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_strHeaderLinhaCabecalho != null)
                    {
                        return _strHeaderLinhaCabecalho;
                    }

                    _strHeaderLinhaCabecalho = this.getStrHeaderLinhaCabecalho();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

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
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_strHost != null)
                    {
                        return _strHost;
                    }

                    _strHost = this.getStrHost();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _strHost;
            }
        }

        /// <summary>
        /// Página que foi solicitada pelo cliente.
        /// </summary>
        public string strPagina
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_strPagina != null)
                    {
                        return _strPagina;
                    }

                    _strPagina = this.getStrPagina();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _strPagina;
            }
        }

        /// <summary>
        /// Código único que identifica o cliente. Todas as solicitações enviadas pelo cliente
        /// através de um mesmo browser terão o mesmo valor.
        /// <para>
        /// Este valor é salvo no browser do cliente através de um cookie com o nome de <see cref="ServerHttp.STR_COOKIE_SESSAO_ID_NOME"/>.
        /// </para>
        /// <para>Esse cookie fica salvo no browser do cliente durante 8 (oito) horas.</para>
        /// </summary>
        public string strSessaoId
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_strSessaoId != null)
                    {
                        return _strSessaoId;
                    }

                    _strSessaoId = this.getStrCookieValor(ServerHttp.STR_COOKIE_SESSAO_ID_NOME);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _strSessaoId;
            }
        }

        /// <summary>
        /// Usuário referênte a esta solicitação.
        /// </summary>
        public Usuario usr
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_usr != null)
                    {
                        return _usr;
                    }

                    _usr = this.getUsr();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _usr;
            }
        }

        private decimal decHttpVersao
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_decHttpVersao > 0)
                    {
                        return _decHttpVersao;
                    }

                    _decHttpVersao = this.getDecHttpVersao();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _decHttpVersao;
            }
        }

        private List<Field> lstObjField
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_lstObjField != null)
                    {
                        return _lstObjField;
                    }

                    _lstObjField = this.getLstObjField();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _lstObjField;
            }
        }

        private NetworkStream nts
        {
            get
            {
                return _nts;
            }

            set
            {
                _nts = value;
            }
        }

        private string strMsgCliente
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_strMsgCliente != null)
                    {
                        return _strMsgCliente;
                    }

                    _strMsgCliente = this.getStrMsgCliente();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _strMsgCliente;
            }
        }

        #endregion Atributos

        #region Construtores

        internal Solicitacao(NetworkStream nts)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.nts = nts;
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
        /// Retorna o valor do cookie que contém o nome indicado em <paramref name="strCookieNome"/>.
        /// <para>Caso não haja nenhum cookie com este nome retorna null.</para>
        /// </summary>
        /// <param name="strCookieNome"></param>
        /// <returns>Valor do cookie que contém o nome indicado em <paramref name="strCookieNome"/>.</returns>
        public string getStrCookieValor(string strCookieNome)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
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

                foreach (Cookie objCookie in this.lstObjCookie)
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
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion Ações

            return null;
        }

        /// <summary>
        /// Retorna o valor do parâmetro GET caso esteja presente na URL solicitada ou null caso não encontre.
        /// </summary>
        public string getStrGetValue(string strGetParam)
        {
            #region Variáveis

            string urlPagina;
            Uri uri;

            #endregion Variáveis

            #region Ações

            try
            {
                if (string.IsNullOrEmpty(strGetParam))
                {
                    return null;
                }

                urlPagina = this.strPagina;

                if (string.IsNullOrEmpty(urlPagina))
                {
                    return null;
                }

                if (urlPagina.StartsWith("/"))
                {
                    urlPagina = "http://localhost" + urlPagina;
                }

                uri = new Uri(urlPagina);

                return HttpUtility.ParseQueryString(uri.Query).Get(strGetParam);
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
        /// Retorna o valor da linha do cabeçalho que tenha o nome indicado no parâmetro.
        /// </summary>
        /// <param name="strHeaderNome">Nome do header que se espera o nome.</param>
        /// <returns>Retorna o valor do header, caso seja encontrado.</returns>
        public string getStrHeaderValor(string strHeaderNome)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
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
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion Ações
        }

        private decimal getDecHttpVersao()
        {
            #region Variáveis

            string[] arrStr;

            #endregion Variáveis

            #region Ações

            try
            {
                if (string.IsNullOrEmpty(this.strHeaderLinhaCabecalho))
                {
                    return 0;
                }

                arrStr = this.strHeaderLinhaCabecalho.Split(" ".ToCharArray());

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
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion Ações
        }

        private Dictionary<string, string> getDicPost()
        {
            #region Variáveis

            Dictionary<string, string> dicResultado;
            string[] arrStrKeyValue;

            #endregion Variáveis

            #region Ações

            try
            {
                if (!EnmMetodo.POST.Equals(this.enmMetodo))
                {
                    return null;
                }

                if (string.IsNullOrEmpty(this.strConteudo))
                {
                    return null;
                }

                arrStrKeyValue = this.strConteudo.Split("&".ToCharArray());

                if (arrStrKeyValue == null)
                {
                    return null;
                }

                dicResultado = new Dictionary<string, string>();

                foreach (string strKeyValue in arrStrKeyValue)
                {
                    this.getDicPost(dicResultado, strKeyValue);
                }

                return dicResultado;
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

        private void getDicPost(Dictionary<string, string> dicResultado, string strKeyValue)
        {
            #region Variáveis

            string[] arrStrKeyValue;

            #endregion Variáveis

            #region Ações

            try
            {
                if (string.IsNullOrEmpty(strKeyValue))
                {
                    return;
                }

                strKeyValue = HttpUtility.UrlDecode(strKeyValue);

                arrStrKeyValue = strKeyValue.Split("=".ToCharArray());

                if (arrStrKeyValue == null)
                {
                    return;
                }

                if (arrStrKeyValue.Length < 2)
                {
                    return;
                }

                dicResultado.Add(arrStrKeyValue[0], arrStrKeyValue[1]);
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

        private DateTime getDttUltimaModificacao()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
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

                    if (!Field.EnmTipo.IF_UNMODIFIED_SINCE.Equals(objField.enmTipo))
                    {
                        continue;
                    }

                    return objField.dttValor;
                }

                return DateTime.MinValue;
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

        private EnmMetodo getEnmMetodo()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
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

                return EnmMetodo.DESCONHECIDO;
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

        private string getJsn()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
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
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion Ações
        }

        private List<Cookie> getLstObjCookie()
        {
            #region Variáveis

            List<Cookie> lstObjCookieResultado;

            #endregion Variáveis

            #region Ações

            try
            {
                lstObjCookieResultado = new List<Cookie>();

                foreach (Field objField in this.lstObjField)
                {
                    this.getLstObjCookie(lstObjCookieResultado, objField);
                }

                return lstObjCookieResultado;
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

        private void getLstObjCookie(List<Cookie> lstObjCookieResultado, Field objField)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (lstObjCookieResultado == null)
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

                if (objField.strValor.IndexOf('=') < 0)
                {
                    return;
                }

                if (objField.strValor.Split('=').Length < 2)
                {
                    return;
                }

                lstObjCookieResultado.Add(new Cookie(objField.strValor.Split('=')[0], objField.strValor.Split('=')[1]));
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

        private List<Field> getLstObjField()
        {
            #region Variáveis

            string[] arrStrLinha;
            List<Field> lstObjFieldResultado;

            #endregion Variáveis

            #region Ações

            try
            {
                if (string.IsNullOrEmpty(this.strMsgCliente))
                {
                    return null;
                }

                arrStrLinha = this.strMsgCliente.Split((new string[] { "\r\n", "\n" }), StringSplitOptions.None);

                if (arrStrLinha == null)
                {
                    return null;
                }

                if (arrStrLinha.Length < 1)
                {
                    return null;
                }

                lstObjFieldResultado = new List<Field>();

                foreach (string strlinha in arrStrLinha)
                {
                    this.getLstObjField(lstObjFieldResultado, strlinha);
                }

                return lstObjFieldResultado;
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

        private void getLstObjField(List<Field> lstObjField, string strLinha)
        {
            #region Variáveis

            Field objFieldHeader;

            #endregion Variáveis

            #region Ações

            try
            {
                if (string.IsNullOrEmpty(strLinha))
                {
                    return;
                }

                objFieldHeader = new Field();

                objFieldHeader.objSolicitacao = this;
                objFieldHeader.strHeaderLinha = strLinha;

                lstObjField.Add(objFieldHeader);
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

        private string getStrConteudo()
        {
            #region Variáveis

            bool booConteudo;
            string[] arrStrLinha;
            string strResultado;

            #endregion Variáveis

            #region Ações

            try
            {
                if (string.IsNullOrEmpty(this.strMsgCliente))
                {
                    return null;
                }

                arrStrLinha = this.strMsgCliente.Split((new string[] { "\r\n", "\n" }), StringSplitOptions.None);

                if (arrStrLinha == null)
                {
                    return null;
                }

                booConteudo = false;
                strResultado = string.Empty;

                foreach (string strLinha in arrStrLinha)
                {
                    if (string.IsNullOrEmpty(strLinha))
                    {
                        booConteudo = true;
                        continue;
                    }

                    if (!booConteudo)
                    {
                        continue;
                    }

                    strResultado += strLinha;
                }

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

        private string getStrHeaderLinhaCabecalho()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
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
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion Ações
        }

        private string getStrHost()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
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
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion Ações
        }

        private string getStrMsgCliente()
        {
            #region VARIÁVEIS

            byte[] arrBte;
            byte[] arrBte2;
            int intQtd;
            StringBuilder stbMsg;

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
                if (!this.nts.CanRead)
                {
                    return null;
                }

                while (!this.nts.DataAvailable)
                {
                    Thread.Sleep(250);
                }

                arrBte = new byte[1024];
                stbMsg = new StringBuilder();

                do
                {
                    intQtd = this.nts.Read(arrBte, 0, arrBte.Length);

                    arrBte2 = new byte[intQtd];

                    Array.Copy(arrBte, arrBte2, intQtd);

                    stbMsg.Append(Encoding.UTF8.GetString(arrBte2));
                } while (this.nts.DataAvailable);

                return stbMsg.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion AÇÕES
        }

        private string getStrPagina()
        {
            #region Variáveis

            string[] arrStr;

            #endregion Variáveis

            #region Ações

            try
            {
                if (string.IsNullOrEmpty(this.strHeaderLinhaCabecalho))
                {
                    return null;
                }

                arrStr = this.strHeaderLinhaCabecalho.Split(" ".ToCharArray());

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
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion Ações
        }

        private Usuario getUsr()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (string.IsNullOrEmpty(this.strSessaoId))
                {
                    return null;
                }

                return AppWeb.i.getUsr(this.strSessaoId);
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

        private void processarHeaderCookie(Field objFieldHeader)
        {
            #region Variáveis

            Cookie objCookie;

            #endregion Variáveis

            #region Ações

            try
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

                objCookie = new Cookie(objFieldHeader.strValor.Split('=')[0], objFieldHeader.strValor.Split('=')[1]);

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

        private bool validarDados()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (this.nts == null)
                {
                    return false;
                }

                if (string.IsNullOrEmpty(this.strMsgCliente))
                {
                    return false;
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

            return true;
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}