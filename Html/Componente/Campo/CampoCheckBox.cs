using System;
using NetZ.Web.Server.Arquivo.Css;

namespace NetZ.Web.Html.Componente.Campo
{
    public class CampoCheckBox : CampoHtml
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
                lstJs.Add(new JavaScriptTag(typeof(CampoCheckBox), 130));
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

        protected override Input.EnmTipo getEnmTipo()
        {
            return Input.EnmTipo.CHECKBOX;
        }

        protected override void setCss(CssArquivo css)
        {
            base.setCss(css);

            this.tagInput.addCss(css.setTextAlign("left"));
        }

        protected override void setCssTagInputHeight(CssArquivo css)
        {
            //base.setCssTagInputHeight(css);
            this.tagInput.addCss(css.setHeight(15));
        }

        protected override void setCssTagInputWidth(CssArquivo css)
        {
            //base.setCssTagInputWidth(css);
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}