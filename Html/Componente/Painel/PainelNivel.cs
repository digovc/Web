using System;
using NetZ.Web.Server.Arquivo.Css;

namespace NetZ.Web.Html.Componente.Painel
{
    public class PainelNivel : PainelHtml, ITagNivel
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private int _intNivel;

        /// <summary>
        /// Indica qual é o nível dentro do formulário.
        /// </summary>
        public int intNivel
        {
            get
            {
                return _intNivel;
            }

            set
            {
                _intNivel = value;
            }
        }

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        protected override void setCss(CssArquivo css)
        {
            base.setCss(css);

            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.addCss(css.setHeight(50));
                this.addCss(css.setPaddingLeft(5));
                this.addCss(css.setPaddingRight(5));
                this.addCss(css.setPosition("relative"));
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

        protected override void addJs(LstTag<JavaScriptTag> lstJs)
        {
            base.addJs(lstJs);


            #region Variáveis
            #endregion Variáveis

            #region Ações
            try
            {
                lstJs.Add(new JavaScriptTag(typeof(PainelNivel), 115));
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