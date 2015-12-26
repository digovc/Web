using System;

namespace NetZ.Web.Html.Componente.Menu.Chat
{
    public class DivChatUsuario : ComponenteHtml
    {
        #region Constantes

        private const int INT_TAMANHO = 50;

        #endregion Constantes

        #region Atributos

        private Div _divUsuarioNome;
        private Imagem _imgPerfil;

        private Div divUsuarioNome
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_divUsuarioNome != null)
                    {
                        return _divUsuarioNome;
                    }

                    _divUsuarioNome = new Div();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _divUsuarioNome;
            }
        }

        private Imagem imgPerfil
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_imgPerfil != null)
                    {
                        return _imgPerfil;
                    }

                    _imgPerfil = new Imagem();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _imgPerfil;
            }
        }

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        protected override void montarLayout()
        {
            base.montarLayout();

            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.imgPerfil.setPai(this);
                this.divUsuarioNome.setPai(this);
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
            base.setCss(css);

            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.addCss(css.setHeight(INT_TAMANHO));
                this.addCss(css.setMarginTop(10));
                this.addCss(css.setPosition("relative"));

                this.divUsuarioNome.addCss(css.setBackgroundColor("#58b296"));
                this.divUsuarioNome.addCss(css.setCursor("pointer"));
                this.divUsuarioNome.addCss(css.setHeight(100, "%"));
                this.divUsuarioNome.addCss(css.setLeft(25));
                this.divUsuarioNome.addCss(css.setPosition("absolute"));
                this.divUsuarioNome.addCss(css.setRight(0));

                this.imgPerfil.addCss(css.setBackgroundColor("#009688"));
                this.imgPerfil.addCss(css.setBorderRadius(50, "%"));
                this.imgPerfil.addCss(css.setCursor("pointer"));
                this.imgPerfil.addCss(css.setHeight(INT_TAMANHO));
                this.imgPerfil.addCss(css.setPosition("absolute"));
                this.imgPerfil.addCss(css.setWidth(INT_TAMANHO));
                this.imgPerfil.addCss(css.setZIndex(1));
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