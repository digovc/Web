using System;
using System.Data;
using NetZ.Persistencia;

namespace NetZ.Web.Html.Componente.Grid
{
    internal class GridRow : Tag
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private DataRow _row;
        private Tabela _tbl;

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

        public GridRow(Tabela tbl, DataRow row) : base("tr")
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.tbl = tbl;
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

        protected override void montarLayout()
        {
            base.montarLayout();

            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (this.tbl == null)
                {
                    return;
                }

                if (this.row == null)
                {
                    return;
                }

                foreach (Coluna cln in this.tbl.lstClnConsulta)
                {
                    this.montarLayout(cln);
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

        protected override void setCss(CssTag css)
        {
            base.setCss(css);

            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.addCss(css.setHeight(GridHtml.INT_LINHA_TAMANHO));
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

        private void montarLayout(Coluna cln)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (cln == null)
                {
                    return;
                }

                new GridData(cln, this.row).setPai(this);
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