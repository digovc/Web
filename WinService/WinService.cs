using System;
using System.ComponentModel;

namespace NetZ.Web.WinService
{
    public class WinService : WinServiceBase
    {
        protected override AppWebBase getAppWeb()
        {
            return AppWebBase.i;
        }

        [STAThread]
        private static void Main(string[] arrStrParam)
        {
            new WinService().iniciar();
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