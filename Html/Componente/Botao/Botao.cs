using System;
using System.Collections.Generic;

namespace NetZ.Web.Html.Componente.Botao
{
    public class Botao : Tag
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        #endregion Atributos

        #region Construtores

        public Botao() : base("button")
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

        protected override void addJs(List<JavaScriptTag> lstJs)
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