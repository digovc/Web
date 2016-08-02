using NetZ.Web.Server.Arquivo.Css;

namespace NetZ.Web.Html.Componente.Campo
{
    public class CampoMapa : CampoHtml
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private Div _divMapa;

        private Div divMapa
        {
            get
            {
                if (_divMapa != null)
                {
                    return _divMapa;
                }

                _divMapa = new Div();

                return _divMapa;
            }
        }

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        protected override void addJs(LstTag<JavaScriptTag> lstJs)
        {
            base.addJs(lstJs);

            lstJs.Add(new JavaScriptTag(typeof(CampoMapa), 132));
        }

        protected override void atualizarStrId()
        {
            base.atualizarStrId();

            if (string.IsNullOrEmpty(this.strId))
            {
                return;
            }

            this.divMapa.strId = (this.strId + "_divMapa");
        }

        protected override Input.EnmTipo getEnmTipo()
        {
            return Input.EnmTipo.HIDDEN;
        }

        protected override void inicializar()
        {
            base.inicializar();

            this.intTamanhoVertical = 4;

            this.tagInput.booDisabled = true;
        }

        protected override void montarLayout()
        {
            base.montarLayout();

            this.divMapa.setPai(this);
        }

        protected override void setCss(CssArquivo css)
        {
            base.setCss(css);

            this.addCss(css.setHeight(250));
            this.addCss(css.setWidth(500));

            this.divMapa.addCss(css.setBorder(1, "solid", AppWeb.i.objTema.corFundoBorda));
            this.divMapa.addCss(css.setHeight(210));
            this.divMapa.addCss(css.setMarginTop(5));
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}