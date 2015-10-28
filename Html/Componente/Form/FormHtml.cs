using System;
using System.Collections.Generic;
using System.Linq;
using NetZ.Web.Html.Componente.Campo;

namespace NetZ.Web.Html.Componente.Form
{
    public class FormHtml : ComponenteHtml
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private Div _divConteudo;
        private List<CampoHtml> _lstDivCampo;
        private List<ComponenteNivel> _lstDivNivel;

        private Div divConteudo
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_divConteudo != null)
                    {
                        return _divConteudo;
                    }

                    _divConteudo = new Div();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _divConteudo;
            }
        }

        private List<CampoHtml> lstDivCampo
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_lstDivCampo != null)
                    {
                        return _lstDivCampo;
                    }

                    _lstDivCampo = new List<CampoHtml>();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _lstDivCampo;
            }
        }

        private List<ComponenteNivel> lstDivNivel
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_lstDivNivel != null)
                    {
                        return _lstDivNivel;
                    }

                    _lstDivNivel = new List<ComponenteNivel>();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _lstDivNivel;
            }
        }

        #endregion Atributos

        #region Construtores

        public FormHtml()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.strNome = "form";
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

        /// <summary>
        /// Adiciona um novo campo para o formulário.
        /// </summary>
        public void addCampo(CampoHtml divCampo)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (divCampo == null)
                {
                    return;
                }

                if (this.lstDivCampo.Contains(divCampo))
                {
                    return;
                }

                this.lstDivCampo.Add(divCampo);
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
                this.divConteudo.strId = "divConteudo";
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
                this.divConteudo.tagPai = this;

                this.montarLayoutItem();
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
                this.divConteudo.addCss(css.setPadding(5));
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

        private void montarLayoutItem()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                foreach (CampoHtml cmp in this.lstDivCampo.OrderBy((x) => x.intFrmNivel))
                {
                    this.montarLayoutItem(cmp);
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

        private void montarLayoutItem(CampoHtml cmp)
        {
            #region Variáveis

            ComponenteNivel divNivel;

            #endregion Variáveis

            #region Ações

            try
            {
                if (cmp == null)
                {
                    return;
                }

                if (this.lstDivNivel.Count < 1)
                {
                    divNivel = new ComponenteNivel(0);
                    divNivel.tagPai = this.divConteudo;

                    this.lstDivNivel.Add(divNivel);
                }

                if (cmp.intFrmNivel.Equals(this.lstDivNivel[this.lstDivNivel.Count - 1].intNivel))
                {
                    divNivel = this.lstDivNivel[this.lstDivNivel.Count - 1];
                }
                else
                {
                    divNivel = new ComponenteNivel(cmp.intFrmNivel);
                    divNivel.tagPai = this.divConteudo;
                }

                cmp.tagPai = divNivel;
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