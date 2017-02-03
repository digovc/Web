using NetZ.Web.Html.Pagina;
using NetZ.Web.Server.Arquivo.Css;
using System.Collections.Generic;
using System.IO;

namespace NetZ.Web.Html.Componente.Markdown
{
    internal class Sumario : ComponenteHtml
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private Div _divConteudo;
        private Div _divTitulo;
        private List<SumarioItem> _lstDivItem;
        private PagDocumentacaoBase _pagMarkdown;

        public PagDocumentacaoBase pagMarkdown
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

        private EmailRegistro _divEmailRegistro;

        private EmailRegistro divEmailRegistro
        {
            get
            {
                if (_divEmailRegistro != null)
                {
                    return _divEmailRegistro;
                }

                _divEmailRegistro = new EmailRegistro();

                return _divEmailRegistro;
            }
        }

        #endregion Atributos

        #region Construtores

        public Sumario(PagDocumentacaoBase pagMarkdown)
        {
            this.pagMarkdown = pagMarkdown;
        }

        #endregion Construtores

        #region Métodos

        protected override bool getBooJs()
        {
            return true;
        }

        protected override void inicializar()
        {
            base.inicializar();

            this.strId = this.GetType().Name;

            this.divTitulo.strConteudo = "Sumário";
        }

        protected override void montarLayout()
        {
            base.montarLayout();

            this.divTitulo.setPai(this);

            this.divConteudo.setPai(this);

            this.lstDivItem?.ForEach((divItem) => divItem.setPai(this.divConteudo));

            this.divEmailRegistro.setPai(this);
        }

        protected override void setCss(CssArquivo css)
        {
            base.setCss(css);

            this.addCss(css.setZIndex(2));

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

        protected override void setStrId(string strId)
        {
            base.setStrId(strId);

            this.divConteudo.strId = (strId + "_divConteudo");
        }

        private List<SumarioItem> getLstDivItem()
        {
            if (this.pagMarkdown == null)
            {
                return null;
            }

            if (!Directory.Exists(this.pagMarkdown.dirRepositorio))
            {
                return null;
            }

            var lstDivItemResultado = new List<SumarioItem>();

            foreach (string dirMarkdown in Directory.GetFiles(this.pagMarkdown.dirRepositorio))
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

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}