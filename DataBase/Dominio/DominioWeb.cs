namespace NetZ.Web.DataBase.Dominio
{
    public abstract class DominioWeb : Persistencia.Dominio
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private bool _booAtivo = true;

        public bool booAtivo
        {
            get
            {
                return _booAtivo;
            }

            set
            {
                _booAtivo = value;
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