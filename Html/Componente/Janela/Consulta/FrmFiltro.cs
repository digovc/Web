using System;
using NetZ.Web.Html.Componente.Botao.Mini;
using NetZ.Web.Html.Componente.Campo;
using NetZ.Web.Html.Componente.Form;
using NetZ.Web.Server.Arquivo.Css;

namespace NetZ.Web.Html.Componente.Janela.Consulta
{
    public class FrmFiltro : FormHtml
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private BotaoAdicionarMini _btnAdicionar;
        private BotaoAlterarMini _btnAlterar;
        private BotaoApagarMini _btnApagar;
        private CampoComboBox _cmpIntFiltroId;

        private BotaoAdicionarMini btnAdicionar
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_btnAdicionar != null)
                    {
                        return _btnAdicionar;
                    }

                    _btnAdicionar = new BotaoAdicionarMini();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _btnAdicionar;
            }
        }

        private BotaoAlterarMini btnAlterar
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_btnAlterar != null)
                    {
                        return _btnAlterar;
                    }

                    _btnAlterar = new BotaoAlterarMini();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _btnAlterar;
            }
        }

        private BotaoApagarMini btnApagar
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_btnApagar != null)
                    {
                        return _btnApagar;
                    }

                    _btnApagar = new BotaoApagarMini();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _btnApagar;
            }
        }

        private CampoComboBox cmpIntFiltroId
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_cmpIntFiltroId != null)
                    {
                        return _cmpIntFiltroId;
                    }

                    _cmpIntFiltroId = new CampoComboBox();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _cmpIntFiltroId;
            }
        }

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        protected override void atualizarStrId()
        {
            base.atualizarStrId();

            if (string.IsNullOrEmpty(this.strId))
            {
                return;
            }

            this.btnAdicionar.strId = (this.strId + "_btnAdicionar");
            this.cmpIntFiltroId.strId = (this.strId + "_cmpIntFiltroId");
        }

        protected override void inicializar()
        {
            base.inicializar();

            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.strId = "frmFiltro";

                this.btnAdicionar.intNivel = 1;

                this.btnAlterar.intNivel = 1;
                this.btnApagar.intNivel = 1;

                this.cmpIntFiltroId.enmTamanho = CampoHtml.EnmTamanho.GRANDE;
                this.cmpIntFiltroId.strTitulo = "Filtro";
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
                this.cmpIntFiltroId.setPai(this);

                this.btnAdicionar.setPai(this);
                //this.btnAlterar.setPai(this);
                //this.btnApagar.setPai(this);
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

            this.btnAdicionar.addCss(css.setMarginRight(10));
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}