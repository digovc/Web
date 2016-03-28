using System;

namespace NetZ.Web.Html.Componente.Campo
{
    /// <summary>
    /// Campo que pode ser utilizado para a entrada de senhas. Todo e qualquer caractere que o
    /// usuário digitar neste campo será encoberto por uma máscara que não permitirá visualizar o que
    /// foi inserido.
    /// </summary>
    public class CampoSenha : CampoAlfanumerico
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
                lstJs.Add(new JavaScriptTag(typeof(CampoSenha), 130));
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
            return Input.EnmTipo.PASSWORD;
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}