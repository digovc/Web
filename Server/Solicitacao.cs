using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Sockets;
using System.Text;
using System.Threading;

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
    public class Solicitacao
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
        private List<Field> _lstObjField;
        private NetworkStream _nts;
        private string _strMsgCliente;
        private string _strPagina;

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

            set
            {
                _enmMetodo = value;
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

        /// <summary>
        /// Página que foi solicitada pelo cliente.
        /// </summary>
        public string strPagina
        {
            get
            {
                return _strPagina;
            }

            set
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

                foreach (string strHeader in arrStrLinha)
                {
                    if (string.IsNullOrEmpty(strHeader))
                    {
                        continue;
                    }

                    this.processarHeader(strHeader);
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

        private void processarHeader(string strHeader)
        {
            #region Variáveis

            Field objHeader;

            #endregion Variáveis

            #region Ações

            try
            {
                if (string.IsNullOrEmpty(strHeader))
                {
                    return;
                }

                objHeader = new Field(strHeader);

                objHeader.objSolicitacao = this;
                objHeader.processar();

                this.lstObjField.Add(objHeader);
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