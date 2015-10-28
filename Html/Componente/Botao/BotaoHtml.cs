using System;

namespace NetZ.Web.Html.Componente.Botao
{
    public abstract class BotaoHtml : ComponenteHtml
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        #endregion Atributos

        #region Construtores

        public BotaoHtml()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.strConteudo = "Botão desconhecido";
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

        protected override void addJs(LstTag<JavaScriptTag> lstJs)
        {
            base.addJs(lstJs);

            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                //lstJs.Add(new JavaScriptTag(AppWeb.DIR_JS_BOTAO));
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