using NetZ.Web.Server.Arquivo.Css;

namespace NetZ.Web.Html.Componente.Botao
{
    public class BotaoCircular : BotaoHtml
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
        protected override void addJs(JavaScriptTag js)
        {
            base.addJs(js);
        }
        protected virtual int getIntTamanho()
        {
            switch (this.enmTamanho)
            {
                case EnmTamanho.GRANDE:
                    return 60;

                case EnmTamanho.PEQUENO:
                    return 30;

                default:
                    return 40;
            }
        }

        protected override void setCss(CssArquivoBase css)
        {
            base.setCss(css);

            this.addCss(css.setBackgroundPosition("center"));
            this.addCss(css.setBackgroundRepeat("no-repeat"));
            this.addCss(css.setBackgroundSize((this.getIntTamanho() * .75).ToString("0px")));
            this.addCss(css.setBorderRadius(50, "%"));
            this.addCss(css.setBoxShadow(0, 2, 2, 0, "rgba(0,0,0,.5)"));
            this.addCss(css.setHeight(this.getIntTamanho()));
            this.addCss(css.setOutline("none"));
            this.addCss(css.setTextAlign("center"));
            this.addCss(css.setWidth(this.getIntTamanho()));
        }

        protected override void setCssHeight(CssArquivoBase css)
        {
            this.addCss(css.setHeight(this.getIntTamanho()));
        }

        protected override void setCssWidth(CssArquivoBase css)
        {
            this.addCss(css.setWidth(this.getIntTamanho()));
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}