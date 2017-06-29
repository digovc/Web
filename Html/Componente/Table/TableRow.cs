using System;
using System.Data;
using NetZ.Persistencia;
using NetZ.Web.Server.Arquivo.Css;

namespace NetZ.Web.Html.Componente.Table
{
    internal class TableRow : ComponenteHtml
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private Atributo _attIntId;
        private DataRow _row;
        private TabelaBase _tbl;

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

        internal TabelaBase tbl
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

        internal TableRow()
        {
        }

        #endregion Construtores

        #region Métodos

        protected override void inicializar()
        {
            base.inicializar();

            this.strNome = "tr";

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

        protected override void setCss(CssArquivoBase css)
        {
            base.setCss(css);

            this.addCss(css.setHeight(TableHtml.INT_LINHA_TAMANHO));
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

            if (this.row[this.tbl.clnIntId.sqlNome] == null)
            {
                return;
            }

            if (DBNull.Value.Equals(this.row[this.tbl.clnIntId.sqlNome]))
            {
                return;
            }

            long intId = (long)this.row[this.tbl.clnIntId.sqlNome];

            if (intId < 1)
            {
                return;
            }

            this.attIntId.addValor(intId);

            strId = "tagRow___tbl_nome__registro_id";

            strId = strId.Replace("_tbl_nome", this.tbl.sqlNome);
            strId = strId.Replace("_registro_id", intId.ToString());

            this.strId = strId;
        }

        private void montarLayout(Coluna cln)
        {
            if (cln == null)
            {
                return;
            }

            new TableColumn(cln, this.row).setPai(this);
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}