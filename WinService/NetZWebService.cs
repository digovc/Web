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
            if (this.getAppWeb() == null)
            {
                throw new NullReferenceException("A instância da aplicação não foi indicada.");
            }

            this.ServiceName = this.getAppWeb().strNomeSimplificado;

            this.CanHandlePowerEvent = false;
            this.CanHandleSessionChangeEvent = false;
            this.CanPauseAndContinue = false;
            this.CanShutdown = false;
            this.CanStop = true;
            this.EventLog.Log = (this.ServiceName + "_log");

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