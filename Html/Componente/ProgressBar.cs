using NetZ.Web.Server.Arquivo.Css;

namespace NetZ.Web.Html.Componente
{
    public class ProgressBar : ComponenteHtmlBase
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private Div _divProgresso;

        private Div divProgresso
        {
            get
            {
                if (_divProgresso != null)
                {
                    return _divProgresso;
                }

                _divProgresso = new Div();

                return _divProgresso;
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

            this.divProgresso.strId = (strId + "_divProgresso");
        }

        protected override void montarLayout()
        {
            base.montarLayout();

            this.divProgresso.setPai(this);
        }

        protected override void setCss(CssArquivoBase css)
        {
            base.setCss(css);

            this.addCss(css.setBackgroundColor(AppWebBase.i.objTema.corFundo1));
            this.addCss(css.setBorderRadius(5));
            this.addCss(css.setHeight(5));

            this.divProgresso.addCss(css.setBackgroundColor(AppWebBase.i.objTema.corTema));
            this.divProgresso.addCss(css.setBorderRadius(5));
            this.divProgresso.addCss(css.setHeight(100, "%"));
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}