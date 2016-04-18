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

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        protected override void addTag(Tag tag)
        {
            if (tag == null)
            {
                return;
            }

            if ((typeof(TabItem).IsAssignableFrom(tag.GetType())))
            {
                this.addTagTabItem(tag as TabItem);
            }

            base.addTag(tag);
        }

        protected override void montarLayout()
        {
            base.montarLayout();

            this.divCabecalho.setPai(this);
            this.divCabecalhoConteudo.setPai(this.divCabecalho);
        }

        protected override void setCss(CssArquivo css)
        {
            base.setCss(css);

            this.addCss(css.setHeight(250));
            this.addCss(css.setBackgroundColor(AppWeb.i.objTema.corTema));

            this.divCabecalho.addCss(css.setHeight(40));

            this.divCabecalhoConteudo.addCss(css.setHeight(30));
        }

        private void addTagTabItem(TabItem tabItem)
        {
            if (tabItem == null)
            {
                return;
            }

            TabItemHead tagTabItemHead = new TabItemHead();

            tagTabItemHead.strTitulo = tabItem.strTitulo;

            tagTabItemHead.setPai(this.divCabecalhoConteudo);

            this.intTabQuantidade++;
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}