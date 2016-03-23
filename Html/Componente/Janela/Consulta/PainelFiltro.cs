using System;
using NetZ.Web.Html.Componente.Painel;
using NetZ.Web.Server.Arquivo.Css;

namespace NetZ.Web.Html.Componente.Janela.Consulta
{
    public class PainelFiltro : PainelHtml
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private FrmFiltro _frmFiltro;
        private PainelHtml _pnlCondicao;
        private PainelHtml _pnlSelecao;

        private FrmFiltro frmFiltro
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_frmFiltro != null)
                    {
                        return _frmFiltro;
                    }

                    _frmFiltro = new FrmFiltro();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _frmFiltro;
            }
        }

        private PainelHtml pnlCondicao
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_pnlCondicao != null)
                    {
                        return _pnlCondicao;
                    }

                    _pnlCondicao = new PainelHtml();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _pnlCondicao;
            }
        }

        private PainelHtml pnlSelecao
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_pnlSelecao != null)
                    {
                        return _pnlSelecao;
                    }

                    _pnlSelecao = new PainelHtml();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _pnlSelecao;
            }
        }

        #endregion Atributos

        #region Construtores

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
                this.intTamanhoVertical = 2;
                this.strId = "pnlFiltro";

                this.pnlCondicao.intTamanhoVertical = this.intTamanhoVertical;
                this.pnlCondicao.strId = (this.strId + "_pnlCondicao");

                this.pnlSelecao.intTamanhoVertical = this.intTamanhoVertical;
                this.pnlSelecao.strId = (this.strId + "_pnlSelecao");
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
                this.pnlSelecao.setPai(this);
                this.frmFiltro.setPai(this.pnlSelecao);
                this.pnlCondicao.setPai(this);
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
                this.addCss(css.setPosition("relative"));

                this.pnlCondicao.addCss(css.setLeft(270));
                this.pnlCondicao.addCss(css.setPosition("absolute"));
                this.pnlCondicao.addCss(css.setRight(0));

                this.pnlSelecao.addCss(css.setBorderRight(1, "solid", AppWeb.i.objTema.corBorda));
                this.pnlSelecao.addCss(css.setFloat("left"));
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