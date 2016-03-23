using System;
using System.Data;
using NetZ.Persistencia;
using NetZ.Web.Server.Arquivo.Css;

namespace NetZ.Web.Html.Componente.Grid
{
    internal class GridRow : Tag
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private Atributo _attIntId;
        private DataRow _row;
        private Tabela _tbl;

        internal DataRow row
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

        internal Tabela tbl
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

        private Atributo attIntId
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_attIntId != null)
                    {
                        return _attIntId;
                    }

                    _attIntId = new Atributo("int_id", null);

                    this.addAtt(_attIntId);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _attIntId;
            }
        }

        #endregion Atributos

        #region Construtores

        public GridRow() : base("tr")
        {
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
                this.inicializarId();
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

        protected override void setCss(CssArquivo css)
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

        private void inicializarId()
        {
            #region Variáveis

            long intId;
            string strId;

            #endregion Variáveis

            #region Ações

            try
            {
                if (this.row == null)
                {
                    return;
                }

                if (this.tbl == null)
                {
                    return;
                }

                if (this.row[this.tbl.clnIntId.strNomeSql] == null)
                {
                    return;
                }

                if (DBNull.Value.Equals(this.row[this.tbl.clnIntId.strNomeSql]))
                {
                    return;
                }

                intId = (long)this.row[this.tbl.clnIntId.strNomeSql];

                if (intId < 1)
                {
                    return;
                }

                this.attIntId.addValor(intId);

                strId = "tagGridRow__registro_id";

                strId = strId.Replace("_registro_id", intId.ToString());

                this.strId = strId;
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