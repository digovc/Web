using NetZ.Web.Html.Componente.Botao;
using NetZ.Web.Server.Arquivo.Css;

namespace NetZ.Web.Html.Componente.Janela.Consulta
{
    public class BtnFavorito : BotaoCircular
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

            this.enmTamanho = EnmTamanho.PEQUENO;
        }

        protected override void setCss(CssArquivoBase css)
        {
            base.setCss(css);

            this.addCss(css.setBackgroundColor(AppWebBase.i.objTema.corTelaFundo));
            this.addCss(css.setBackgroundImage("/res/media/png/bnt_favorito_desmarcado_30x30.png"));
            this.addCss(css.setBackgroundPosition("center"));
            this.addCss(css.setBackgroundRepeat("no-repeat"));
            this.addCss(css.setBackgroundSize("20px 20px"));
            this.addCss(css.setBoxShadow(0, 0, 0, 0, null));
            this.addCss(css.setMarginLeft(5));
            this.addCss(css.setMarginRight(5));
            this.addCss(css.setMarginTop(4));
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}