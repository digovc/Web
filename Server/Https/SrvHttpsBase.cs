using System.Net.Sockets;

namespace NetZ.Web.Server.Https
{
    public abstract class SrvHttpsBase : SrvHttpBase
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        public override Resposta responder(Solicitacao objSolicitacao)
        {
            return base.responder(objSolicitacao);
        }

        protected override int getIntPorta()
        {
            return 443;
        }

        protected override Cliente getObjCliente(TcpClient tcpClient)
        {
            //return base.getObjCliente(tcpClient);
            return new ClienteHttps(tcpClient, this);
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}