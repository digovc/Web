using System;
using System.Data;
using NetZ.Persistencia;
using NetZ.Web.Server.Arquivo.Css;

namespace NetZ.Web.Html.Componente.Grid
{
    internal class GridRow : Tag
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private Atributo _attIntId;
        private DataRow _row;
        private Tabela _tbl;

        internal DataRow row
        {
            get
            {
                return _row;
            }

            set
            {
                _row = value;
            }
        }

        internal Tabela tbl
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

        private Atributo attIntId
        {
            get
            {
                if (_attIntId != null)
                {
                    return _attIntId;
                }

                _attIntId = new Atributo("int_id", null);

                this.addAtt(_attIntId);

                return _attIntId;
            }
        }

        #endregion Atributos

        #region Construtores

        public GridRow() : base("tr")
        {
        }

        #endregion Construtores

        #region Métodos

        protected override void inicializar()
        {
            base.inicializar();

            this.inicializarIntId();
        }

        protected override void montarLayout()
        {
            base.montarLayout();

            if (this.tbl == null)
            {
                return;
            }

            if (this.row == null)
            {
                return;
            }

            foreach (Coluna cln in this.tbl.lstClnConsulta)
            {
                this.montarLayout(cln);
            }
        }

        protected override void setCss(CssArquivo css)
        {
            base.setCss(css);

            this.addCss(css.setHeight(GridHtml.INT_LINHA_TAMANHO));
        }

        private void inicializarIntId()
        {
            if (this.row == null)
            {
                return;
            }

            if (this.tbl == null)
            {
                return;
            }

            if (this.row[this.tbl.clnIntId.strNomeSql] == null)
            {
                return;
            }

            if (DBNull.Value.Equals(this.row[this.tbl.clnIntId.strNomeSql]))
            {
                return;
            }

            long intId = (long)this.row[this.tbl.clnIntId.strNomeSql];

            if (intId < 1)
            {
                return;
            }

            this.attIntId.addValor(intId);

            strId = "tagGridRow___tbl_nome__registro_id";

            strId = strId.Replace("_tbl_nome", this.tbl.strNomeSql);
            strId = strId.Replace("_registro_id", intId.ToString());

            this.strId = strId;
        }

        private void montarLayout(Coluna cln)
        {
            if (cln == null)
            {
                return;
            }

            new GridColumn(cln, this.row).setPai(this);
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}