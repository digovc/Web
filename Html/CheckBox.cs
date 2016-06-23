using NetZ.Web.Html.Componente;
using NetZ.Web.Server.Arquivo.Css;

namespace NetZ.Web.Html
{
    public class CheckBox : Input
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private Div _divQuadrado;
        private Div _divTitulo;

        private string _strTitulo;

        /// <summary>
        /// Título que ficará visível para o usuário na frente do checkbox.
        /// </summary>
        public string strTitulo
        {
            get
            {
                return _strTitulo;
            }

            set
            {
                _strTitulo = value;
            }
        }

        private Div divQuadrado
        {
            get
            {
                if (_divQuadrado != null)
                {
                    return _divQuadrado;
                }

                _divQuadrado = new Div();

                return _divQuadrado;
            }
        }

        private Div divTitulo
        {
            get
            {
                if (_divTitulo != null)
                {
                    return _divTitulo;
                }

                _divTitulo = new Div();

                return _divTitulo;
            }
        }

        #endregion Atributos

        #region Construtores

        public CheckBox()
        {
            this.strNome = "div";
        }

        #endregion Construtores

        #region Métodos

        protected override void finalizar()
        {
            base.finalizar();

            this.divTitulo.strConteudo = this.strTitulo;
        }

        protected override void montarLayout()
        {
            base.montarLayout();

            this.divQuadrado.setPai(this);

            this.divTitulo.setPai(this);

            new LimiteFloat().setPai(this);
        }

        protected override void setCss(CssArquivo css)
        {
            base.setCss(css);

            this.addCss(css.setCursor("pointer"));

            this.divQuadrado.addCss(css.setBackgroundColor("white"));
            this.divQuadrado.addCss(css.setBorder(1, "solid", "gray"));
            this.divQuadrado.addCss(css.setBorderRadius(3));
            this.divQuadrado.addCss(css.setFloat("left"));
            this.divQuadrado.addCss(css.setHeight(16));
            this.divQuadrado.addCss(css.setWidth(16));

            this.divTitulo.addCss(css.setPaddingLeft(25));
            this.divTitulo.addCss(css.setPaddingTop(2));
            this.divTitulo.addCss(css.setTextAlign("left"));
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}