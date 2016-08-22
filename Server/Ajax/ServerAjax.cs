using System;
using NetZ.Web.Server.Arquivo;

namespace NetZ.Web.Server.Ajax
{
    public abstract class ServerAjax : ServerBase
    {
        #region Constantes

        protected const string STR_RESULTADO_VAZIO = "_____null_____";

        #endregion Constantes

        #region Atributos

        #endregion Atributos

        #region Construtores

        protected ServerAjax(string strNome) : base(strNome)
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

            return null;
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

            if (ConfigWeb.i.intPorta != 80)
            {
                strHost = string.Format("http://{0}:{1}", uri.Host, ConfigWeb.i.intPorta);
            }

            objResposta.addHeader("Access-Control-Allow-Credentials", "true");
            objResposta.addHeader("Access-Control-Allow-Methods", "POST");
            objResposta.addHeader("Access-Control-Allow-Origin", strHost);
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