using DigoFramework;
using NetZ.Web;
using NetZ.Web.WinService;
using System;
using System.ComponentModel;
using System.Diagnostics;

namespace Cia.WinService.WinService
{
    public class WinService : WinServiceBase
    {
        public static WinService i = new WinService();

        private WinService()
        {
        }

        protected override AppWebBase getAppWeb()
        {
            return AppWebBase.i;
        }

        [STAThread]
        private static void Main(string[] arrStrParam)
        {
            if (!i.validarDebug(arrStrParam))
            {
                i.runService();
            }
            else
            {
                i.runDebug();
            }
        }

        private void runDebug()
        {
            Log.i.info("Abrindo em modo \"aplicação\".");

            i.getAppWeb().iniciarServidorWeb();

            Console.Read();

            Log.i.info("Fechando a aplicação.");

            i.getAppWeb().pararServidor();
        }

        private void runService()
        {
            //Debugger.Launch();

            Log.i.info("Abrindo em modo \"serviço\".");

            Run(i);
        }

        private bool validarDebug(string[] arrStrParam)
        {
            if (Debugger.IsAttached)
            {
                return true;
            }

            if (arrStrParam == null)
            {
                return false;
            }

            if (arrStrParam.Length < 1)
            {
                return false;
            }

            if (!arrStrParam[0].Equals("debug"))
            {
                return false;
            }

            return true;
        }
    }

    [RunInstaller(true)]
    public class WinServiceIntaller : WinServiceInstallerBase
    {
        protected override AppWebBase getAppWeb()
        {
            return AppWebBase.i;
        }
    }
}