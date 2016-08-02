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

        protected override void atualizarStrId()
        {
            base.atualizarStrId();

            if (string.IsNullOrEmpty(this.strId))
            {
                return;
            }

            this.divBarra.strId = (this.strId + "_divBarra");
            this.pnlCondicao.strId = (this.strId + "_pnlCondicao");
            this.pnlSelecao.strId = (this.strId + "_pnlSelecao");
        }

        protected override void inicializar()
        {
            base.inicializar();

            this.intTamanhoVertical = -1;
            this.strId = "pnlFiltro";

            this.divBarra.strConteudo = "=============";

            this.pnlCondicao.intTamanhoVertical = this.intTamanhoVertical;

            this.pnlSelecao.intTamanhoVertical = this.intTamanhoVertical;
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

        protected override void setCss(CssArquivo css)
        {
            base.setCss(css);

            this.addCss(css.setMinHeight(10));
            this.addCss(css.setPosition("relative"));

            this.divBarra.addCss(css.setBackgroundColor("rgb(130,202,156)"));
            this.divBarra.addCss(css.setBorderTop(1, "solid", AppWeb.i.objTema.corFundoBorda));
            this.divBarra.addCss(css.setBottom(0));
            this.divBarra.addCss(css.setColor("#4ca06a"));
            this.divBarra.addCss(css.setCursor("pointer"));
            this.divBarra.addCss(css.setHeight(10));
            this.divBarra.addCss(css.setLineHeight(10));
            this.divBarra.addCss(css.setPosition("absolute"));
            this.divBarra.addCss(css.setWidth(100, "%"));

            this.pnlCondicao.addCss(css.setLeft(210));
            this.pnlCondicao.addCss(css.setPosition("absolute"));
            this.pnlCondicao.addCss(css.setRight(0));
            
            this.pnlSelecao.addCss(css.setFloat("left"));
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}