using System;
using NetZ.Web.DataBase;
using NetZ.Web.Html.Componente.Campo;
using NetZ.Web.Html.Componente.Tab;

namespace NetZ.Web.Html.Componente.Janela.Cadastro
{
    public class JnlFiltroCadastro : JnlCadastro
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private CampoAlfanumerico _cmpStrDescricao;
        private CampoAlfanumerico _cmpStrNome;

        private TabItem _tabFiltroItem;

        private CampoAlfanumerico cmpStrDescricao
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_cmpStrDescricao != null)
                    {
                        return _cmpStrDescricao;
                    }

                    _cmpStrDescricao = new CampoAlfanumerico();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _cmpStrDescricao;
            }
        }

        private CampoAlfanumerico cmpStrNome
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_cmpStrNome != null)
                    {
                        return _cmpStrNome;
                    }

                    _cmpStrNome = new CampoAlfanumerico();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _cmpStrNome;
            }
        }

        private TabItem tabFiltroItem
        {
            get
            {
                if (_tabFiltroItem != null)
                {
                    return _tabFiltroItem;
                }

                _tabFiltroItem = new TabItem();

                return _tabFiltroItem;
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
                this.cmpStrNome.enmTamanho = CampoHtml.EnmTamanho.TOTAL;
                this.cmpStrNome.intNivel = 1;

                this.cmpStrDescricao.enmTamanho = CampoHtml.EnmTamanho.TOTAL;
                this.cmpStrDescricao.intNivel = 2;

                this.tabFiltroItem.tbl = TblFiltroItem.i;
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
                this.cmpStrNome.setPai(this);
                this.cmpStrDescricao.setPai(this);

                this.tabFiltroItem.setPai(this);
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