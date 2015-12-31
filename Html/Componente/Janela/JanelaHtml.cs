﻿using System;
using NetZ.Web.Html.Componente.Botao.Mini;

namespace NetZ.Web.Html.Componente.Janela
{
    public class JanelaHtml : ComponenteHtml
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private BotaoFecharMini _btnFechar;
        private Div _divAcao;
        private Div _divCabecalho;
        private Div _divTitulo;
        private int _intTamanhoX = 5;
        private int _intTamanhoY = 5;
        private string _strTitulo;

        /// <summary>
        /// Indica o tamanho horizontal desta janela. A unidade deste valor são 50 pixels, ou seja,
        /// 1 = 50px, 5 = 250px.
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

        private BotaoFecharMini btnFechar
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

                    _btnFechar = new BotaoFecharMini();
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

        protected override void addJs(LstTag<JavaScriptTag> lstJs)
        {
            base.addJs(lstJs);

            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                lstJs.Add(new JavaScriptTag(typeof(JanelaHtml)));
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

        protected override void inicializar()
        {
            base.inicializar();

            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.strId = this.GetType().Name;

                this.divAcao.strId = "divAcao";

                this.divCabecalho.strId = "divCabecalho";

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
                this.addCss(css.setBackgroundColor("white"));
                this.addCss(css.setBorder(1, "solid", AppWeb.i.objTema.corBorda));
                this.addCss(css.setBoxShadow(0, 1, 3, 0, AppWeb.i.objTema.corSombra));
                this.addCss(css.setHeight(50 * this.intTamanhoY));
                this.addCss(css.setWidth(50 * this.intTamanhoX));

                this.btnFechar.addCss(css.setMarginRight(10));
                this.btnFechar.addCss(css.setMarginTop(10));

                this.divAcao.addCss(css.setBottom(0));
                this.divAcao.addCss(css.setPosition("absolute"));
                this.divAcao.addCss(css.setRight(0));
                this.divAcao.addCss(css.setTop(0));

                this.divCabecalho.addCss(css.setCursor("default"));
                this.divCabecalho.addCss(css.setHeight(50));
                this.divCabecalho.addCss(css.setLineHeight(35));
                this.divCabecalho.addCss(css.setPosition("relative"));

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