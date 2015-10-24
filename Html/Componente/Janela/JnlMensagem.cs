using System;
using NetZ.Web.Html.Design;

namespace NetZ.Web.Html.Componente.Janela
{
    public class JnlMensagem : JanelaHtml
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private Imagem _imgLateral;

        private Imagem imgLateral
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_imgLateral != null)
                    {
                        return _imgLateral;
                    }

                    _imgLateral = new Imagem();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _imgLateral;
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
                this.addCss(css.setHeight(250));
                this.addCss(css.setWidth(600));

                this.imgLateral.addCss(css.setBackgroundColor("white"));
                this.imgLateral.addCss(css.setBorderRight(1, "solid", Tema.i.corBorda2Normal));
                this.imgLateral.addCss(css.setFloat("left"));
                this.imgLateral.addCss(css.setHeight(250));
                this.imgLateral.addCss(css.setPosition("relative"));
                this.imgLateral.addCss(css.setTop(-50));
                this.imgLateral.addCss(css.setWidth(200));
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

        protected override void montarLayout()
        {
            base.montarLayout();

            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.imgLateral.tagPai = this;
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