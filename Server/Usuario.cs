using System;
using NetZ.SistemaBase;

namespace NetZ.Web.Server
{
    /// <summary>
    /// Representa o usuário que está utilizando este sistema.
    /// </summary>
    public class Usuario : Objeto
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private bool _booLogado;
        private DateTime _dttLogin;
        private DateTime _dttPrimeiroAcesso;
        private DateTime _dttUltimoAcesso;
        private int _intId;
        private string _strSessaoId;

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
        /// Data e hora do primeiro acesso deste usuário na sessão atual.
        /// </summary>
        public DateTime dttPrimeiroAcesso
        {
            get
            {
                return _dttPrimeiroAcesso;
            }

            private set
            {
                _dttPrimeiroAcesso = value;
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
        /// Código deste usuário dentro do banco de dados.
        /// </summary>
        public int intId
        {
            get
            {
                return _intId;
            }

            set
            {
                _intId = value;
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

            private set
            {
                _strSessaoId = value;
            }
        }

        #endregion Atributos

        #region Construtores

        internal Usuario(string strSessaoId)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.dttPrimeiroAcesso = DateTime.Now;
                this.dttUltimoAcesso = DateTime.Now;
                this.strSessaoId = strSessaoId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion Ações
        }

        #endregion Construtores

        #region Métodos

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}