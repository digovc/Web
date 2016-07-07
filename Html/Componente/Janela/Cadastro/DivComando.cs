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

        private BotaoCircular _btnDireita;
        private BotaoCircular _btnEsquerda;
        private BotaoCircular _btnNovo;
        private BotaoCircular _btnSalvar;

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

        private BotaoCircular btnNovo
        {
            get
            {
                if (_btnNovo != null)
                {
                    return _btnNovo;
                }

                _btnNovo = new BotaoCircular();

                return _btnNovo;
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
            this.btnNovo.strId = (this.strId + "_btnNovo");
            this.btnSalvar.strId = (this.strId + "_btnSalvar");
        }

        protected override void inicializar()
        {
            base.inicializar();

            this.btnDireita.enmLado = BotaoHtml.EnmLado.ESQUERDA;
            this.btnDireita.enmTamanho = BotaoCircular.EnmTamanho.PEQUENO;

            this.btnEsquerda.enmLado = BotaoHtml.EnmLado.ESQUERDA;
            this.btnEsquerda.enmTamanho = BotaoCircular.EnmTamanho.PEQUENO;

            this.btnNovo.enmTamanho = BotaoCircular.EnmTamanho.PEQUENO;
        }

        protected override void montarLayout()
        {
            base.montarLayout();

            this.btnEsquerda.setPai(this);
            this.btnDireita.setPai(this);
            this.btnNovo.setPai(this);
            this.btnSalvar.setPai(this);
        }

        protected override void setCss(CssArquivo css)
        {
            base.setCss(css);

            this.addCss(css.setPaddingTop(10));

            this.btnEsquerda.addCss(css.setMarginRight(5));
            this.btnEsquerda.addCss(css.setBackgroundImage("/res/media/png/btn_voltar_30x30.png"));
            this.btnEsquerda.addCss(css.setBackgroundPosition("center"));
            this.btnEsquerda.addCss(css.setBackgroundRepeat("no-repeat"));

            this.btnDireita.addCss(css.setMarginRight(5));
            this.btnDireita.addCss(css.setBackgroundImage("/res/media/png/btn_avancar_30x30.png"));
            this.btnDireita.addCss(css.setBackgroundPosition("center"));
            this.btnDireita.addCss(css.setBackgroundRepeat("no-repeat"));
            
            this.btnNovo.addCss(css.setBackgroundImage("/res/media/png/btn_adicionar_30x30.png"));
            this.btnNovo.addCss(css.setBackgroundPosition("center"));
            this.btnNovo.addCss(css.setBackgroundRepeat("no-repeat"));
            this.btnNovo.addCss(css.setPosition("absolute"));
            this.btnNovo.addCss(css.setRight(55));

            this.btnSalvar.addCss(css.setBackgroundImage("/res/media/png/btn_salvar_40x40.png"));
            this.btnSalvar.addCss(css.setBackgroundPosition("center"));
            this.btnSalvar.addCss(css.setBackgroundRepeat("no-repeat"));
            this.btnSalvar.addCss(css.setPosition("absolute"));
            this.btnSalvar.addCss(css.setRight(5));
            this.btnSalvar.addCss(css.setTop(5));
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}