using System;
using NetZ.Persistencia;
using NetZ.Web.Html.Componente.Janela.Cadastro;

namespace NetZ.Web.DataBase
{
    public class TblFiltroItem : Tabela
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private static TblFiltroItem _i;

        private Coluna _clnBooAnd;
        private Coluna _clnIntFiltroId;
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

        public Coluna clnIntFiltroId
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_clnIntFiltroId != null)
                    {
                        return _clnIntFiltroId;
                    }

                    _clnIntFiltroId = new Coluna("int_filtro_id", this, Coluna.EnmTipo.BIGINT);

                    _clnIntFiltroId.clnRef = TblFiltro.i.clnIntId;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _clnIntFiltroId;
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

                    _clnIntOperador.addOpcao((int)Filtro.EnmOperador.DIFERENTE, "Diferente");
                    _clnIntOperador.addOpcao((int)Filtro.EnmOperador.IGUAL, "Igual");
                    _clnIntOperador.addOpcao((int)Filtro.EnmOperador.IGUAL_CONSULTA, "Consulta");
                    _clnIntOperador.addOpcao((int)Filtro.EnmOperador.LIKE, "Contém");
                    _clnIntOperador.addOpcao((int)Filtro.EnmOperador.LIKE_PREFIXO, "Prefixo");
                    _clnIntOperador.addOpcao((int)Filtro.EnmOperador.LIKE_SUFIXO, "Sufixo");
                    _clnIntOperador.addOpcao((int)Filtro.EnmOperador.MAIOR, "Maior");
                    _clnIntOperador.addOpcao((int)Filtro.EnmOperador.MAIOR_IGUAL, "Maior igual");
                    _clnIntOperador.addOpcao((int)Filtro.EnmOperador.MENOR, "Menor");
                    _clnIntOperador.addOpcao((int)Filtro.EnmOperador.MENOR_IGUAL, "Menor igual");
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

        protected override void inicializar()
        {
            base.inicializar();

            this.clsJnlCadastro = typeof(JnlFiltroItemCadastro);
        }

        protected override int inicializarColunas(int intOrdem)
        {
            intOrdem = base.inicializarColunas(intOrdem);

            this.clnBooAnd.intOrdem = ++intOrdem;
            this.clnIntFiltroId.intOrdem = ++intOrdem;
            this.clnIntOperador.intOrdem = ++intOrdem;
            this.clnStrColunaNome.intOrdem = ++intOrdem;

            return intOrdem;
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}