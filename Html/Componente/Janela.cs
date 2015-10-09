using System;

namespace NetZ.Web.Html.Componente
{
    public class Janela : ComponenteHtml
    {
        #region Constantes

        private const string STR_TITULO = "Janela desconhecida";

        #endregion Constantes

        #region Atributos

        private Div _divAcao;
        private Div _divCabecalho;
        private Div _divFechar;
        private Div _divTitulo;
        private string _strTitulo = STR_TITULO;

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

                    _divAcao.strId = "divAcao";
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

                    _divCabecalho.strId = "divCabecalho";
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

        private Div divFechar
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_divFechar != null)
                    {
                        return _divFechar;
                    }

                    _divFechar = new Div();

                    _divFechar.strConteudo = "X";
                    _divFechar.strId = "divFechar";
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _divFechar;
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

                    _divTitulo.strConteudo = STR_TITULO;
                    _divTitulo.strId = "divTitulo";
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

        protected override void montarLayout()
        {
            base.montarLayout();

            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.divCabecalho.tagPai = this;
                this.divTitulo.tagPai = this.divCabecalho;
                this.divAcao.tagPai = this.divCabecalho;
                this.divFechar.tagPai = this.divAcao;
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
                this.addCss(css.setBorder(1, "solid", "black"));
                this.addCss(css.setBoxShadow(0, 0, 10, 0, "gray"));
                this.addCss(css.setHeight(250));
                this.addCss(css.setLeft(250));
                this.addCss(css.setPosition("absolute"));
                this.addCss(css.setTop(250));
                this.addCss(css.setWidth(250));

                this.divAcao.addCss(css.setBottom(0));
                this.divAcao.addCss(css.setPosition("absolute"));
                this.divAcao.addCss(css.setRight(0));
                this.divAcao.addCss(css.setTop(0));

                this.divCabecalho.addCss(css.setBackgroundColor("#F3F3F3"));
                this.divCabecalho.addCss(css.setCursor("pointer"));
                this.divCabecalho.addCss(css.setPosition("relative"));

                this.divFechar.addCss(css.setBackgroundColor("#CE5757"));
                this.divFechar.addCss(css.setColor("white"));
                this.divFechar.addCss(css.setFloat("left"));
                this.divFechar.addCss(css.setHeight(100, "%"));
                this.divFechar.addCss(css.setLineHeight(30));
                this.divFechar.addCss(css.setTextAlign("center"));
                this.divFechar.addCss(css.setWidth(50));

                this.divTitulo.addCss(css.setFontSize(20));
                this.divTitulo.addCss(css.setPadding(5));
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