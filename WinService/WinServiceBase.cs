using DigoFramework;
using System;
using System.Diagnostics;
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

        protected void iniciar()
        {
            if (this.validarDebug())
            {
                this.runDebug();
                return;
            }

            this.runService();
        }

        private void runDebug()
        {
            Log.i.info("Abrindo em modo de aplicação.");

            this.getAppWeb().iniciar();

            Console.Read();

            Log.i.info("Fechando a aplicação.");

            this.getAppWeb().pararServidor();
        }

        private void runService()
        {
            Log.i.info("Abrindo em modo de serviço.");

            Run(this);
        }

        private bool validarDebug()
        {
            if (this.getAppWeb().booDesenvolvimento)
            {
                return true;
            }

            if (Debugger.IsAttached)
            {
                return true;
            }

            var arrStrParam = Environment.GetCommandLineArgs();

            if (arrStrParam == null)
            {
                return false;
            }

            if (string.Join(" ", arrStrParam).Contains("debug"))
            {
                return true;
            }

            return false;
        }

        #endregion Métodos

        #region Eventos

        protected override void OnStart(string[] args)
        {
            base.OnStart(args);

            Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);

            this.getAppWeb().iniciar();
        }

        protected override void OnStop()
        {
            base.OnStop();

            this.getAppWeb().pararServidor();
        }

        #endregion Eventos
    }
}