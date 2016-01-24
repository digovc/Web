using System;

namespace NetZ.Web.Html.Componente.Botao.Acao
{
    public class BotaoAcao : BotaoHtml
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
                lstJs.Add(new JavaScriptTag(typeof(BotaoAcao), 120));
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
                this.addCss(css.setBackgroundColor("#03a9f4"));
                this.addCss(css.setBorder(1, "solid", "#059ce0"));
                this.addCss(css.setBorderRadius(50, "%"));
                this.addCss(css.setBoxShadow(0, 5, 10, 0, AppWeb.i.objTema.corSombra));
                this.addCss(css.setHeight(65));
                this.addCss(css.setOutLine("none"));
                this.addCss(css.setPosition("absolute"));
                this.addCss(css.setWidth(65));
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