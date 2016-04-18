using NetZ.Web.Html.Componente.Botao.Comando;
using NetZ.Web.Html.Componente.Botao.Mini;
using NetZ.Web.Html.Componente.Painel;
using NetZ.Web.Server.Arquivo.Css;

namespace NetZ.Web.Html.Componente.Janela.Cadastro
{
    public class DivComando : PainelNivel
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private BotaoDireitaMini _btnDireita;
        private BotaoEsquerdaMini _btnEsquerda;
        private BotaoNovoComando _btnNovo;
        private BotaoSalvarComando _btnSalvar;

        private BotaoDireitaMini btnDireita
        {
            get
            {
                if (_btnDireita != null)
                {
                    return _btnDireita;
                }

                _btnDireita = new BotaoDireitaMini();

                return _btnDireita;
            }
        }

        private BotaoEsquerdaMini btnEsquerda
        {
            get
            {
                if (_btnEsquerda != null)
                {
                    return _btnEsquerda;
                }

                _btnEsquerda = new BotaoEsquerdaMini();

                return _btnEsquerda;
            }
        }

        private BotaoNovoComando btnNovo
        {
            get
            {
                if (_btnNovo != null)
                {
                    return _btnNovo;
                }

                _btnNovo = new BotaoNovoComando();

                return _btnNovo;
            }
        }

        private BotaoSalvarComando btnSalvar
        {
            get
            {
                if (_btnSalvar != null)
                {
                    return _btnSalvar;
                }

                _btnSalvar = new BotaoSalvarComando();

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

            this.btnSalvar.strId = (this.strId + "_btnSalvar");
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
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}