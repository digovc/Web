using System;
using NetZ.Web.Server.Arquivo.Css;

namespace NetZ.Web.Html.Componente
{
    public class LimiteFloat : ComponenteHtml
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        protected override void setCss(CssArquivo tagCss)
        {
            base.setCss(tagCss);

            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.addCss(tagCss.setClearBoth());
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