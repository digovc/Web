using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace NetZ.Web.Server
{
    public class Solicitacao
    {
        #region Constantes

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
        private EnmMetodo _enmMetodo = EnmMetodo.NONE;
        private List<Field> _lstObjHeader;
        private NetworkStream _nts;
        private string _strMsgCliente;
        private string _strPagina;

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

        private List<Field> lstObjHeader
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_lstObjHeader != null)
                    {
                        return _lstObjHeader;
                    }

                    _lstObjHeader = new List<Field>();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _lstObjHeader;
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

        private string strPagina
        {
            get
            {
                return _strPagina;
            }

            set
            {
                _strPagina = value;
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

                objHeader.processar();

                this.lstObjHeader.Add(objHeader);
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