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
                this.strNome = "button";
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
                this.addCss(css.setBorder(0));
                this.addCss(css.setCursor("pointer"));
                this.addCss(css.setFloat("right"));
                this.addCss(css.setHeight(50));
                this.addCss(css.setWidth(this.getIntWidth()));
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

        private double getIntWidth()
        {

            #region Variáveis
            #endregion Variáveis

            #region Ações
            try
            {
                if (string.IsNullOrEmpty(this.strConteudo))
                {
                    return 30;
                }

                if (this.strConteudo.Length < 25)
                {
                    return 100;
                }

                if (this.strConteudo.Length < 50)
                {
                    return 125;
                }

                if (this.strConteudo.Length < 75)
                {
                    return 150;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }
            #endregion Ações

            return 175;
        }

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