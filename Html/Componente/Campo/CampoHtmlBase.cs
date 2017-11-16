using NetZ.Persistencia;
using NetZ.Web.Html.Componente.Botao;
using NetZ.Web.Server.Arquivo.Css;

namespace NetZ.Web.Html.Componente.Campo
{
    public abstract class CampoHtmlBase : ComponenteHtmlBase, ITagNivel
    {
        #region Constantes

        public enum EnmTamanho
        {
            /// <summary>
            /// Width 320.
            /// </summary>
            GRANDE,

            /// <summary>
            /// Width 160px.
            /// </summary>
            PEQUENO,

            /// <summary>
            /// Width 100%.
            /// </summary>
            TOTAL,
        }

        private const string STR_TITULO = "Campo desconhecido";

        #endregion Constantes

        #region Atributos

        private bool _booDireita;
        private bool _booObrigatorio;
        private bool _booPermitirAlterar = true;
        private bool _booSomenteLeitura;
        private bool _booTituloFixo;
        private BotaoHtml _btnAcao;
        private Coluna _cln;
        private Div _divAreaDireita;
        private Div _divAreaEsquerda;
        private Div _divConteudo;
        private Div _divTitulo;
        private EnmTamanho _enmTamanho = EnmTamanho.GRANDE;
        private int _intNivel;
        private int _intTamanhoVertical;
        private string _strRegex;
        private string _strRegexAjuda;
        private string _strTitulo;
        private Input _tagInput;

        /// <summary>
        /// Indica se o campo estará alinhado a direita da janela.
        /// </summary>
        public bool booDireita
        {
            get
            {
                return _booDireita;
            }

            set
            {
                _booDireita = value;
            }
        }

        /// <summary>
        /// Define se este campo é de preenchimento obrigatório ou não. Caso seja, será indicado de
        /// forma visual para o usuário.
        /// </summary>
        public bool booObrigatorio
        {
            get
            {
                return _booObrigatorio;
            }

            set
            {
                _booObrigatorio = value;
            }
        }

        /// <summary>
        /// Indica se o usuário poderá alterar o valor do campo.
        /// </summary>
        public bool booSomenteLeitura
        {
            get
            {
                return _booSomenteLeitura;
            }

            set
            {
                _booSomenteLeitura = value;

                this.setBooSomenteLeitura(_booSomenteLeitura);
            }
        }

        /// <summary>
        /// Indica se o título ficará sempre a mostra.
        /// </summary>
        public bool booTituloFixo
        {
            get
            {
                return _booTituloFixo;
            }

            set
            {
                _booTituloFixo = value;
            }
        }

        /// <summary>
        /// Coluna que este campo representa no formulário.
        /// </summary>
        public Coluna cln
        {
            get
            {
                return _cln;
            }

            set
            {
                if (_cln == value)
                {
                    return;
                }

                _cln = value;

                this.setCln(_cln);
            }
        }

        public Div divAreaEsquerda
        {
            get
            {
                if (_divAreaEsquerda != null)
                {
                    return _divAreaEsquerda;
                }

                _divAreaEsquerda = new Div();

                return _divAreaEsquerda;
            }
        }

        /// <summary>
        /// Indica o tamanho horizontal deste campo.
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

        /// <summary>
        /// Indica em qual nível do formulário este campo aparecerá, sendo o nível 0 (zero) o
        /// primeiro nível de cima para baixo.
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

        public string strRegex
        {
            get
            {
                return _strRegex;
            }

            set
            {
                _strRegex = value;
            }
        }

        public string strRegexAjuda
        {
            get
            {
                return _strRegexAjuda;
            }

            set
            {
                _strRegexAjuda = value;
            }
        }

        /// <summary>
        /// Título que será apresentado no canto superior esquerdo deste campo para que o usuário
        /// possa identificá-lo.
        /// </summary>
        public string strTitulo
        {
            get
            {
                return _strTitulo;
            }

            set
            {
                if (_strTitulo == value)
                {
                    return;
                }

                _strTitulo = value;

                this.setStrTitulo(_strTitulo);
            }
        }

        public Input tagInput
        {
            get
            {
                if (_tagInput != null)
                {
                    return _tagInput;
                }

                _tagInput = this.getTagInput();

                return _tagInput;
            }
        }

        protected BotaoHtml btnAcao
        {
            get
            {
                if (_btnAcao != null)
                {
                    return _btnAcao;
                }

                _btnAcao = new BotaoHtml();

                return _btnAcao;
            }
        }

        protected Div divAreaDireita
        {
            get
            {
                if (_divAreaDireita != null)
                {
                    return _divAreaDireita;
                }

                _divAreaDireita = new Div();

                return _divAreaDireita;
            }
        }

        protected Div divConteudo
        {
            get
            {
                if (_divConteudo != null)
            {
                    return _divConteudo;
            }

                _divConteudo = new Div();

                return _divConteudo;
            }
        }

        protected Div divTitulo
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

        private bool booPermitirAlterar
        {
            get
            {
                return _booPermitirAlterar;
            }

            set
            {
                _booPermitirAlterar = value;
            }
        }

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        protected override void finalizar()
        {
            base.finalizar();

            this.addAtt("permitir-alterar", this.booPermitirAlterar);

            this.finalizarBooObrigatorio();
            this.finalizarStrRegex();
            this.finalizarStrRegexAjuda();
            this.finalizarTitulofixo();
        }

        protected abstract Input.EnmTipo getEnmTipo();

        protected virtual Input getTagInput()
        {
            return new Input();
        }

        protected override void inicializar()
        {
            base.inicializar();

            this.tagInput.enmTipo = this.getEnmTipo();
        }

        protected override void montarLayout()
        {
            base.montarLayout();

            this.divTitulo.setPai(this);

            this.divConteudo.setPai(this);

            this.divAreaEsquerda.setPai(this.divConteudo);

            this.montarLayoutDivConteudo();

            this.divAreaDireita.setPai(this.divConteudo);

            this.btnAcao.setPai(this.divAreaDireita);
        }

        protected virtual void montarLayoutDivConteudo()
        {
            this.tagInput.setPai(this.divConteudo);
        }

        protected virtual void setCln(Coluna cln)
        {
            if (cln == null)
            {
                return;
            }

            this.setClnDica(cln);

            this.addAtt("coluna-nome", cln.sqlNome);

            this.booObrigatorio = cln.booObrigatorio;
            this.booPermitirAlterar = cln.booPermitirAlterar;
            this.booSomenteLeitura = cln.booSomenteLeitura;
            this.strId = string.Format("cmp_{0}_{1}", cln.sqlNome, this.intObjetoId);
            this.strTitulo = cln.strNomeExibicao;

            this.tagInput.strValor = cln.strValor;
        }

        protected override void setCss(CssArquivoBase css)
        {
            base.setCss(css);

            this.setCssWidth(css);

            this.addCss(css.setFloat(this.booDireita ? "right" : "left"));
            this.addCss(css.setHeight(100, "%"));
            this.addCss(css.setMaxHeight(65));
            this.addCss(css.setPaddingLeft(10));
            this.addCss(css.setPaddingRight(10));
            this.addCss(css.setPosition((EnmTamanho.TOTAL.Equals(this.enmTamanho)) ? "absolute" : "relative"));

            this.btnAcao.addCss(css.setBackgroundColor("rgba(255,255,255,.5)"));
            this.btnAcao.addCss(css.setBackgroundPosition("center"));
            this.btnAcao.addCss(css.setBackgroundPositionX(-2));
            this.btnAcao.addCss(css.setBorderRadius(0, 20, 20, 0));
            this.btnAcao.addCss(css.setDisplay("none"));
            this.btnAcao.addCss(css.setHeight(100, "%"));
            this.btnAcao.addCss(css.setWidth(40));

            this.divAreaDireita.addCss(css.setFloat("right"));
            this.divAreaDireita.addCss(css.setHeight(100, "%"));
            this.divAreaDireita.addCss(css.setMinWidth(20));

            this.divAreaEsquerda.addCss(css.setFloat("left"));
            this.divAreaEsquerda.addCss(css.setHeight(100, "%"));
            this.divAreaEsquerda.addCss(css.setMinWidth(20));

            this.divConteudo.addCss(css.setBackgroundColor("rgba(255,255,255,.15)"));
            this.divConteudo.addCss(css.setBorderRadius(20));
            this.divConteudo.addCss(css.setBorderRadius(20));
            this.divConteudo.addCss(css.setFontSize(15));
            this.divConteudo.addCss(css.setHeight(40));
            this.divConteudo.addCss(css.setMarginLeft(10));
            this.divConteudo.addCss(css.setMarginRight(10));
            this.divConteudo.addCss(css.setTextAlign("left"));

            this.divTitulo.addCss(css.setFontSize(14));
            this.divTitulo.addCss(css.setLineHeight(20));
            this.divTitulo.addCss(css.setOpacity(0));
            this.divTitulo.addCss(css.setTextAlign("left"));
            this.divTitulo.addCss(css.setTextIndent(15));

            this.tagInput.addCss(css.setBackground("none"));
            this.tagInput.addCss(css.setBorder(0));
            this.tagInput.addCss(css.setColor(AppWebBase.i.objTema.corFonte));
            this.tagInput.addCss(css.setFontSize(15));
            this.tagInput.addCss(css.setOutline("none"));

            this.setCssTagInputHeight(css);
            this.setCssTagInputWidth(css);
        }

        protected virtual void setCssTagInputHeight(CssArquivoBase css)
        {
            this.tagInput.addCss(css.setLineHeight(37));
        }

        protected virtual void setCssTagInputWidth(CssArquivoBase css)
        {
            this.tagInput.addCss(css.setWidth(this.getIntWigth() - 60));
        }

        protected override void setStrId(string strId)
        {
            base.setStrId(strId);

            if (string.IsNullOrEmpty(strId))
            {
                return;
            }

            this.btnAcao.strId = (strId + "_btnAcao");
            this.divConteudo.strId = (strId + "_divConteudo");
            this.divTitulo.strId = (strId + "_divTitulo");
            this.tagInput.strId = (strId + "_tagInput");
        }

        protected virtual void setStrTitulo(string strTitulo)
        {
            this.divTitulo.strConteudo = (!string.IsNullOrEmpty(strTitulo)) ? strTitulo : STR_TITULO;
            this.tagInput.strPlaceHolder = (!string.IsNullOrEmpty(strTitulo)) ? strTitulo : STR_TITULO;
        }

        private void finalizarBooObrigatorio()
        {
            if (!this.booObrigatorio)
            {
                return;
            }

            this.addAtt("required", true);
        }

        private void finalizarStrRegex()
        {
            if (string.IsNullOrWhiteSpace(this.strRegex))
            {
                return;
            }

            this.addAtt("regex", this.strRegex);
        }

        private void finalizarStrRegexAjuda()
        {
            if (string.IsNullOrWhiteSpace(this.strRegexAjuda))
            {
                return;
            }

            this.addAtt("regex-ajuda", this.strRegex);
        }

        private void finalizarTitulofixo()
        {
            if (!this.booTituloFixo)
            {
                return;
            }

            this.addAtt("titulo-fixo", true);
        }

        private int getIntWigth()
        {
            switch (this.enmTamanho)
            {
                case EnmTamanho.PEQUENO:
                    return 160;

                default:
                    return 320;
            }
        }

        private void setBooSomenteLeitura(bool booSomenteLeitura)
        {
            this.tagInput.booDisabled = booSomenteLeitura;
        }

        private void setClnDica(Coluna cln)
        {
            if (string.IsNullOrEmpty(cln.strDica))
            {
                return;
            }

            this.addAtt("dica", cln.strDica);
        }

        private void setCssWidth(CssArquivoBase css)
        {
            switch (this.enmTamanho)
            {
                case EnmTamanho.TOTAL:
                    this.setCssWidthTotal(css);
                    return;

                default:
                    this.addCss(css.setWidth(this.getIntWigth()));
                    return;
            }
        }

        private void setCssWidthTotal(CssArquivoBase css)
        {
            this.addCss(css.setLeft(0));
            this.addCss(css.setRight(0));
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}