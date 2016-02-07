using System;

namespace NetZ.Web.Server.Arquivo.Css
{
    public class CssPrint : CssArquivo
    {
        #region Constantes

        public const string STR_CSS_ID = "cssPrint";
        public const string STR_CSS_SRC = "/res/css/print.css";

        #endregion Constantes

        #region Atributos

        private static CssPrint _i;

        public static CssPrint i
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

                    _i = new CssPrint();
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

        private CssPrint()
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