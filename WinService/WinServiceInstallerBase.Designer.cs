namespace NetZ.Web.WinService
{
    partial class WinServiceInstallerBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.spi = new System.ServiceProcess.ServiceProcessInstaller();
            this.svi = new System.ServiceProcess.ServiceInstaller();
            // 
            // spi
            // 
            this.spi.Account = System.ServiceProcess.ServiceAccount.NetworkService;
            this.spi.Password = null;
            this.spi.Username = null;
            // 
            // svi
            // 
            this.svi.Description = "Servidor HTTP da Relatar Sistemas.";
            this.svi.DisplayName = "NetZ.Web";
            this.svi.ServiceName = "NetZWeb";
            this.svi.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.spi,
            this.svi});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller spi;
        private System.ServiceProcess.ServiceInstaller svi;
    }
}