namespace NetZ.Web.Server
{
    public class SolicitacaoAjaxDb : SolicitacaoAjax
    {
        #region Constantes

        public enum EnmMetodo
        {
            ABRIR_CADASTRO,
            ABRIR_CADASTRO_FILTRO_CONTEUDO,
            ABRIR_CONSULTA,
            ABRIR_JANELA_TAG,
            ADICIONAR,
            APAGAR,
            CARREGAR_TBL_WEB,
            FILTRO,
            NONE,
            PESQUISAR_COMBO_BOX,
            PESQUISAR_GRID,
            RECUPERAR,
            SALVAR,
        }

        #endregion Constantes

        #region Atributos

        private EnmMetodo _enmMetodo = EnmMetodo.NONE;

        /// <summary>
        /// Enumerado que indica o método que deve ser executado por esta solicitação.
        /// </summary>
        public EnmMetodo enmMetodo
        {
            get
            {
                return _enmMetodo;
            }

            set
            {
                _enmMetodo = value;
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