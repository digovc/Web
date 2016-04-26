using NetZ.Web.Server.Arquivo.Css;

namespace NetZ.Web.Html.Componente.Tab
{
    public class TabHtml : ComponenteHtml
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private Div _divCabecalho;
        private Div _divCabecalhoConteudo;
        private Div _divConteudo;
        private int _intTabQuantidade;

        /// <summary>
        /// Retorna a quantidade de tabs que essa tag possui.
        /// </summary>
        public int intTabQuantidade
        {
            get
            {
                return _intTabQuantidade;
            }

            private set
            {
                _intTabQuantidade = value;
            }
        }

        private Div divCabecalho
        {
            get
            {
                if (_divCabecalho != null)
                {
                    return _divCabecalho;
                }

                _divCabecalho = new Div();

                return _divCabecalho;
            }
        }

        private Div divCabecalhoConteudo
        {
            get
            {
                if (_divCabecalhoConteudo != null)
                {
                    return _divCabecalhoConteudo;
                }

                _divCabecalhoConteudo = new Div();

                return _divCabecalhoConteudo;
            }
        }

        private Div divConteudo
        {
            get
            {
                if (_divConteudo != null)
                {
                    return _divConteudo;
                }

                _divConteudo = new Div();

                return _divConteudo;
            }
        }

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        protected override void addJs(LstTag<JavaScriptTag> lstJs)
        {
            base.addJs(lstJs);

            lstJs.Add(new JavaScriptTag(typeof(TabHtml), 110));
        }

        protected override void addTag(Tag tag)
        {
            if (tag == null)
            {
                return;
            }

            if ((typeof(TabItem).IsAssignableFrom(tag.GetType())))
            {
                this.addTagTabItem(tag as TabItem);
                return;
            }

            base.addTag(tag);
        }

        protected override void montarLayout()
        {
            base.montarLayout();

            this.divCabecalho.setPai(this);
            this.divCabecalhoConteudo.setPai(this.divCabecalho);
            this.divConteudo.setPai(this);
        }

        protected override void setCss(CssArquivo css)
        {
            base.setCss(css);

            this.addCss(css.setBackgroundColor(AppWeb.i.objTema.corTema));
            this.addCss(css.setHeight(250));
            this.addCss(css.setPosition("relative"));

            this.divCabecalho.addCss(css.setHeight(40));

            this.divCabecalhoConteudo.addCss(css.setHeight(30));

            this.divConteudo.addCss(css.setBottom(0));
            this.divConteudo.addCss(css.setOverflow("auto"));
            this.divConteudo.addCss(css.setPosition("absolute"));
            this.divConteudo.addCss(css.setTop(40));
            this.divConteudo.addCss(css.setWidth(100, "%"));
        }

        private void addTagTabItem(TabItem tabItem)
        {
            if (tabItem == null)
            {
                return;
            }

            tabItem.setPai(this.divConteudo);

            this.addTagTabItemTabItemHead(tabItem);

            this.intTabQuantidade++;
        }

        private void addTagTabItemTabItemHead(TabItem tabItem)
        {
            TabItemHead tagTabItemHead = new TabItemHead();

            tagTabItemHead.tabItem = tabItem;

            tagTabItemHead.setPai(this.divCabecalhoConteudo);
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}