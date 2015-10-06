using System;
using System.Collections.Generic;

namespace NetZ.Web.Html
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
                lstJs.Add(new JavaScriptTag(AppWeb.DIR_JS_BOTAO));
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

        protected override void setCss(CssTag css)
        {
            base.setCss(css);

            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.addCss(css.setColor("#333"));
                this.addCss(css.setFloat("right"));
                this.addCss(css.setNegrito());
                this.addCss(css.setMarginLeft(5));
                this.addCss(css.setPaddingBottom(7));
                this.addCss(css.setPaddingLeft(25));
                this.addCss(css.setPaddingRight(25));
                this.addCss(css.setPaddingTop(7));
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