using System;
using System.Collections.Generic;
using System.Data;
using NetZ.Persistencia;
using NetZ.Web.DataBase.Tabela;
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
            strResultado = strResultado.Replace("_operador_nome", Filtro.getStrOperadorNome(Convert.ToInt32(row[TblFiltroItem.i.clnIntOperador.sqlNome])));

            return strResultado;
        }

        private Tabela getTblFiltrada()
        {
            if (AppWeb.i == null)
            {
                return null;
            }

            if (AppWeb.i.dbe == null)
            {
                return null;
            }

            if (this.intFiltroId < 1)
            {
                return null;
            }

            TblFiltro.i.recuperar(this.intFiltroId);

            return AppWeb.i.dbe[TblFiltro.i.clnStrTabelaNome.strValor];
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

            if (DBNull.Value.Equals(row[TblFiltroItem.i.clnStrColunaNome.sqlNome]))
            {
                return;
            }

            Coluna clnFiltrada = this.tblFiltrada[Convert.ToString(row[TblFiltroItem.i.clnStrColunaNome.sqlNome])];

            this.inicializarLstCmpFiltro(row, clnFiltrada);
        }

        private void inicializarLstCmpFiltro(DataRow row, Coluna clnFiltrada)
        {
            if (clnFiltrada == null)
            {
                return;
            }

            CampoHtml cmpFiltro = this.inicializarLstCmpFiltro(clnFiltrada);

            if (cmpFiltro == null)
            {
                return;
            }

            cmpFiltro.booMostrarTituloSempre = true;
            cmpFiltro.cln = clnFiltrada;
            cmpFiltro.enmTamanho = CampoHtml.EnmTamanho.GRANDE;
            cmpFiltro.strTitulo = this.getStrCampoTitulo(row, clnFiltrada);

            cmpFiltro.addAtt("enm_operador", Convert.ToInt32(row[TblFiltroItem.i.clnIntOperador.sqlNome]));
            cmpFiltro.addAtt("int_filtro_item_id", Convert.ToInt32(row[TblFiltroItem.i.clnIntId.sqlNome]));

            this.lstCmpFiltro.Add(cmpFiltro);
        }

        private CampoHtml inicializarLstCmpFiltro(Coluna clnFiltrada)
        {
            if (clnFiltrada.lstKvpOpcao.Count > 0)
            {
                return this.inicializarLstCmpFiltroOpcao(clnFiltrada);
            }

            switch (clnFiltrada.enmGrupo)
            {
                case Coluna.EnmGrupo.ALFANUMERICO:
                    return new CampoAlfanumerico();

                case Coluna.EnmGrupo.BOOLEANO:
                    return new CampoCheckBox();

                case Coluna.EnmGrupo.NUMERICO_INTEIRO:
                case Coluna.EnmGrupo.NUMERICO_PONTO_FLUTUANTE:
                    return new CampoNumerico();

                case Coluna.EnmGrupo.TEMPORAL:
                    return new CampoDataHora();

                default:
                    return null;
            }
        }

        private CampoHtml inicializarLstCmpFiltroOpcao(Coluna clnFiltrada)
        {
            CampoComboBox cmpComboBox = new CampoComboBox();

            cmpComboBox.addOpcao(clnFiltrada.lstKvpOpcao);

            return cmpComboBox;
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