using NetZ.Web.Server.Arquivo.Css;

namespace NetZ.Web.Html.Componente.Grid.Coluna
{
    internal abstract class DivGridColunaBase : ComponenteHtml
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        protected override void inicializar()
        {
            base.inicializar();

            this.strId = "_div_id";
        }

        protected override void setCss(CssArquivoBase css)
        {
            base.setCss(css);

            this.addCss(css.setFloat("left"));
            this.addCss(css.setOverflowX("hidden"));
            this.addCss(css.setPaddingLeft(5));
            this.addCss(css.setPaddingRight(5));
            this.addCss(css.setWhiteSpace("nowrap"));
            this.addCss(css.setWidth(150));
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}