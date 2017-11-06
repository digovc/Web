using NetZ.Web.Html.Componente.Markdown;
using NetZ.Web.Server.Arquivo.Css;

namespace NetZ.Web.Html.Componente.Documentacao
{
    internal class Viewer : ComponenteHtmlBase
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private DivMarkdown _divMarkdown;

        private DivMarkdown divMarkdown
        {
            get
            {
                if (_divMarkdown != null)
                {
                    return _divMarkdown;
                }

                _divMarkdown = new DivMarkdown();

                return _divMarkdown;
            }
        }

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        protected override void inicializar()
        {
            base.inicializar();

            this.strId = this.GetType().Name;
        }

        protected override void montarLayout()
        {
            base.montarLayout();

            this.divMarkdown.setPai(this);
        }

        protected override void setCss(CssArquivoBase css)
        {
            base.setCss(css);

            this.addCss(css.setBottom(0));
            this.addCss(css.setLeft(0));
            this.addCss(css.setOverflow("auto"));
            this.addCss(css.setRight(0));
            this.addCss(css.setPaddingBottom(50));
            this.addCss(css.setPaddingTop(50));
            this.addCss(css.setZIndex(1));

            this.divMarkdown.addCss(css.setDisplay("none"));
            this.divMarkdown.addCss(css.setMargin("auto"));
            this.divMarkdown.addCss(css.setMaxWidth(640));
            this.divMarkdown.addCss(css.setPadding(15));
        }

        protected override void setStrId(string strId)
        {
            base.setStrId(strId);

            this.divMarkdown.strId = (strId + "_divMarkdown");
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}