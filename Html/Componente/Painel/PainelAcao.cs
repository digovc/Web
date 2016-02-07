using System;
using System.Collections.Generic;
using NetZ.Web.Html.Componente.Botao;
using NetZ.Web.Html.Componente.Botao.Mini;
using NetZ.Web.Server.Arquivo.Css;

namespace NetZ.Web.Html.Componente.Painel
{
    public class PainelAcao : Div
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private BotaoCircular _btnAcaoPrincipal;
        private int _intBtnMiniTop = -45;
        private List<BotaoMini> _lstBtnMini;

        private BotaoCircular btnAcaoPrincipal
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_btnAcaoPrincipal != null)
                    {
                        return _btnAcaoPrincipal;
                    }

                    _btnAcaoPrincipal = new BotaoCircular();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _btnAcaoPrincipal;
            }
        }

        private int intBtnMiniTop
        {
            get
            {
                return _intBtnMiniTop;
            }

            set
            {
                _intBtnMiniTop = value;
            }
        }

        private List<BotaoMini> lstBtnMini
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_lstBtnMini != null)
                    {
                        return _lstBtnMini;
                    }

                    _lstBtnMini = new List<BotaoMini>();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _lstBtnMini;
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
                lstJs.Add(new JavaScriptTag(typeof(PainelAcao), 120));
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

        protected override void addTag(Tag tag)
        {
            base.addTag(tag);

            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (!(tag is BotaoMini))
                {
                    return;
                }

                this.addBtnMini(tag as BotaoMini);
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
                this.btnAcaoPrincipal.strId = "btnAcaoPrincipal";
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
                this.btnAcaoPrincipal.setPai(this);
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
                this.addCss(css.setPosition("absolute"));

                this.setCssLstBtnMini(css);
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

        private void addBtnMini(BotaoMini btnMini)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (btnMini == null)
                {
                    return;
                }

                if (this.lstBtnMini.Contains(btnMini))
                {
                    return;
                }

                this.lstBtnMini.Add(btnMini);
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

        private void setCss(CssArquivo css, BotaoMini btnMini)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (btnMini == null)
                {
                    return;
                }

                btnMini.addCss(css.setPosition("absolute"));
                btnMini.addCss(css.setRight(20));
                btnMini.addCss(css.setTop(this.intBtnMiniTop));

                this.intBtnMiniTop -= 40;
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

        private void setCssLstBtnMini(CssArquivo css)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                foreach (BotaoMini btnMini in this.lstBtnMini)
                {
                    this.setCss(css, btnMini);
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
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}