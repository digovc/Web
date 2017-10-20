using DigoFramework;
using NetZ.Web.Server.Arquivo.Css;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace NetZ.Web.Html.Componente.Documentacao
{
    internal class SumarioItem : ComponenteHtmlBase
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private string _dirMarkdown;
        private Div _divConteudo;
        private Div _divIndice;
        private Div _divTitulo;
        private List<SumarioItem> _lstDivItem;
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

        private Div divIndice
        {
            get
            {
                if (_divIndice != null)
                {
                    return _divIndice;
                }

                _divIndice = new Div();

                return _divIndice;
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

        private List<SumarioItem> lstDivItem
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

        public SumarioItem(string dirMarkdown)
        {
            this.dirMarkdown = dirMarkdown;
        }

        #endregion Construtores

        #region Métodos

        protected override void addLayoutFixo(JavaScriptTag tagJs)
        {
            base.addLayoutFixo(tagJs);

            tagJs.addLayoutFixo(typeof(IndiceItem));
        }

        protected override void inicializar()
        {
            base.inicializar();

            this.booClazz = true;
            this.strId = (this.GetType().Name + "_" + Utils.simplificar(this.dirMarkdown));

            this.addAtt("url-markdown", ("/" + this.dirMarkdown.Replace("\\", "/")));

            this.inicializarDivTitulo();
        }

        protected override void montarLayout()
        {
            base.montarLayout();

            this.divTitulo.setPai(this);

            this.divConteudo.setPai(this);

            this.divIndice.setPai(this);

            this.lstDivItem?.ForEach((divItem) => divItem.setPai(this.divConteudo));
        }

        protected override void setCss(CssArquivoBase css)
        {
            base.setCss(css);

            this.addCss(css.setCursor("pointer"));

            this.divConteudo.addCss(css.setDisplay("none"));
            this.divConteudo.addCss(css.setPaddingLeft(10));

            this.divIndice.addCss(css.setDisplay("none"));
            this.divIndice.addCss(css.setFontStyle("italic"));
            this.divIndice.addCss(css.setMarginLeft(30));

            this.divTitulo.addCss(css.setPadding(10));
            this.divTitulo.addCss(css.setPaddingLeft(20));
        }

        protected override void setStrId(string strId)
        {
            base.setStrId(strId);

            if (string.IsNullOrEmpty(strId))
            {
                return;
            }

            this.divConteudo.strId = (strId + "_divConteudo");
            this.divIndice.strId = (strId + "_divIndice");
            this.divTitulo.strId = (strId + "_divTitulo");
        }

        private List<SumarioItem> getLstDivItem()
        {
            var dirMarkdownFolder = this.dirMarkdown?.Replace(".md", null);

            if (!Directory.Exists(dirMarkdownFolder))
            {
                return null;
            }

            var lstDivItemResultado = new List<SumarioItem>();

            foreach (string dirMarkdown in Directory.GetFiles(dirMarkdownFolder).OrderBy(dir => dir))
            {
                this.getLstDivItem(lstDivItemResultado, dirMarkdown);
            }

            return lstDivItemResultado;
        }

        private void getLstDivItem(List<SumarioItem> lstDivItem, string dirMarkdown)
        {
            if (string.IsNullOrEmpty(dirMarkdown))
            {
                return;
            }

            if (!".md".Equals(Path.GetExtension(dirMarkdown)))
            {
                return;
            }

            lstDivItem.Add(new SumarioItem(dirMarkdown));
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