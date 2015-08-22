using System;
using System.Collections.Generic;
using System.Text;

namespace NetZ.Web.Server
{
    public class Resposta
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private byte[] _arrBteResposta;
        private DateTime _dttUltimaModificacao = DateTime.Now;
        private List<Field> _lstObjField;
        private Solicitacao _objSolicitacao;

        private string _strConteudo;

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

        private string strConteudo
        {
            get
            {
                return _strConteudo;
            }

            set
            {
                _strConteudo = value;
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

                if (string.IsNullOrEmpty(this.strConteudo))
                {
                    this.strConteudo = string.Empty;
                }

                this.strConteudo += strHtml;
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

            string strResposta;

            #endregion Variáveis

            #region Ações

            try
            {
                strResposta = string.Empty;

                strResposta += this.getStrHeader();
                strResposta += Environment.NewLine;
                strResposta += Environment.NewLine;
                strResposta += this.strConteudo;

                return Encoding.UTF8.GetBytes(strResposta);
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

            string strHeader;

            #endregion Variáveis

            #region Ações

            try
            {
                strHeader = string.Empty;

                strHeader += "HTTP/1.1 200 OK";
                strHeader += Environment.NewLine;
                strHeader += this.getStrHeaderData(DateTime.Now);
                strHeader += Environment.NewLine;
                strHeader += "Server: NetZ.Web Server";
                strHeader += Environment.NewLine;
                strHeader += this.getStrHeaderData(this.dttUltimaModificacao);

                return strHeader;
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

        private string getStrHeaderData(string strDttNome, DateTime dtt)
        {
            #region Variáveis

            string strResultado;

            #endregion Variáveis

            #region Ações

            try
            {
                if (string.IsNullOrEmpty(strDttNome))
                {
                    strDttNome = "Date";
                }

                strResultado = "_str_date_nome: _date";
                strResultado = strResultado.Replace("_date", dtt.ToString("ddd,' 'dd' 'MMM' 'yyyy' 'HH':'mm':'ss' 'K"));

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

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}