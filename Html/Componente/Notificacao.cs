using NetZ.Web.Server.Arquivo.Css;

namespace NetZ.Web.Html.Componente
{
    public class Notificacao : ComponenteHtml
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private Div _divAdiar;
        private Div _divComando;
        private Div _divFechar;
        private Div _divIcone;
        private Div _divLink;
        private Div _divTexto;

        private Div divAdiar
        {
            get
            {
                if (_divAdiar != null)
                {
                    return _divAdiar;
                }

                _divAdiar = new Div();

                return _divAdiar;
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

        private Div divFechar
        {
            get
            {
                if (_divFechar != null)
                {
                    return _divFechar;
                }

                _divFechar = new Div();

                return _divFechar;
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

        private Div divLink
        {
            get
            {
                if (_divLink != null)
                {
                    return _divLink;
                }

                _divLink = new Div();

                return _divLink;
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

            this.divAdiar.strId = "_str_div_adiar_id";

            this.divFechar.strId = "_str_div_fechar_id";

            this.divIcone.strId = "_str_div_icone_id";

            this.divLink.strId = "_str_div_link_id";

            this.divTexto.strConteudo = "_str_div_texto_conteudo";
        }

        protected override void montarLayout()
        {
            base.montarLayout();

            this.divComando.setPai(this);

            this.divAdiar.setPai(this.divComando);
            this.divLink.setPai(this.divComando);
            this.divFechar.setPai(this.divComando);

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

            this.divAdiar.addCss(css.setDisplay("none"));
            this.divAdiar.addCss(css.setFloat("left"));
            this.divAdiar.addCss(css.setHeight(100, "%"));
            this.divAdiar.addCss(css.setMarginRight(5));
            this.divAdiar.addCss(css.setWidth(20));

            this.divComando.addCss(css.setHeight(20));
            this.divComando.addCss(css.setPosition("absolute"));
            this.divComando.addCss(css.setRight(0));

            this.divFechar.addCss(css.setFloat("left"));
            this.divFechar.addCss(css.setHeight(100, "%"));
            this.divFechar.addCss(css.setWidth(20));

            this.divIcone.addCss(css.setBackgroundColor("#f4f5f5"));
            this.divIcone.addCss(css.setBorderRight(5, "solid", "#4caf50"));
            this.divIcone.addCss(css.setFloat("left"));
            this.divIcone.addCss(css.setHeight(100, "%"));
            this.divIcone.addCss(css.setWidth(100));

            this.divLink.addCss(css.setDisplay("none"));
            this.divLink.addCss(css.setFloat("left"));
            this.divLink.addCss(css.setHeight(100, "%"));
            this.divLink.addCss(css.setMarginRight(5));
            this.divLink.addCss(css.setWidth(20));

            this.divTexto.addCss(css.setMarginLeft(110));
            this.divTexto.addCss(css.setPadding(20));
            this.divTexto.addCss(css.setPaddingTop(30));
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}