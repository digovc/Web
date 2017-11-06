using NetZ.Web.Server.Arquivo.Css;

namespace NetZ.Web.Html.Componente
{
    public class Notificacao : ComponenteHtmlBase
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private Div _divOk;

        private Div divOk
        {
            get
            {
                if (_divOk != null)
                {
                    return _divOk;
                }

                _divOk = new Div();

                return _divOk;
            }
        }

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        protected override void inicializar()
        {
            base.inicializar();

            this.strConteudo = "_div_conteudo";
            this.strId = "_div_id";

            this.divOk.strConteudo = "OK";
        }

        protected override void montarLayout()
        {
            base.montarLayout();

            this.divOk.setPai(this);
        }

        protected override void setCss(CssArquivoBase css)
        {
            base.setCss(css);

            this.addCss(css.setBackgroundColor("#c5e1a5"));
            this.addCss(css.setBottom(0));
            this.addCss(css.setColor("black"));
            this.addCss(css.setDisplay("none"));
            this.addCss(css.setLeft(0));
            this.addCss(css.setPadding(10));
            this.addCss(css.setPosition("fixed"));
            this.addCss(css.setRight(0));

            this.divOk.addCss(css.setBackground("none"));
            this.divOk.addCss(css.setFloat("right"));
            this.divOk.addCss(css.setFontWeight("bold"));
            this.divOk.addCss(css.setHeight(100, "%"));
            this.divOk.addCss(css.setPaddingLeft(10));
            this.divOk.addCss(css.setPaddingRight(10));
        }

        protected override void setStrId(string strId)
        {
            base.setStrId(strId);

            this.divOk.strId = (strId + "_divOk");
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}