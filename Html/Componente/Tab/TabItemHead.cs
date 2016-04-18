using NetZ.Web.Server.Arquivo.Css;

namespace NetZ.Web.Html.Componente.Tab
{
    internal class TabItemHead : ComponenteHtml
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private string _strTitulo = "Tab desconhecida";

        public string strTitulo
        {
            get
            {
                return _strTitulo;
            }

            set
            {
                _strTitulo = value;

                this.atualizarStrTitulo();
            }
        }

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        protected override void setCss(CssArquivo css)
        {
            base.setCss(css);

            this.addCss(css.setBackgroundColor("rgba(88,178,150,0.5)"));
            this.addCss(css.setFloat("left"));
            this.addCss(css.setHeight(30));
            this.addCss(css.setLineHeight(30));
            this.addCss(css.setOverflow("hide"));
            this.addCss(css.setPaddingLeft(10));
            this.addCss(css.setPaddingRight(10));
            this.addCss(css.setWidth(130));
        }

        private void atualizarStrTitulo()
        {
            this.strConteudo = this.strTitulo;
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}