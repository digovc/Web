using System;
using NetZ.Web.Server.Arquivo.Css;

namespace NetZ.Web.Html.Componente.Janela
{
    public class JanelaHtml : ComponenteHtml
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private Atributo _attHeight;
        private Atributo _attWidth;
        private Div _divAcao;
        private Div _divBtnFechar;
        private Div _divCabecalho;
        private Div _divInativa;
        private Div _divTitulo;
        private int _intTamanhoX = 5;
        private int _intTamanhoY = 5;
        private string _strTitulo;

        /// <summary>
        /// Indica o tamanho horizontal desta janela. A unidade deste valor são 50 pixels, ou seja, 1
        /// = 50px, 5 = 250px.
        /// </summary>
        public int intTamanhoX
        {
            get
            {
                return _intTamanhoX;
            }

            set
            {
                _intTamanhoX = value;
            }
        }

        /// <summary>
        /// Indica o tamanho vertical desta janela. A unidade deste valor são 50 pixels, ou seja, 1
        /// = 50px, 5 = 250px.
        /// </summary>
        public int intTamanhoY
        {
            get
            {
                return _intTamanhoY;
            }

            set
            {
                _intTamanhoY = value;
            }
        }

        /// <summary>
        /// Título da janela.
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

        private Atributo attHeight
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_attHeight != null)
                    {
                        return _attHeight;
                    }

                    _attHeight = new Atributo("height");

                    this.addAtt(_attHeight);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _attHeight;
            }
        }

        private Atributo attWidth
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_attWidth != null)
                    {
                        return _attWidth;
                    }

                    _attWidth = new Atributo("width");

                    this.addAtt(_attWidth);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _attWidth;
            }
        }

        private Div divAcao
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_divAcao != null)
                    {
                        return _divAcao;
                    }

                    _divAcao = new Div();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _divAcao;
            }
        }

        private Div divBtnFechar
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_divBtnFechar != null)
                    {
                        return _divBtnFechar;
                    }

                    _divBtnFechar = new Div();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _divBtnFechar;
            }
        }

        protected Div divCabecalho
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_divCabecalho != null)
                    {
                        return _divCabecalho;
                    }

                    _divCabecalho = new Div();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _divCabecalho;
            }
        }

        private Div divInativa
        {
            get
            {
                if (_divInativa != null)
                {
                    return _divInativa;
                }

                _divInativa = new Div();

                return _divInativa;
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

        public JanelaHtml()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.strId = "divJnl";
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
                lstJs.Add(new JavaScriptTag(typeof(JanelaHtml), 111));
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

            this.divAcao.strId = (this.strId + "_divAcao");
            this.divBtnFechar.strId = (this.strId + "_divBtnFechar");
            this.divCabecalho.strId = (this.strId + "_divCabecalho");
            this.divInativa.strId = (this.strId + "_divInativa");
            this.divTitulo.strId = (this.strId + "_divTitulo");
        }

        protected override void finalizar()
        {
            base.finalizar();

            this.divInativa.setPai(this);
        }

        protected override void finalizarCss(CssArquivo css)
        {
            base.finalizarCss(css);

            this.finalizarCssHeight(css);
            this.finalizarCssWidth(css);
        }

        protected virtual void finalizarCssHeight(CssArquivo css)
        {
            this.addCss(css.setHeight((this.intTamanhoY * 50) - 20));
        }

        protected virtual void finalizarCssWidth(CssArquivo css)
        {
            this.addCss(css.setWidth((this.intTamanhoX * 50)));
        }

        protected override void inicializar()
        {
            base.inicializar();

            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.strId = this.GetType().Name;
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

            this.divCabecalho.setPai(this);
            this.divTitulo.setPai(this.divCabecalho);
            this.divAcao.setPai(this.divCabecalho);
            this.divBtnFechar.setPai(this.divAcao);
        }

        protected override void setCss(CssArquivo css)
        {
            base.setCss(css);

            this.addCss(css.setBackgroundColor("white"));
            this.addCss(css.setBoxShadow(0, 5, 10, 0, AppWeb.i.objTema.corSombra));
            this.addCss(css.setCenter());
            this.addCss(css.setPosition("absolute"));

            this.divBtnFechar.addCss(css.setBorderRadius(0, 0, 2, 2));
            this.divBtnFechar.addCss(css.setBoxShadow(0, 1, 5, 0, AppWeb.i.objTema.corSombra));
            this.divBtnFechar.addCss(css.setHeight(25));
            this.divBtnFechar.addCss(css.setMarginRight(10));
            this.divBtnFechar.addCss(css.setTextAlign("center"));
            this.divBtnFechar.addCss(css.setWidth(50));

            this.divAcao.addCss(css.setBottom(0));
            this.divAcao.addCss(css.setPosition("absolute"));
            this.divAcao.addCss(css.setRight(0));
            this.divAcao.addCss(css.setTop(0));

            this.divCabecalho.addCss(css.setBackgroundColor(AppWeb.i.objTema.corTema));
            this.divCabecalho.addCss(css.setCursor("default"));
            this.divCabecalho.addCss(css.setHeight(30));
            this.divCabecalho.addCss(css.setPosition("relative"));

            this.divInativa.addCss(css.setBackgroundColor("rgba(0,0,0,0.5)"));
            this.divInativa.addCss(css.setDisplay("none"));
            this.divInativa.addCss(css.setHeight(100, "%"));
            this.divInativa.addCss(css.setPosition("absolute"));
            this.divInativa.addCss(css.setTop(0));
            this.divInativa.addCss(css.setWidth(100, "%"));

            this.divTitulo.addCss(css.setColor("white"));
            this.divTitulo.addCss(css.setFontSize(18));
            this.divTitulo.addCss(css.setLineHeight(30));
            this.divTitulo.addCss(css.setPaddingLeft(5));
        }

        private void atualizarStrTitulo()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.divTitulo.strConteudo = this.strTitulo;
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