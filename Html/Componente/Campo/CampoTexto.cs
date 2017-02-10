using NetZ.Web.Server.Arquivo.Css;

namespace NetZ.Web.Html.Componente.Campo
{
    public class CampoTexto : CampoHtml
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        protected override void addJsDebug(LstTag<JavaScriptTag> lstJsDebug)
        {
            base.addJsDebug(lstJsDebug);

            lstJsDebug.Add(new JavaScriptTag(typeof(CampoTexto), 130));
        }

        protected override Input.EnmTipo getEnmTipo()
        {
            return Input.EnmTipo.TEXT_AREA;
        }

        protected override void inicializar()
        {
            base.inicializar();

            this.intTamanhoVertical = 2;
        }

        protected override void setCss(CssArquivo css)
        {
            base.setCss(css);

            this.tagInput.addCss(css.setMinHeight(this.intTamanhoVertical * 50 - 35));
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}