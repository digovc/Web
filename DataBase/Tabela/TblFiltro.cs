using System;
using NetZ.Persistencia;
using NetZ.Web.Html.Componente.Janela.Cadastro;

namespace NetZ.Web.DataBase.Tabela
{
    public class TblFiltro : TblWebBase
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private static TblFiltro _i;

        private Coluna _clnStrDescricao;
        private Coluna _clnStrNome;
        private Coluna _clnStrTabelaNome;

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

        public Coluna clnStrDescricao
        {
            get
            {
                if (_clnStrDescricao != null)
                {
                    return _clnStrDescricao;
                }

                _clnStrDescricao = new Coluna("str_descricao", this, Coluna.EnmTipo.TEXT);

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

                _clnStrNome = new Coluna("str_nome", this, Coluna.EnmTipo.TEXT);

                return _clnStrNome;
            }
        }

        public Coluna clnStrTabelaNome
        {
            get
            {
                if (_clnStrTabelaNome != null)
                {
                    return _clnStrTabelaNome;
                }

                _clnStrTabelaNome = new Coluna("str_tabela_nome", this, Coluna.EnmTipo.TEXT);

                return _clnStrTabelaNome;
            }
        }

        #endregion Atributos

        #region Construtores

        private TblFiltro() : base(AppWeb.i.dbe, "tbl_filtro")
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

            this.clnStrTabelaNome.booObrigatorio = true;
        }

        protected override int inicializarColunas(int intOrdem)
        {
            intOrdem = base.inicializarColunas(intOrdem);

            this.clnStrDescricao.intOrdem = ++intOrdem;
            this.clnStrNome.intOrdem = ++intOrdem;
            this.clnStrTabelaNome.intOrdem = ++intOrdem;

            return intOrdem;
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}