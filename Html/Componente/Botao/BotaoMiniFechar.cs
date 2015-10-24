using System;

namespace NetZ.Web.Html.Componente.Botao
{
    public class BotaoMiniFechar : BotaoMini
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        #endregion Atributos

        #region Construtores

        public BotaoMiniFechar()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.strConteudo = "X";
                this.strId = "divFechar";
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

        protected override void setCss(CssTag css)
        {
            base.setCss(css);

            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.addCss(css.setBackgroundColor("#CE5757"));
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