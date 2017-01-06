using System;
using System.Diagnostics;
using System.ServiceProcess;

namespace NetZ.Web.WinService
{
    public abstract partial class NetZWebService : ServiceBase
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private AppWebBase _appWeb;

        private AppWebBase appWeb
        {
            get
            {
                if (_appWeb != null)
                {
                    return _appWeb;
                }

                _appWeb = this.getAppWeb();

                return _appWeb;
            }
        }

        #endregion Atributos

        #region Construtores

        public NetZWebService()
        {
            this.InitializeComponent();

            this.ServiceName = this.GetType().Name;
            this.EventLog.Log = (this.GetType().Name + "_log");

            this.CanHandlePowerEvent = true;
            this.CanHandleSessionChangeEvent = true;
            this.CanPauseAndContinue = true;
            this.CanShutdown = true;
            this.CanStop = true;
        }

        #endregion Construtores

        #region Métodos

        protected abstract AppWebBase getAppWeb();

        private void inicializar()
        {
            Console.WriteLine(this.appWeb);

            if (this.appWeb == null)
            {
                throw new NullReferenceException("A propriedade \"appWeb\" está nula.");
            }

            this.appWeb.inicializarServidor();
        }

        #endregion Métodos

        #region Eventos

        protected override void OnStart(string[] args)
        {
            base.OnStart(args);

            // Comentar sempre que não quiser debugar.
            //Debugger.Launch();

            this.inicializar();
        }

        protected override void OnStop()
        {
            base.OnStop();

            if (this.appWeb == null)
            {
                throw new NullReferenceException("A propriedade \"appWeb\" está nula.");
            }

            this.appWeb.pararServidor();
        }

        #endregion Eventos
    }
}