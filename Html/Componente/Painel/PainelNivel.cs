using System;
using NetZ.Web.Html.Design;

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

        protected override void setCss(CssTag css)
        {
            base.setCss(css);

            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.addCss(css.setBorderBottom(1, "solid", Tema.i.corBorda1Normal));
                this.addCss(css.setHeight(50));
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