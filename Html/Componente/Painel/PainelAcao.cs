using System.Collections.Generic;
using NetZ.Web.Html.Componente.Botao;
using NetZ.Web.Server.Arquivo.Css;

namespace NetZ.Web.Html.Componente.Painel
{
    public class PainelAcao : Div
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private BotaoCircular _btnAcaoPrincipal;
        private int _intBtnAcaoSecundariaTop = -45;
        private List<BotaoCircular> _lstBtnAcaoSecundaria;

        private BotaoCircular btnAcaoPrincipal
        {
            get
            {
                if (_btnAcaoPrincipal != null)
                {
                    return _btnAcaoPrincipal;
                }

                _btnAcaoPrincipal = new BotaoCircular();

                return _btnAcaoPrincipal;
            }
        }

        private int intBtnAcaoSecundariaTop
        {
            get
            {
                return _intBtnAcaoSecundariaTop;
            }

            set
            {
                _intBtnAcaoSecundariaTop = value;
            }
        }

        private List<BotaoCircular> lstBtnAcaoSecundaria
        {
            get
            {
                if (_lstBtnAcaoSecundaria != null)
                {
                    return _lstBtnAcaoSecundaria;
                }

                _lstBtnAcaoSecundaria = new List<BotaoCircular>();

                return _lstBtnAcaoSecundaria;
            }
        }

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        protected override void addJs(LstTag<JavaScriptTag> lstJs)
        {
            base.addJs(lstJs);

            lstJs.Add(new JavaScriptTag(typeof(PainelAcao), 120));
        }

        protected override void addTag(Tag tag)
        {
            base.addTag(tag);

            if (tag == null)
            {
                return;
            }

            if (!(tag is BotaoCircular))
            {
                return;
            }

            if (tag.Equals(this.btnAcaoPrincipal))
            {
                return;
            }

            this.addBtnAcaoSecundaria(tag as BotaoCircular);
        }

        protected override void inicializar()
        {
            base.inicializar();

            this.btnAcaoPrincipal.enmTamanho = BotaoCircular.EnmTamanho.GRANDE;
            this.btnAcaoPrincipal.strId = "btnAcaoPrincipal";
        }

        protected override void montarLayout()
        {
            base.montarLayout();

            this.btnAcaoPrincipal.setPai(this);
        }

        protected override void setCss(CssArquivoBase css)
        {
            base.setCss(css);

            this.addCss(css.setPosition("absolute"));

            this.setCssLstBtnMini(css);

            this.btnAcaoPrincipal.addCss(css.setBackgroundColor("rgb(248,248,248)"));
            this.btnAcaoPrincipal.addCss(css.setBackgroundImage("/res/media/png/btn_pesquisar_60x60.png"));
        }

        private void addBtnAcaoSecundaria(BotaoCircular btnAcaoSecundaria)
        {
            if (btnAcaoSecundaria == null)
            {
                return;
            }

            if (this.lstBtnAcaoSecundaria.Contains(btnAcaoSecundaria))
            {
                return;
            }

            this.lstBtnAcaoSecundaria.Add(btnAcaoSecundaria);
        }

        private void setCss(CssArquivoBase css, BotaoCircular btnAcaoSecundaria)
        {
            if (btnAcaoSecundaria == null)
            {
                return;
            }

            btnAcaoSecundaria.addCss(css.setPosition("absolute"));
            btnAcaoSecundaria.addCss(css.setRight(17));
            btnAcaoSecundaria.addCss(css.setTop(this.intBtnAcaoSecundariaTop));

            this.intBtnAcaoSecundariaTop -= 40;
        }

        private void setCssLstBtnMini(CssArquivoBase css)
        {
            foreach (BotaoCircular btnAcaoSecundaria in this.lstBtnAcaoSecundaria)
            {
                this.setCss(css, btnAcaoSecundaria);
            }
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}