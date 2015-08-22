using System;
using NetZ.Web.Server;

namespace NetZ.Web
{
    public abstract class AppWeb
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private static AppWeb _i;

        public static AppWeb i
        {
            get
            {
                return _i;
            }

            set
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_i != null)
                    {
                        return;
                    }

                    _i = value;
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
        }

        #endregion Atributos

        #region Construtores

        protected AppWeb()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                AppWeb.i = this;
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

        /// <summary>
        /// Inicializa o serviço WEB e demais componentes que ficarão disponíveis para servir esta
        /// aplicação para os cliente.
        /// <para>
        /// Estes serviços levarão em consideração as configurações presentes em <seealso cref="ConfigWeb.i"/>.
        /// </para>
        /// </summary>
        public void inicializar()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                Server.Server.i.iniciar();
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

        public abstract Resposta responder(Solicitacao objSolicitacao);

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}