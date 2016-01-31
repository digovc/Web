using System;
using NetZ.Persistencia;
using NetZ.Web.Html.Componente.Janela;

namespace NetZ.Web.Html.Pagina.Cadastro
{
    public class PagCadastro : PaginaHtml
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private JnlCadastro _jnlCadastro;
        private Tabela _tbl;

        private JnlCadastro jnlCadastro
        {
            get
            {
                return _jnlCadastro;
            }

            set
            {
                _jnlCadastro = value;
            }
        }

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

        public PagCadastro(Tabela tbl) : base("Cadastro")
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
                lstJs.Add(new JavaScriptTag(typeof(PagCadastro), 103));
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
                this.inicializarTbl();
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
                this.jnlCadastro.setPai(this);
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

        private void inicializarTbl()
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

                if (this.tbl.clsJnlCadastro == null)
                {
                    return;
                }

                this.jnlCadastro = (JnlCadastro)Activator.CreateInstance(this.tbl.clsJnlCadastro);
                this.jnlCadastro.tbl = this.tbl;
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