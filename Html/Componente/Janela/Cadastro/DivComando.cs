using NetZ.Web.Html.Componente.Botao;
using NetZ.Web.Html.Componente.Painel;
using NetZ.Web.Server.Arquivo.Css;

namespace NetZ.Web.Html.Componente.Janela.Cadastro
{
    public class DivComando : PainelNivel
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private BotaoCircular _btnAdicionar;
        private BotaoCircular _btnDireita;
        private BotaoCircular _btnEsquerda;
        private BotaoCircular _btnSalvar;

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

        private BotaoCircular btnDireita
        {
            get
            {
                if (_btnDireita != null)
                {
                    return _btnDireita;
                }

                _btnDireita = new BotaoCircular();

                return _btnDireita;
            }
        }

        private BotaoCircular btnEsquerda
        {
            get
            {
                if (_btnEsquerda != null)
                {
                    return _btnEsquerda;
                }

                _btnEsquerda = new BotaoCircular();

                return _btnEsquerda;
            }
        }

        private BotaoCircular btnSalvar
        {
            get
            {
                if (_btnSalvar != null)
                {
                    return _btnSalvar;
                }

                _btnSalvar = new BotaoCircular();

                return _btnSalvar;
            }
        }

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        protected override void addJs(LstTag<JavaScriptTag> lstJs)
        {
            base.addJs(lstJs);

            lstJs.Add(new JavaScriptTag(typeof(DivComando), 116));
        }

        protected override void atualizarStrId()
        {
            base.atualizarStrId();

            if (string.IsNullOrEmpty(this.strId))
            {
                return;
            }

            this.btnDireita.strId = (this.strId + "_btnDireita");
            this.btnEsquerda.strId = (this.strId + "_btnEsquerda");
            this.btnAdicionar.strId = (this.strId + "_btnAdicionar");
            this.btnSalvar.strId = (this.strId + "_btnSalvar");
        }

        protected override void inicializar()
        {
            base.inicializar();

            this.btnDireita.enmLado = BotaoHtml.EnmLado.ESQUERDA;
            this.btnDireita.enmTamanho = BotaoCircular.EnmTamanho.PEQUENO;

            this.btnEsquerda.enmLado = BotaoHtml.EnmLado.ESQUERDA;
            this.btnEsquerda.enmTamanho = BotaoCircular.EnmTamanho.PEQUENO;

            this.btnAdicionar.enmTamanho = BotaoCircular.EnmTamanho.PEQUENO;
        }

        protected override void montarLayout()
        {
            base.montarLayout();

            this.btnEsquerda.setPai(this);
            this.btnDireita.setPai(this);
            this.btnAdicionar.setPai(this);
            this.btnSalvar.setPai(this);
        }

        protected override void setCss(CssArquivo css)
        {
            base.setCss(css);

            this.btnEsquerda.addCss(css.setBackgroundImage("/res/media/png/btn_voltar_30x30.png"));
            this.btnEsquerda.addCss(css.setLeft(10));
            this.btnEsquerda.addCss(css.setPosition("absolute"));
            this.btnEsquerda.addCss(css.setTop(10));

            this.btnDireita.addCss(css.setBackgroundImage("/res/media/png/btn_avancar_30x30.png"));
            this.btnDireita.addCss(css.setLeft(50));
            this.btnDireita.addCss(css.setPosition("absolute"));
            this.btnDireita.addCss(css.setTop(10));

            this.btnAdicionar.addCss(css.setBackgroundImage("/res/media/png/btn_adicionar_30x30.png"));
            this.btnAdicionar.addCss(css.setPosition("absolute"));
            this.btnAdicionar.addCss(css.setRight(55));
            this.btnAdicionar.addCss(css.setTop(10));

            this.btnSalvar.addCss(css.setBackgroundImage("/res/media/png/btn_salvar_40x40.png"));
            this.btnSalvar.addCss(css.setPosition("absolute"));
            this.btnSalvar.addCss(css.setRight(5));
            this.btnSalvar.addCss(css.setTop(5));
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}