using System;
using NetZ.Web.Html.Design;

namespace NetZ.Web.Html.Componente.Botao
{
    public class BotaoMini : BotaoHtml
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        protected override void inicializar()
        {
            base.inicializar();

            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.strConteudo = null;
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
            //base.setCss(css);

            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.addCss(css.setBorder(0));
                this.addCss(css.setBorderRadius(50, "%"));
                this.addCss(css.setBoxShadow(0, 2, 2, 0, Tema.i.corSombra2));
                this.addCss(css.setColor("white"));
                this.addCss(css.setCursor("pointer"));
                this.addCss(css.setFloat("left"));
                this.addCss(css.setHeight(40));
                this.addCss(css.setLineHeight(40));
                this.addCss(css.setMargin(5));
                this.addCss(css.setTextAlign("center"));
                this.addCss(css.setWidth(40));
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