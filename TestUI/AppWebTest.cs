using System;
using NetZ.Web;
using NetZ.Web.Server;

namespace NetZ.WebTestUi
{
    public class AppWebTest : AppWeb
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private static AppWebTest _i;

        public static AppWebTest i
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_i != null)
                    {
                        return _i;
                    }

                    _i = new AppWebTest();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _i;
            }
        }

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        public override Resposta responder(Solicitacao objSolicitacao)
        {
            throw new NotImplementedException();
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}