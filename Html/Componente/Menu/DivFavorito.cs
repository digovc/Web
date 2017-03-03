using NetZ.Web.DataBase.Dominio;
using NetZ.Web.Server.Arquivo.Css;

namespace NetZ.Web.Html.Componente.Menu
{
    public class DivFavorito : ComponenteHtml
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private Div _divContainer;

        private Div divContainer
        {
            get
            {
                if (_divContainer != null)
                {
                    return _divContainer;
                }

                _divContainer = new Div();

                return _divContainer;
            }
        }

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        protected override void addJs(LstTag<JavaScriptTag> lstJsDebug)
        {
            base.addJs(lstJsDebug);

            lstJsDebug.Add(new JavaScriptTag(typeof(DivFavorito), 111));
            lstJsDebug.Add(new JavaScriptTag(typeof(DominioWebBase), 101));
            lstJsDebug.Add(new JavaScriptTag(typeof(FavoritoDominio), 102));
        }

        protected override void inicializar()
        {
            base.inicializar();

            this.strId = "divFavorito";
        }

        protected override void montarLayout()
        {
            base.montarLayout();

            this.divContainer.setPai(this);

            this.montarLayoutItem();
        }

        protected override void setCss(CssArquivo css)
        {
            base.setCss(css);

            this.addCss(css.setBottom(0));
            this.addCss(css.setLeft(0));
            this.addCss(css.setPosition("absolute"));
            this.addCss(css.setRight(0));
            this.addCss(css.setTop(0));
            this.addCss(css.setZIndex(-1));

            this.divContainer.addCss(css.setBottom(0));
            this.divContainer.addCss(css.setCenter());
            this.divContainer.addCss(css.setHeight(380));
            this.divContainer.addCss(css.setLeft(0));
            this.divContainer.addCss(css.setPosition("absolute"));
            this.divContainer.addCss(css.setRight(0));
            this.divContainer.addCss(css.setTop(0));
            this.divContainer.addCss(css.setWidth(380));
        }

        private void montarLayoutItem()
        {
            for (int i = 0; i < 9; i++)
            {
                new DivFavoritoItem(i).setPai(this.divContainer);
            }
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}