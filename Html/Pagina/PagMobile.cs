using NetZ.Web.Server.Arquivo.Css;

namespace NetZ.Web.Html.Pagina
{
    public class PagMobile : PaginaHtml
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private Tag _tagMetaMobile;
        private Tag _tagMetaViewPort;

        private Tag tagMetaMobile
        {
            get
            {
                if (_tagMetaMobile != null)
                {
                    return _tagMetaMobile;
                }

                _tagMetaMobile = this.getTagMetaMobile();

                return _tagMetaMobile;
            }
        }

        private Tag tagMetaViewPort
        {
            get
            {
                if (_tagMetaViewPort != null)
                {
                    return _tagMetaViewPort;
                }

                _tagMetaViewPort = this.getTagMetaViewPort();

                return _tagMetaViewPort;
            }
        }

        #endregion Atributos

        #region Construtores

        public PagMobile(string strNome) : base(strNome)
        {
        }

        #endregion Construtores

        #region Métodos

        protected override void addJs(LstTag<JavaScriptTag> lstJs)
        {
            base.addJs(lstJs);

            lstJs.Add(new JavaScriptTag(typeof(PagMobile), 103));
        }

        protected override void montarLayout()
        {
            base.montarLayout();

            this.tagMetaMobile.setPai(this.tagHead);
            this.tagMetaViewPort.setPai(this.tagHead);
        }

        protected override void setCss(CssArquivoBase css)
        {
            base.setCss(css);

            this.addCss(css.addCss("-webkit-tap-highlight-color", "rgba(255,255,255, 0)"));
        }

        private Tag getTagMetaMobile()
        {
            var tagMetaMobileResultado = new Tag("meta");

            tagMetaMobileResultado.booClazz = false;
            tagMetaMobileResultado.booDupla = false;

            tagMetaMobileResultado.addAtt("content", "yes");
            tagMetaMobileResultado.addAtt("name", "mobile-web-app-capable");

            return tagMetaMobileResultado;
        }

        private Tag getTagMetaViewPort()
        {
            var tagMetaViewPortResultado = new Tag("meta");

            tagMetaViewPortResultado.booClazz = false;
            tagMetaViewPortResultado.booDupla = false;

            tagMetaViewPortResultado.addAtt("name", "viewport");
            tagMetaViewPortResultado.addAtt("content", "width=device-width, initial-scale=1.0");

            return tagMetaViewPortResultado;
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}