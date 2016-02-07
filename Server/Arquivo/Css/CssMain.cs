using System;

namespace NetZ.Web.Server.Arquivo.Css
{
    public class CssMain : CssArquivo
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
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_i != null)
                    {
                        return _i;
                    }

                    _i = new CssMain();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

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

            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.strHref = STR_CSS_SRC;

                this.addCssPuro("::-webkit-scrollbar-corner{background-color:rgb(239,239,239)}");
                this.addCssPuro("::-webkit-scrollbar-thumb{background-color:rgb(215, 215, 215);border:1px solid rgb(195,195,195)}");
                this.addCssPuro("::-webkit-scrollbar-track{background-color:rgb(239,239,239)}");
                this.addCssPuro("::-webkit-scrollbar{height:12px;width:12px}");
                this.addCssPuro("a{color:#428bca;text-decoration:none}");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion Ações
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}