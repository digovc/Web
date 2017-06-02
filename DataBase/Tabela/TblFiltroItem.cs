using NetZ.Persistencia;
using NetZ.Web.DataBase.View;
using NetZ.Web.Html.Componente.Janela.Cadastro;
using System.Collections.Generic;

namespace NetZ.Web.DataBase.Tabela
{
    public class TblFiltroItem : TblWebBase
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private static TblFiltroItem _i;

        private Coluna _clnBooAnd;
        private Coluna _clnIntFiltroId;
        private Coluna _clnIntOperador;
        private Coluna _clnSqlColunaNome;

        public static TblFiltroItem i
        {
            get
            {
                if (_i != null)
                {
                    return _i;
                }

                _i = new TblFiltroItem();

                return _i;
            }
        }

        public Coluna clnBooAnd
        {
            get
            {
                if (_clnBooAnd != null)
                {
                    return _clnBooAnd;
                }

                _clnBooAnd = new Coluna("boo_and", Coluna.EnmTipo.BOOLEAN);

                return _clnBooAnd;
            }
        }

        public Coluna clnIntFiltroId
        {
            get
            {
                if (_clnIntFiltroId != null)
                {
                    return _clnIntFiltroId;
                }

                _clnIntFiltroId = new Coluna("int_filtro_id", Coluna.EnmTipo.BIGINT, TblFiltro.i.clnIntId);

                return _clnIntFiltroId;
            }
        }

        public Coluna clnIntOperador
        {
            get
            {
                if (_clnIntOperador != null)
                {
                    return _clnIntOperador;
                }

                _clnIntOperador = new Coluna("int_operador", Coluna.EnmTipo.INTEGER);

                return _clnIntOperador;
            }
        }

        public Coluna clnSqlColunaNome
        {
            get
            {
                if (_clnSqlColunaNome != null)
                {
                    return _clnSqlColunaNome;
                }

                _clnSqlColunaNome = new Coluna("sql_coluna_nome", Coluna.EnmTipo.TEXT);

                return _clnSqlColunaNome;
            }
        }

        #endregion Atributos

        #region Construtores

        private TblFiltroItem()
        {
        }

        #endregion Construtores

        #region Métodos

        protected override void inicializar()
        {
            base.inicializar();

            this.clsJnlCadastro = typeof(JnlFiltroItemCadastro);

            this.clnBooAnd.booValorDefault = true;
            this.clnBooAnd.strNomeExibicao = "E";

            this.clnIntOperador.addOpcao((int)Filtro.EnmOperador.DIFERENTE, "Diferente");
            this.clnIntOperador.addOpcao((int)Filtro.EnmOperador.IGUAL, "Igual");
            this.clnIntOperador.addOpcao((int)Filtro.EnmOperador.IGUAL_CONSULTA, "Consulta");
            this.clnIntOperador.addOpcao((int)Filtro.EnmOperador.LIKE, "Contém");
            this.clnIntOperador.addOpcao((int)Filtro.EnmOperador.LIKE_PREFIXO, "Prefixo");
            this.clnIntOperador.addOpcao((int)Filtro.EnmOperador.LIKE_SUFIXO, "Sufixo");
            this.clnIntOperador.addOpcao((int)Filtro.EnmOperador.MAIOR, "Maior");
            this.clnIntOperador.addOpcao((int)Filtro.EnmOperador.MAIOR_IGUAL, "Maior igual");
            this.clnIntOperador.addOpcao((int)Filtro.EnmOperador.MENOR, "Menor");
            this.clnIntOperador.addOpcao((int)Filtro.EnmOperador.MENOR_IGUAL, "Menor igual");
        }

        protected override void inicializarLstCln(List<Coluna> lstCln)
        {
            base.inicializarLstCln(lstCln);

            lstCln.Add(this.clnBooAnd);
            lstCln.Add(this.clnIntFiltroId);
            lstCln.Add(this.clnIntOperador);
            lstCln.Add(this.clnSqlColunaNome);
        }

        protected override void inicializarLstView(List<ViewBase> lstViw)
        {
            base.inicializarLstView(lstViw);

            lstViw.Add(ViwFiltroItem.i);
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}