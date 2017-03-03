using DigoFramework;

namespace NetZ.Web
{
    public abstract class ConfigWebBase : ConfigBase
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private static ConfigWebBase _i;

        private string[] _arrDirIgnorado;
        private string[] _arrStrExtencaoIgnorada;
        private bool _booSrvAjaxDbeAtivar = true;
        private int _intSrvAjaxDbePorta = 8082;
        private int _intSrvAjaxDocumentacao = 8081;
        private int _intSrvHttpPorta = 80;
        private int _intTimeOut = 5;

        public static new ConfigWebBase i
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
        public bool booSrvAjaxDbeAtivar
        {
            get
            {
                return _booSrvAjaxDbeAtivar;
            }

            set
            {
                _booSrvAjaxDbeAtivar = value;
            }
        }

        /// <summary>
        /// Porta que será utilizada pelo servidor <see cref="SrvAjaxDbe"/>.
        /// </summary>
        public int intSrvAjaxDbePorta
        {
            get
            {
                return _intSrvAjaxDbePorta;
            }

            set
            {
                _intSrvAjaxDbePorta = value;
            }
        }

        /// <summary>
        /// Porta que será utilizada pelo servidor <see cref="SrvAjaxDocumentacao"/>.
        /// </summary>
        public int intSrvAjaxDocumentacao
        {
            get
            {
                return _intSrvAjaxDocumentacao;
            }

            set
            {
                _intSrvAjaxDocumentacao = value;
            }
        }

        /// <summary>
        /// Porta TCP que será utilizada para rodar o servidor WEB.
        /// </summary>
        public int intSrvHttpPorta
        {
            get
            {
                return _intSrvHttpPorta;
            }

            set
            {
                _intSrvHttpPorta = value;
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

        protected ConfigWebBase()
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