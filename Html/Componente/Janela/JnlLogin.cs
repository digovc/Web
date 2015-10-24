using System;
using NetZ.Web.Html.Componente.Campo;
using NetZ.Web.Html.Componente.Form;

namespace NetZ.Web.Html.Componente.Janela
{
    public class JnlLogin : JnlMensagem
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private FormHtml _frmLogin;

        private FormHtml frmLogin
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_frmLogin != null)
                    {
                        return _frmLogin;
                    }

                    _frmLogin = new FormHtml();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _frmLogin;
            }
        }

        #endregion Atributos

        #region Construtores

        public JnlLogin()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.strTitulo = null;
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
                this.frmLogin.tagPai = this;

                this.frmLogin.addCampo(new CampoAlfanumerico("Login", 0));
                this.frmLogin.addCampo(new CampoAlfanumerico("Senha", 1));
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