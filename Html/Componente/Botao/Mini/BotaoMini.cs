using NetZ.Web.Server.Arquivo.Css;

namespace NetZ.Web.Html.Componente.Botao.Mini
{
    public class BotaoMini : BotaoCircular
    {
        #region Constantes

        public enum EnmLado
        {
            DIREITA,
            ESQUERDA,
        }

        #endregion Constantes

        #region Atributos

        private EnmLado _enmLado = EnmLado.DIREITA;

        /// <summary>
        /// Indica o lado que que este componente estará dentro do seu container.
        /// </summary>
        public EnmLado enmLado
        {
            get
            {
                return _enmLado;
            }

            set
            {
                _enmLado = value;
            }
        }

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        protected override void addJs(LstTag<JavaScriptTag> lstJs)
        {
            base.addJs(lstJs);

            lstJs.Add(new JavaScriptTag(typeof(BotaoMini), 117));
        }

        protected override void finalizarCss(CssArquivo css)
        {
            base.finalizarCss(css);

            this.finalizarCssPadding(css);
        }

        protected override int getIntTamanho()
        {
            return 30;
        }

        protected override void inicializar()
        {
            base.inicializar();

            this.strConteudo = "?";
        }

        protected override void setCss(CssArquivo css)
        {
            base.setCss(css);

            this.addCss(css.setFloat(EnmLado.DIREITA.Equals(this.enmLado) ? "right" : "left"));
            this.addCss(css.setFontSize(15));
            this.addCss(css.setHeight(this.getIntTamanho()));
            this.addCss(css.setTextAlign("center"));
            this.addCss(css.setWidth(this.getIntTamanho()));
        }

        protected override void setCssBoxShadow(CssArquivo css)
        {
            return;
        }

        private void finalizarCssPadding(CssArquivo css)
        {
            if (EnmLado.DIREITA.Equals(this.enmLado))
            {
                this.addCss(css.setMarginLeft(5));
            }
            else
            {
                this.addCss(css.setMarginRight(5));
            }
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}