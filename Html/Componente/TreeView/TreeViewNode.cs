using NetZ.Web.Server.Arquivo.Css;

namespace NetZ.Web.Html.Componente.TreeView
{
    public class TreeViewNode : ComponenteHtml
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private Div _divCabecalho;
        private Div _divNodeContainer;
        private Div _divIcone;
        private Div _divSeta;
        private Div _divTitulo;

        private Div divCabecalho
        {
            get
            {
                if (_divCabecalho != null)
                {
                    return _divCabecalho;
                }

                _divCabecalho = new Div();

                return _divCabecalho;
            }
        }

        private Div divNodeContainer
        {
            get
            {
                if (_divNodeContainer != null)
                {
                    return _divNodeContainer;
                }

                _divNodeContainer = new Div();

                return _divNodeContainer;
            }
        }

        private Div divIcone
        {
            get
            {
                if (_divIcone != null)
                {
                    return _divIcone;
                }

                _divIcone = new Div();

                return _divIcone;
            }
        }

        private Div divSeta
        {
            get
            {
                if (_divSeta != null)
                {
                    return _divSeta;
                }

                _divSeta = new Div();

                return _divSeta;
            }
        }

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

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        protected override void inicializar()
        {
            base.inicializar();

            this.strId = "_node_id";
            this.divTitulo.strConteudo = "_node_titulo";
            this.divNodeContainer.strId = "_node_container_id";
            // TODO: Colocar o icode dinâmico.
        }
        protected override void montarLayout()
        {
            base.montarLayout();

            this.divCabecalho.setPai(this);

            this.divSeta.setPai(this.divCabecalho);
            this.divIcone.setPai(this.divCabecalho);
            this.divTitulo.setPai(this.divCabecalho);

            this.divNodeContainer.setPai(this);
        }

        protected override void setCss(CssArquivo css)
        {
            base.setCss(css);

            this.addCss(css.setCursor("pointer"));
            this.addCss(css.setPosition("relative"));

            this.divCabecalho.addCss(css.setHeight(25));

            this.divNodeContainer.addCss(css.setMarginLeft(10));

            this.divIcone.addCss(css.setBackgroundImage("/res/media/png/tree_view_icon_default.png"));
            this.divIcone.addCss(css.setHeight(25));
            this.divIcone.addCss(css.setLeft(10));
            this.divIcone.addCss(css.setPosition("absolute"));
            this.divIcone.addCss(css.setWidth(25));

            this.divSeta.addCss(css.setHeight(100, "%"));
            this.divSeta.addCss(css.setPosition("absolute"));
            this.divSeta.addCss(css.setWidth(10));

            this.divTitulo.addCss(css. setLineHeight(25));
            this.divTitulo.addCss(css.setLeft(35));
            this.divTitulo.addCss(css.setPosition("absolute"));
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}