using NetZ.Persistencia;

namespace NetZ.Web.DataBase.Tabela
{
    public abstract class TblWebBase : TabelaBase
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private Coluna _clnBooAtivo;
        private Coluna _clnDttExclusao;

        public Coluna clnBooAtivo
        {
            get
            {
                if (_clnBooAtivo != null)
                {
                    return _clnBooAtivo;
                }

                _clnBooAtivo = new Coluna("boo_ativo", this, Coluna.EnmTipo.BOOLEAN);

                return _clnBooAtivo;
            }
        }

        public Coluna clnDttExclusao
        {
            get
            {
                if (_clnDttExclusao != null)
                {
                    return _clnDttExclusao;
                }

                _clnDttExclusao = new Coluna("dtt_exclusao", this, Coluna.EnmTipo.TIMESTAMP_WITHOUT_TIME_ZONE);

                return _clnDttExclusao;
            }
        }

        #endregion Atributos

        #region Construtores

        public TblWebBase(string strNome) : base(strNome, AppWebBase.i.dbe)
        {
        }

        #endregion Construtores

        #region Métodos

        protected override void inicializar()
        {
            base.inicializar();

            this.clnBooAtivo.booValorDefault = true;
            this.clnBooAtivo.strValorDefaultSql = "true";
            this.clnDttExclusao.strNomeExibicao = STR_DTT_EXCLUSAO_NOME_EXIBICAO;
        }

        protected override int inicializarColunas(int intOrdem)
        {
            intOrdem = base.inicializarColunas(intOrdem);

            this.clnBooAtivo.intOrdem = ++intOrdem;
            this.clnDttExclusao.intOrdem = ++intOrdem;

            return intOrdem;
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}