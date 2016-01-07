using System;

namespace NetZ.Web.Server
{
    public class ServerAjaxDb : ServerAjax
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private static ServerAjaxDb _i;

        public static ServerAjaxDb i
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_i != null)
                    {
                        return _i;
                    }

                    _i = new ServerAjaxDb();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _i;
            }
        }

        #endregion Atributos

        #region Construtores

        protected ServerAjaxDb() : base("Server Ajax Data Base")
        {
        }

        #endregion Construtores

        #region Métodos

        internal override Resposta responder(Solicitacao objSolicitacao)
        {
            #region Variáveis

            Resposta objResposta;

            #endregion Variáveis

            #region Ações

            try
            {
                if (objSolicitacao == null)
                {
                    return null;
                }

                objResposta = AppWeb.i.responderAjaxDb(objSolicitacao);

                this.responderAddAcessControl(objResposta, objSolicitacao);

                return objResposta;
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

        protected override int getIntPort()
        {
            return ConfigWeb.i.intServerAjaxDbPorta;
        }

        private void responderAddAcessControl(Resposta objResposta, Solicitacao objSolicitacao)
        {
            #region Variáveis

            string strReferer;

            #endregion Variáveis

            #region Ações

            try
            {
                if (objResposta == null)
                {
                    return;
                }

                if (!Resposta.INT_STATUS_CODE_200_OK.Equals(objResposta.intStatus))
                {
                    return;
                }

                if (objSolicitacao == null)
                {
                    return;
                }

                strReferer = objSolicitacao.getStrHeaderValor("referer");

                if (string.IsNullOrEmpty(strReferer))
                {
                    return;
                }

                if (strReferer.EndsWith("/"))
                {
                    strReferer = strReferer.Substring(0, (strReferer.Length - 1));
                }

                objResposta.addHeader("Access-Control-Allow-Origin", strReferer);
                objResposta.addHeader("Access-Control-Allow-Credentials", "true");
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