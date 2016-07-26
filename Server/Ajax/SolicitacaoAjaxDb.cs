namespace NetZ.Web.Server.Ajax
{
    public class SolicitacaoAjaxDb : SolicitacaoAjax
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private string _strMetodo;

        /// <summary>
        /// Enumerado que indica o método que deve ser executado por esta solicitação.
        /// </summary>
        public string strMetodo
        {
            get
            {
                return _strMetodo;
            }

            set
            {
                _strMetodo = value;
            }
        }

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}