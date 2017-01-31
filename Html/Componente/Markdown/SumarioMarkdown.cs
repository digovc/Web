using NetZ.Web.Html.Pagina;
using NetZ.Web.Server.Arquivo.Css;
using System.Collections.Generic;
using System.IO;

namespace NetZ.Web.Html.Componente.Markdown
{
    internal class SumarioMarkdown : ComponenteHtml
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private Div _divTitulo;
        private List<SumarioMarkdownItem> _lstDivItem;
        private PagMarkdownBase _pagMarkdown;

        public PagMarkdownBase pagMarkdown
        {
            get
            {
                return _pagMarkdown;
            }

            set
            {
                _pagMarkdown = value;
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

        private List<SumarioMarkdownItem> lstDivItem
        {
            get
            {
                if (_lstDivItem != null)
                {
                    return _lstDivItem;
                }

                _lstDivItem = this.getLstDivItem();

                return _lstDivItem;
            }
        }

        #endregion Atributos

        #region Construtores

        public SumarioMarkdown(PagMarkdownBase pagMarkdown)
        {
            this.pagMarkdown = pagMarkdown;
        }

        #endregion Construtores

        #region Métodos

        protected override void inicializar()
        {
            base.inicializar();

            this.divTitulo.strConteudo = this.pagMarkdown.strNome;
        }

        protected override void montarLayout()
        {
            base.montarLayout();

            this.divTitulo.setPai(this);

            this.lstDivItem?.ForEach((divItem) => divItem.setPai(this));
        }

        protected override void setCss(CssArquivo css)
        {
            base.setCss(css);

            this.addCss(css.setBackgroundColor("#e3e3e3"));
            this.addCss(css.setBottom(0));
            this.addCss(css.setMinWidth(250));
            this.addCss(css.setPosition("absolute"));
            this.addCss(css.setTop(50));

            this.divTitulo.addCss(css.setBackgroundColor("#cecece"));
            this.divTitulo.addCss(css.setFontSize(20));
            this.divTitulo.addCss(css.setFontWeight("bold"));
            this.divTitulo.addCss(css.setPadding(10));
        }

        private List<SumarioMarkdownItem> getLstDivItem()
        {
            if (this.pagMarkdown == null)
            {
                return null;
            }

            if (!Directory.Exists(this.pagMarkdown.dirRepositorio))
            {
                return null;
            }

            var lstDivItemResultado = new List<SumarioMarkdownItem>();

            foreach (string dirMarkdown in Directory.GetFiles(this.pagMarkdown.dirRepositorio))
            {
                this.getLstDivItem(lstDivItemResultado, dirMarkdown);
            }

            return lstDivItemResultado;
        }

        private void getLstDivItem(List<SumarioMarkdownItem> lstDivItem, string dirMarkdown)
        {
            if (string.IsNullOrEmpty(dirMarkdown))
            {
                return;
            }

            if (!".md".Equals(Path.GetExtension(dirMarkdown)))
            {
                return;
            }

            lstDivItem.Add(new SumarioMarkdownItem(dirMarkdown));
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}