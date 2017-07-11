using System;

namespace NetZ.Web.Server.Arquivo.Css
{
    public class CssMain : CssArquivoBase
    {
        #region Constantes

        public const string STR_CSS_ID = "cssMain";
        public const string STR_CSS_SRC = "/res/css/main.css";

        #endregion Constantes

        #region Atributos

        private static CssMain _i;

        public static CssMain i
        {
            get
            {
                if (_i != null)
                {
                    return _i;
                }

                _i = new CssMain();

                return _i;
            }
        }

        #endregion Atributos

        #region Construtores

        private CssMain()
        {
        }

        #endregion Construtores

        #region Métodos

        protected override void inicializar()
        {
            base.inicializar();

            this.strHref = (STR_CSS_SRC + "?" + DateTime.Now.ToString("yyyyMMddHHmm"));

            this.addCssPuro("::-webkit-scrollbar{margin-right:15px;height:10px;width:10px;background-color:rgba(0,0,0,0.0)}");
            this.addCssPuro("::-webkit-scrollbar-button{height:5px;width:5px;background-color:rgba(0,0,0,0.0)}");
            this.addCssPuro("::-webkit-scrollbar-track{background-color:rgba(0,0,0,0.0);border-radius:5px;}");
            this.addCssPuro("::-webkit-scrollbar-thumb{background-color:rgba(80,80,80,0.5);border-radius:5px;}");
            this.addCssPuro("::-webkit-scrollbar-corner{border-radius:5px;}");
            
            this.addCssPuro("a:link{color:inherit;text-decoration:none;}");
            this.addCssPuro("a:visited{color:inherit;text-decoration:none;}");
            this.addCssPuro("a:hover{color:inherit;text-decoration:none;}");
            this.addCssPuro("a:active{color:inherit;text-decoration:none;}");
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}