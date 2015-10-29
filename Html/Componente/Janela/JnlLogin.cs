﻿using System;
using NetZ.Web.Html.Componente.Botao;
using NetZ.Web.Html.Componente.Campo;
using NetZ.Web.Html.Componente.Form;

namespace NetZ.Web.Html.Componente.Janela
{
    public class JnlLogin : JnlMensagem
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private BotaoAcao _btnEntrar;
        private CampoAlfanumerico _cmpLogin;
        private CampoAlfanumerico _cmpSenha;
        private FormHtml _frmLogin;

        private BotaoAcao btnEntrar
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_btnEntrar != null)
                    {
                        return _btnEntrar;
                    }

                    _btnEntrar = new BotaoAcao();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _btnEntrar;
            }
        }

        private CampoAlfanumerico cmpLogin
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_cmpLogin != null)
                    {
                        return _cmpLogin;
                    }

                    _cmpLogin = new CampoAlfanumerico("Login", 0);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _cmpLogin;
            }
        }

        private CampoAlfanumerico cmpSenha
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_cmpSenha != null)
                    {
                        return _cmpSenha;
                    }

                    _cmpSenha = new CampoAlfanumerico("Senha", 1);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _cmpSenha;
            }
        }

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

        protected override void inicializar()
        {
            base.inicializar();

            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.btnEntrar.strConteudo = "Entrar";
                this.cmpSenha.booSenha = true;
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
                this.frmLogin.tagPai = this.pnlConteudo;

                this.frmLogin.addCampo(this.cmpLogin);
                this.frmLogin.addCampo(this.cmpSenha);

                this.btnEntrar.tagPai = this.pnlComando;
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