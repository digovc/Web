using System;
using NetZ.Web.Html.Componente.Menu.Chat;

namespace NetZ.Web.Html.Componente.Menu
{
    public class DivGavetaLateral : ComponenteHtml
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        protected override void montarLayout()
        {
            base.montarLayout();

            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                new DivChatUsuario().setPai(this);
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
                this.addCss(css.setBackgroundColor("rgba(88,178,150,0.75)"));
                this.addCss(css.setBottom(0));
                this.addCss(css.setPadding(20));
                this.addCss(css.setPosition("absolute"));
                this.addCss(css.setRight(0));
                this.addCss(css.setTop(50));
                this.addCss(css.setWidth(300));
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