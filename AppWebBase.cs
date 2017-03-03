using DigoFramework;
using NetZ.Persistencia;
using NetZ.Web.DataBase.Dominio;
using NetZ.Web.Html;
using NetZ.Web.Server;
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

        public const string DIR_CSS = "/res/css/";
        public const string DIR_JS_LIB = "/res/js/lib/";
        public const string DIR_JSON_CONFIG = "JSON Config/";
        public const string DIR_MEDIA_PNG = "/res/media/png/";

        #endregion Constantes

        #region Atributos

        private static AppWebBase _i;

        private bool _booMostrarGrade;
        private DbeBase _dbe;
        private List<UsuarioDominio> _lstObjUsuario;
        private List<ServerBase> _lstSrv;
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

        private List<ServerBase> lstSrv
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
        public virtual void inicializarServidor()
        {
            Log.i.info("Inicializando o servidor.");

            this.inicializarConfig();
            this.inicializarLstSrv();
        }

        /// <summary>
        /// Para o servidor imediatamente.
        /// </summary>
        public void pararServidor()
        {
            foreach (ServerBase srv in this.lstSrv)
            {
                this.pararServidor(srv);
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

            if (string.IsNullOrEmpty(objUsuario.strSessaoId))
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
        /// Busca o usuário que pertence a <param name="strSessaoId"/>.
        /// </summary>
        internal UsuarioDominio getObjUsuario(string strSessaoId)
        {
            lock (this.objLstObjUsuarioLock)
            {
                if (string.IsNullOrEmpty(strSessaoId))
                {
                    return null;
                }

                foreach (UsuarioDominio objUsuario in this.lstObjUsuario)
                {
                    if (objUsuario == null)
                    {
                        continue;
                    }

                    if (string.IsNullOrEmpty(objUsuario.strSessaoId))
                    {
                        continue;
                    }

                    if (!objUsuario.strSessaoId.Equals(strSessaoId))
                    {
                        continue;
                    }

                    return objUsuario;
                }

                UsuarioDominio objUsuarioNovo = new UsuarioDominio();

                objUsuarioNovo.strSessaoId = strSessaoId;

                this.addObjUsuario(objUsuarioNovo);

                return objUsuarioNovo;
            }
        }

        protected virtual DbeBase getDbe()
        {
            return null;
        }

        protected abstract ConfigWebBase getObjConfig();

        protected virtual SmtpClient getObjSmtpClient()
        {
            throw new NotImplementedException();
        }

        protected virtual string getStrEmail()
        {
            throw new NotFiniteNumberException();
        }

        protected abstract void inicializarLstSrv(List<ServerBase> lstSrv);

        private List<ServerBase> getLstSrv()
        {
            var lstSrvResultado = new List<ServerBase>();

            this.inicializarLstSrv(lstSrvResultado);

            return lstSrvResultado;
        }

        private void inicializarConfig()
        {
            this.getObjConfig();
        }

        private void inicializarLstSrv()
        {
            this.lstSrv?.ForEach((srv) => srv.iniciar());
        }

        private void pararServidor(ServerBase srv)
        {
            if (srv == null)
            {
                return;
            }

            srv.parar();
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}