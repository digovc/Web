using System;
using NetZ.Web.Server.Arquivo.Css;

namespace NetZ.Web.Html.Componente.Circulo
{
    public class DivCirculo : Div
    {
        #region Constantes

        public enum EnmTamanho
        {
            GRANDE,
            NORMAL,
            PEQUENO,
        }

        #endregion Constantes

        #region Atributos

        private EnmTamanho _enmTamanho = EnmTamanho.NORMAL;

        /// <summary>
        /// Indica o tamanho deste componente.
        /// </summary>
        public EnmTamanho enmTamanho
        {
            get
            {
                return _enmTamanho;
            }

            set
            {
                _enmTamanho = value;
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
                this.addCss(css.setBorderRadius(50, "%"));
                this.addCss(css.setOutLine("none"));

                this.setCssEnmTamanho(css);
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

        private void setCssEnmTamanho(CssArquivo css)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                switch (this.enmTamanho)
                {
                    case EnmTamanho.GRANDE:
                        this.addCss(css.setHeight(150));
                        this.addCss(css.setWidth(150));
                        return;

                    case EnmTamanho.PEQUENO:
                        this.addCss(css.setHeight(20));
                        this.addCss(css.setWidth(20));
                        return;

                    default:
                        this.addCss(css.setHeight(50));
                        this.addCss(css.setWidth(50));
                        return;
                }
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