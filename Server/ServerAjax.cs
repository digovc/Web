using System;

namespace NetZ.Web.Server
{
    public abstract class ServerAjax : ServerBase
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        #endregion Atributos

        #region Construtores

        protected ServerAjax(string strNome) : base(strNome)
        {
        }

        #endregion Construtores

        #region Métodos

        protected void addAcessControl(Resposta objResposta, Solicitacao objSolicitacao)
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

            string strReferer = objSolicitacao.getStrHeaderValor("referer");

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

            objResposta.addHeader("Access-Control-Allow-Origin", strHost);
            objResposta.addHeader("Access-Control-Allow-Credentials", "true");
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}