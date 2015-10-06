using System;

namespace NetZ.Web.Html
{
    internal class LimiteFloat : Tag
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        #endregion Atributos

        #region Construtores

        public LimiteFloat() : base("div")
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.booTagDupla = true;
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

        protected override void setCss(CssTag tagCss)
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