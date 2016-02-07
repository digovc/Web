using System;
using NetZ.Web.Server.Arquivo.Css;

namespace NetZ.Web.Html.Componente.Botao
{
    public class BotaoHtml : ComponenteHtml, ITagNivel
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private bool _booFrmSubmit;
        private int _intNivel;

        /// <summary>
        /// Caso este botão esteja dentro de um formulário e não deseje que acione o submit do mesmo
        /// ao ser clicado (que é a ação padrão), basta alterar essa propriedade para false.
        /// </summary>
        public bool booFrmSubmit
        {
            get
            {
                return _booFrmSubmit;
            }

            set
            {
                _booFrmSubmit = value;
            }
        }

        /// <summary>
        /// Indica em que nível este botão será apresentado no formulário.
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

        public BotaoHtml()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.strNome = "button";
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
                lstJs.Add(new JavaScriptTag(typeof(BotaoHtml), 115));
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
                this.inicializarBooFrmSubmit();
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
                this.addCss(css.setBorder(0));
                this.addCss(css.setCursor("pointer"));
                this.addCss(css.setFloat("right"));
                this.addCss(css.setHeight(30));
                this.addCss(css.setWidth(this.getDecWidth()));
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

        private decimal getDecWidth()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (string.IsNullOrEmpty(this.strConteudo))
                {
                    return 30;
                }

                if (this.strConteudo.Length < 25)
                {
                    return 100;
                }

                if (this.strConteudo.Length < 50)
                {
                    return 125;
                }

                if (this.strConteudo.Length < 75)
                {
                    return 150;
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

            return 175;
        }

        private void inicializarBooFrmSubmit()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (this.booFrmSubmit)
                {
                    return;
                }

                this.addAtt("onclick", "return false");
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