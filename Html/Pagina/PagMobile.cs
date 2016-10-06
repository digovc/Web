using NetZ.Web.Html.Componente;

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

                _tagMetaMobile = new Tag("meta");

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

                _tagMetaViewPort = new Tag("meta");

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

        protected override void addJsDebug(LstTag<JavaScriptTag> lstJsDebug)
        {
            base.addJsDebug(lstJsDebug);

            lstJsDebug.Add(new JavaScriptTag(typeof(PagMobile), 103));
        }

        protected override void inicializar()
        {
            base.inicializar();

            this.tagMetaMobile.addAtt("name", "mobile-web-app-capable");
            this.tagMetaMobile.addAtt("content", "yes");

            this.tagMetaMobile.booBarraFinal = false;
            this.tagMetaMobile.booDupla = false;

            this.tagMetaViewPort.addAtt("name", "viewport");
            this.tagMetaViewPort.addAtt("content", "width=device-width, initial-scale=1.0");

            this.tagMetaViewPort.booBarraFinal = false;
            this.tagMetaViewPort.booDupla = false;
        }

        protected override void montarLayout()
        {
            base.montarLayout();

            this.tagMetaMobile.setPai(this.tagHead);
            this.tagMetaViewPort.setPai(this.tagHead);
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}