using NetZ.Web.Html.Componente.Painel;
using NetZ.Web.Server.Arquivo.Css;

namespace NetZ.Web.Html.Componente.Janela
{
    public class JnlMensagem : JanelaHtml
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private Imagem _imgLateral;
        private PainelNivel _pnlComando;
        private PainelHtml _pnlConteudo;

        protected PainelNivel pnlComando
        {
            get
            {
                if (_pnlComando != null)
                {
                    return _pnlComando;
                }

                _pnlComando = new PainelNivel();

                return _pnlComando;
            }
        }

        protected PainelHtml pnlConteudo
        {
            get
            {
                if (_pnlConteudo != null)
                {
                    return _pnlConteudo;
                }

                _pnlConteudo = new PainelHtml();

                return _pnlConteudo;
            }
        }

        private Imagem imgLateral
        {
            get
            {
                if (_imgLateral != null)
                {
                    return _imgLateral;
                }

                _imgLateral = new Imagem();

                return _imgLateral;
            }
        }

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        protected override void inicializar()
        {
            base.inicializar();

            this.pnlConteudo.intTamanhoVertical = 2;
        }

        protected override void montarLayout()
        {
            base.montarLayout();

            this.imgLateral.setPai(this);
            this.pnlConteudo.setPai(this);
            this.pnlComando.setPai(this);
        }

        protected override void setCss(CssArquivo css)
        {
            base.setCss(css);

            this.addCss(css.setHeight(250));
            this.addCss(css.setWidth(600));

            this.imgLateral.addCss(css.setBackgroundColor("white"));
            this.imgLateral.addCss(css.setBorderRight(1, "solid", AppWebBase.i.objTema.corBorda));
            this.imgLateral.addCss(css.setFloat("left"));
            this.imgLateral.addCss(css.setHeight(250));
            this.imgLateral.addCss(css.setPosition("relative"));
            this.imgLateral.addCss(css.setTop(-50));
            this.imgLateral.addCss(css.setWidth(200));
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}