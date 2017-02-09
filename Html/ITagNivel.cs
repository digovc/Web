namespace NetZ.Web.Html
{
    internal interface ITagNivel
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        /// <summary>
        /// Indica o nível que esta tag estará presente no componente pai.
        /// </summary>
        int intNivel
        {
            get;
            set;
        }

        int intTamanhoVerticalPx
        {
            get;
            set;
        }

        #endregion Atributos

        #region Métodos

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}