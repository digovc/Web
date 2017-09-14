using NetZ.Persistencia;
using NetZ.Web.Html.Componente.Botao;
using NetZ.Web.Server.Arquivo.Css;

namespace NetZ.Web.Html.Componente.Campo
{
    public abstract class CampoHtml : ComponenteHtmlBase, ITagNivel
    {
        #region Constantes

        public enum EnmTamanho
        {
            /// <summary>
            /// Width 370px.
            /// </summary>
            EXTRA,

            /// <summary>
            /// Width 240.
            /// </summary>
            GRANDE,

            /// <summary>
            /// Width 110px.
            /// </summary>
            MEDIO,

            /// <summary>
            /// Width 175px.
            /// </summary>
            NORMAL,

            /// <summary>
            /// Width 45px.
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
        private bool _booMostrarTituloSempre;
        private bool _booObrigatorio;
        private bool _booPermitirAlterar;
        private bool _booSomenteLeitura;
        private BotaoHtml _btnAcao;
        private Coluna _cln;
        private Div _divAreaDireita;
        private Div _divAreaEsquerda;
        private Div _divContainer;
        private Div _divTitulo;
        private EnmTamanho _enmTamanho = EnmTamanho.NORMAL;
        private int _intNivel;
        private int _intTamanhoVertical;
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

        public bool booMostrarTituloSempre
        {
            get
            {
                return _booMostrarTituloSempre;
            }

            set
            {
                _booMostrarTituloSempre = value;
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

        protected Div divContainer
        {
            get
            {
                if (_divContainer != null)
                {
                    return _divContainer;
                }

                _divContainer = new Div();

                return _divContainer;
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

        private BotaoHtml btnAcao
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

        private Div divAreaDireita
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

        private Div divAreaEsquerda
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

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        protected override void finalizar()
        {
            base.finalizar();

            this.addAtt("permitir_alterar", this.booPermitirAlterar);

            this.finalizarBooObrigatorio();

            this.finalizarMostrarTituloSempre();
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

            this.divContainer.setPai(this);

            this.divAreaEsquerda.setPai(this.divContainer);

            this.tagInput.setPai(this.divContainer);

            this.divAreaDireita.setPai(this.divContainer);

            this.btnAcao.setPai(this.divAreaDireita);
        }

        protected virtual void setCln(Coluna cln)
        {
            if (cln == null)
            {
                return;
            }

            this.addAtt("cln_web_nome", cln.sqlNome);
            this.addAtt("str_dica", cln.strDica);

            this.booObrigatorio = cln.booObrigatorio;
            this.booPermitirAlterar = cln.booPermitirAlterar;
            this.booSomenteLeitura = cln.booSomenteLeitura;
            this.strTitulo = cln.strNomeExibicao;

            this.tagInput.strValor = cln.strValor;

            this.setClnStrId(cln);
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

            this.btnAcao.addCss(css.setBackground("none"));
            this.btnAcao.addCss(css.setBackgroundColor("rgba(255,255,255,.5)"));
            this.btnAcao.addCss(css.setBorderRadius(0, 20, 20, 0));
            this.btnAcao.addCss(css.setHeight(100, "%"));
            this.btnAcao.addCss(css.setWidth(50));

            this.divAreaDireita.addCss(css.setFloat("right"));
            this.divAreaDireita.addCss(css.setHeight(100, "%"));
            this.divAreaDireita.addCss(css.setMinWidth(20));

            this.divAreaEsquerda.addCss(css.setFloat("left"));
            this.divAreaEsquerda.addCss(css.setHeight(100, "%"));
            this.divAreaEsquerda.addCss(css.setMinWidth(20));

            this.divContainer.addCss(css.setBackgroundColor("rgba(255,255,255,.25)"));
            this.divContainer.addCss(css.setBorderRadius(20));
            this.divContainer.addCss(css.setBorderRadius(20));
            this.divContainer.addCss(css.setFontSize(15));
            this.divContainer.addCss(css.setHeight(40));
            this.divContainer.addCss(css.setLeft(10));
            this.divContainer.addCss(css.setOverflow("hidden"));
            this.divContainer.addCss(css.setPosition("absolute"));
            this.divContainer.addCss(css.setRight(10));
            this.divContainer.addCss(css.setTextAlign("left"));

            this.divTitulo.addCss(css.setColor(AppWebBase.i.objTema.corTelaFundo));
            this.divTitulo.addCss(css.setFontSize(14));
            this.divTitulo.addCss(css.setHeight(15));
            this.divTitulo.addCss(css.setLineHeight(15));
            this.divTitulo.addCss(css.setOpacity(0));
            this.divTitulo.addCss(css.setPaddingTop(5));
            this.divTitulo.addCss(css.setTextAlign("left"));
            this.divTitulo.addCss(css.setTextIndent(15));

            this.setCssTagInputHeight(css);
            this.setCssTagInputWidth(css);

            this.tagInput.addCss(css.setBackground("none"));
            this.tagInput.addCss(css.setBorder(0));
            this.tagInput.addCss(css.setFontSize(15));
            this.tagInput.addCss(css.setOutline("none"));
        }

        protected virtual void setCssTagInputHeight(CssArquivoBase css)
        {
            this.tagInput.addCss(css.setHeight(100, "%"));
        }

        protected virtual void setCssTagInputWidth(CssArquivoBase css)
        {
            //this.tagInput.addCss(css.setWidth(100, "%"));
        }

        protected override void setStrId(string strId)
        {
            base.setStrId(strId);

            if (string.IsNullOrEmpty(strId))
            {
                return;
            }

            this.btnAcao.strId = (strId + "_btnAcao");
            this.divContainer.strId = (strId + "_divContainer");
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

        private void finalizarMostrarTituloSempre()
        {
            if (!this.booMostrarTituloSempre)
            {
                return;
            }

            this.addAtt("mostrar_titulo_sempre", true);
        }

        private void setBooSomenteLeitura(bool booSomenteLeitura)
        {
            this.tagInput.booDisabled = booSomenteLeitura;
        }

        private void setClnStrId(Coluna cln)
        {
            if (cln.tbl == null)
            {
                return;
            }

            string strId = "cmp__cln_nome__obj_id";

            strId = strId.Replace("_cln_nome", cln.sqlNome);
            strId = strId.Replace("_obj_id", this.intObjetoId.ToString());

            this.strId = strId;
        }

        private void setCssWidth(CssArquivoBase css)
        {
            switch (this.enmTamanho)
            {
                case EnmTamanho.EXTRA:
                    this.addCss(css.setWidth(370));
                    return;

                case EnmTamanho.GRANDE:
                    this.addCss(css.setWidth(240));
                    return;

                case EnmTamanho.NORMAL:
                    this.addCss(css.setWidth(175));
                    return;

                case EnmTamanho.PEQUENO:
                    this.addCss(css.setWidth(45));
                    return;

                case EnmTamanho.TOTAL:
                    this.setCssWidthTotal(css);
                    return;

                default:
                    this.addCss(css.setWidth(110));
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