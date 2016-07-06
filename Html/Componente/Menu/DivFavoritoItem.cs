using System;
using NetZ.Web.Server.Arquivo.Css;

namespace NetZ.Web.Html.Componente.Menu
{
    public class DivFavoritoItem : ComponenteHtml
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private Imagem _imgIcone;

        private Imagem imgIcone
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_imgIcone != null)
                    {
                        return _imgIcone;
                    }

                    _imgIcone = new Imagem();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _imgIcone;
            }
        }

        #endregion Atributos

        #region Construtores

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
                this.imgIcone.src = "res/media/png/btn_favorito_novo_80x80.png";
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
                //this.imgIcone.setPai(this);
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
                //this.addCss(css.setFloat("left"));
                //this.addCss(css.setHeight(32, "%"));
                //this.addCss(css.setWidth(32, "%"));

                //this.imgIcone.addCss(css.setBorder(2, "solid", "#e7e8e9"));
                //this.imgIcone.addCss(css.setBorderRadius(50, "%"));
                //this.imgIcone.addCss(css.setCursor("pointer"));
                //this.imgIcone.addCss(css.setHeight(75, "%"));
                //this.imgIcone.addCss(css.setMargin(12.5m, "%"));
                //this.imgIcone.addCss(css.setWidth(75, "%"));
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