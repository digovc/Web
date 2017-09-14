using System;
using NetZ.Web.Html.Componente.Botao.ActionBar;
using NetZ.Web.Server.Arquivo.Css;

namespace NetZ.Web.Html.Componente.Mobile
{
    public abstract class ActionBarBase : ComponenteHtmlBase
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private bool _booMostrarMenu = true;
        private bool _booMostrarVoltar;
        private BotaoActionBar _btnMenu;
        private BotaoActionBar _btnVoltar;
        private Div _divLinha;
        private Div _divTitulo;
        private string _strTitulo;

        public bool booMostrarMenu
        {
            get
            {
                return _booMostrarMenu;
            }

            set
            {
                _booMostrarMenu = value;
            }
        }

        public bool booMostrarVoltar
        {
            get
            {
                return _booMostrarVoltar;
            }

            set
            {
                _booMostrarVoltar = value;
            }
        }

        public string strTitulo
        {
            get
            {
                return _strTitulo;
            }

            set
            {
                _strTitulo = value;

                this.setStrTitulo(_strTitulo);
            }
        }

        private BotaoActionBar btnMenu
        {
            get
            {
                if (_btnMenu != null)
                {
                    return _btnMenu;
                }

                _btnMenu = new BotaoActionBar();

                return _btnMenu;
            }
        }

        private BotaoActionBar btnVoltar
        {
            get
            {
                if (_btnVoltar != null)
                {
                    return _btnVoltar;
                }

                _btnVoltar = new BotaoActionBar();

                return _btnVoltar;
            }
        }

        private Div divLinha
        {
            get
            {
                if (_divLinha != null)
                {
                    return _divLinha;
                }

                _divLinha = new Div();

                return _divLinha;
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

        protected override void montarLayout()
        {
            base.montarLayout();

            this.btnMenu.setPai(this.booMostrarMenu ? this : null);

            this.divLinha.setPai(this.booMostrarMenu ? this : null);

            this.btnVoltar.setPai(this.booMostrarVoltar ? this : null);

            this.divTitulo.setPai(this);
        }

        protected override void setCss(CssArquivoBase css)
        {
            base.setCss(css);

            this.addCss(css.setBackgroundColor(AppWebBase.i.objTema.corTema));
            this.addCss(css.setBoxShadow(0, 0, 15, 0, "black"));
            this.addCss(css.setColor(AppWebBase.i.objTema.corFonteTema));
            this.addCss(css.setHeight(50, "px"));
            this.addCss(css.setLeft(0));
            this.addCss(css.setPosition("fixed"));
            this.addCss(css.setRight(0));
            this.addCss(css.setTop(0));
            this.addCss(css.setWidth(100, "%"));
            this.addCss(css.setZIndex(1000));

            this.setCssBtnMenu(css);

            this.setCssBtnVoltar(css);

            this.divLinha.addCss(css.setBackgroundColor(AppWebBase.i.objTema.corFonteTema));
            this.divLinha.addCss(css.setFloat("left"));
            this.divLinha.addCss(css.setHeight(30));
            this.divLinha.addCss(css.setMarginLeft(5));
            this.divLinha.addCss(css.setMarginTop(10));
            this.divLinha.addCss(css.setWidth(1));

            this.divTitulo.addCss(css.setFontSize(25));
            this.divTitulo.addCss(css.setLineHeight(50));
            this.divTitulo.addCss(css.setPaddingLeft(65));
            this.divTitulo.addCss(css.setWidth(100, "%"));
        }

        private void setCssBtnVoltar(CssArquivoBase css)
        {
            if (!this.booMostrarVoltar)
            {
                return;
            }

            this.btnVoltar.addCss(css.setBackgroundImage(AppWebBase.DIR_MEDIA_SVG + "return.svg"));
            this.btnVoltar.addCss(css.setFloat("left"));
        }

        private void setCssBtnMenu(CssArquivoBase css)
        {
            if (!this.booMostrarMenu)
            {
                return;
            }

            this.btnMenu.addCss(css.setBackgroundImage(AppWebBase.DIR_MEDIA_SVG + "menu.svg"));
            this.btnMenu.addCss(css.setFloat("left"));
        }

        protected override void setStrId(string strId)
        {
            base.setStrId(strId);

            this.btnMenu.strId = (strId + "_btnMenu");
            this.btnVoltar.strId = (strId + "_btnVoltar");
            this.divTitulo.strId = (strId + "_divTitulo");
        }

        private void setStrTitulo(string strTitulo)
        {
            this.divTitulo.strConteudo = strTitulo;
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}