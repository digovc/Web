using System;
using System.Collections.Generic;

namespace NetZ.Web.Html
{
    internal class Imagem : Tag
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        #endregion Atributos

        #region Construtores

        public Imagem() : base("img")
        {
        }

        #endregion Construtores

        #region Métodos

        protected override void addJs(List<JavaScriptTag> lstJs)
        {
            base.addJs(lstJs);

            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                lstJs.Add(new JavaScriptTag(AppWeb.DIR_JS_IMAGEM));
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