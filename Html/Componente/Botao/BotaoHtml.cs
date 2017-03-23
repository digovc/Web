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
        private int _intNivel;
        private int _intTamanhoVertical;

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

        public BotaoHtml()
        {
            this.strNome = "button";
        }

        #endregion Construtores

        #region Métodos

        protected override void addJs(LstTag<JavaScriptTag> lstJs)
        {
            base.addJs(lstJs);

            lstJs.Add(new JavaScriptTag(typeof(BotaoHtml), 113));
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

            this.setCssHeight(css);
            this.setCssWidth(css);
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