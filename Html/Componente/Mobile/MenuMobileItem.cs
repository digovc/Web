using NetZ.Web.Server.Arquivo.Css;

namespace NetZ.Web.Html.Componente.Mobile
{
    public class MenuMobileItem : ComponenteHtml
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private Div _divIcone;
        private Div _divTitulo;
        private string _srcIcone;
        private string _strTitulo;

        public string srcIcone
        {
            get
            {
                return _srcIcone;
            }

            set
            {
                _srcIcone = value;
            }
        }

        public string strTitulo
        {
            get
            {
                return _strTitulo;
            }

            set
            {
                _strTitulo = value;

                this.setStrTitulo(_strTitulo);
            }
        }

        private Div divIcone
        {
            get
            {
                if (_divIcone != null)
                {
                    return _divIcone;
                }

                _divIcone = new Div();

                return _divIcone;
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

        #endregion Construtores

        #region Métodos

        protected override void montarLayout()
        {
            base.montarLayout();

            this.divIcone.setPai(this);
            this.divTitulo.setPai(this);
        }

        protected override void setCss(CssArquivoBase css)
        {
            base.setCss(css);

            this.addCss(css.setBackgroundColor("white"));
            this.addCss(css.setCursor("pointer"));
            this.addCss(css.setHeight(50));
            this.addCss(css.setMarginBottom(10));
            this.addCss(css.setWidth(100, "%"));

            this.divIcone.addCss(css.setBackgroundColor(AppWebBase.i.objTema.corTema));
            this.divIcone.addCss(css.setBorderRadius(50, "%"));
            this.divIcone.addCss(css.setFloat("left"));
            this.divIcone.addCss(css.setHeight(50));
            this.divIcone.addCss(css.setMarginRight(10));
            this.divIcone.addCss(css.setWidth(50));

            this.divTitulo.addCss(css.setLineHeight(50));
        }

        private void setStrTitulo(string strTitulo)
        {
            this.divTitulo.strConteudo = strTitulo;
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}