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
                if (_btnAdicionar != null)
                {
                    return _btnAdicionar;
                }

                _btnAdicionar = new BotaoAdicionarMini();

                return _btnAdicionar;
            }
        }

        private BotaoAlterarMini btnAlterar
        {
            get
            {
                if (_btnAlterar != null)
                {
                    return _btnAlterar;
                }

                _btnAlterar = new BotaoAlterarMini();

                return _btnAlterar;
            }
        }

        private BotaoApagarMini btnApagar
        {
            get
            {
                if (_btnApagar != null)
                {
                    return _btnApagar;
                }

                _btnApagar = new BotaoApagarMini();

                return _btnApagar;
            }
        }

        private CampoComboBox cmpIntFiltroId
        {
            get
            {
                if (_cmpIntFiltroId != null)
                {
                    return _cmpIntFiltroId;
                }

                _cmpIntFiltroId = new CampoComboBox();

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
            this.btnAlterar.strId = (this.strId + "_btnAlterar");
            this.btnApagar.strId = (this.strId + "_btnApagar");
            this.cmpIntFiltroId.strId = (this.strId + "_cmpIntFiltroId");
        }

        protected override void inicializar()
        {
            base.inicializar();

            this.strId = "frmFiltro";

            this.btnAdicionar.intNivel = 1;

            this.btnAlterar.intNivel = 1;
            this.btnApagar.intNivel = 1;

            this.cmpIntFiltroId.enmTamanho = CampoHtml.EnmTamanho.GRANDE;
            this.cmpIntFiltroId.strTitulo = "Filtro";
        }

        protected override void montarLayout()
        {
            base.montarLayout();

            this.cmpIntFiltroId.setPai(this);

            this.btnApagar.setPai(this);
            this.btnAlterar.setPai(this);
            this.btnAdicionar.setPai(this);
        }

        protected override void setCss(CssArquivo css)
        {
            base.setCss(css);

            this.btnApagar.addCss(css.setMarginRight(10));
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}