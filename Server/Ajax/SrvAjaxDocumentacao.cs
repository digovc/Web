namespace NetZ.Web.Server.Ajax
{
    public sealed class SrvAjaxDocumentacao : ServerAjaxBase
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        #endregion Atributos

        #region Construtores

        public SrvAjaxDocumentacao() : base("Servidor AJAX (Geral)")
        {
        }

        #endregion Construtores

        #region Métodos

        protected override int getIntPorta()
        {
            return ConfigWebBase.i.intSrvAjaxDocumentacao;
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}