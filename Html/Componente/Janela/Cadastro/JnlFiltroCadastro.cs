using NetZ.Web.DataBase.View;
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
                if (_cmpStrDescricao != null)
                {
                    return _cmpStrDescricao;
                }

                _cmpStrDescricao = new CampoAlfanumerico();

                return _cmpStrDescricao;
            }
        }

        private CampoAlfanumerico cmpStrNome
        {
            get
            {
                if (_cmpStrNome != null)
                {
                    return _cmpStrNome;
                }

                _cmpStrNome = new CampoAlfanumerico();

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

            this.cmpStrNome.enmTamanho = CampoHtml.EnmTamanho.GRANDE;
            this.cmpStrNome.intNivel = 1;

            this.cmpStrDescricao.enmTamanho = CampoHtml.EnmTamanho.TOTAL;
            this.cmpStrDescricao.intNivel = 2;

            this.tabFiltroItem.tbl = ViwFiltroItem.i;
        }

        protected override void montarLayout()
        {
            base.montarLayout();

            this.cmpStrNome.setPai(this);
            this.cmpStrDescricao.setPai(this);

            this.tabFiltroItem.setPai(this);
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}