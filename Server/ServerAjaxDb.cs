using System;
using DigoFramework.Json;

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
            SolicitacaoAjaxDb objSolicitacaoAjaxDb;

            #endregion Variáveis

            #region Ações

            try
            {
                if (objSolicitacao == null)
                {
                    return null;
                }

                if (string.IsNullOrEmpty(objSolicitacao.jsn))
                {
                    return null;
                }

                objSolicitacaoAjaxDb = Json.i.fromJson<SolicitacaoAjaxDb>(objSolicitacao.jsn);

                if (objSolicitacaoAjaxDb == null)
                {
                    return null;
                }

                AppWeb.i.responderAjaxDb(objSolicitacao, objSolicitacaoAjaxDb);

                objResposta = new Resposta(objSolicitacao);

                objResposta.addJson(objSolicitacaoAjaxDb);

                this.responderAddAcessControl(objResposta, objSolicitacao);

                return objResposta;
            }
            catch (Exception ex)
            {
                throw ex; // TODO: Entregar a mensagem de erro para o usuário.
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
            Uri uri;

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

                uri = new Uri(strReferer);

                string strHost = ("http://" + uri.Host);

                if (ConfigWeb.i.intPorta != 80)
                {
                    strHost = string.Format("http://{0}:{1}", uri.Host, ConfigWeb.i.intPorta);
                }

                objResposta.addHeader("Access-Control-Allow-Origin", strHost);
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