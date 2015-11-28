using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Sockets;
using System.Text;
using System.Threading;
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
        private DateTime _dttUltimaModificacao = DateTime.MinValue;
        private EnmMetodo _enmMetodo = EnmMetodo.NONE;
        private List<Cookie> _lstObjCookie;
        private List<Field> _lstObjField;
        private NetworkStream _nts;
        private string _strHost;
        private string _strMsgCliente;
        private string _strPagina;
        private string _strSessaoId;
        private Usuario _usr;

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
                return _dttUltimaModificacao;
            }

            set
            {
                _dttUltimaModificacao = value;
            }
        }

        /// <summary>
        /// Indica o método que o cliente utilizou e aguarda a resposta.
        /// </summary>
        public EnmMetodo enmMetodo
        {
            get
            {
                return _enmMetodo;
            }

            private set
            {
                _enmMetodo = value;
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
                return _strPagina;
            }

            private set
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    _strPagina = value;

                    if (string.IsNullOrEmpty(_strPagina))
                    {
                        return;
                    }

                    _strPagina = _strPagina.ToLower();
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
        /// Código único que identifica o cliente. Todas as solicitações enviadas pelo cliente
        /// através de um mesmo browser terão o mesmo valor.
        /// <para>
        /// Este valor é salvo no browser do cliente através de um cookie com o nome de <see cref="Server.STR_COOKIE_SESSAO_ID_NOME"/>.
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

                    _strSessaoId = this.getStrCookieValor(Server.STR_COOKIE_SESSAO_ID_NOME);
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

                    if (_usr != null)
                    {
                        return _usr;
                    }

                    _usr = new Usuario(this.strSessaoId);

                    AppWeb.i.addUsr(_usr);
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
                return _decHttpVersao;
            }

            set
            {
                _decHttpVersao = value;
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

                    _lstObjField = new List<Field>();
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

        internal void processar()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (!this.validar())
                {
                    return;
                }

                this.processarHeader();
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

        private void processarHeader()
        {
            #region Variáveis

            string[] arrStrLinha;

            #endregion Variáveis

            #region Ações

            try
            {
                if (string.IsNullOrEmpty(this.strMsgCliente))
                {
                    return;
                }

                arrStrLinha = this.strMsgCliente.Split(Environment.NewLine.ToCharArray());

                if (arrStrLinha == null)
                {
                    return;
                }

                if (arrStrLinha.Length < 1)
                {
                    return;
                }

                this.processarHeaderMetodo(arrStrLinha[0]);
                this.processarHeaderPagina(arrStrLinha[0]);
                this.processarHeaderHttpVersao(arrStrLinha[0]);

                arrStrLinha[0] = null;

                foreach (string strlinha in arrStrLinha)
                {
                    if (string.IsNullOrEmpty(strlinha))
                    {
                        continue;
                    }

                    this.processarHeader(strlinha);
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

        private void processarHeader(string strLinha)
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

                objFieldHeader.processar();

                this.lstObjField.Add(objFieldHeader);
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

        private void processarHeaderHttpVersao(string strHeader)
        {
            #region Variáveis

            string[] arrStr;

            #endregion Variáveis

            #region Ações

            try
            {
                this.decHttpVersao = 0;

                if (string.IsNullOrEmpty(strHeader))
                {
                    return;
                }

                arrStr = strHeader.Split(" ".ToCharArray());

                if (arrStr == null)
                {
                    return;
                }

                if (arrStr.Length < 3)
                {
                    return;
                }

                this.decHttpVersao = Convert.ToDecimal(arrStr[2].ToLower().Replace("http/", null), CultureInfo.CreateSpecificCulture("en-USA"));
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

        private void processarHeaderMetodo(string strHeader)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.enmMetodo = EnmMetodo.DESCONHECIDO;

                if (string.IsNullOrEmpty(strHeader))
                {
                    return;
                }

                if (strHeader.ToLower().Contains("get"))
                {
                    this.enmMetodo = EnmMetodo.GET;
                    return;
                }

                if (strHeader.ToLower().Contains("post"))
                {
                    this.enmMetodo = EnmMetodo.POST;
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

        private void processarHeaderPagina(string strHeader)
        {
            #region Variáveis

            string[] arrStr;

            #endregion Variáveis

            #region Ações

            try
            {
                this.strPagina = null;

                if (string.IsNullOrEmpty(strHeader))
                {
                    return;
                }

                arrStr = strHeader.Split(" ".ToCharArray());

                if (arrStr == null)
                {
                    return;
                }

                if (arrStr.Length < 2)
                {
                    return;
                }

                this.strPagina = arrStr[1];
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

        private bool validar()
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