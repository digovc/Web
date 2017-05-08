using System;
using System.IO;
using System.ServiceProcess;

namespace NetZ.Web.WinService
{
    public abstract partial class WinServiceBase : ServiceBase
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        #endregion Atributos

        #region Construtores

        public WinServiceBase()
        {
            this.InitializeComponent();
        }

        #endregion Construtores

        #region Métodos

        protected abstract AppWebBase getAppWeb();

        private void inicializar()
        {
            Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);

            this.getAppWeb().iniciarServidorWeb();
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