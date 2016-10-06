using System;

namespace NetZ.Web.Html.Componente.Campo
{
    public class CampoDataHora : CampoHtml
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        protected override void addJsDebug(LstTag<JavaScriptTag> lstJsDebug)
        {
            base.addJsDebug(lstJsDebug);

            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                lstJsDebug.Add(new JavaScriptTag(typeof(CampoDataHora), 130));
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

        protected override Input.EnmTipo getEnmTipo()
        {
            return Input.EnmTipo.DATETIME;
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}