using System.Collections.Generic;
using NetZ.Persistencia;
using NetZ.Web.Html.Componente.Circulo;
using NetZ.Web.Server.Arquivo.Css;

namespace NetZ.Web.Html.Componente.Menu
{
    public class MenuItem : ComponenteHtml
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private bool _booFilho;
        private DivCirculo _divIcone;
        private Div _divItemConteudo;
        private Div _divTitulo;
        private List<MenuItem> _lstMni;
        private string _strTitulo;

        private Tabela _tbl;

        /// <summary>
        /// Texto que será apresentado para o usuário.
        /// </summary>
        public string strTitulo
        {
            get
            {
                return _strTitulo;
            }

            set
            {
                _strTitulo = value;
            }
        }

        public Tabela tbl
        {
            get
            {
                return _tbl;
            }

            set
            {
                _tbl = value;

                this.atualizarTbl();
            }
        }

        protected DivCirculo divIcone
        {
            get
            {
                if (_divIcone != null)
                {
                    return _divIcone;
                }

                _divIcone = new DivCirculo();

                return _divIcone;
            }
        }

        private bool booFilho
        {
            get
            {
                return _booFilho = 0.Equals(this.lstMni.Count);
            }
        }

        private Div divItemConteudo
        {
            get
            {
                if (_divItemConteudo != null)
                {
                    return _divItemConteudo;
                }

                _divItemConteudo = new Div();

                return _divItemConteudo;
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

        private List<MenuItem> lstMni
        {
            get
            {
                if (_lstMni != null)
                {
                    return _lstMni;
                }

                _lstMni = new List<MenuItem>();

                return _lstMni;
            }
        }

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        protected override void addJs(LstTag<JavaScriptTag> lstJs)
        {
            base.addJs(lstJs);

            lstJs.Add(new JavaScriptTag(typeof(MenuItem), 151));

            lstJs.Add(new JavaScriptTag("res/js/web/database/TabelaWeb.js"));
        }

        protected override void addTag(Tag tag)
        {
            if (tag == null)
            {
                return;
            }

            if (!typeof(MenuItem).IsAssignableFrom(tag.GetType()))
            {
                base.addTag(tag);
                return;
            }

            tag.setPai(this.divItemConteudo);

            this.lstMni.Add(tag as MenuItem);
        }

        protected override void atualizarStrId()
        {
            base.atualizarStrId();

            if (string.IsNullOrEmpty(this.strId))
            {
                return;
            }

            this.divIcone.strId = (this.strId + "_divIcone");
            this.divItemConteudo.strId = (this.strId + "_divItemConteudo");
            this.divTitulo.strId = (this.strId + "_divTitulo");
        }

        protected override void finalizar()
        {
            base.finalizar();

            this.divTitulo.strConteudo = this.strTitulo;
        }

        protected override void inicializar()
        {
            base.inicializar();

            this.intTabStop = 1;
        }

        protected override void montarLayout()
        {
            base.montarLayout();

            this.divIcone.setPai(this);
            this.divTitulo.setPai(this);
            this.divItemConteudo.setPai(this);
        }

        protected override void setCss(CssArquivo css)
        {
            base.setCss(css);

            this.addCss(css.setCursor("pointer"));
            this.addCss(css.setFontFamily("ubuntu"));
            this.addCss(css.setFontStyle("ligth"));
            this.addCss(css.setOutLine("none"));

            this.setCssPai(css);
            this.setCssFilho(css);

            this.divItemConteudo.addCss(css.setBackgroundColor(AppWeb.i.objTema.corTelaFundo));
            this.divItemConteudo.addCss(css.setDisplay("none"));
            this.divItemConteudo.addCss(css.setFontSize(14));
        }

        private void atualizarTbl()
        {
            if (this.tbl == null)
            {
                return;
            }

            this.strTitulo = this.tbl.strNomeExibicao;

            this.addAtt("tbl_web_nome", this.tbl.strNomeSql);
        }

        private void setCssFilho(CssArquivo css)
        {
            if (!this.booFilho)
            {
                return;
            }

            this.addCss(css.setBorder(1, "solid", AppWeb.i.objTema.corSombra));
            this.addCss(css.setBorderBottom(0, "solid", null));
            this.addCss(css.setHeight(40));
            this.addCss(css.setMinHeight(40));
            this.addCss(css.setPaddingLeft(60));

            this.divIcone.addCss(css.setDisplay("none"));

            this.divTitulo.addCss(css.setLineHeight(40));
        }

        private void setCssPai(CssArquivo css)
        {
            if (this.booFilho)
            {
                return;
            }

            this.addCss(css.setBorderTop(1, "solid", AppWeb.i.objTema.corSombra));
            this.addCss(css.setLineHeight(50));
            this.addCss(css.setMinHeight(50));

            this.divIcone.addCss(css.setBackgroundColor(AppWeb.i.objTema.corTelaFundo));
            this.divIcone.addCss(css.setBorder(1, "solid", "rgb(130,202,156)"));
            this.divIcone.addCss(css.setFloat("left"));
            this.divIcone.addCss(css.setMarginLeft(5));
            this.divIcone.addCss(css.setMarginRight(15));
            this.divIcone.addCss(css.setMarginTop(4));

            this.divTitulo.addCss(css.setLineHeight(50));
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}