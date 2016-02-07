using System;
using NetZ.Web.Server.Arquivo.Css;

namespace NetZ.Web.Html.Componente.Botao
{
    public class BotaoCircular : BotaoHtml
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
                lstJs.Add(new JavaScriptTag(typeof(BotaoCircular), 116));
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

        protected virtual int getIntTamanho()
        {
            return 65;
        }

        protected override void setCss(CssArquivo css)
        {
            //base.setCss(css);

            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.addCss(css.setBackgroundColor("#03a9f4"));
                this.addCss(css.setBorder(0));
                this.addCss(css.setBorderRadius(50, "%"));
                this.addCss(css.setBoxShadow(0, 5, 10, 0, AppWeb.i.objTema.corSombra));
                this.addCss(css.setCursor("pointer"));
                this.addCss(css.setHeight(this.getIntTamanho()));
                this.addCss(css.setOutLine("none"));
                this.addCss(css.setWidth(this.getIntTamanho()));
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