using System;

namespace NetZ.Web.Html.Componente.Botao.Comando
{
    public class BotaoSalvarComando : BotaoComando
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
                lstJs.Add(new JavaScriptTag(typeof(BotaoSalvarComando), 115));
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

        protected override void inicializar()
        {
            base.inicializar();

            // TODO: Teste.
            this.strConteudo = "Salvar";
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}