using NetZ.Persistencia;
using NetZ.Web.Html.Componente.Grid;
using NetZ.Web.Server.Arquivo.Css;

namespace NetZ.Web.Html.Componente.Janela.Consulta
{
    public sealed class JnlConsulta : JanelaHtml
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private ComboBox _cmbStrViewNome;
        private Div _divGrid;
        private GridHtml _grdDados;
        private PainelAcaoConsulta _pnlAcaoConsulta;
        private PainelFiltro _pnlFiltro;
        private Tabela _tbl;

        private ComboBox cmbStrViewNome
        {
            get
            {
                if (_cmbStrViewNome != null)
                {
                    return _cmbStrViewNome;
                }

                _cmbStrViewNome = new ComboBox();

                return _cmbStrViewNome;
            }
        }

        private Div divGrid
        {
            get
            {
                if (_divGrid != null)
                {
                    return _divGrid;
                }

                _divGrid = new Div();

                return _divGrid;
            }
        }

        private GridHtml grdDados
        {
            get
            {
                if (_grdDados != null)
                {
                    return _grdDados;
                }

                _grdDados = new GridHtml();

                return _grdDados;
            }
        }

        private PainelAcaoConsulta pnlAcaoConsulta
        {
            get
            {
                if (_pnlAcaoConsulta != null)
                {
                    return _pnlAcaoConsulta;
                }

                _pnlAcaoConsulta = new PainelAcaoConsulta();

                return _pnlAcaoConsulta;
            }
        }

        private PainelFiltro pnlFiltro
        {
            get
            {
                if (_pnlFiltro != null)
                {
                    return _pnlFiltro;
                }

                _pnlFiltro = new PainelFiltro();

                return _pnlFiltro;
            }
        }

        private Tabela tbl
        {
            get
            {
                return _tbl;
            }

            set
            {
                if (_tbl == value)
                {
                    return;
                }

                _tbl = value;

                this.atualizarTbl();
            }
        }

        #endregion Atributos

        #region Construtores

        public JnlConsulta(Tabela tbl)
        {
            this.tbl = tbl;
        }

        #endregion Construtores

        #region Métodos

        protected override void atualizarStrId()
        {
            base.atualizarStrId();

            if (string.IsNullOrEmpty(this.strId))
            {
                return;
            }

            this.cmbStrViewNome.strId = (this.strId + "_cmbStrViewNome");
            this.divGrid.strId = (this.strId + "_divGrid");
            this.pnlAcaoConsulta.strId = (this.strId + "_pnlAcaoConsulta");
        }

        protected override void finalizarCssWidth(CssArquivo css)
        {
            //base.finalizarCssWidth(css);
        }

        protected override void inicializar()
        {
            base.inicializar();

            this.strId = "jnlConsulta";
        }

        protected override void montarLayout()
        {
            base.montarLayout();

            this.pnlFiltro.setPai(this);
            this.divGrid.setPai(this);
            this.pnlAcaoConsulta.setPai(this);

            this.montarLayoutCmbStrViewNome();
        }

        protected override void setCss(CssArquivo css)
        {
            base.setCss(css);

            this.addCss(css.setBackgroundColor(AppWeb.i.objTema.corFundo));
            this.addCss(css.setBottom(0));
            this.addCss(css.setLeft(0));
            this.addCss(css.setPosition("absolute"));
            this.addCss(css.setRight(0));
            this.addCss(css.setTop(0));

            this.divGrid.addCss(css.setBottom(0));
            this.divGrid.addCss(css.setLeft(0));
            this.divGrid.addCss(css.setOverflow("auto"));
            this.divGrid.addCss(css.setPosition("absolute"));
            this.divGrid.addCss(css.setRight(0));
            this.divGrid.addCss(css.setTop(190));

            this.pnlAcaoConsulta.addCss(css.setBottom(25));
            this.pnlAcaoConsulta.addCss(css.setDisplay("none"));
            this.pnlAcaoConsulta.addCss(css.setRight(50));

            this.setCssCmbStrViewNome(css);
        }

        private void atualizarTbl()
        {
            if (this.tbl == null)
            {
                return;
            }

            this.addAtt("tbl_web_nome", this.tbl.strNomeSql);
            this.addAtt("viw_web_nome", this.tbl.viwPrincipal.strNomeSql);

            this.atualizarTblLstViw();
        }

        private void atualizarTblLstViw()
        {
            if (this.tbl.lstViw.Count < 2)
            {
                this.strTitulo = this.tbl.strNomeExibicao;
                return;
            }

            foreach (View viw in this.tbl.lstViw)
            {
                this.atualizarTblLstViw(viw);
            }
        }

        private void atualizarTblLstViw(View viw)
        {
            if (viw == null)
            {
                return;
            }

            this.cmbStrViewNome.addOpcao((viw.intObjetoId), viw.strNomeExibicao);
        }

        private void montarLayoutCmbStrViewNome()
        {
            if (this.tbl.lstViw.Count < 2)
            {
                return;
            }

            this.cmbStrViewNome.setPai(this.divCabecalho);
        }

        private void setCssCmbStrViewNome(CssArquivo css)
        {
            if (this.tbl.lstViw.Count < 2)
            {
                return;
            }

            this.cmbStrViewNome.addCss(css.setBackgroundColor("rgba(0,0,0,0)"));
            this.cmbStrViewNome.addCss(css.setBorder(0));
            this.cmbStrViewNome.addCss(css.setHeight(100, "%"));
            this.cmbStrViewNome.addCss(css.setMinWidth(255));
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}