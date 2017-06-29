using NetZ.Persistencia;
using NetZ.Web.Server.Arquivo.Css;
using System.Data;

namespace NetZ.Web.Html.Componente.Table
{
    public class TableHtml : ComponenteHtml
    {
        #region Constantes

        internal const decimal INT_LINHA_TAMANHO = 35;

        #endregion Constantes

        #region Atributos

        private Tag _tagTable;
        private Tag _tagTbody;
        private Tag _tagTfoot;
        private Tag _tagThead;
        private Tag _tagTrHead;
        private TabelaBase _tbl;
        private DataTable _tblData;

        /// <summary>
        /// Tabela que este componente irá representar.
        /// </summary>
        public TabelaBase tbl
        {
            get
            {
                return _tbl;
            }

            set
            {
                _tbl = value;
            }
        }

        /// <summary>
        /// DataTable com os dados que serão mostrados neste componente.
        /// </summary>
        public DataTable tblData
        {
            get
            {
                return _tblData;
            }

            set
            {
                _tblData = value;
            }
        }

        private Tag tagTable
        {
            get
            {
                if (_tagTable != null)
                {
                    return _tagTable;
                }

                _tagTable = new Tag("table");

                return _tagTable;
            }
        }

        private Tag tagTbody
        {
            get
            {
                if (_tagTbody != null)
                {
                    return _tagTbody;
                }

                _tagTbody = new Tag("tbody");

                return _tagTbody;
            }
        }

        private Tag tagTfoot
        {
            get
            {
                if (_tagTfoot != null)
                {
                    return _tagTfoot;
                }

                _tagTfoot = new Tag("tfoot");

                return _tagTfoot;
            }
        }

        private Tag tagThead
        {
            get
            {
                if (_tagThead != null)
                {
                    return _tagThead;
                }

                _tagThead = new Tag("thead");

                return _tagThead;
            }
        }

        private Tag tagTrHead
        {
            get
            {
                if (_tagTrHead != null)
                {
                    return _tagTrHead;
                }

                _tagTrHead = new Tag("tr");

                return _tagTrHead;
            }
        }

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        protected override void inicializar()
        {
            base.inicializar();

            if (this.tbl == null)
            {
                return;
            }

            this.booClazz = true;
            this.strId = ("tagTableHtml_" + this.tbl.sqlNome);

            this.addAtt("tbl_web_nome", this.tbl.sqlNome);
            this.addAtt("tbl_web_principal_nome", this.tbl.tblPrincipal.sqlNome);
        }

        protected override void montarLayout()
        {
            base.montarLayout();

            this.tagTable.setPai(this);
            this.tagThead.setPai(this.tagTable);
            this.tagTrHead.setPai(this.tagThead);
            this.tagTbody.setPai(this.tagTable);
            this.tagTfoot.setPai(this.tagTable);

            this.montarLayoutHead();
            this.montarLayoutTbody();
        }

        protected override void setCss(CssArquivoBase css)
        {
            base.setCss(css);

            this.tagTable.addCss(css.addCss("border-spacing", "0"));
            this.tagTable.addCss(css.setBackgroundColor(AppWebBase.i.objTema.corFundo));
            this.tagTable.addCss(css.setBorderBottom(1, "solid", AppWebBase.i.objTema.corFundoBorda));
            this.tagTable.addCss(css.setCenter());
            this.tagTable.addCss(css.setWhiteSpace("nowrap"));

            this.tagTrHead.addCss(css.setHeight(INT_LINHA_TAMANHO));
        }

        protected override void setStrId(string strId)
        {
            base.setStrId(strId);

            if (string.IsNullOrEmpty(strId))
            {
                return;
            }

            this.tagTable.strId = (strId + "_table");
            this.tagTbody.strId = (strId + "_tbody");
        }

        private void montarLayoutHead()
        {
            if (this.tbl == null)
            {
                return;
            }

            foreach (Coluna cln in this.tbl.lstClnConsulta)
            {
                this.montarLayoutHead(cln);
            }
        }

        private void montarLayoutHead(Coluna cln)
        {
            if (cln == null)
            {
                return;
            }

            new TableHead(cln).setPai(this.tagTrHead);
        }

        private void montarLayoutTbody()
        {
            if (this.tbl == null)
            {
                return;
            }

            if (this.tblData == null)
            {
                return;
            }

            foreach (DataRow row in this.tblData.Rows)
            {
                this.montarLayoutTbody(row);
            }
        }

        private void montarLayoutTbody(DataRow row)
        {
            if (row == null)
            {
                return;
            }

            var tagTable = new TableRow();

            tagTable.row = row;
            tagTable.tbl = tbl;

            tagTable.setPai(this.tagTbody);
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}