﻿using System;
using NetZ.Persistencia;
using NetZ.Web.Html.Componente.Campo;
using NetZ.Web.Html.Componente.Form;

namespace NetZ.Web.Html.Componente.Janela
{
    public abstract class JnlCadastro : JanelaHtml
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private CampoNumerico _cmpIntId;
        private DivComando _divComando;
        private FormHtml _frm;
        private Tabela _tbl;

        protected FormHtml frm
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_frm != null)
                    {
                        return _frm;
                    }

                    _frm = new FormHtml();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _frm;
            }
        }

        private CampoNumerico cmpIntId
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_cmpIntId != null)
                    {
                        return _cmpIntId;
                    }

                    _cmpIntId = new CampoNumerico();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _cmpIntId;
            }
        }

        private DivComando divComando
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_divComando != null)
                    {
                        return _divComando;
                    }

                    _divComando = new DivComando();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _divComando;
            }
        }

        /// <summary>
        /// Tabela que esta janela de cadastro representa.
        /// </summary>
        private Tabela tbl
        {
            get
            {
                return _tbl;
            }

            set
            {
                _tbl = value;
            }
        }

        #endregion Atributos

        #region Construtores

        public JnlCadastro(Tabela tbl)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.tbl = tbl;
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

        protected override void addJs(LstTag<JavaScriptTag> lstJs)
        {
            base.addJs(lstJs);

            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                lstJs.Add(new JavaScriptTag(typeof(JnlCadastro)));
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
                this.divComando.setPai(this.frm);
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
                this.strId = this.GetType().Name;
                this.addAtt(new Atributo("tbl", this.tbl.strNomeSql));

                // TODO: O nível da div de comando deve ser dinâmico.
                this.divComando.intNivel = 2;

                this.cmpIntId.enmTamanho = CampoHtml.EnmTamanho.PEQUENO;

                this.inicializarColunas();
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

        /// <summary>
        /// Este método deve ser sobescrito pelos herdeiros desta classe para atribuir os campos as
        /// suas respectivas colunas.
        /// </summary>
        protected virtual void inicializarColunas()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.cmpIntId.cln = this.tbl.clnIntId;
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
                this.frm.setPai(this);
                this.cmpIntId.setPai(this.frm);
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