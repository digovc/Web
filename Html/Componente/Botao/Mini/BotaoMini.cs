using System;
using NetZ.Web.Server.Arquivo.Css;

namespace NetZ.Web.Html.Componente.Botao.Mini
{
    public class BotaoMini : BotaoCircular
    {
        #region Constantes

        public enum EnmLado
        {
            DIREITA,
            ESQUERDA,
        }

        #endregion Constantes

        #region Atributos

        private EnmLado _enmLado = EnmLado.DIREITA;

        /// <summary>
        /// Indica o lado que que este componente estará dentro do seu container.
        /// </summary>
        public EnmLado enmLado
        {
            get
            {
                return _enmLado;
            }

            set
            {
                _enmLado = value;
            }
        }

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        protected override void addJs(LstTag<JavaScriptTag> lstJs)
        {
            base.addJs(lstJs);

            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                lstJs.Add(new JavaScriptTag(typeof(BotaoMini), 117));
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

        protected override int getIntTamanho()
        {
            return 30;
        }

        protected override void inicializar()
        {
            base.inicializar();

            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.strConteudo = "?";
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

        protected override void setCss(CssArquivo css)
        {
            base.setCss(css);

            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.addCss(css.setFloat(EnmLado.DIREITA.Equals(this.enmLado) ? "right" : "left"));
                this.addCss(css.setFontSize(15));
                this.addCss(css.setHeight(this.getIntTamanho()));
                this.addCss(css.setTextAlign("center"));
                this.addCss(css.setWidth(this.getIntTamanho()));
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