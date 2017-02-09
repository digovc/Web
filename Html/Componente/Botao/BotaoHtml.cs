using NetZ.Web.Server.Arquivo.Css;

namespace NetZ.Web.Html.Componente.Botao
{
    public class BotaoHtml : ComponenteHtml, ITagNivel
    {
        #region Constantes

        public enum EnmLado
        {
            DIREITA,
            ESQUERDA,
        }

        #endregion Constantes

        #region Atributos

        private bool _booFrmSubmit;
        private EnmLado _enmLado = EnmLado.DIREITA;
        private int _intNivel;
        private int _intTamanhoVerticalPx;

        /// <summary>
        /// Caso este botão esteja dentro de um formulário e não deseje que acione o submit do mesmo
        /// ao ser clicado (que é a ação padrão), basta alterar essa propriedade para false.
        /// </summary>
        public bool booFrmSubmit
        {
            get
            {
                return _booFrmSubmit;
            }

            set
            {
                _booFrmSubmit = value;
            }
        }

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

        /// <summary>
        /// Indica em que nível este botão será apresentado no formulário.
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

        /// <summary>
        /// Tamanho vertical do botão em pixels.
        /// </summary>
        public int intTamanhoVerticalPx
        {
            get
            {
                return _intTamanhoVerticalPx;
            }

            set
            {
                _intTamanhoVerticalPx = value;
            }
        }

        #endregion Atributos

        #region Construtores

        public BotaoHtml()
        {
            this.strNome = "button";
        }

        #endregion Construtores

        #region Métodos

        protected override void addJsDebug(LstTag<JavaScriptTag> lstJsDebug)
        {
            base.addJsDebug(lstJsDebug);

            lstJsDebug.Add(new JavaScriptTag(typeof(BotaoHtml), 113));
        }

        protected override void inicializar()
        {
            base.inicializar();

            this.addAtt("type", "button");
        }

        protected override void setCss(CssArquivo css)
        {
            base.setCss(css);

            this.addCss(css.setBorder(0));
            this.addCss(css.setCursor("pointer"));
            this.addCss(css.setFloat(EnmLado.DIREITA.Equals(this.enmLado) ? "right" : "left"));

            this.setCssFload(css);
            this.setCssHeight(css);
            this.setCssWidth(css);
        }

        protected virtual void setCssFload(CssArquivo css)
        {
            this.addCss(css.setFloat("right"));
        }

        protected virtual void setCssHeight(CssArquivo css)
        {
            this.addCss(css.setHeight(30));
        }

        protected virtual void setCssWidth(CssArquivo css)
        {
            this.addCss(css.setWidth(this.getDecWidth()));
        }

        private decimal getDecWidth()
        {
            if (this.intTamanhoVerticalPx > 0)
            {
                return this.intTamanhoVerticalPx;
            }

            if (string.IsNullOrEmpty(this.strConteudo))
            {
                return 30;
            }

            if (this.strConteudo.Length < 25)
            {
                return 100;
            }

            if (this.strConteudo.Length < 50)
            {
                return 125;
            }

            if (this.strConteudo.Length < 75)
            {
                return 150;
            }

            return 200;
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}