using System;
using NetZ.Web.Html.Componente.Botao.Comando;
using NetZ.Web.Html.Componente.Botao.Mini;
using NetZ.Web.Html.Componente.Painel;

namespace NetZ.Web.Html.Componente.Form
{
    public class DivComando : PainelNivel
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private BotaoDireitaMini _btnDireita;
        private BotaoEsquerdaMini _btnEsquerda;
        private BotaoNovoComando _btnNovo;
        private BotaoSalvarComando _btnSalvar;

        private BotaoDireitaMini btnDireita
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_btnDireita != null)
                    {
                        return _btnDireita;
                    }

                    _btnDireita = new BotaoDireitaMini();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _btnDireita;
            }
        }

        private BotaoEsquerdaMini btnEsquerda
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_btnEsquerda != null)
                    {
                        return _btnEsquerda;
                    }

                    _btnEsquerda = new BotaoEsquerdaMini();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _btnEsquerda;
            }
        }

        private BotaoNovoComando btnNovo
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_btnNovo != null)
                    {
                        return _btnNovo;
                    }

                    _btnNovo = new BotaoNovoComando();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _btnNovo;
            }
        }

        private BotaoSalvarComando btnSalvar
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_btnSalvar != null)
                    {
                        return _btnSalvar;
                    }

                    _btnSalvar = new BotaoSalvarComando();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _btnSalvar;
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
                this.btnEsquerda.setPai(this);
                this.btnDireita.setPai(this);
                this.btnNovo.setPai(this);
                this.btnSalvar.setPai(this);
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
                this.addCss(css.setPaddingLeft(10));
                this.addCss(css.setPaddingRight(10));
                this.addCss(css.setPaddingTop(10));
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