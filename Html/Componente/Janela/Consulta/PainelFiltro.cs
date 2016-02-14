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
        private PainelHtml _pnlFiltroSelecao;

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
                this.intTamanhoVertical = 2;
                this.strId = "pnlFiltro";

                this.frmFiltro.strId = "frmFiltro";

                this.pnlFiltroSelecao.intTamanhoVertical = 2;
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
                this.frmFiltro.setPai(this.pnlFiltroSelecao);
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