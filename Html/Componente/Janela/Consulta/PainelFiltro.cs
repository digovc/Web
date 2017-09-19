using NetZ.Web.Html.Componente.Painel;
using NetZ.Web.Server.Arquivo.Css;

namespace NetZ.Web.Html.Componente.Janela.Consulta
{
    public class PainelFiltro : PainelHtml
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private Div _divBarra;
        private FrmFiltro _frmFiltro;
        private PainelHtml _pnlCondicao;
        private PainelHtml _pnlSelecao;

        private Div divBarra
        {
            get
            {
                if (_divBarra != null)
                {
                    return _divBarra;
                }

                _divBarra = new Div();

                return _divBarra;
            }
        }

        private FrmFiltro frmFiltro
        {
            get
            {
                if (_frmFiltro != null)
                {
                    return _frmFiltro;
                }

                _frmFiltro = new FrmFiltro();

                return _frmFiltro;
            }
        }

        private PainelHtml pnlCondicao
        {
            get
            {
                if (_pnlCondicao != null)
                {
                    return _pnlCondicao;
                }

                _pnlCondicao = new PainelHtml();

                return _pnlCondicao;
            }
        }

        private PainelHtml pnlSelecao
        {
            get
            {
                if (_pnlSelecao != null)
                {
                    return _pnlSelecao;
                }

                _pnlSelecao = new PainelHtml();

                return _pnlSelecao;
            }
        }

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        protected override void setStrId(string strId)
        {
            base.setStrId(strId);

            if (string.IsNullOrEmpty(strId))
            {
                return;
            }

            this.divBarra.strId = (strId + "_divBarra");
            this.pnlCondicao.strId = (strId + "_pnlCondicao");
            this.pnlSelecao.strId = (strId + "_pnlSelecao");
        }

        protected override void inicializar()
        {
            base.inicializar();

            this.strId = "pnlFiltro";
        }

        protected override void montarLayout()
        {
            base.montarLayout();

            this.pnlSelecao.setPai(this);
            this.frmFiltro.setPai(this.pnlSelecao);
            this.pnlCondicao.setPai(this);
            this.divBarra.setPai(this);

            new LimiteFloat().setPai(this);
        }

        protected override void setCss(CssArquivoBase css)
        {
            base.setCss(css);

            this.addCss(css.setMinHeight(10));
            this.addCss(css.setPosition("relative"));

            this.divBarra.addCss(css.setBackgroundColor(AppWebBase.i.objTema.corTema));
            this.divBarra.addCss(css.setBackgroundImage("/res/media/png/btn_ocultar_filtro_40x40.png"));
            this.divBarra.addCss(css.setBackgroundPosition("center"));
            this.divBarra.addCss(css.setBackgroundRepeat("no-repeat"));
            this.divBarra.addCss(css.setBackgroundSize("contain"));
            this.divBarra.addCss(css.setBottom(0));
            this.divBarra.addCss(css.setCursor("pointer"));
            this.divBarra.addCss(css.setHeight(10));
            this.divBarra.addCss(css.setLineHeight(10));
            this.divBarra.addCss(css.setPosition("absolute"));
            this.divBarra.addCss(css.setWidth(100, "%"));

            this.pnlCondicao.addCss(css.setLeft(220));
            this.pnlCondicao.addCss(css.setPosition("absolute"));
            this.pnlCondicao.addCss(css.setRight(0));

            this.pnlSelecao.addCss(css.setFloat("left"));
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}