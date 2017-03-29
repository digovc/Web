using NetZ.Web.Server.Arquivo.Css;

namespace NetZ.Web.Html.Componente.Circulo
{
    public class DivCirculo : Div
    {
        #region Constantes

        public enum EnmTamanho
        {
            GRANDE,
            NORMAL,
            PEQUENO,
        }

        #endregion Constantes

        #region Atributos

        private EnmTamanho _enmTamanho = EnmTamanho.NORMAL;

        /// <summary>
        /// Indica o tamanho deste componente.
        /// </summary>
        public EnmTamanho enmTamanho
        {
            get
            {
                return _enmTamanho;
            }

            set
            {
                _enmTamanho = value;
            }
        }

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        protected override void addJs(LstTag<JavaScriptTag> lstJs)
        {
            base.addJs(lstJs);

            lstJs.Add(new JavaScriptTag(typeof(DivCirculo), 110));
        }

        protected override void setCss(CssArquivoBase css)
        {
            base.setCss(css);

            this.addCss(css.setBorderRadius(50, "%"));
            this.addCss(css.setOutline("none"));

            this.setCssEnmTamanho(css);
        }

        private void setCssEnmTamanho(CssArquivoBase css)
        {
            switch (this.enmTamanho)
            {
                case EnmTamanho.GRANDE:
                    this.addCss(css.setHeight(150));
                    this.addCss(css.setWidth(150));
                    return;

                case EnmTamanho.PEQUENO:
                    this.addCss(css.setHeight(25));
                    this.addCss(css.setWidth(25));
                    return;

                default:
                    this.addCss(css.setHeight(40));
                    this.addCss(css.setWidth(40));
                    return;
            }
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}