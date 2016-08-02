using System;

namespace NetZ.Web.DataBase.Dominio
{
    /// <summary>
    /// Representa o usuário que está utilizando este sistema.
    /// </summary>
    public class UsuarioDominio : DominioWeb
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private bool _booAdministrador;
        private bool _booLogado;
        private DateTime _dttLogin;
        private DateTime _dttUltimoAcesso;
        private string _strSessaoId;

        /// <summary>
        /// Indica se o usuário é administrador do sistema.
        /// </summary>
        public bool booAdministrador
        {
            get
            {
                return _booAdministrador;
            }

            set
            {
                _booAdministrador = value;
            }
        }

        /// <summary>
        /// Indica se este usuário está logado no sistema.
        /// </summary>
        public bool booLogado
        {
            get
            {
                return _booLogado;
            }

            set
            {
                _booLogado = value;
            }
        }

        /// <summary>
        /// Indica a data e hora que o usuário logou na aplicação.
        /// </summary>
        public DateTime dttLogin
        {
            get
            {
                return _dttLogin;
            }

            set
            {
                _dttLogin = value;
            }
        }

        /// <summary>
        /// Data e hora do último acesso deste usuário na sessão atual.
        /// </summary>
        public DateTime dttUltimoAcesso
        {
            get
            {
                return _dttUltimoAcesso;
            }

            private set
            {
                _dttUltimoAcesso = value;
            }
        }

        /// <summary>
        /// Valor do cookie que mantém a sessão atual do usuário.
        /// </summary>
        public string strSessaoId
        {
            get
            {
                return _strSessaoId;
            }

            set
            {
                _strSessaoId = value;
            }
        }

        #endregion Atributos

        #region Construtores

        public UsuarioDominio()
        {
        }

        #endregion Construtores

        #region Métodos

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}