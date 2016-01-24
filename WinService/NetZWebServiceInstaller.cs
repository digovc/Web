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
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.InitializeComponent();
                this.inicializar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion Ações
        }

        #endregion Construtores

        #region Métodos

        protected abstract Type getClsService();

        protected abstract string getStrAplicacaoNome();

        protected virtual string getStrDescricao()
        {
            return "NetZ.Web (Servidor HTTP para aplicações Web da empresa Relatar Sistemas).";
        }

        private string getStrNome()
        {
            #region Variáveis

            Type clsService;

            #endregion Variáveis

            #region Ações

            try
            {
                clsService = this.getClsService();

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
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion Ações
        }

        private string getStrNomeExibicao()
        {
            #region Variáveis

            string strNomeExibicao;

            #endregion Variáveis

            #region Ações

            try
            {
                strNomeExibicao = "NetZ.Web Service (_aplicacao_nome)";
                strNomeExibicao = strNomeExibicao.Replace("_aplicacao_nome", this.getStrAplicacaoNome());

                return strNomeExibicao;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion Ações
        }

        private void inicializar()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.inicializarSpi();

                this.inicializarSvi();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion Ações
        }

        private void inicializarSpi()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.spi.Account = ServiceAccount.NetworkService;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion Ações
        }

        private void inicializarSvi()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.svi.Description = this.getStrDescricao();
                this.svi.DisplayName = this.getStrNomeExibicao();
                this.svi.ServiceName = this.getStrNome();
                this.svi.StartType = ServiceStartMode.Manual;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion Ações
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}