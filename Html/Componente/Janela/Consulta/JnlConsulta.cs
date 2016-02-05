using System;
using NetZ.Persistencia;
using NetZ.Web.Html.Componente.Grid;

namespace NetZ.Web.Html.Componente.Janela.Consulta
{
    public sealed class JnlConsulta : JanelaHtml
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private Div _divCadastro;
        private Div _divGrid;
        private GridHtml _grdDados;
        private PainelAcaoConsulta _pnlAcaoConsulta;
        private PainelFiltro _pnlFiltro;
        private Tabela _tbl;

        private Div divCadastro
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_divCadastro != null)
                    {
                        return _divCadastro;
                    }

                    _divCadastro = new Div();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _divCadastro;
            }
        }

        private Div divGrid
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_divGrid != null)
                    {
                        return _divGrid;
                    }

                    _divGrid = new Div();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _divGrid;
            }
        }

        private GridHtml grdDados
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_grdDados != null)
                    {
                        return _grdDados;
                    }

                    _grdDados = new GridHtml();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _grdDados;
            }
        }

        private PainelAcaoConsulta pnlAcaoConsulta
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_pnlAcaoConsulta != null)
                    {
                        return _pnlAcaoConsulta;
                    }

                    _pnlAcaoConsulta = new PainelAcaoConsulta();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _pnlAcaoConsulta;
            }
        }

        private PainelFiltro pnlFiltro
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_pnlFiltro != null)
                    {
                        return _pnlFiltro;
                    }

                    _pnlFiltro = new PainelFiltro();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _pnlFiltro;
            }
        }

        private Tabela tbl
        {
            get
            {
                return _tbl;
            }

            set
            {
                _tbl = value;
            }
        }

        #endregion Atributos

        #region Construtores

        public JnlConsulta(Tabela tbl)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.tbl = tbl;
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
                this.strId = "jnlConsulta";
                this.strTitulo = this.tbl.strNomeExibicao;

                this.divCadastro.strId = "divCadastro";

                this.divGrid.strId = "divGrid";

                this.pnlAcaoConsulta.strId = "pnlAcaoConsulta";

                this.addAtt("tbl_web_nome", this.tbl.strNomeSql);
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
                this.pnlFiltro.setPai(this);
                this.divGrid.setPai(this);
                this.pnlAcaoConsulta.setPai(this);
                this.divCadastro.setPai(this);
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
                this.addCss(css.setBackgroundColor(AppWeb.i.objTema.corTelaFundo));

                this.divCadastro.addCss(css.setDisplay("none"));

                this.divGrid.addCss(css.setBorderTop(1, "solid", AppWeb.i.objTema.corBorda));
                this.divGrid.addCss(css.setBottom(0));
                this.divGrid.addCss(css.setLeft(0));
                this.divGrid.addCss(css.setOverflow("auto"));
                this.divGrid.addCss(css.setPosition("absolute"));
                this.divGrid.addCss(css.setRight(0));
                this.divGrid.addCss(css.setTop(150));

                this.pnlAcaoConsulta.addCss(css.setBottom(25));
                this.pnlAcaoConsulta.addCss(css.setRight(50));
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

        protected override void setCssTamanho(CssTag css)
        {
            //base.setCssTamanho(css);

            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.addCss(css.setBottom(0));
                this.addCss(css.setLeft(0));
                this.addCss(css.setPosition("absolute"));
                this.addCss(css.setRight(0));
                this.addCss(css.setTop(0));
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