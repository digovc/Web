using System;
using System.Collections.Generic;
using System.Linq;
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
        private List<PainelNivel> _lstPnlNivel;
        private List<ITagNivel> _lstTagNivel;

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

                    _lstPnlNivel = this.getLstPnlNivel();
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

        private List<ITagNivel> lstTagNivel
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_lstTagNivel != null)
                    {
                        return _lstTagNivel;
                    }

                    _lstTagNivel = new List<ITagNivel>();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _lstTagNivel;
            }
        }

        private List<PainelNivel> getLstPnlNivel()
        {
            #region Variáveis

            List<PainelNivel> lstPnlNivelResultado;
            PainelNivel pnlNivel;

            #endregion Variáveis

            #region Ações

            try
            {
                pnlNivel = new PainelNivel();

                pnlNivel.setPai(this.divConteudo);

                lstPnlNivelResultado = new List<PainelNivel>();

                lstPnlNivelResultado.Add(pnlNivel);

                return lstPnlNivelResultado;
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

                if (!(typeof(ITagNivel).IsAssignableFrom(tag.GetType())))
                {
                    base.addTag(tag);
                    return;
                }

                if (this.lstTagNivel.Contains((ITagNivel)tag))
                {
                    return;
                }

                this.lstTagNivel.Add((ITagNivel)tag);
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

        protected override void finalizar()
        {
            base.finalizar();

            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.finalizarMontarLayoutLstCmp();
                this.finalizarMontarLayoutLstPnlNivel();
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

        private void finalizarMontarLayoutLstCmp()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                foreach (ITagNivel tag in this.lstTagNivel.OrderBy((x) => x.intNivel))
                {
                    this.montarLayoutItem(tag);
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

        private void finalizarMontarLayoutLstPnlNivel()
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

        private void montarLayoutItem(ITagNivel tag)
        {
            #region Variáveis

            PainelNivel pnlNivel;

            #endregion Variáveis

            #region Ações

            try
            {
                if (tag == null)
                {
                    return;
                }

                if (!(typeof(Tag).IsAssignableFrom(tag.GetType())))
                {
                    return;
                }

                pnlNivel = this.lstPnlNivel.Last();

                if (tag.intNivel > pnlNivel.intNivel)
                {
                    pnlNivel = new PainelNivel();

                    pnlNivel.intNivel = tag.intNivel;
                    pnlNivel.setPai(this.divConteudo);

                    this.lstPnlNivel.Add(pnlNivel);
                }

                (tag as Tag).setPai(pnlNivel);
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