using NetZ.Web.Server.Arquivo.Css;

namespace NetZ.Web.Html.Componente.Painel
{
    public class PainelNivel : PainelHtml, ITagNivel
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private int _intNivel;

        /// <summary>
        /// Indica qual é o nível dentro do formulário.
        /// </summary>
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

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        protected override void setCss(CssArquivoBase css)
        {
            base.setCss(css);

            this.addCss(css.setMinHeight(50));
            this.addCss(css.setPaddingLeft(0));
            this.addCss(css.setPaddingRight(0));
            this.addCss(css.setPosition("relative"));
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}