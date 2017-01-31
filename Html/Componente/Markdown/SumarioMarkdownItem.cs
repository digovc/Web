using NetZ.Web.Server.Arquivo.Css;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace NetZ.Web.Html.Componente.Markdown
{
    internal class SumarioMarkdownItem : ComponenteHtml
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private string _dirMarkdown;
        private Div _divItemContainer;
        private Div _divTitulo;
        private List<SumarioMarkdownItem> _lstDivItem;
        private string _mkd;

        private string dirMarkdown
        {
            get
            {
                return _dirMarkdown;
            }

            set
            {
                _dirMarkdown = value;
            }
        }

        private Div divItemContainer
        {
            get
            {
                if (_divItemContainer != null)
                {
                    return _divItemContainer;
                }

                _divItemContainer = new Div();

                return _divItemContainer;
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

        private string mkd
        {
            get
            {
                if (_mkd != null)
                {
                    return _mkd;
                }

                _mkd = this.getMkd();

                return _mkd;
            }
        }

        #endregion Atributos

        #region Construtores

        public SumarioMarkdownItem(string dirMarkdown)
        {
            this.dirMarkdown = dirMarkdown;
        }

        #endregion Construtores

        #region Métodos

        protected override void inicializar()
        {
            base.inicializar();

            this.inicializarDivTitulo();
        }

        protected override void montarLayout()
        {
            base.montarLayout();

            this.divTitulo.setPai(this);

            this.divItemContainer.setPai(this);

            this.lstDivItem?.ForEach((divItem) => divItem.setPai(this.divItemContainer));
        }

        protected override void setCss(CssArquivo css)
        {
            base.setCss(css);

            this.divItemContainer.addCss(css.setPaddingLeft(10));

            this.divTitulo.addCss(css.setPadding(10));
            this.divTitulo.addCss(css.setPaddingLeft(20));
        }

        private List<SumarioMarkdownItem> getLstDivItem()
        {
            var dirMarkdownFolder = this.dirMarkdown?.Replace(".md", null);

            if (!Directory.Exists(dirMarkdownFolder))
            {
                return null;
            }

            var lstDivItemResultado = new List<SumarioMarkdownItem>();

            foreach (string dirMarkdown in Directory.GetFiles(dirMarkdownFolder))
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

        private string getMkd()
        {
            if (!File.Exists(this.dirMarkdown))
            {
                return null;
            }

            return File.ReadAllText(this.dirMarkdown);
        }

        private void inicializarDivTitulo()
        {
            if (string.IsNullOrEmpty(this.mkd))
            {
                return;
            }

            if (!this.mkd.StartsWith("# "))
            {
                return;
            }

            var strTitulo = this.mkd.Split(new[] { '\r', '\n' }).FirstOrDefault();

            if (string.IsNullOrEmpty(strTitulo))
            {
                return;
            }

            if (strTitulo.Length < 3)
            {
                return;
            }

            this.divTitulo.strConteudo = strTitulo.Substring(2);
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}