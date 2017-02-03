using System;
using System.Configuration.Install;
using System.ServiceProcess;

namespace NetZ.Web.WinService
{
    public abstract partial class WinServiceInstallerBase : Installer
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        #endregion Atributos

        #region Construtores

        public WinServiceInstallerBase()
        {
            this.InitializeComponent();
            this.inicializar();
        }

        #endregion Construtores

        #region Métodos

        protected abstract AppWebBase getAppWeb();

        private void inicializar()
        {
            this.inicializarSpi();

            this.inicializarSvi();
        }

        private void inicializarSpi()
        {
            this.spi.Account = ServiceAccount.NetworkService;
        }

        private void inicializarSvi()
        {
            if (this.getAppWeb() == null)
            {
                throw new NullReferenceException("A instância da aplicação não foi indicada.");
            }

            this.svi.Description = this.getAppWeb().strDescricao ?? "A descrição do serviço não foi indicada.";
            this.svi.DisplayName = this.getAppWeb().strNome;
            this.svi.ServiceName = this.getAppWeb().strNomeSimplificado;
            this.svi.StartType = ServiceStartMode.Automatic;
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}