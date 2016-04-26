using NetZ.Web.Html.Componente.Painel;
using NetZ.Web.Server.Arquivo.Css;

namespace NetZ.Web.Html.Componente.Janela.Consulta
{
    public class PainelFiltro : PainelHtml
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private FrmFiltro _frmFiltro;
        private PainelHtml _pnlCondicao;
        private PainelHtml _pnlSelecao;

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

            this.pnlCondicao.strId = (this.strId + "_pnlCondicao");
            this.pnlSelecao.strId = (this.strId + "_pnlSelecao");
        }

        protected override void inicializar()
        {
            base.inicializar();

            this.intTamanhoVertical = 2;
            this.strId = "pnlFiltro";

            this.pnlCondicao.intTamanhoVertical = this.intTamanhoVertical;

            this.pnlSelecao.intTamanhoVertical = this.intTamanhoVertical;
        }

        protected override void montarLayout()
        {
            base.montarLayout();

            this.pnlSelecao.setPai(this);
            this.frmFiltro.setPai(this.pnlSelecao);
            this.pnlCondicao.setPai(this);
        }

        protected override void setCss(CssArquivo css)
        {
            base.setCss(css);

            this.addCss(css.setPosition("relative"));

            this.pnlCondicao.addCss(css.setLeft(270));
            this.pnlCondicao.addCss(css.setPosition("absolute"));
            this.pnlCondicao.addCss(css.setRight(0));

            this.pnlSelecao.addCss(css.setBorderRight(1, "solid", AppWeb.i.objTema.corBorda));
            this.pnlSelecao.addCss(css.setFloat("left"));
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}