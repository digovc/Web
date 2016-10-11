using NetZ.Web.Server.Arquivo.Css;

namespace NetZ.Web.Html.Componente.Menu.Contexto
{
    public class MenuContextoItem : ComponenteHtml
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private Div _divTitulo;

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
        }

        protected override void setCss(CssArquivo css)
        {
            base.setCss(css);

            this.addCss(css.setBorderBottom(1, "solid", AppWebBase.i.objTema.corSombra));
            this.addCss(css.setColor("white"));
            this.addCss(css.setCursor("pointer"));
            this.addCss(css.setPadding(10));
            this.addCss(css.setPosition("relative"));
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}