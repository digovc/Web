using System;
using NetZ.Web.Html.Componente.Botao;
using NetZ.Web.Html.Componente.Botao.Mini;
using NetZ.Web.Html.Design;

namespace NetZ.Web.Html.Componente.Janela
{
    public class JanelaHtml : ComponenteHtml
    {
        #region Constantes

        private const string STR_TITULO = "Janela desconhecida";

        #endregion Constantes

        #region Atributos

        private BotaoMiniFechar _btnFechar;
        private Div _divAcao;
        private Div _divCabecalho;
        private Div _divTitulo;
        private string _strTitulo = STR_TITULO;

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
                _strTitulo = value;
            }
        }

        private BotaoMiniFechar btnFechar
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_btnFechar != null)
                    {
                        return _btnFechar;
                    }

                    _btnFechar = new BotaoMiniFechar();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _btnFechar;
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

        private Div divCabecalho
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

        protected override void inicializar()
        {
            base.inicializar();

            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.divAcao.strId = "divAcao";

                this.divCabecalho.strId = "divCabecalho";

                this.divTitulo.strConteudo = (string.IsNullOrEmpty(this.strTitulo)) ? STR_TITULO : this.strTitulo;
                this.divTitulo.strId = "divTitulo";
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
                this.divCabecalho.setPai(this);
                this.divTitulo.setPai(this.divCabecalho);
                this.divAcao.setPai(this.divCabecalho);
                this.btnFechar.setPai(this.divAcao);
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
                this.addCss(css.addCss("margin", "10% auto"));
                this.addCss(css.setBackgroundColor(Tema.i.corFundo2Normal));
                this.addCss(css.setBorder(1, "solid", "black"));
                this.addCss(css.setBoxShadow(0, 5, 20, 0, Tema.i.corSombra2));
                this.addCss(css.setHeight(500));
                this.addCss(css.setWidth(500));

                this.divAcao.addCss(css.setBottom(0));
                this.divAcao.addCss(css.setPosition("absolute"));
                this.divAcao.addCss(css.setRight(0));
                this.divAcao.addCss(css.setTop(0));

                this.divCabecalho.addCss(css.setCursor("default"));
                this.divCabecalho.addCss(css.setHeight(50));
                this.divCabecalho.addCss(css.setLineHeight(35));
                this.divCabecalho.addCss(css.setPosition("relative"));

                this.btnFechar.addCss(css.setBackgroundColor("#CE5757"));
                this.btnFechar.addCss(css.setBorderRadius(50, "%"));
                this.btnFechar.addCss(css.setBoxShadow(0, 2, 2, 0, Tema.i.corSombra2));
                this.btnFechar.addCss(css.setColor("white"));
                this.btnFechar.addCss(css.setCursor("pointer"));
                this.btnFechar.addCss(css.setFloat("left"));
                this.btnFechar.addCss(css.setHeight(40));
                this.btnFechar.addCss(css.setLineHeight(40));
                this.btnFechar.addCss(css.setMargin(5));
                this.btnFechar.addCss(css.setTextAlign("center"));
                this.btnFechar.addCss(css.setWidth(40));

                this.divTitulo.addCss(css.setFontSize(20));
                this.divTitulo.addCss(css.setLineHeight(50));
                this.divTitulo.addCss(css.setPaddingLeft(5));
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