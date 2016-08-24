using DigoFramework;

namespace NetZ.Web
{
    public abstract class ConfigWeb : ConfigMain
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private static ConfigWeb _i;

        private string[] _arrDirIgnorado;
        private string[] _arrStrExtencaoIgnorada;
        private bool _booServerAjaxDbAtivar = true;
        private int _intServerHttpPorta = 80;
        private int _intServerAjaxDbPorta = 8081;
        private int _intTimeOut = 5;

        public static new ConfigWeb i
        {
            get
            {
                return _i;
            }

            private set
            {
                _i = value;
            }
        }

        /// <summary>
        /// Lista de diretórios ou arquivos estáticos que devem ser ignorados e que não estarão
        /// disponíveis do lado do cliente.
        /// <para>Estes diretórios e arquivos são relativos ao diretório presente em <see cref="dirLocal"/>.</para>
        /// </summary>
        public string[] arrDirIgnorado
        {
            get
            {
                return _arrDirIgnorado;
            }

            set
            {
                _arrDirIgnorado = value;
            }
        }

        /// <summary>
        /// Lista de extenções de arquivos que devem ser ignorados e que não estarão disponíveis do
        /// lado do cliente.
        /// </summary>
        public string[] arrStrExtencaoIgnorada
        {
            get
            {
                return _arrStrExtencaoIgnorada;
            }

            set
            {
                _arrStrExtencaoIgnorada = value;
            }
        }

        /// <summary>
        /// Indica se ao inicializar o servidor HTTP, o servidor de solicitações AJAX do banco de
        /// dados será ativo também.
        /// </summary>
        public bool booServerAjaxDbAtivar
        {
            get
            {
                return _booServerAjaxDbAtivar;
            }

            set
            {
                _booServerAjaxDbAtivar = value;
            }
        }

        /// <summary>
        /// Porta TCP que será utilizada para rodar o servidor WEB.
        /// </summary>
        public int intServerHttpPorta
        {
            get
            {
                return _intServerHttpPorta;
            }

            set
            {
                _intServerHttpPorta = value;
            }
        }

        /// <summary>
        /// Porta que será utilizada pelo servidor <see cref="ServerAjaxDb"/>.
        /// </summary>
        public int intServerAjaxDbPorta
        {
            get
            {
                return _intServerAjaxDbPorta;
            }

            set
            {
                _intServerAjaxDbPorta = value;
            }
        }

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

        protected ConfigWeb()
        {
            i = this;
        }

        #endregion Construtores

        #region Métodos

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}