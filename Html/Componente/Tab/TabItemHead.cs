using NetZ.Web.Server.Arquivo.Css;

namespace NetZ.Web.Html.Componente.Tab
{
    internal class TabItemHead : ComponenteHtml
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private TabItem _tabItem;

        internal TabItem tabItem
        {
            get
            {
                return _tabItem;
            }

            set
            {
                if (_tabItem == value)
                {
                    return;
                }

                _tabItem = value;

                this.atualizarTabItem();
            }
        }

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        protected override void addJs(LstTag<JavaScriptTag> lstJs)
        {
            base.addJs(lstJs);

            lstJs.Add(new JavaScriptTag(typeof(TabItemHead), 110));
        }

        protected override void setCss(CssArquivo css)
        {
            base.setCss(css);

            this.addCss(css.setBackgroundColor(AppWeb.i.objTema.corTelaFundo));
            this.addCss(css.setBorderBottom(1, "solid", "rgb(130,202,156)"));
            this.addCss(css.setBorderLeft(1, "solid", "rgb(130,202,156)"));
            this.addCss(css.setBorderRadius(0, 0, 5, 5));
            this.addCss(css.setBorderRight(1, "solid", "rgb(130,202,156)"));
            this.addCss(css.setBoxShadow(0, 1, 5, 0, AppWeb.i.objTema.corSombra));
            this.addCss(css.setFloat("left"));
            this.addCss(css.setHeight(30));
            this.addCss(css.setLineHeight(30));
            this.addCss(css.setOverflow("hide"));
            this.addCss(css.setPaddingLeft(10));
            this.addCss(css.setMarginLeft(10));
            this.addCss(css.setWidth(130));
        }

        private void atualizarTabItem()
        {
            if (this.tabItem == null)
            {
                return;
            }

            this.strConteudo = this.tabItem.strTitulo;
            this.strId = (this.tabItem.strId + "_tabItemHead");
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}