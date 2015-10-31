using System;
using System.Collections.Generic;
using System.Linq;
using NetZ.Web.Html.Componente.Campo;
using NetZ.Web.Html.Componente.Painel;

namespace NetZ.Web.Html.Componente.Form
{
    public class FormHtml : ComponenteHtml
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private Div _divConteudo;
        private LimiteFloat _divLimiteFloat;
        private List<CampoHtml> _lstCmp;
        private List<PainelNivel> _lstPnlNivel;

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

        private LimiteFloat divLimiteFloat
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_divLimiteFloat != null)
                    {
                        return _divLimiteFloat;
                    }

                    _divLimiteFloat = new LimiteFloat();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _divLimiteFloat;
            }
        }

        private List<CampoHtml> lstCmp
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_lstCmp != null)
                    {
                        return _lstCmp;
                    }

                    _lstCmp = new List<CampoHtml>();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _lstCmp;
            }
        }

        private List<PainelNivel> lstPnlNivel
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_lstPnlNivel != null)
                    {
                        return _lstPnlNivel;
                    }

                    _lstPnlNivel = new List<PainelNivel>();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _lstPnlNivel;
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

        protected override void addTag(Tag tag)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (tag == null)
                {
                    return;
                }

                if (!(tag is CampoHtml))
                {
                    base.addTag(tag);
                    return;
                }

                if (this.lstCmp.Contains(tag))
                {
                    return;
                }

                this.lstCmp.Add((CampoHtml)tag);
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
                this.divConteudo.setPai(this);

                this.montarLayoutLstCmp();
                this.montarLayoutLstPnlNivel();
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
                //this.divConteudo.addCss(css.setPadding(5));
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

            PainelNivel pnlNivel;

            #endregion Variáveis

            #region Ações

            try
            {
                if (cmp == null)
                {
                    return;
                }

                if (this.lstPnlNivel.Count < 1)
                {
                    pnlNivel = new PainelNivel(0);
                    pnlNivel.setPai(this.divConteudo);

                    this.lstPnlNivel.Add(pnlNivel);
                }

                if (cmp.intFrmNivel.Equals(this.lstPnlNivel[this.lstPnlNivel.Count - 1].intNivel))
                {
                    pnlNivel = this.lstPnlNivel[this.lstPnlNivel.Count - 1];
                }
                else
                {
                    pnlNivel = new PainelNivel(cmp.intFrmNivel);
                    pnlNivel.setPai(this.divConteudo);
                }

                cmp.setPai(pnlNivel);
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

        private void montarLayoutLstCmp()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                foreach (CampoHtml cmp in this.lstCmp.OrderBy((x) => x.intFrmNivel))
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

        private void montarLayoutLstPnlNivel()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                foreach (PainelNivel pnl in this.lstPnlNivel)
                {
                    if (pnl == null)
                    {
                        continue;
                    }

                    this.divLimiteFloat.setPai(pnl);
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