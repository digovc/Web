using NetZ.Web.Html.Componente.Botao;
using NetZ.Web.Server.Arquivo.Css;

namespace NetZ.Web.Html.Componente
{
    public class Notificacao : ComponenteHtml
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private BotaoMini _btnFechar;
        private Div _divComando;
        private Div _divIcone;
        private Div _divTexto;

        private BotaoMini btnFechar
        {
            get
            {
                if (_btnFechar != null)
                {
                    return _btnFechar;
                }

                _btnFechar = new BotaoMini();

                return _btnFechar;
            }
        }

        private Div divComando
        {
            get
            {
                if (_divComando != null)
                {
                    return _divComando;
                }

                _divComando = new Div();

                return _divComando;
            }
        }

        private Div divIcone
        {
            get
            {
                if (_divIcone != null)
                {
                    return _divIcone;
                }

                _divIcone = new Div();

                return _divIcone;
            }
        }

        private Div divTexto
        {
            get
            {
                if (_divTexto != null)
                {
                    return _divTexto;
                }

                _divTexto = new Div();

                return _divTexto;
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

            this.btnFechar.strId = "_str_div_fechar_id";

            this.divIcone.strId = "_str_div_icone_id";

            this.divTexto.strConteudo = "_str_div_texto_conteudo";
        }

        protected override void montarLayout()
        {
            base.montarLayout();

            this.divComando.setPai(this);

            this.btnFechar.setPai(this.divComando);

            this.divIcone.setPai(this);

            this.divTexto.setPai(this);
        }

        protected override void setCss(CssArquivo css)
        {
            base.setCss(css);

            this.addCss(css.setBackgroundColor("white"));
            this.addCss(css.setBorder(1, "solid", "gray"));
            this.addCss(css.setColor("black"));
            this.addCss(css.setDisplay("none"));
            this.addCss(css.setHeight(100));
            this.addCss(css.setMarginTop(10));
            this.addCss(css.setWidth(400));

            this.divComando.addCss(css.setHeight(20));
            this.divComando.addCss(css.setPosition("absolute"));
            this.divComando.addCss(css.setRight(0));

            this.btnFechar.addCss(css.setBackgroundColor("white"));
            this.btnFechar.addCss(css.setBackgroundImage("/res/media/png/btn_fechar_notificacao_20x20.png"));
            this.btnFechar.addCss(css.setFloat("left"));

            this.divIcone.addCss(css.setBackgroundColor("#f1f2f2"));
            this.divIcone.addCss(css.setBackgroundImage("/res/media/png/img_notificacao_positiva.png"));
            this.divIcone.addCss(css.setBorderRight(5, "solid", "#49ac81"));
            this.divIcone.addCss(css.setFloat("left"));
            this.divIcone.addCss(css.setHeight(100, "%"));
            this.divIcone.addCss(css.setWidth(100));

            this.divTexto.addCss(css.setMarginLeft(110));
            this.divTexto.addCss(css.setPadding(20));
            this.divTexto.addCss(css.setPaddingTop(30));
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}