using NetZ.Web.Server.Arquivo.Css;

namespace NetZ.Web.Html.Componente.Menu.Contexto
{
    public class MenuContextoItem : ComponenteHtml
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private Div _divSeta;
        private Div _divTitulo;

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

            this.strId = "_id";

            this.divTitulo.strConteudo = "_conteudo";
        }

        protected override void montarLayout()
        {
            base.montarLayout();

            this.divTitulo.setPai(this);
            this.divSeta.setPai(this);
        }

        protected override void setCss(CssArquivo css)
        {
            base.setCss(css);

            this.addCss(css.setBorderBottom(1, "solid", AppWeb.i.objTema.corBorda));
            this.addCss(css.setCursor("pointer"));
            this.addCss(css.setPadding(10));
            this.addCss(css.setPosition("relative"));

            this.divSeta.addCss(css.setHeight(100, "%"));
            this.divSeta.addCss(css.setLineHeight(35));
            this.divSeta.addCss(css.setPosition("absolute"));
            this.divSeta.addCss(css.setRight(0));
            this.divSeta.addCss(css.setTop(0));
            this.divSeta.addCss(css.setWidth(15));
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}