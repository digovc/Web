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

        private BtnFavorito _btnFavorito;
        private ComboBox _cmbStrViewNome;
        private Div _divGrid;
        private TableHtml _grdDados;
        private PainelAcaoConsulta _pnlAcaoConsulta;
        private PainelFiltro _pnlFiltro;
        private TabelaBase _tbl;

        private BtnFavorito btnFavorito
        {
            get
            {
                if (_btnFavorito != null)
                {
                    return _btnFavorito;
                }

                _btnFavorito = new BtnFavorito();

                return _btnFavorito;
            }
        }

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

        private TableHtml grdDados
        {
            get
            {
                if (_grdDados != null)
                {
                    return _grdDados;
                }

                _grdDados = new TableHtml();

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

        private TabelaBase tbl
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

                this.setTbl(_tbl);
            }
        }

        #endregion Atributos

        #region Construtores

        public JnlConsulta(TabelaBase tbl)
        {
            this.tbl = tbl;
        }

        #endregion Construtores

        #region Métodos

        protected override void finalizarCssWidth(CssArquivoBase css)
        {
            // base.finalizarCssWidth(css);
        }

        protected override void inicializar()
        {
            base.inicializar();

            this.strId = this.GetType().Name; // TODO: Colocar o id desta janela baseado no nome da sua tabela.
        }

        protected override void montarLayout()
        {
            this.btnFavorito.setPai(this.divCabecalho);

            base.montarLayout();

            this.pnlFiltro.setPai(this);
            this.divGrid.setPai(this);
            this.pnlAcaoConsulta.setPai(this);

            this.montarLayoutCmbStrViewNome();
        }

        protected override void setCss(CssArquivoBase css)
        {
            base.setCss(css);

            this.addCss(css.setBackgroundColor(AppWebBase.i.objTema.corFundo));
            this.addCss(css.setBottom(0));
            this.addCss(css.setLeft(0));
            this.addCss(css.setPosition("absolute"));
            this.addCss(css.setRight(0));
            this.addCss(css.setTop(0));

            this.btnFavorito.addCss(css.setFloat("left"));

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

        protected override void setStrId(string strId)
        {
            base.setStrId(strId);

            if (string.IsNullOrEmpty(strId))
            {
                return;
            }

            this.btnFavorito.strId = (strId + "_btnFavorito");
            this.cmbStrViewNome.strId = (strId + "_cmbStrViewNome");
            this.divGrid.strId = (strId + "_divGrid");
            this.pnlAcaoConsulta.strId = (strId + "_pnlAcaoConsulta");
        }

        private void montarLayoutCmbStrViewNome()
        {
            if (this.tbl.lstViw.Count < 2)
            {
                return;
            }

            this.cmbStrViewNome.setPai(this.divCabecalho);
        }

        private void setCssCmbStrViewNome(CssArquivoBase css)
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

        private void setTbl(TabelaBase tbl)
        {
            if (tbl == null)
            {
                return;
            }

            this.addAtt("tbl_web_nome", tbl.sqlNome);
            this.addAtt("viw_web_nome", tbl.viwPrincipal.sqlNome);

            this.setTblLstViw(tbl);
        }

        private void setTblLstViw(TabelaBase tbl)
        {
            if (tbl.lstViw.Count < 2)
            {
                this.strTitulo = tbl.strNomeExibicao;
                return;
            }

            foreach (ViewBase viw in tbl.lstViw)
            {
                this.setTblLstViw(viw);
            }
        }

        private void setTblLstViw(ViewBase viw)
        {
            if (viw == null)
            {
                return;
            }

            this.cmbStrViewNome.addOpcao((viw.intObjetoId), viw.strNomeExibicao);
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}