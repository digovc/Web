using System;
using NetZ.Web.Html.Componente.Botao.Mini;
using NetZ.Web.Html.Componente.Painel;

namespace NetZ.Web.Html.Pagina.Consulta
{
    public class PainelAcaoConsulta : PainelAcao
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private BotaoAdicionarMini _btnAdicionar;
        private BotaoAlterarMini _btnAlterar;

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

        #endregion Atributos

        #region Construtores

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
                lstJs.Add(new JavaScriptTag(typeof(PainelAcaoConsulta), 121));
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
                this.btnAdicionar.setPai(this);
                this.btnAlterar.setPai(this);
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
                this.btnAdicionar.strId = "btnAdicionar";
                this.btnAlterar.strId = "btnAlterar";
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