using System;

namespace NetZ.Web.Html.Componente.Botao
{
    public class BotaoAtalho : Botao
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        protected override void setCss(CssTag css)
        {
            base.setCss(css);

            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.addCss(css.setBackgroundColor("#AFAFAF"));
                this.addCss(css.setHeight(70));
                this.addCss(css.setWidth(70));
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