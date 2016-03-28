using System;
using NetZ.Persistencia;

namespace NetZ.Web.DataBase
{
    public class TblFiltroItem : Tabela
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private static TblFiltroItem _i;

        private Coluna _clnBooAnd;
        private Coluna _clnIntOperador;
        private Coluna _clnStrColunaNome;

        public static TblFiltroItem i
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_i != null)
                    {
                        return _i;
                    }

                    _i = new TblFiltroItem();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _i;
            }
        }

        public Coluna clnBooAnd
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_clnBooAnd != null)
                    {
                        return _clnBooAnd;
                    }

                    _clnBooAnd = new Coluna("boo_and", this, Coluna.EnmTipo.BOOLEAN);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _clnBooAnd;
            }
        }

        public Coluna clnIntOperador
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_clnIntOperador != null)
                    {
                        return _clnIntOperador;
                    }

                    _clnIntOperador = new Coluna("int_operador", this, Coluna.EnmTipo.INTEGER);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _clnIntOperador;
            }
        }

        public Coluna clnStrColunaNome
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_clnStrColunaNome != null)
                    {
                        return _clnStrColunaNome;
                    }

                    _clnStrColunaNome = new Coluna("str_coluna_nome", this, Coluna.EnmTipo.TEXT);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _clnStrColunaNome;
            }
        }

        #endregion Atributos

        #region Construtores

        private TblFiltroItem() : base(AppWeb.i.objDbPrincipal, "tbl_filtro_item")
        {
        }

        #endregion Construtores

        #region Métodos

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}