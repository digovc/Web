using NetZ.Web.Html.Componente.Botao.ActionBar;
using NetZ.Web.Server.Arquivo.Css;

namespace NetZ.Web.Html.Componente.Mobile
{
    public abstract class ActionBarBase : ComponenteHtml
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private BotaoActionBar _btnMenu;
        private BotaoActionBar _btnVoltar;
        private Div _divLinha;
        private Div _divTitulo;
        private string _strTitulo;

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

        protected override void addJsDebug(LstTag<JavaScriptTag> lstJsDebug)
        {
            base.addJsDebug(lstJsDebug);

            lstJsDebug.Add(new JavaScriptTag(typeof(ActionBarBase), 111));
        }

        protected override void montarLayout()
        {
            base.montarLayout();

            this.btnMenu.setPai(this);
            this.btnVoltar.setPai(this);
            this.divLinha.setPai(this);
            this.divTitulo.setPai(this);
        }

        protected override void setCss(CssArquivo css)
        {
            base.setCss(css);

            this.addCss(css.setBackgroundColor(AppWebBase.i.objTema.corTema));
            this.addCss(css.setBoxShadow(0, 0, 15, 0, "black"));
            this.addCss(css.setColor(AppWebBase.i.objTema.corFonteTema));
            this.addCss(css.setHeight(50, "px"));
            this.addCss(css.setPosition("fixed"));
            this.addCss(css.setWidth(100, "%"));

            this.btnMenu.addCss(css.setBackgroundImage(AppWebBase.DIR_MEDIA_PNG + "icon-menu-action-bar.png"));
            this.btnMenu.addCss(css.setBackgroundPosition("center"));
            this.btnMenu.addCss(css.setBackgroundRepeat("no-repeat"));
            this.btnMenu.addCss(css.setFloat("left"));

            this.btnVoltar.addCss(css.setDisplay("none"));
            this.btnVoltar.addCss(css.setFloat("left"));

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