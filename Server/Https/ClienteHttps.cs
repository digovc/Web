using System.Net.Security;
using System.Net.Sockets;

namespace NetZ.Web.Server.Https
{
    internal class ClienteHttps : Cliente
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        #endregion Atributos

        #region Construtores

        internal ClienteHttps(TcpClient tcpClient, ServerBase srv) : base(tcpClient, srv)
        {
        }

        #endregion Construtores

        #region Métodos

        protected override Solicitacao carregarSolicitacao()
        {
            if (!this.getBooConectado())
            {
                return null;
            }

            if (!this.tcpClient.GetStream().DataAvailable)
            {
                return null;
            }

            return new Solicitacao(new SslStream(this.tcpClient.GetStream()));
        }


        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}