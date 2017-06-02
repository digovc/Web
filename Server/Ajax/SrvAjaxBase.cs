using DigoFramework.Json;
using NetZ.Web.Server.Arquivo;
using System;

namespace NetZ.Web.Server.Ajax
{
    public abstract class SrvAjaxBase : ServerBase
    {
        #region Constantes

        protected const string STR_RESULTADO_VAZIO = "_____null_____";

        #endregion Constantes

        #region Atributos

        #endregion Atributos

        #region Construtores

        protected SrvAjaxBase(string strNome) : base(strNome)
        {
        }

        #endregion Construtores

        #region Métodos

        public override Resposta responder(Solicitacao objSolicitacao)
        {
            if (objSolicitacao == null)
            {
                return null;
            }

            if (Solicitacao.EnmMetodo.OPTIONS.Equals(objSolicitacao.enmMetodo))
            {
                return this.responderOptions(objSolicitacao);
            }

            if ("/?upload-file".Equals(objSolicitacao.strPaginaCompleta))
            {
                return this.responderUploadFile(objSolicitacao);
            }

            Interlocutor objInterlocutor = null;

            try
            {
                if (string.IsNullOrEmpty(objSolicitacao.jsn))
                {
                    return null;
                }

                objInterlocutor = Json.i.fromJson<Interlocutor>(objSolicitacao.jsn);

                if (objInterlocutor == null)
                {
                    return null;
                }

                if (!this.responder(objSolicitacao, objInterlocutor))
                {
                    return null;
                }

                var objResposta = new Resposta(objSolicitacao);

                objResposta.addJson(objInterlocutor);

                this.addAcessControl(objResposta);

                return objResposta;
            }
            catch (Exception ex)
            {
                return this.responderErro(objSolicitacao, ex, objInterlocutor);
            }
        }

        protected void addAcessControl(Resposta objResposta)
        {
            if (objResposta == null)
            {
                return;
            }

            if (!Resposta.INT_STATUS_CODE_200_OK.Equals(objResposta.intStatus))
            {
                return;
            }

            if (objResposta.objSolicitacao == null)
            {
                return;
            }

            string strReferer = objResposta.objSolicitacao.getStrHeaderValor("referer");

            if (string.IsNullOrEmpty(strReferer))
            {
                return;
            }

            Uri uri = new Uri(strReferer);

            string strHost = ("http://" + uri.Host);

            if ((AppWebBase.i.cfg as ConfigWebBase).intSrvHttpPorta != 80)
            {
                strHost = string.Format("http://{0}:{1}", uri.Host, (AppWebBase.i.cfg as ConfigWebBase).intSrvHttpPorta);
            }

            objResposta.addHeader("Access-Control-Allow-Credentials", "true");
            objResposta.addHeader("Access-Control-Allow-Methods", "POST");
            objResposta.addHeader("Access-Control-Allow-Origin", strHost);
        }

        protected virtual bool responder(Solicitacao objSolicitacao, Interlocutor objInterlocutor)
        {
            return false;
        }

        protected Resposta responderErro(Solicitacao objSolicitacao, Exception ex, Interlocutor objInterlocutor)
        {
            if (objSolicitacao == null)
            {
                return null;
            }

            string strErro = "Erro desconhecido.";

            if (ex != null)
            {
                strErro = ex.Message;
            }

            if (objInterlocutor == null)
            {
                objInterlocutor = new Interlocutor();
            }

            objInterlocutor.strErro = strErro;

            Resposta objResposta = new Resposta(objSolicitacao);

            objResposta.addJson(objInterlocutor);

            this.addAcessControl(objResposta);

            return objResposta;
        }

        private Resposta responderOptions(Solicitacao objSolicitacao)
        {
            Resposta objResposta = new Resposta(objSolicitacao);

            this.addAcessControl(objResposta);

            return objResposta;
        }

        private Resposta responderUploadFile(Solicitacao objSolicitacao)
        {
            Interlocutor objInterlocutor = new Interlocutor();

            Resposta objResposta = new Resposta(objSolicitacao);

            this.addAcessControl(objResposta);

            if (objSolicitacao == null)
            {
                objInterlocutor.strErro = "Erro ao processar arquivo.";

                return objResposta.addJson(objInterlocutor);
            }

            if (objSolicitacao.objUsuario == null)
            {
                objInterlocutor.strErro = "Usuário desconhecido não pode fazer upload de arquivos.";

                return objResposta.addJson(objInterlocutor);
            }

            if (!objSolicitacao.objUsuario.booLogado)
            {
                objInterlocutor.strErro = "Usuário deslogado não pode fazer upload de arquivos.";
                return objResposta.addJson(objInterlocutor);
            }

            objSolicitacao.objUsuario.addArqUpload(new ArqUpload(objSolicitacao));

            objInterlocutor.objData = "Arquivo recebido com sucesso.";

            return objResposta.addJson(objInterlocutor);
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}