using System;

namespace NetZ.Web.Html.Componente.Campo
{
    public abstract class CampoHtml : ComponenteHtml
    {
        #region Constantes

        public enum EnmTamanho
        {
            /// <summary>
            /// Width 400px.
            /// </summary>
            GRANDE,

            /// <summary>
            /// Width 250px.
            /// </summary>
            MEDIO,

            /// <summary>
            /// Width 100px.
            /// </summary>
            MINIMO,

            /// <summary>
            /// Width 150px.
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

        private bool _booObrigatorio;
        private Div _divObrigatorio;
        private Div _divTitulo;
        private EnmTamanho _enmTamanho = EnmTamanho.MEDIO;
        private int _intFrmNivel;
        private string _strTitulo;
        private Input _tagInput;

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
        public int intFrmNivel
        {
            get
            {
                return _intFrmNivel;
            }

            set
            {
                _intFrmNivel = value;
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
                _strTitulo = value;
            }
        }

        protected Input tagInput
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

        private Div divTitulo
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

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

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
                this.divObrigatorio.strId = "divObrigatorio";

                this.divTitulo.strConteudo = (string.IsNullOrEmpty(this.strTitulo)) ? STR_TITULO : this.strTitulo;
                this.divTitulo.strId = "divTitulo";

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
                this.tagInput.setPai(this);
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

        protected override void setCss(CssTag css)
        {
            base.setCss(css);

            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.setCssWidth(css);

                this.addCss(css.setFloat("left"));
                this.addCss(css.setHeight(100, "%"));
                this.addCss(css.setPaddingLeft(5));
                this.addCss(css.setPaddingRight(5));

                this.divObrigatorio.addCss(css.setColor("red"));
                this.divObrigatorio.addCss(css.setDisplay(!this.booObrigatorio ? "none" : null));
                this.divObrigatorio.addCss(css.setFloat("left"));
                this.divObrigatorio.addCss(css.setPaddingLeft(5));
                this.divObrigatorio.addCss(css.setPaddingRight(5));

                this.divTitulo.addCss(css.setHeight(20));
                this.divTitulo.addCss(css.setLineHeight(20));
                this.divTitulo.addCss(css.setTextAlign("left"));

                this.tagInput.addCss(css.setFloat("left"));
                this.tagInput.addCss(css.setWidth(100, "%"));
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

        private void setCssWidth(CssTag css)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                switch (this.enmTamanho)
                {
                    case EnmTamanho.GRANDE:
                        this.addCss(css.setWidth(400));
                        return;

                    case EnmTamanho.MINIMO:
                        this.addCss(css.setWidth(100));

                        return;

                    case EnmTamanho.PEQUENO:
                        this.addCss(css.setWidth(150));

                        return;

                    case EnmTamanho.TOTAL:
                        this.addCss(css.setWidth(100, "%"));

                        return;

                    default:
                        this.addCss(css.setWidth(250));
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

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}