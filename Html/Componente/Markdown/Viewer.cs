using NetZ.Web.Server.Arquivo.Css;

namespace NetZ.Web.Html.Componente.Markdown
{
    internal class Viewer : ComponenteHtml
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private Div _divConteudo;

        private Div divConteudo
        {
            get
            {
                if (_divConteudo != null)
                {
                    return _divConteudo;
                }

                _divConteudo = new Div();

                return _divConteudo;
            }
        }

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        protected override bool getBooJs()
        {
            return true;
        }

        protected override void inicializar()
        {
            base.inicializar();

            this.strId = this.GetType().Name;

            this.divConteudo.addClass("markdown-body");
        }

        protected override void montarLayout()
        {
            base.montarLayout();

            this.divConteudo.setPai(this);
        }

        protected override void setCss(CssArquivo css)
        {
            base.setCss(css);

            this.addCss(css.setBottom(0));
            this.addCss(css.setLeft(0));
            this.addCss(css.setOverflow("auto"));
            this.addCss(css.setPosition("absolute"));
            this.addCss(css.setRight(0));
            this.addCss(css.setTop(50));
            this.addCss(css.setZIndex(-1));

            this.divConteudo.addCss(css.setDisplay("none"));
            this.divConteudo.addCss(css.setMargin("auto"));
            this.divConteudo.addCss(css.setMaxWidth(640));
            this.divConteudo.addCss(css.setPadding(15));
        }

        protected override void setStrId(string strId)
        {
            base.setStrId(strId);

            this.divConteudo.strId = (strId + "_divConteudo");
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}