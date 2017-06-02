using NetZ.Persistencia;
using NetZ.Web.Html.Componente.Janela.Cadastro;
using System.Collections.Generic;

namespace NetZ.Web.DataBase.Tabela
{
    public class TblFiltro : TblWebBase
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private static TblFiltro _i;

        private Coluna _clnSqlTabelaNome;
        private Coluna _clnStrDescricao;
        private Coluna _clnStrNome;

        public static TblFiltro i
        {
            get
            {
                if (_i != null)
                {
                    return _i;
                }

                _i = new TblFiltro();

                return _i;
            }
        }

        public Coluna clnSqlTabelaNome
        {
            get
            {
                if (_clnSqlTabelaNome != null)
                {
                    return _clnSqlTabelaNome;
                }

                _clnSqlTabelaNome = new Coluna("sql_tabela_nome", Coluna.EnmTipo.TEXT);

                return _clnSqlTabelaNome;
            }
        }

        public Coluna clnStrDescricao
        {
            get
            {
                if (_clnStrDescricao != null)
                {
                    return _clnStrDescricao;
                }

                _clnStrDescricao = new Coluna("str_descricao", Coluna.EnmTipo.TEXT);

                return _clnStrDescricao;
            }
        }

        public Coluna clnStrNome
        {
            get
            {
                if (_clnStrNome != null)
                {
                    return _clnStrNome;
                }

                _clnStrNome = new Coluna("str_nome", Coluna.EnmTipo.TEXT);

                return _clnStrNome;
            }
        }

        #endregion Atributos

        #region Construtores

        private TblFiltro()
        {
        }

        #endregion Construtores

        #region Métodos

        protected override void inicializar()
        {
            base.inicializar();

            this.clsJnlCadastro = typeof(JnlFiltroCadastro);

            this.clnStrDescricao.strNomeExibicao = "descrição";

            this.clnStrNome.booNome = true;
            this.clnStrNome.booObrigatorio = true;

            this.clnSqlTabelaNome.booObrigatorio = true;
        }

        protected override void inicializarLstCln(List<Coluna> lstCln)
        {
            base.inicializarLstCln(lstCln);

            lstCln.Add(this.clnStrDescricao);
            lstCln.Add(this.clnStrNome);
            lstCln.Add(this.clnSqlTabelaNome);
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}