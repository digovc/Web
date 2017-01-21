using NetZ.Web.Server.Arquivo.Css;

namespace NetZ.Web.Html.Componente.Menu
{
    public abstract class Menu : ComponenteHtml
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private Div _divGaveta;
        private Div _divGavetaContainer;
        private Div _divPesquisa;
        private Input _txtPesquisa;

        protected Div divGaveta
        {
            get
            {
                if (_divGaveta != null)
                {
                    return _divGaveta;
                }

                _divGaveta = new Div();

                return _divGaveta;
            }
        }

        private Div divGavetaContainer
        {
            get
            {
                if (_divGavetaContainer != null)
                {
                    return _divGavetaContainer;
                }

                _divGavetaContainer = new Div();

                return _divGavetaContainer;
            }
        }

        private Div divPesquisa
        {
            get
            {
                if (_divPesquisa != null)
                {
                    return _divPesquisa;
                }

                _divPesquisa = new Div();

                return _divPesquisa;
            }
        }

        private Input txtPesquisa
        {
            get
            {
                if (_txtPesquisa != null)
                {
                    return _txtPesquisa;
                }

                _txtPesquisa = new Input();

                return _txtPesquisa;
            }
        }

        #endregion Atributos

        #region Construtores

        protected Menu(string strId)
        {
            this.strId = strId;
        }

        #endregion Construtores

        #region Métodos

        protected override void addJsDebug(LstTag<JavaScriptTag> lstJsDebug)
        {
            base.addJsDebug(lstJsDebug);

            lstJsDebug.Add(new JavaScriptTag(typeof(Menu), 150));
        }

        protected override void inicializar()
        {
            base.inicializar();

            this.divGaveta.strId = "divGaveta";

            this.txtPesquisa.strId = "txtPesquisa";
            this.txtPesquisa.strPlaceHolder = "Digite para pesquisar";
        }

        protected override void montarLayout()
        {
            base.montarLayout();

            this.divPesquisa.setPai(this);
            this.txtPesquisa.setPai(this.divPesquisa);
            this.divGavetaContainer.setPai(this);
            this.divGaveta.setPai(this.divGavetaContainer);
        }

        protected override void setCss(CssArquivo css)
        {
            base.setCss(css);

            this.divGaveta.addCss(css.setBackgroundColor(AppWebBase.i.objTema.corTelaFundo));
            this.divGaveta.addCss(css.setBorderBottom(1, "solid", AppWebBase.i.objTema.corSombra));
            this.divGaveta.addCss(css.setBorderLeft(1, "solid", AppWebBase.i.objTema.corSombra));
            this.divGaveta.addCss(css.setBorderRight(1, "solid", AppWebBase.i.objTema.corSombra));
            this.divGaveta.addCss(css.setBoxShadow(0, 3, 5, -1, "rgba(80, 80, 80,0.8)"));
            this.divGaveta.addCss(css.setCenter());
            this.divGaveta.addCss(css.setColor(AppWebBase.i.objTema.corFonte));
            this.divGaveta.addCss(css.setDisplay("none"));
            this.divGaveta.addCss(css.setMaxHeight(650));
            this.divGaveta.addCss(css.setMinWidth(370));
            this.divGaveta.addCss(css.setOverflow("hidden"));
            this.divGaveta.addCss(css.setPaddingLeft(10, "px"));
            this.divGaveta.addCss(css.setPaddingRight(10, "px"));
            this.divGaveta.addCss(css.setWidth(25, "%"));
            this.divGaveta.addCss(css.setZIndex(10));

            this.divGavetaContainer.addCss(css.setPosition("absolute"));
            this.divGavetaContainer.addCss(css.setTop(50));
            this.divGavetaContainer.addCss(css.setWidth(100, "%"));

            this.divPesquisa.addCss(css.setPosition("absolute"));
            this.divPesquisa.addCss(css.setTop(0));
            this.divPesquisa.addCss(css.setWidth(100, "%"));

            this.txtPesquisa.limparClass();

            this.txtPesquisa.addCss(css.setBorder(0));
            this.txtPesquisa.addCss(css.setBorderRadius(5, "px"));
            this.txtPesquisa.addCss(css.setCenter());
            this.txtPesquisa.addCss(css.setDisplay("block"));
            this.txtPesquisa.addCss(css.setFontSize(20));
            this.txtPesquisa.addCss(css.setHeight(29));
            this.txtPesquisa.addCss(css.setPaddingLeft(10));
            this.txtPesquisa.addCss(css.setPaddingRight(10));
            this.txtPesquisa.addCss(css.setPosition("relative"));
            this.txtPesquisa.addCss(css.setTop(9));
            this.txtPesquisa.addCss(css.setWidth(350));
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}