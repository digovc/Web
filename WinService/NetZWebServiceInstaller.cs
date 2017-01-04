using System;
using System.Configuration.Install;
using System.ServiceProcess;

namespace NetZ.Web.WinService
{
    public abstract partial class NetZWebServiceInstaller : Installer
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        #endregion Atributos

        #region Construtores

        public NetZWebServiceInstaller()
        {
            this.InitializeComponent();
            this.inicializar();
        }

        #endregion Construtores

        #region Métodos

        protected abstract Type getClsService();

        protected abstract string getStrAplicacaoNome();

        protected virtual string getStrDescricao()
        {
            return "NetZ.Web (Servidor HTTP para aplicações Web).";
        }

        private string getStrNome()
        {
            Type clsService = this.getClsService();

            if (clsService == null)
            {
                throw new NullReferenceException("Classe do serviço não indicada.");
            }

            if (!(typeof(ServiceBase).IsAssignableFrom(clsService)))
            {
                throw new NullReferenceException("Classe do serviço não herda de \"ServiceBase\".");
            }

            return clsService.Name;
        }

        private string getStrNomeExibicao()
        {
            if (string.IsNullOrEmpty(this.getStrAplicacaoNome()))
            {
                return "NetZ.Web";
            }

            return string.Format("{0} (NetZ.Web)", this.getStrAplicacaoNome());
        }

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
            this.svi.Description = this.getStrDescricao();
            this.svi.DisplayName = this.getStrNomeExibicao();
            this.svi.ServiceName = this.getStrNome();
            this.svi.StartType = ServiceStartMode.Manual;
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}