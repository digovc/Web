using System;
using System.ServiceProcess;

namespace NetZ.Web.WinService
{
    public abstract partial class NetZWebService : ServiceBase
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        #endregion Atributos

        #region Construtores

        public NetZWebService()
        {
            this.InitializeComponent();
        }

        #endregion Construtores

        #region Métodos

        protected abstract AppWebBase getAppWeb();

        private void inicializar()
        {
            this.getAppWeb().inicializarServidor();
        }

        #endregion Métodos

        #region Eventos

        protected override void OnStart(string[] args)
        {
            base.OnStart(args);

            this.inicializar();
        }

        protected override void OnStop()
        {
            base.OnStop();

            this.getAppWeb().pararServidor();
        }

        #endregion Eventos
    }
}