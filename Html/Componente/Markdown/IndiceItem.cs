using NetZ.Web.Server.Arquivo.Css;

namespace NetZ.Web.Html.Componente.Markdown
{
    internal class IndiceItem : ComponenteHtml
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

            this.strConteudo = "_conteudo";
            this.strLink = "_link";
        }

        protected override void setCss(CssArquivoBase css)
        {
            base.setCss(css);

            this.addCss(css.setPadding(5));
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}