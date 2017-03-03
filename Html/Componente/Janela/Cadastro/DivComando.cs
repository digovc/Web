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

        private BotaoCircular _btnTag;

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

        private BotaoCircular btnTag
        {
            get
            {
                if (_btnTag != null)
                {
                    return _btnTag;
                }

                _btnTag = new BotaoCircular();

                return _btnTag;
            }
        }

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        protected override void addJs(LstTag<JavaScriptTag> lstJsDebug)
        {
            base.addJs(lstJsDebug);

            lstJsDebug.Add(new JavaScriptTag(typeof(DivComando), 116));
        }

        protected override void setStrId(string strId)
        {
            base.setStrId(strId);

            if (string.IsNullOrEmpty(strId))
            {
                return;
            }

            this.btnAdicionar.strId = (strId + "_btnAdicionar");
            this.btnDireita.strId = (strId + "_btnDireita");
            this.btnEsquerda.strId = (strId + "_btnEsquerda");
            this.btnSalvar.strId = (strId + "_btnSalvar");
            this.btnTag.strId = (strId + "_btnTag");
        }

        protected override void inicializar()
        {
            base.inicializar();

            this.btnDireita.enmLado = BotaoHtml.EnmLado.ESQUERDA;
            this.btnDireita.enmTamanho = BotaoCircular.EnmTamanho.PEQUENO;

            this.btnEsquerda.enmLado = BotaoHtml.EnmLado.ESQUERDA;
            this.btnEsquerda.enmTamanho = BotaoCircular.EnmTamanho.PEQUENO;

            this.btnAdicionar.enmTamanho = BotaoCircular.EnmTamanho.PEQUENO;

            this.btnTag.enmTamanho = BotaoCircular.EnmTamanho.PEQUENO;
        }

        protected override void montarLayout()
        {
            base.montarLayout();

            this.btnEsquerda.setPai(this);
            this.btnDireita.setPai(this);
            this.btnAdicionar.setPai(this);
            this.btnSalvar.setPai(this);
            this.btnTag.setPai(this);
        }

        protected override void setCss(CssArquivo css)
        {
            base.setCss(css);

            this.btnEsquerda.addCss(css.setBackgroundImage("/res/media/png/btn_voltar_30x30.png"));
            this.btnEsquerda.addCss(css.setDisplay("none"));
            this.btnEsquerda.addCss(css.setLeft(10));
            this.btnEsquerda.addCss(css.setPosition("absolute"));
            this.btnEsquerda.addCss(css.setTop(10));

            this.btnDireita.addCss(css.setBackgroundImage("/res/media/png/btn_avancar_30x30.png"));
            this.btnDireita.addCss(css.setDisplay("none"));
            this.btnDireita.addCss(css.setLeft(50));
            this.btnDireita.addCss(css.setPosition("absolute"));
            this.btnDireita.addCss(css.setTop(10));

            this.btnAdicionar.addCss(css.setBackgroundImage("/res/media/png/btn_adicionar_30x30.png"));
            this.btnAdicionar.addCss(css.setDisplay("none"));
            this.btnAdicionar.addCss(css.setPosition("absolute"));
            this.btnAdicionar.addCss(css.setRight(55));
            this.btnAdicionar.addCss(css.setTop(10));

            this.btnSalvar.addCss(css.setBackgroundImage("/res/media/png/btn_salvar_40x40.png"));
            this.btnSalvar.addCss(css.setPosition("absolute"));
            this.btnSalvar.addCss(css.setRight(5));
            this.btnSalvar.addCss(css.setTop(5));

            this.btnTag.addCss(css.setBackgroundImage("/res/media/png/btn_tag_30x30.png"));
            this.btnTag.addCss(css.setDisplay("none"));
            this.btnTag.addCss(css.setPosition("absolute"));
            this.btnTag.addCss(css.setRight(95));
            this.btnTag.addCss(css.setTop(10));
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}