using System;

namespace NetZ.Web.Html.Componente.Campo
{
    /// <summary>
    /// Campo para a inserção de valores de qualquer espécie, como letras, números e até mesmo pontuação.
    /// </summary>
    public class CampoAlfanumerico : CampoHtml
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
                lstJsDebug.Add(new JavaScriptTag(typeof(CampoAlfanumerico), 131));
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
            return Input.EnmTipo.TEXT;
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}