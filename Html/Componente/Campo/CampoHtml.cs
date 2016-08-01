using System;
using NetZ.Persistencia;
using NetZ.Web.Server.Arquivo.Css;

namespace NetZ.Web.Html.Componente.Campo
{
    public abstract class CampoHtml : ComponenteHtml, ITagNivel
    {
        #region Constantes

        public enum EnmTamanho
        {
            /// <summary>
            /// Width 400.
            /// </summary>
            GRANDE,

            /// <summary>
            /// Width 150px.
            /// </summary>
            MEDIO,

            /// <summary>
            /// Width 50px.
            /// </summary>
            MINIMO,

            /// <summary>
            /// Width 250px.
            /// </summary>
            NORMAL,

            /// <summary>
            /// Width 100px.
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
        private bool _booSomenteLeitura;
        private Coluna _cln;
        private Div _divInputContainer;
        private Div _divObrigatorio;
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
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    _booSomenteLeitura = value;

                    this.atualizarBooSomenteLeitura();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações
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
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_cln == value)
                    {
                        return;
                    }

                    _cln = value;

                    this.atualizarCln();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações
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
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_strTitulo == value)
                    {
                        return;
                    }

                    _strTitulo = value;

                    this.atualizarStrTitulo();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações
            }
        }

        public Input tagInput
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_tagInput != null)
                    {
                        return _tagInput;
                    }

                    _tagInput = this.getTagInput();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _tagInput;
            }
        }

        protected Div divInputContainer
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_divInputContainer != null)
                    {
                        return _divInputContainer;
                    }

                    _divInputContainer = new Div();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _divInputContainer;
            }
        }

        protected Div divTitulo
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_divTitulo != null)
                    {
                        return _divTitulo;
                    }

                    _divTitulo = new Div();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _divTitulo;
            }
        }

        private Div divObrigatorio
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_divObrigatorio != null)
                    {
                        return _divObrigatorio;
                    }

                    _divObrigatorio = new Div();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _divObrigatorio;
            }
        }

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        protected override void addJs(LstTag<JavaScriptTag> lstJs)
        {
            base.addJs(lstJs);

            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                lstJs.Add(new JavaScriptTag(typeof(CampoHtml), 130));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion Ações
        }

        protected virtual void atualizarCln()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (this.cln == null)
                {
                    return;
                }

                this.addAtt("cln_web_nome", this.cln.strNomeSql);
                this.addAtt("str_dica", this.cln.strDica);

                this.booObrigatorio = this.cln.booObrigatorio;
                this.booSomenteLeitura = this.cln.booSomenteLeitura;
                this.strTitulo = this.cln.strNomeExibicao;

                this.tagInput.strValor = cln.strValor;

                this.atualizarClnStrId();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion Ações
        }

        protected override void atualizarStrId()
        {
            base.atualizarStrId();

            if (string.IsNullOrEmpty(this.strId))
            {
                return;
            }

            this.divObrigatorio.strId = (this.strId + "_divObrigatorio");
            this.divTitulo.strId = (this.strId + "_divTitulo");
            this.tagInput.strId = (this.strId + "_tagInput");
        }

        protected virtual void atualizarStrTitulo()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.divTitulo.strConteudo = (!string.IsNullOrEmpty(this.strTitulo)) ? this.strTitulo : STR_TITULO;
                this.tagInput.strPlaceHolder = (!string.IsNullOrEmpty(this.strTitulo)) ? this.strTitulo : STR_TITULO;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion Ações
        }

        protected override void finalizar()
        {
            base.finalizar();

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

            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.divObrigatorio.strConteudo = "*";

                this.tagInput.enmTipo = this.getEnmTipo();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion Ações
        }

        protected override void montarLayout()
        {
            base.montarLayout();

            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.divTitulo.setPai(this);
                this.divInputContainer.setPai(this);
                this.tagInput.setPai(this.divInputContainer);
                this.divObrigatorio.setPai(this);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion Ações
        }

        protected override void setCss(CssArquivo css)
        {
            base.setCss(css);

            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.setCssWidth(css);

                this.addCss(css.setFloat(this.booDireita ? "right" : "left"));
                this.addCss(css.setHeight(100, "%"));
                this.addCss(css.setPaddingLeft(5));
                this.addCss(css.setPaddingRight(5));
                this.addCss(css.setPosition((EnmTamanho.TOTAL.Equals(this.enmTamanho)) ? "absolute" : "relative"));

                this.divInputContainer.addCss(css.setFontSize(15));
                this.divInputContainer.addCss(css.setLeft(5));
                this.divInputContainer.addCss(css.setPosition("absolute"));
                this.divInputContainer.addCss(css.setRight(10));
                this.divInputContainer.addCss(css.setTextAlign("left"));

                this.divObrigatorio.addCss(css.setColor("red"));
                this.divObrigatorio.addCss(css.setDisplay(!this.booObrigatorio ? "none" : null));
                this.divObrigatorio.addCss(css.setPosition("absolute"));
                this.divObrigatorio.addCss(css.setRight(0));

                this.divTitulo.addCss(css.setColor(AppWeb.i.objTema.corTema));
                this.divTitulo.addCss(css.setFontSize(14));
                this.divTitulo.addCss(css.setHeight(15));
                this.divTitulo.addCss(css.setLineHeight(15));
                this.divTitulo.addCss(css.setOpacity(0));
                this.divTitulo.addCss(css.setPaddingTop(5));
                this.divTitulo.addCss(css.setTextAlign("left"));

                this.setCssTagInputHeight(css);
                this.setCssTagInputWidth(css);

                this.tagInput.addCss(css.setBackgroundColor("rgba(0,0,0,0)"));
                this.tagInput.addCss(css.setBorder(0));
                this.tagInput.addCss(css.setBorderBottom(1, "solid", AppWeb.i.objTema.corFundoBorda));
                this.tagInput.addCss(css.setFontSize(15));
                this.tagInput.addCss(css.setOutLine("none"));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion Ações
        }

        protected virtual void setCssTagInputHeight(CssArquivo css)
        {
            this.tagInput.addCss(css.setHeight(19));
        }

        protected virtual void setCssTagInputWidth(CssArquivo css)
        {
            this.tagInput.addCss(css.setWidth(100, "%"));
        }

        private void atualizarBooSomenteLeitura()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.tagInput.booDisabled = this.booSomenteLeitura;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion Ações
        }

        private void atualizarClnStrId()
        {
            if (this.cln.tbl == null)
            {
                return;
            }

            string strId = "cmp__cln_nome__obj_id";

            strId = strId.Replace("_cln_nome", this.cln.strNomeSql);
            strId = strId.Replace("_obj_id", this.intObjetoId.ToString());

            this.strId = strId;
        }

        private void finalizarMostrarTituloSempre()
        {
            if (!this.booMostrarTituloSempre)
            {
                return;
            }

            this.addAtt("mostrar_titulo_sempre", true);
        }

        private void setCssWidth(CssArquivo css)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                switch (this.enmTamanho)
                {
                    case EnmTamanho.GRANDE:
                        this.addCss(css.setWidth(250));
                        return;

                    case EnmTamanho.MINIMO:
                        this.addCss(css.setWidth(50));
                        return;

                    case EnmTamanho.PEQUENO:
                        this.addCss(css.setWidth(100));
                        return;

                    case EnmTamanho.TOTAL:
                        this.setCssWidthTotal(css);
                        return;

                    default:
                        this.addCss(css.setWidth(150));
                        return;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion Ações
        }

        private void setCssWidthTotal(CssArquivo css)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.addCss(css.setLeft(5));
                this.addCss(css.setRight(5));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion Ações
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}