using NetZ.Web.Html.Componente.Botao;
using NetZ.Web.Server.Arquivo.Css;

namespace NetZ.Web.Html.Componente.Grid
{
    public class MenuGrid : ComponenteHtml
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private BotaoCircular _btnAdicionar;
        private BotaoCircular _btnAlterar;
        private BotaoCircular _btnApagar;
        private BotaoCircular _btnMenu;

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

        private BotaoCircular btnMenu
        {
            get
            {
                if (_btnMenu != null)
                {
                    return _btnMenu;
                }

                _btnMenu = new BotaoCircular();

                return _btnMenu;
            }
        }

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        protected override void inicializar()
        {
            base.inicializar();

            this.strId = "_str_id";

            this.btnAdicionar.strId = "_btn_adicionar_str_id";
            this.btnAlterar.strId = "_btn_alterar_str_id";
            this.btnApagar.strId = "_btn_apagar_str_id";

            this.btnMenu.enmTamanho = BotaoCircular.EnmTamanho.PEQUENO;
            this.btnMenu.strId = "_btn_menu_str_id";
        }

        protected override void montarLayout()
        {
            base.montarLayout();

            this.btnMenu.setPai(this);
            this.btnApagar.setPai(this);
            this.btnAlterar.setPai(this);
            this.btnAdicionar.setPai(this);
        }

        protected override void setCss(CssArquivo css)
        {
            base.setCss(css);

            this.addCss(css.setLeft(350));
            this.addCss(css.setPosition("absolute"));
            this.addCss(css.setTop(150));

            this.btnMenu.addCss(css.setBackgroundImage("/res/media/png/btn_opcoes_30x30.png"));
            this.btnMenu.addCss(css.setPosition("absolute"));
            this.btnMenu.addCss(css.setRight(-150));
            this.btnMenu.addCss(css.setTop(-30));

            this.btnApagar.addCss(css.setDisplay("none"));
            this.btnApagar.addCss(css.setLeft(75));
            this.btnApagar.addCss(css.setPosition("absolute"));
            this.btnApagar.addCss(css.setTop(-50));

            this.btnAlterar.addCss(css.setBackgroundImage("/res/media/png/btn_alterar_30x30.png"));
            this.btnAlterar.addCss(css.setBackgroundPosition("center"));
            this.btnAlterar.addCss(css.setLeft(25));
            this.btnAlterar.addCss(css.setPosition("absolute"));
            this.btnAlterar.addCss(css.setTop(-30));

            this.btnAdicionar.addCss(css.setBackgroundImage("/res/media/png/btn_adicionar_30x30.png"));
            this.btnAdicionar.addCss(css.setBackgroundPosition("center"));
            this.btnAdicionar.addCss(css.setLeft(5));
            this.btnAdicionar.addCss(css.setPosition("absolute"));
            this.btnAdicionar.addCss(css.setTop(20));
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}