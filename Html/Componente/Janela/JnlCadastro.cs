using System;
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

        /// <summary>
        /// Tabela que esta janela de cadastro representa.
        /// </summary>
        protected Tabela tbl
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_tbl != null)
                    {
                        return _tbl;
                    }

                    _tbl = this.getTbl();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _tbl;
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

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

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

        /// <summary>
        /// Este método deve retornar a instância da tabela que este cadastro representa.
        /// </summary>
        /// <returns>A instância da tabela que este cadastro representa.</returns>
        protected abstract Tabela getTbl();

        protected override void inicializar()
        {
            base.inicializar();

            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                // TODO: O nível da div de comando deve ser dinâmico.
                this.divComando.intNivel = 2;

                this.cmpIntId.enmTamanho = CampoHtml.EnmTamanho.PEQUENO;

                this.inicializarTitulo();
                this.inicializarColunasLocal();
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
        /// Tem a responsabilidade de inicializar as propriedades <see cref="CampoHtml.cln"/> dos
        /// campos desta janela de cadastro.
        /// </summary>
        protected abstract void inicializarColunas();

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

        private void inicializarColunasLocal()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (this.tbl == null)
                {
                    return;
                }

                this.cmpIntId.cln = this.tbl.clnIntId;

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

        private void inicializarTitulo()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (this.tbl == null)
                {
                    return;
                }

                this.strTitulo = this.tbl.strNomeExibicao;
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