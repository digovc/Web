using NetZ.Web.Server.Arquivo.Css;

namespace NetZ.Web.Html.Componente.Menu
{
    public class DivFavoritoItem : ComponenteHtml
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private Div _divTitulo;
        private Imagem _imgIcone;

        private Div divTitulo
        {
            get
            {
                if (_divTitulo != null)
                {
                    return _divTitulo;
                }

                _divTitulo = new Div();

                return _divTitulo;
            }
        }

        private Imagem imgIcone
        {
            get
            {
                if (_imgIcone != null)
                {
                    return _imgIcone;
                }

                _imgIcone = new Imagem();

                return _imgIcone;
            }
        }

        #endregion Atributos

        #region Construtores

        public DivFavoritoItem(int intIndex)
        {
            this.strId = string.Format("divFavoritoItem_{0}", intIndex);
        }

        #endregion Construtores

        #region Métodos

        protected override void setStrId(string strId)
        {
            base.setStrId(strId);

            if (string.IsNullOrEmpty(strId))
            {
                return;
            }

            this.divTitulo.strId = (strId + "_divTitulo");
            this.imgIcone.strId = (strId + "_imgIcone");
        }

        protected override void inicializar()
        {
            base.inicializar();

            this.imgIcone.src = "/res/media/png/btn_favorito_novo_80x80.png";
        }

        protected override void montarLayout()
        {
            base.montarLayout();

            this.imgIcone.setPai(this);

            this.divTitulo.setPai(this);
        }

        protected override void setCss(CssArquivoBase css)
        {
            base.setCss(css);

            this.addCss(css.setFloat("left"));
            this.addCss(css.setHeight(32, "%"));
            this.addCss(css.setPosition("relative"));
            this.addCss(css.setWidth(32, "%"));

            this.divTitulo.addCss(css.setBottom(0));
            this.divTitulo.addCss(css.setColor(AppWebBase.i.objTema.corTelaFundo));
            this.divTitulo.addCss(css.setCursor("pointer"));
            this.divTitulo.addCss(css.setLeft(0));
            this.divTitulo.addCss(css.setPosition("absolute"));
            this.divTitulo.addCss(css.setRight(0));
            this.divTitulo.addCss(css.setTextAlign("center"));

            this.imgIcone.addCss(css.setCursor("pointer"));
            this.imgIcone.addCss(css.setHeight(75, "%"));
            this.imgIcone.addCss(css.setMargin(12.5m, "%"));
            this.imgIcone.addCss(css.setWidth(75, "%"));
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}