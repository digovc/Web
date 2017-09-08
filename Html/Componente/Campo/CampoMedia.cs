using NetZ.Web.Server.Arquivo.Css;

namespace NetZ.Web.Html.Componente.Campo
{
    public abstract class CampoMedia : CampoHtmlBase
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private Div _divComando;
        private Div _divContent;

        protected Div divComando
        {
            get
            {
                if (_divComando != null)
                {
                    return _divComando;
                }

                _divComando = new Div();

                return _divComando;
            }
        }

        protected Div divContent
        {
            get
            {
                if (_divContent != null)
                {
                    return _divContent;
                }

                _divContent = new Div();

                return _divContent;
            }
        }

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        protected override void setStrId(string strId)
        {
            base.setStrId(strId);

            if (string.IsNullOrEmpty(strId))
            {
                return;
            }

            this.divContent.strId = (strId + "_divContent");
        }

        protected override void inicializar()
        {
            base.inicializar();

            this.intTamanhoVertical = 4;
        }

        protected override void montarLayout()
        {
            base.montarLayout();

            this.divContent.setPai(this);
            this.divComando.setPai(this);
        }

        protected override void setCss(CssArquivoBase css)
        {
            base.setCss(css);

            this.addCss(css.setHeight(250));
            this.addCss(css.setWidth(500));

            this.divComando.addCss(css.setBottom(8));
            this.divComando.addCss(css.setPadding(10));
            this.divComando.addCss(css.setPosition("absolute"));
            this.divComando.addCss(css.setRight(10));

            this.divContent.addCss(css.setBorder(1, "solid", AppWebBase.i.objTema.corFundoBorda));
            this.divContent.addCss(css.setHeight(210));
            this.divContent.addCss(css.setMarginTop(5));

            this.tagInput.addCss(css.setDisplay("none"));
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}