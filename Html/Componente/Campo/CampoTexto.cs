using System;

namespace NetZ.Web.Html.Componente.Campo
{
    public class CampoTexto : CampoHtml
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        protected override void addJs(LstTag<JavaScriptTag> lstJs)
        {
            base.addJs(lstJs);

            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                lstJs.Add(new JavaScriptTag(typeof(CampoTexto), 130));
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
            return Input.EnmTipo.TEXT_AREA;
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}