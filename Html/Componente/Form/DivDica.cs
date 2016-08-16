using NetZ.Web.Server.Arquivo.Css;

namespace NetZ.Web.Html.Componente.Form
{
    public class DivDica : ComponenteHtml, ITagNivel
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private int _intNivel;
        private int _intTamanhoVertical;

        public int intNivel
        {
            get
            {
                return _intNivel;
            }

            set
            {
                _intNivel = value;
            }
        }

        public int intTamanhoVertical
        {
            get
            {
                return _intTamanhoVertical;
            }

            set
            {
                _intTamanhoVertical = value;
            }
        }

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        protected override void setCss(CssArquivo css)
        {
            base.setCss(css);

            this.addCss(css.setFontSize(12));
            this.addCss(css.setPaddingTop(8));
            this.addCss(css.setTextAlign("center"));
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}