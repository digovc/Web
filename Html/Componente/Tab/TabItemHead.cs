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

                this.setTabItem(_tabItem);
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

            this.addCss(css.setBorderRight(1, "solid", AppWebBase.i.objTema.corFundoBorda));
            this.addCss(css.setCursor("pointer"));
            this.addCss(css.setFloat("left"));
            this.addCss(css.setLineHeight(30));
            this.addCss(css.setOverflow("hide"));
            this.addCss(css.setWidth(130));
        }

        private void setTabItem(TabItem tabItem)
        {
            if (tabItem == null)
            {
                return;
            }

            this.strConteudo = tabItem.strTitulo;

            this.strId = (tabItem.strId + "_tabItemHead");
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}