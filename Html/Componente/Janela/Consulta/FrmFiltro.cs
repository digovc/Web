using NetZ.Web.Html.Componente.Botao;
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

        private BotaoCircular _btnAdicionar;
        private BotaoCircular _btnAlterar;
        private BotaoCircular _btnApagar;
        private CampoComboBox _cmpIntFiltroId;

        private BotaoCircular btnAdicionar
        {
            get
            {
                if (_btnAdicionar != null)
                {
                    return _btnAdicionar;
                }

                _btnAdicionar = new BotaoCircular();

                return _btnAdicionar;
            }
        }

        private BotaoCircular btnAlterar
        {
            get
            {
                if (_btnAlterar != null)
                {
                    return _btnAlterar;
                }

                _btnAlterar = new BotaoCircular();

                return _btnAlterar;
            }
        }

        private BotaoCircular btnApagar
        {
            get
            {
                if (_btnApagar != null)
                {
                    return _btnApagar;
                }

                _btnApagar = new BotaoCircular();

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

            this.btnAdicionar.enmTamanho = BotaoCircular.EnmTamanho.PEQUENO;
            this.btnAdicionar.intNivel = 1;

            this.btnAlterar.enmTamanho = BotaoCircular.EnmTamanho.PEQUENO;
            this.btnAlterar.intNivel = 1;

            this.btnApagar.enmTamanho = BotaoCircular.EnmTamanho.PEQUENO;        
            this.btnApagar.intNivel = 1;

            this.cmpIntFiltroId.enmTamanho = CampoHtml.EnmTamanho.NORMAL;
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

            this.btnAdicionar.addCss(css.setBackgroundImage("/res/media/png/btn_adicionar_30x30.png"));

            this.btnAlterar.addCss(css.setBackgroundImage("/res/media/png/btn_alterar_30x30.png"));
            this.btnAlterar.addCss(css.setMarginRight(10));

            this.btnApagar.addCss(css.setBackgroundImage("/res/media/png/btn_apagar_30x30.png"));
            this.btnApagar.addCss(css.setDisplay("none"));
            this.btnApagar.addCss(css.setMarginRight(10));
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}