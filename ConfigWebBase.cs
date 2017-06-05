using DigoFramework;

namespace NetZ.Web
{
    public abstract class ConfigWebBase : ConfigBase
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private int _intTimeOut = 5;

        /// <summary>
        /// Tempo em segundos que o servidor esperará pela mensagem vinda do cliente após este ter
        /// começado uma conexão. Caso nada tenha sido enviado pelo cliente neste período a conexão é
        /// cancelada automaticamente.
        /// </summary>
        public int intTimeOut
        {
            get
            {
                return _intTimeOut;
            }

            set
            {
                _intTimeOut = value;
            }
        }

        #endregion Atributos

        #region Construtores

        protected ConfigWebBase()
        {
        }

        #endregion Construtores

        #region Métodos

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}