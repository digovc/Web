using System;
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
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_appWeb != null)
                    {
                        return _appWeb;
                    }

                    _appWeb = this.getAppWeb();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _appWeb;
            }
        }

        #endregion Atributos

        #region Construtores

        public NetZWebService()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.InitializeComponent();

                this.ServiceName = this.GetType().Name;
                this.EventLog.Log = this.GetType().Name + "_log";

                this.CanHandlePowerEvent = true;
                this.CanHandleSessionChangeEvent = true;
                this.CanPauseAndContinue = true;
                this.CanShutdown = true;
                this.CanStop = true;
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

        protected abstract AppWebBase getAppWeb();

        private void inicializar()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (this.appWeb == null)
                {
                    throw new NullReferenceException("A propriedade \"appWeb\" está nula.");
                }

                this.appWeb.inicializarServidor();
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

        protected override void OnStart(string[] args)
        {
            base.OnStart(args);

            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                // Comentar sempre que não quiser debugar.
                //Debugger.Launch();

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

        protected override void OnStop()
        {
            base.OnStop();

            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (this.appWeb == null)
                {
                    throw new NullReferenceException("A propriedade \"appWeb\" está nula.");
                }

                this.appWeb.pararServidor();
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

        #endregion Eventos
    }
}