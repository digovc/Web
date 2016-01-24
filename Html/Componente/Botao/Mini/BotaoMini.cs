using System;

namespace NetZ.Web.Html.Componente.Botao.Mini
{
    public class BotaoMini : BotaoHtml
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
                lstJs.Add(new JavaScriptTag(typeof(BotaoMini), 120));
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

        protected override void setCss(CssTag css)
        {
            //base.setCss(css);

            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.addCss(css.setBorder(0));
                this.addCss(css.setBorderRadius(50, "%"));
                this.addCss(css.setBoxShadow(0, 0, 1, 0, AppWeb.i.objTema.corSombra));
                this.addCss(css.setColor("white"));
                this.addCss(css.setCursor("pointer"));
                this.addCss(css.setFloat(EnmLado.DIREITA.Equals(this.enmLado) ? "right" : "left"));
                this.addCss(css.setFontSize(15));
                this.addCss(css.setHeight(30));
                this.addCss(css.setMarginRight(5));
                this.addCss(css.setOutLine("none"));
                this.addCss(css.setTextAlign("center"));
                this.addCss(css.setWidth(30));
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