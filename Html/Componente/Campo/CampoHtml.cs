using System;

namespace NetZ.Web.Html.Componente.Campo
{
    public abstract class CampoHtml : ComponenteHtml
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private Div _divObrigatorio;
        private Div _divTitulo;
        private int _intFrmNivel;
        private Input _ipt;

        /// <summary>
        /// Indica em qual nível do formulário este campo aparecerá, sendo o nível 0 (zero) o
        /// primeiro nível de cima para baixo.
        /// </summary>
        public int intFrmNivel
        {
            get
            {
                return _intFrmNivel;
            }

            set
            {
                _intFrmNivel = value;
            }
        }

        private Div divObrigatorio
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_divObrigatorio != null)
                    {
                        return _divObrigatorio;
                    }

                    _divObrigatorio = new Div();

                    _divObrigatorio.strConteudo = "*";
                    _divObrigatorio.strId = "divObrigatorio";
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _divObrigatorio;
            }
        }

        private Div divTitulo
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_divTitulo != null)
                    {
                        return _divTitulo;
                    }

                    _divTitulo = new Div();

                    _divTitulo.strConteudo = "Campo desconhecido";
                    _divTitulo.strId = "divTitulo";
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _divTitulo;
            }
        }

        private Input ipt
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_ipt != null)
                    {
                        return _ipt;
                    }

                    _ipt = new Input();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _ipt;
            }
        }

        #endregion Atributos

        #region Construtores

        /// <summary>
        /// Cria um novo campo para a inserção de dados pelo usuário.
        /// </summary>
        /// <param name="strTitulo">
        /// Título do campo que identificará visualmente o campo para o usuário.
        /// </param>
        /// <param name="intFrmNivel">
        /// Nível que o campo será mostrado na tela para o usuário. Vide <see cref="CampoHtml.intFrmNivel"/>.
        /// </param>
        public CampoHtml(string strTitulo, int intFrmNivel)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.divTitulo.strConteudo = strTitulo;
                this.intFrmNivel = intFrmNivel;
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

        protected override void montarLayout()
        {
            base.montarLayout();

            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.divTitulo.tagPai = this;
                this.ipt.tagPai = this;
                this.divObrigatorio.tagPai = this;
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
                this.addCss(css.setFloat("left"));
                this.addCss(css.setHeight(100, "%"));
                this.addCss(css.setPaddingLeft(5));
                this.addCss(css.setPaddingRight(5));

                this.divObrigatorio.addCss(css.setColor("red"));
                this.divObrigatorio.addCss(css.setFloat("left"));
                this.divObrigatorio.addCss(css.setPaddingLeft(5));
                this.divObrigatorio.addCss(css.setPaddingRight(5));

                this.divTitulo.addCss(css.setHeight(20));
                this.divTitulo.addCss(css.setLineHeight(20));

                this.ipt.addCss(css.setFloat("left"));
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