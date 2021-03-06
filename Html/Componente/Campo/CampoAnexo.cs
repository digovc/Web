﻿using NetZ.Web.Html.Componente.Botao;
using NetZ.Web.Server.Arquivo.Css;

namespace NetZ.Web.Html.Componente.Campo
{
    public class CampoAnexo : CampoMedia
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private BotaoCircular _btnDownload;
        private BotaoCircular _btnPesquisar;
        private Div _divArquivoNome;
        private Div _divArquivoTamanho;
        private Div _divIcone;
        private ProgressBar _divProgressBar;

        private BotaoCircular btnDownload
        {
            get
            {
                if (_btnDownload != null)
                {
                    return _btnDownload;
                }

                _btnDownload = new BotaoCircular();

                return _btnDownload;
            }
        }

        private BotaoCircular btnPesquisar
        {
            get
            {
                if (_btnPesquisar != null)
                {
                    return _btnPesquisar;
                }

                _btnPesquisar = new BotaoCircular();

                return _btnPesquisar;
            }
        }

        private Div divArquivoNome
        {
            get
            {
                if (_divArquivoNome != null)
                {
                    return _divArquivoNome;
                }

                _divArquivoNome = new Div();

                return _divArquivoNome;
            }
        }

        private Div divArquivoTamanho
        {
            get
            {
                if (_divArquivoTamanho != null)
                {
                    return _divArquivoTamanho;
                }

                _divArquivoTamanho = new Div();

                return _divArquivoTamanho;
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

        private ProgressBar divProgressBar
        {
            get
            {
                if (_divProgressBar != null)
                {
                    return _divProgressBar;
                }

                _divProgressBar = new ProgressBar();

                return _divProgressBar;
            }
        }

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        protected override Input.EnmTipo getEnmTipo()
        {
            return Input.EnmTipo.FILE;
        }

        protected override void inicializar()
        {
            base.inicializar();

            this.btnDownload.enmTamanho = BotaoCircular.EnmTamanho.PEQUENO;
            this.btnPesquisar.enmTamanho = BotaoCircular.EnmTamanho.PEQUENO;
        }

        protected override void montarLayout()
        {
            base.montarLayout();

            this.btnDownload.setPai(this.divComando);
            this.btnPesquisar.setPai(this.divComando);

            this.divIcone.setPai(this.divContent);
            this.divProgressBar.setPai(this.divContent);
            this.divArquivoNome.setPai(this.divContent);
            this.divArquivoTamanho.setPai(this.divContent);
        }

        protected override void setCss(CssArquivoBase css)
        {
            base.setCss(css);

            this.btnDownload.addCss(css.setBackgroundImage("/res/media/png/btn_download_30x30.png"));

            this.btnPesquisar.addCss(css.setBackgroundImage("/res/media/png/btn_pesquisar_30x30.png"));

            this.divArquivoTamanho.addCss(css.setFontSize(12));

            this.divIcone.addCss(css.setBackgroundImage("/res/media/png/file_100x100.png"));
            this.divIcone.addCss(css.setBackgroundPosition("center"));
            this.divIcone.addCss(css.setBackgroundRepeat("no-repeat"));
            this.divIcone.addCss(css.setColor(AppWebBase.i.objTema.corTema));
            this.divIcone.addCss(css.setDisplay("none"));
            this.divIcone.addCss(css.setFontSize(20));
            this.divIcone.addCss(css.setFontWeight("bold"));
            this.divIcone.addCss(css.setHeight(170));
            this.divIcone.addCss(css.setLineHeight(170));

            this.divProgressBar.addCss(css.setDisplay("none"));
            this.divProgressBar.addCss(css.setMarginLeft(150));
            this.divProgressBar.addCss(css.setMarginRight(150));
        }

        protected override void setStrId(string strId)
        {
            base.setStrId(strId);

            if (string.IsNullOrEmpty(strId))
            {
                return;
            }

            this.btnDownload.strId = (strId + "_btnDownload");
            this.btnPesquisar.strId = (strId + "_btnPesquisar");
            this.divArquivoNome.strId = (strId + "_divArquivoNome");
            this.divArquivoTamanho.strId = (strId + "_divArquivoTamanho");
            this.divIcone.strId = (strId + "_divIcone");
            this.divProgressBar.strId = (strId + "_divProgressBar");
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}