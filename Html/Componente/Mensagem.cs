﻿using NetZ.Web.Html.Componente.Botao;
using NetZ.Web.Html.Componente.Painel;
using NetZ.Web.Server.Arquivo.Css;

namespace NetZ.Web.Html.Componente
{
    public class Mensagem : PainelModal
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private BotaoCircular _btnCancelar;
        private BotaoCircular _btnConfirmar;
        private Div _divComando;
        private Div _divContainer;
        private Div _divContainerFaixa;
        private Div _divMensagem;
        private Div _divTitulo;

        private BotaoCircular btnCancelar
        {
            get
            {
                if (_btnCancelar != null)
                {
                    return _btnCancelar;
                }

                _btnCancelar = new BotaoCircular();

                return _btnCancelar;
            }
        }

        private BotaoCircular btnConfirmar
        {
            get
            {
                if (_btnConfirmar != null)
                {
                    return _btnConfirmar;
                }

                _btnConfirmar = new BotaoCircular();

                return _btnConfirmar;
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

        private Div divContainer
        {
            get
            {
                if (_divContainer != null)
                {
                    return _divContainer;
                }

                _divContainer = new Div();

                return _divContainer;
            }
        }

        private Div divContainerFaixa
        {
            get
            {
                if (_divContainerFaixa != null)
                {
                    return _divContainerFaixa;
                }

                _divContainerFaixa = new Div();

                return _divContainerFaixa;
            }
        }

        private Div divMensagem
        {
            get
            {
                if (_divMensagem != null)
                {
                    return _divMensagem;
                }

                _divMensagem = new Div();

                return _divMensagem;
            }
        }

        private Div divTitulo
        {
            get
            {
                if (_divTitulo != null)
                {
                    return _divTitulo;
                }

                _divTitulo = new Div();

                return _divTitulo;
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

            this.btnCancelar.enmTamanho = BotaoCircular.EnmTamanho.PEQUENO;
            this.btnCancelar.strId = "_btn_cancelar_str_id";

            this.btnConfirmar.strId = "_btn_confirmar_str_id";

            this.divContainerFaixa.strId = "_div_container_faixa_str_id";

            this.divMensagem.strConteudo = "_str_msg_mensagem";

            this.divTitulo.strConteudo = "_str_msg_titulo";
        }

        protected override void montarLayout()
        {
            base.montarLayout();

            this.divContainerFaixa.setPai(this);
            this.divContainer.setPai(this.divContainerFaixa);
            this.divTitulo.setPai(this.divContainer);
            this.divMensagem.setPai(this.divContainer);

            this.divComando.setPai(this.divContainer);

            this.btnConfirmar.setPai(this.divComando);
            this.btnCancelar.setPai(this.divComando);
        }

        protected override void setCss(CssArquivoBase css)
        {
            base.setCss(css);

            this.addCss(css.setColor("white"));
            this.addCss(css.setTextAlign("left"));

            this.btnCancelar.addCss(css.setBackgroundImage("/res/media/png/btn_cancelar_30x30.png"));
            this.btnCancelar.addCss(css.setDisplay("none"));
            this.btnCancelar.addCss(css.setFloat("right"));
            this.btnCancelar.addCss(css.setMarginRight(10));
            this.btnCancelar.addCss(css.setMarginTop(7));

            this.btnConfirmar.addCss(css.setBackgroundImage("/res/media/png/btn_salvar_40x40.png"));
            this.btnConfirmar.addCss(css.setFloat("right"));

            this.divComando.addCss(css.setBottom(0));
            this.divComando.addCss(css.setHeight(50));
            this.divComando.addCss(css.setLeft(15));
            this.divComando.addCss(css.setPosition("absolute"));
            this.divComando.addCss(css.setRight(15));

            this.divContainer.addCss(css.setCenter());
            this.divContainer.addCss(css.setHeight(250));
            this.divContainer.addCss(css.setMaxWidth(500));
            this.divContainer.addCss(css.setPaddingLeft(15));
            this.divContainer.addCss(css.setPaddingRight(15));
            this.divContainer.addCss(css.setPosition("relative"));

            this.divContainerFaixa.addCss(css.setBackgroundColor("#607C60"));
            this.divContainerFaixa.addCss(css.setHeight(250));
            this.divContainerFaixa.addCss(css.setLeft(0));
            this.divContainerFaixa.addCss(css.setPosition("absolute"));
            this.divContainerFaixa.addCss(css.setRight(0));
            this.divContainerFaixa.addCss(css.setTop(35, "vh"));

            this.divMensagem.addCss(css.setHeight(125));
            this.divMensagem.addCss(css.setOverflow("auto"));
            this.divMensagem.addCss(css.setPadding(10));
            this.divMensagem.addCss(css.setWordWrap("break-word"));

            this.divTitulo.addCss(css.setFontSize(25));
            this.divTitulo.addCss(css.setPaddingBottom(10));
            this.divTitulo.addCss(css.setPaddingTop(10));
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}