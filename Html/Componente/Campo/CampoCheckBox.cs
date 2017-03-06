using NetZ.Web.Server.Arquivo.Css;

namespace NetZ.Web.Html.Componente.Campo
{
    public class CampoCheckBox : CampoHtml
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private CheckBox _ckb;

        private CheckBox ckb
        {
            get
            {
                if (_ckb != null)
                {
                    return _ckb;
                }

                _ckb = new CheckBox();

                return _ckb;
            }
        }

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        protected override void addJs(LstTag<JavaScriptTag> lstJs)
        {
            base.addJs(lstJs);

            lstJs.Add(new JavaScriptTag(typeof(CampoCheckBox), 130));
        }

        protected override Input.EnmTipo getEnmTipo()
        {
            return Input.EnmTipo.CHECKBOX;
        }

        protected override Input getTagInput()
        {
            return this.ckb;
        }

        protected override void setCss(CssArquivo css)
        {
            base.setCss(css);

            this.ckb.addCss(css.setBorderBottom(0, "solid", AppWebBase.i.objTema.corTema));
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}