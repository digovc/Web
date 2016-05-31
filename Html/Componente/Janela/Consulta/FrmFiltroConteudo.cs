using System;
using System.Collections.Generic;
using System.Data;
using NetZ.Persistencia;
using NetZ.Web.DataBase;
using NetZ.Web.Html.Componente.Campo;
using NetZ.Web.Html.Componente.Form;

namespace NetZ.Web.Html.Componente.Janela.Consulta
{
    public class FrmFiltroConteudo : FormHtml
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private int _intFiltroId;
        private List<CampoHtml> _lstCmpFiltro;
        private Tabela _tblFiltrada;

        public int intFiltroId
        {
            get
            {
                return _intFiltroId;
            }

            set
            {
                _intFiltroId = value;
            }
        }

        private List<CampoHtml> lstCmpFiltro
        {
            get
            {
                if (_lstCmpFiltro != null)
                {
                    return _lstCmpFiltro;
                }

                _lstCmpFiltro = new List<CampoHtml>();

                return _lstCmpFiltro;
            }
        }

        private Tabela tblFiltrada
        {
            get
            {
                if (_tblFiltrada != null)
                {
                    return _tblFiltrada;
                }

                _tblFiltrada = this.getTblFiltrada();

                return _tblFiltrada;
            }
        }

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        protected override void inicializar()
        {
            base.inicializar();

            this.strId = "frmFiltroConteudo";

            this.inicializarLstCmpFiltro();
        }

        protected override void montarLayout()
        {
            base.montarLayout();

            this.montarLayoutLstCmpFiltro();
        }

        private string getStrCampoTitulo(DataRow row, Coluna clnFiltrada)
        {
            string strResultado = "_cln_filtrada_nome (_operador_nome)";

            strResultado = strResultado.Replace("_cln_filtrada_nome", clnFiltrada.strNomeExibicao);
            strResultado = strResultado.Replace("_operador_nome", Filtro.getStrOperadorNome(Convert.ToInt32(row[TblFiltroItem.i.clnIntOperador.strNomeSql])));

            return strResultado;
        }

        private Tabela getTblFiltrada()
        {
            if (this.intFiltroId < 1)
            {
                return null;
            }

            TblFiltro.i.recuperar(this.intFiltroId);

            return AppWeb.i.getTbl(TblFiltro.i.clnStrTabelaNome.strValor);
        }

        private void inicializarLstCmpFiltro()
        {
            if (this.intFiltroId < 1)
            {
                return;
            }

            if (this.tblFiltrada == null)
            {
                return;
            }

            DataTable tblFiltroItemData = TblFiltroItem.i.pesquisar(TblFiltroItem.i.clnIntFiltroId, this.intFiltroId);

            if (tblFiltroItemData == null)
            {
                return;
            }

            if (tblFiltroItemData.Rows.Count < 1)
            {
                return;
            }

            foreach (DataRow row in tblFiltroItemData.Rows)
            {
                this.inicializarLstCmpFiltro(row);
            }
        }

        private void inicializarLstCmpFiltro(DataRow row)
        {
            if (row == null)
            {
                return;
            }

            if (DBNull.Value.Equals(row[TblFiltroItem.i.clnStrColunaNome.strNomeSql]))
            {
                return;
            }

            Coluna clnFiltrada = this.tblFiltrada[Convert.ToString(row[TblFiltroItem.i.clnStrColunaNome.strNomeSql])];

            this.inicializarLstCmpFiltro(row, clnFiltrada);
        }

        private void inicializarLstCmpFiltro(DataRow row, Coluna clnFiltrada)
        {
            if (clnFiltrada == null)
            {
                return;
            }

            CampoHtml cmpFiltro = this.inicializarLstCmpFiltro2(row, clnFiltrada);

            if (cmpFiltro == null)
            {
                return;
            }

            cmpFiltro.booMostrarTituloSempre = true;
            cmpFiltro.cln = clnFiltrada;
            cmpFiltro.enmTamanho = CampoHtml.EnmTamanho.GRANDE;
            cmpFiltro.strTitulo = this.getStrCampoTitulo(row, clnFiltrada);

            cmpFiltro.addAtt("enm_operador", Convert.ToInt32(row[TblFiltroItem.i.clnIntOperador.strNomeSql]));
            cmpFiltro.addAtt("int_filtro_item_id", Convert.ToInt32(row[TblFiltroItem.i.clnIntId.strNomeSql]));

            this.lstCmpFiltro.Add(cmpFiltro);
        }

        private CampoHtml inicializarLstCmpFiltro2(DataRow row, Coluna clnFiltrada)
        {
            switch (clnFiltrada.enmTipo)
            {
                case Coluna.EnmTipo.BIGINT:
                case Coluna.EnmTipo.BIGSERIAL:
                case Coluna.EnmTipo.BYTEA:
                case Coluna.EnmTipo.INTEGER:
                case Coluna.EnmTipo.SERIAL:
                case Coluna.EnmTipo.SMALLINT:
                    return new CampoNumerico();

                case Coluna.EnmTipo.BLOB:
                    return null;

                case Coluna.EnmTipo.BOOLEAN:
                case Coluna.EnmTipo.BOOLEAN_ANTIGO:
                    return null;

                case Coluna.EnmTipo.CHAR:
                case Coluna.EnmTipo.TEXT:
                case Coluna.EnmTipo.VARCHAR:
                    return new CampoAlfanumerico();

                case Coluna.EnmTipo.DATE:
                    return null;

                case Coluna.EnmTipo.DECIMAL:
                case Coluna.EnmTipo.DOUBLE:
                case Coluna.EnmTipo.FLOAT:
                case Coluna.EnmTipo.MONEY:
                case Coluna.EnmTipo.NUMERIC:
                    return new CampoNumerico();

                case Coluna.EnmTipo.INET:
                    return null;

                case Coluna.EnmTipo.TIME:
                    return null;

                case Coluna.EnmTipo.TIMESTAMP:
                    return null;

                case Coluna.EnmTipo.XML:
                    return null;

                default:
                    return null;
            }
        }

        private void montarLayoutLstCmpFiltro()
        {
            if (this.lstCmpFiltro == null)
            {
                return;
            }

            foreach (CampoHtml cmpFiltro in this.lstCmpFiltro)
            {
                cmpFiltro.setPai(this);
            }
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}