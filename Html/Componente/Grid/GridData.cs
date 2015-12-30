using System;
using System.Data;
using NetZ.Persistencia;

namespace NetZ.Web.Html.Componente.Grid
{
    internal class GridData : Tag
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private Coluna _cln;
        private DataRow _row;

        private Coluna cln
        {
            get
            {
                return _cln;
            }

            set
            {
                _cln = value;
            }
        }

        private DataRow row
        {
            get
            {
                return _row;
            }

            set
            {
                _row = value;
            }
        }

        #endregion Atributos

        #region Construtores

        public GridData(Coluna cln, DataRow row) : base("td")
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.cln = cln;
                this.row = row;
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
                if (this.cln == null)
                {
                    return;
                }

                if (this.row == null)
                {
                    return;
                }

                if (this.row[this.cln.strNomeSql] == null)
                {
                    return;
                }

                this.cln.strValor = this.row[this.cln.strNomeSql].ToString();

                this.strConteudo = this.cln.strValorExibicao;
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
                this.addCss(css.setBorderBottom(1, "solid", AppWeb.i.objTema.corBorda));
                this.addCss(css.setOverflowX("hidden"));
                this.addCss(css.setPaddingLeft(25));
                this.addCss(css.setPaddingRight(25));
                this.addCss(css.setWhiteSpace("nowrap"));
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