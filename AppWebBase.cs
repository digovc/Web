using DigoFramework;
using DigoFramework.Servico;
using NetZ.Persistencia;
using NetZ.Web.DataBase.Dominio;
using System;
using System.Collections.Generic;
using System.Net.Mail;

namespace NetZ.Web
{
    /// <summary>
    /// Classe mais importante para a utilização desta biblioteca. Ele que faz a ligação de toda a
    /// lógica interna do servidor WEB e os clientes que consomem os recursos deste.
    /// <para>
    /// Essa classe deve ser herdada por uma classe do desenvolvedor que represente a sua própria aplicação.
    /// </para>
    /// <para>
    /// Para interceptar e construir as páginas da aplicação WEB, esta classe que herda desta,
    /// obrigatóriamente terá de implementar o método <see cref="responder(Solicitacao)"/>, sendo
    /// capaz através disto, construir as respostas adequadas para os clientes e suas solicitações.
    /// </para>
    /// </summary>
    public abstract class AppWebBase : AppBase
    {
        #region Constantes

        public const string DIR_CSS = (DIR_RESOURCE + "css/");
        public const string DIR_HTML = "res/html/";
        public const string DIR_HTML_PAGINA = (DIR_HTML + "pagina/");
        public const string DIR_JS = (DIR_RESOURCE + "js/");
        public const string DIR_JS_LIB = (DIR_RESOURCE + "js/lib/");
        public const string DIR_JS_WEB = (DIR_JS + "web/");
        public const string DIR_JSON_CONFIG = "JSON Config/";
        public const string DIR_MEDIA_GIF = (DIR_RESOURCE + "media/gif/");
        public const string DIR_MEDIA_JPG = (DIR_RESOURCE + "media/jpg/");
        public const string DIR_MEDIA_PNG = (DIR_RESOURCE + "media/png/");
        public const string DIR_MEDIA_SVG = (DIR_RESOURCE + "media/svg/");
        public const string DIR_RESOURCE = "/res/";

        public const string STR_CONSTANTE_DESENVOLVIMENTO = "STR_CONSTANTE_DESENVOLVIMENTO";
        public const string STR_CONSTANTE_NAMESPACE_PROJETO = "STR_CONSTANTE_NAMESPACE_PROJETO";

        #endregion Constantes

        #region Atributos

        private static AppWebBase _i;

        private bool _booMostrarGrade;
        private DbeBase _dbe;
        private List<UsuarioDominio> _lstObjUsuario;
        private List<ServicoBase> _lstSrv;
        private object _objLstObjUsuarioLock;
        private SmtpClient _objSmtpClient;
        private string _strEmail;

        public new static AppWebBase i
        {
            get
            {
                return _i;
            }

            set
            {
                _i = value;
            }
        }

        /// <summary>
        /// Caso esta propriedade seja marcada como true, todas as tags geradas serão marcadas
        /// automaticamente para mostrar uma borda para que fique visível o tamanho de gasto por
        /// todas elas.
        /// <para>Utilize esta função para facilitar a montagem da tela.</para>
        /// <para>
        /// Lembre-se de considerar que a borda que será apresentada consome 1px nos quatro lados do
        /// componente, o que pode "estourar" o layout.
        /// </para>
        /// </summary>
        public bool booMostrarGrade
        {
            get
            {
                return _booMostrarGrade;
            }

            set
            {
                _booMostrarGrade = value;
            }
        }

        public DbeBase dbe
        {
            get
            {
                if (_dbe != null)
                {
                    return _dbe;
                }

                _dbe = this.getDbe();

                return _dbe;
            }
        }

        /// <summary>
        /// Conta de email que será utilizada para envio de emails pela aplicação.
        /// </summary>
        public SmtpClient objSmtpClient
        {
            get
            {
                if (_objSmtpClient != null)
                {
                    return _objSmtpClient;
                }

                _objSmtpClient = this.getObjSmtpClient();

                return _objSmtpClient;
            }
        }

        public string strEmail
        {
            get
            {
                if (_strEmail != null)
                {
                    return _strEmail;
                }

                _strEmail = this.getStrEmail();

                return _strEmail;
            }
        }

        internal List<UsuarioDominio> lstObjUsuario
        {
            get
            {
                if (_lstObjUsuario != null)
                {
                    return _lstObjUsuario;
                }

                _lstObjUsuario = new List<UsuarioDominio>();

                return _lstObjUsuario;
            }
        }

        private List<ServicoBase> lstSrv
        {
            get
            {
                if (_lstSrv != null)
                {
                    return _lstSrv;
                }

                _lstSrv = this.getLstSrv();

                return _lstSrv;
            }
        }

        private object objLstObjUsuarioLock
        {
            get
            {
                if (_objLstObjUsuarioLock != null)
                {
                    return _objLstObjUsuarioLock;
                }

                _objLstObjUsuarioLock = new object();

                return _objLstObjUsuarioLock;
            }
        }

        #endregion Atributos

        #region Construtores

        protected AppWebBase(string strNome) : base(strNome)
        {
            i = this;
        }

        #endregion Construtores

        #region Métodos

        /// <summary>
        /// Para o servidor imediatamente.
        /// </summary>
        public void pararServidor()
        {
            foreach (ServicoBase srv in this.lstSrv)
            {
                srv?.parar();
            }
        }

        /// <summary>
        /// Adiciona um usuário para a lista de usuários.
        /// </summary>
        internal void addObjUsuario(UsuarioDominio objUsuario)
        {
            if (objUsuario == null)
            {
                return;
            }

            if (string.IsNullOrEmpty(objUsuario.strSessao))
            {
                return;
            }

            if (this.lstObjUsuario.Contains(objUsuario))
            {
                return;
            }

            // TODO: Eliminar os usuários mais antigos.
            this.lstObjUsuario.Add(objUsuario);
        }

        /// <summary>
        /// Busca o usuário que pertence a <param name="strSessao"/>.
        /// </summary>
        internal UsuarioDominio getObjUsuario(string strSessao)
        {
            lock (this.objLstObjUsuarioLock)
            {
                if (string.IsNullOrEmpty(strSessao))
                {
                    return null;
                }

                foreach (UsuarioDominio objUsuario in this.lstObjUsuario)
                {
                    if (objUsuario == null)
                    {
                        continue;
                    }

                    if (string.IsNullOrEmpty(objUsuario.strSessao))
                    {
                        continue;
                    }

                    if (!objUsuario.strSessao.Equals(strSessao))
                    {
                        continue;
                    }

                    return objUsuario;
                }

                var objUsuarioNovo = new UsuarioDominio();

                objUsuarioNovo.strSessao = strSessao;

                this.addObjUsuario(objUsuarioNovo);

                return objUsuarioNovo;
            }
        }

        protected virtual DbeBase getDbe()
        {
            return null;
        }

        protected virtual SmtpClient getObjSmtpClient()
        {
            throw new NotImplementedException();
        }

        protected virtual string getStrEmail()
        {
            throw new NotFiniteNumberException();
        }

        /// <summary>
        /// Inicializa a aplicação e o servidor WEB em sí, juntamente com os demais componentes que
        /// ficarão disponíveis para servir esta aplicação para os cliente.
        /// <para>
        /// Estes serviços levarão em consideração as configurações presentes em <seealso cref="ConfigWebBase"/>.
        /// </para>
        /// <para>
        /// O servidor de solicitações AJAX do banco de dados <see cref="ServerAjaxDb"/> também será
        /// inicializado, caso a configuração <seealso cref="ConfigWebBase.booSrvAjaxDbeAtivar"/>
        /// esteja marcada.
        /// </para>
        /// </summary>
        protected override void inicializar()
        {
            base.inicializar();

            Log.i.info("Inicializando o servidor.");

            this.inicializarDbe();
            this.inicializarLstSrv();
        }

        protected abstract void inicializarLstSrv(List<ServicoBase> lstSrv);

        private List<ServicoBase> getLstSrv()
        {
            var lstSrvResultado = new List<ServicoBase>();

            this.inicializarLstSrv(lstSrvResultado);

            return lstSrvResultado;
        }

        private void inicializarDbe()
        {
            if (this.dbe == null)
            {
                return;
            }

            this.dbe.iniciar();
        }

        private void inicializarLstSrv()
        {
            Log.i.info("Inicializando a lista de servidores.");

            this.lstSrv?.ForEach((srv) => srv.iniciar());
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}