﻿using NetZ.Web.Html.Componente.Botao;
using NetZ.Web.Server.Arquivo.Css;

namespace NetZ.Web.Html.Componente
{
    public class Notificacao : ComponenteHtml
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private BotaoMini _btnAdiar;
        private BotaoMini _btnFechar;
        private BotaoMini _btnLink;
        private Div _divComando;
        private Div _divIcone;
        private Div _divTexto;

        private BotaoMini btnAdiar
        {
            get
            {
                if (_btnAdiar != null)
                {
                    return _btnAdiar;
                }

                _btnAdiar = new BotaoMini();

                return _btnAdiar;
            }
        }

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

        private BotaoMini btnLink
        {
            get
            {
                if (_btnLink != null)
                {
                    return _btnLink;
                }

                _btnLink = new BotaoMini();

                return _btnLink;
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

            this.btnAdiar.strId = "_str_div_adiar_id";

            this.btnFechar.strId = "_str_div_fechar_id";

            this.divIcone.strId = "_str_div_icone_id";

            this.btnLink.strId = "_str_div_link_id";

            this.divTexto.strConteudo = "_str_div_texto_conteudo";
        }

        protected override void montarLayout()
        {
            base.montarLayout();

            this.divComando.setPai(this);

            this.btnAdiar.setPai(this.divComando);
            this.btnLink.setPai(this.divComando);
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

            this.btnAdiar.addCss(css.setFloat("left"));

            this.divComando.addCss(css.setHeight(20));
            this.divComando.addCss(css.setPosition("absolute"));
            this.divComando.addCss(css.setRight(0));

            this.btnFechar.addCss(css.setFloat("left"));

            this.divIcone.addCss(css.setBackgroundColor("#f4f5f5"));
            this.divIcone.addCss(css.setBorderRight(5, "solid", "#4caf50"));
            this.divIcone.addCss(css.setFloat("left"));
            this.divIcone.addCss(css.setHeight(100, "%"));
            this.divIcone.addCss(css.setWidth(100));

            this.btnLink.addCss(css.setFloat("left"));

            this.divTexto.addCss(css.setMarginLeft(110));
            this.divTexto.addCss(css.setPadding(20));
            this.divTexto.addCss(css.setPaddingTop(30));
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}