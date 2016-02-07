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

        private FrmFiltroSelecao _frmFiltroSelecao;
        private PainelHtml _pnlFiltroSelecao;

        private FrmFiltroSelecao frmFiltroSelecao
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_frmFiltroSelecao != null)
                    {
                        return _frmFiltroSelecao;
                    }

                    _frmFiltroSelecao = new FrmFiltroSelecao();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _frmFiltroSelecao;
            }
        }

        private PainelHtml pnlFiltroSelecao
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_pnlFiltroSelecao != null)
                    {
                        return _pnlFiltroSelecao;
                    }

                    _pnlFiltroSelecao = new PainelHtml();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _pnlFiltroSelecao;
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
                this.intTamanhoVertical = 3;
                this.strId = "pnlFiltro";

                this.frmFiltroSelecao.strId = "frmFiltroSelecao";

                this.pnlFiltroSelecao.intTamanhoVertical = 3;
                this.pnlFiltroSelecao.strId = "pnlFiltroSelecao";
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
                this.pnlFiltroSelecao.setPai(this);
                this.frmFiltroSelecao.setPai(this.pnlFiltroSelecao);
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
                this.pnlFiltroSelecao.addCss(css.setFloat("left"));
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