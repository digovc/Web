using NetZ.Persistencia;
using NetZ.Web.DataBase.Tabela;

namespace NetZ.Web.DataBase.View
{
    public class ViwFiltroItem : ViwWebBase
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private static ViwFiltroItem _i;

        private Coluna _clnBooFiltroItemAnd;
        private Coluna _clnDttFiltroItemAlteracao;
        private Coluna _clnDttFiltroItemCadastro;
        private Coluna _clnIntFiltroItemFiltroId;
        private Coluna _clnIntFiltroItemOperador;
        private Coluna _clnIntFiltroItemUsuarioAlteracaoId;
        private Coluna _clnIntFiltroItemUsuarioCadastroId;
        private Coluna _clnStrFiltroDescricao;
        private Coluna _clnStrFiltroItemColunaNome;
        private Coluna _clnStrFiltroNome;
        private Coluna _clnStrFiltroTabelaNome;
        private Coluna _clnStrUsuarioAlteracaoLogin;
        private Coluna _clnStrUsuarioCadastroLogin;

        public static ViwFiltroItem i
        {
            get
            {
                if (_i != null)
                {
                    return _i;
                }

                _i = new ViwFiltroItem();

                return _i;
            }
        }

        public Coluna clnBooFiltroItemAnd
        {
            get
            {
                if (_clnBooFiltroItemAnd != null)
                {
                    return _clnBooFiltroItemAnd;
                }

                _clnBooFiltroItemAnd = new Coluna("boo_filtro_item_and", this, Coluna.EnmTipo.BOOLEAN);

                return _clnBooFiltroItemAnd;
            }
        }

        public Coluna clnDttFiltroItemAlteracao
        {
            get
            {
                if (_clnDttFiltroItemAlteracao != null)
                {
                    return _clnDttFiltroItemAlteracao;
                }

                _clnDttFiltroItemAlteracao = new Coluna("dtt_filtro_item_alteracao", this, Coluna.EnmTipo.TIMESTAMP_WITHOUT_TIME_ZONE);

                return _clnDttFiltroItemAlteracao;
            }
        }

        public Coluna clnDttFiltroItemCadastro
        {
            get
            {
                if (_clnDttFiltroItemCadastro != null)
                {
                    return _clnDttFiltroItemCadastro;
                }

                _clnDttFiltroItemCadastro = new Coluna("dtt_filtro_item_cadastro", this, Coluna.EnmTipo.TIMESTAMP_WITHOUT_TIME_ZONE);

                return _clnDttFiltroItemCadastro;
            }
        }

        public Coluna clnIntFiltroItemFiltroId
        {
            get
            {
                if (_clnIntFiltroItemFiltroId != null)
                {
                    return _clnIntFiltroItemFiltroId;
                }

                _clnIntFiltroItemFiltroId = new Coluna("int_filtro_item_filtro_id", this, Coluna.EnmTipo.BIGINT, TblFiltro.i.clnIntId);

                return _clnIntFiltroItemFiltroId;
            }
        }

        public Coluna clnIntFiltroItemOperador
        {
            get
            {
                if (_clnIntFiltroItemOperador != null)
                {
                    return _clnIntFiltroItemOperador;
                }

                _clnIntFiltroItemOperador = new Coluna("int_filtro_item_operador", this, Coluna.EnmTipo.INTEGER);

                return _clnIntFiltroItemOperador;
            }
        }

        public Coluna clnIntFiltroItemUsuarioAlteracaoId
        {
            get
            {
                if (_clnIntFiltroItemUsuarioAlteracaoId != null)
                {
                    return _clnIntFiltroItemUsuarioAlteracaoId;
                }

                _clnIntFiltroItemUsuarioAlteracaoId = new Coluna("int_filtro_item_usuario_alteracao_id", this, Coluna.EnmTipo.BIGINT);

                return _clnIntFiltroItemUsuarioAlteracaoId;
            }
        }

        public Coluna clnIntFiltroItemUsuarioCadastroId
        {
            get
            {
                if (_clnIntFiltroItemUsuarioCadastroId != null)
                {
                    return _clnIntFiltroItemUsuarioCadastroId;
                }

                _clnIntFiltroItemUsuarioCadastroId = new Coluna("int_filtro_item_usuario_cadastro_id", this, Coluna.EnmTipo.BIGINT);

                return _clnIntFiltroItemUsuarioCadastroId;
            }
        }

        public Coluna clnStrFiltroDescricao
        {
            get
            {
                if (_clnStrFiltroDescricao != null)
                {
                    return _clnStrFiltroDescricao;
                }

                _clnStrFiltroDescricao = new Coluna("str_filtro_descricao", this, Coluna.EnmTipo.TEXT);

                return _clnStrFiltroDescricao;
            }
        }

        public Coluna clnStrFiltroItemColunaNome
        {
            get
            {
                if (_clnStrFiltroItemColunaNome != null)
                {
                    return _clnStrFiltroItemColunaNome;
                }

                _clnStrFiltroItemColunaNome = new Coluna("str_filtro_item_coluna_nome", this, Coluna.EnmTipo.TEXT);

                return _clnStrFiltroItemColunaNome;
            }
        }

        public Coluna clnStrFiltroNome
        {
            get
            {
                if (_clnStrFiltroNome != null)
                {
                    return _clnStrFiltroNome;
                }

                _clnStrFiltroNome = new Coluna("str_filtro_nome", this, Coluna.EnmTipo.TEXT);

                return _clnStrFiltroNome;
            }
        }

        public Coluna clnStrFiltroTabelaNome
        {
            get
            {
                if (_clnStrFiltroTabelaNome != null)
                {
                    return _clnStrFiltroTabelaNome;
                }

                _clnStrFiltroTabelaNome = new Coluna("str_filtro_tabela_nome", this, Coluna.EnmTipo.TEXT);

                return _clnStrFiltroTabelaNome;
            }
        }

        public Coluna clnStrUsuarioAlteracaoLogin
        {
            get
            {
                if (_clnStrUsuarioAlteracaoLogin != null)
                {
                    return _clnStrUsuarioAlteracaoLogin;
                }

                _clnStrUsuarioAlteracaoLogin = new Coluna("str_usuario_alteracao_login", this, Coluna.EnmTipo.TEXT);

                return _clnStrUsuarioAlteracaoLogin;
            }
        }

        public Coluna clnStrUsuarioCadastroLogin
        {
            get
            {
                if (_clnStrUsuarioCadastroLogin != null)
                {
                    return _clnStrUsuarioCadastroLogin;
                }

                _clnStrUsuarioCadastroLogin = new Coluna("str_usuario_cadastro_login", this, Coluna.EnmTipo.TEXT);

                return _clnStrUsuarioCadastroLogin;
            }
        }

        #endregion Atributos

        #region Construtores

        public ViwFiltroItem() : base("viw_filtro_item")
        {
        }

        protected override string getSql()
        {
            return Properties.View.viw_filtro_item;
        }

        protected override string getStrViewChavePrimariaNome()
        {
            return "int_filtro_item_id";
        }

        #endregion Construtores

        #region Métodos

        protected override void inicializar()
        {
            base.inicializar();

            this.clnIntFiltroItemOperador.addOpcao((int)Filtro.EnmOperador.DIFERENTE, "Diferente");
            this.clnIntFiltroItemOperador.addOpcao((int)Filtro.EnmOperador.IGUAL, "Igual");
            this.clnIntFiltroItemOperador.addOpcao((int)Filtro.EnmOperador.IGUAL_CONSULTA, "Consulta");
            this.clnIntFiltroItemOperador.addOpcao((int)Filtro.EnmOperador.LIKE, "Contém");
            this.clnIntFiltroItemOperador.addOpcao((int)Filtro.EnmOperador.LIKE_PREFIXO, "Prefixo");
            this.clnIntFiltroItemOperador.addOpcao((int)Filtro.EnmOperador.LIKE_SUFIXO, "Sufixo");
            this.clnIntFiltroItemOperador.addOpcao((int)Filtro.EnmOperador.MAIOR, "Maior");
            this.clnIntFiltroItemOperador.addOpcao((int)Filtro.EnmOperador.MAIOR_IGUAL, "Maior igual");
            this.clnIntFiltroItemOperador.addOpcao((int)Filtro.EnmOperador.MENOR, "Menor");
            this.clnIntFiltroItemOperador.addOpcao((int)Filtro.EnmOperador.MENOR_IGUAL, "Menor igual");
        }

        protected override int inicializarColunas(int intOrdem)
        {
            intOrdem = base.inicializarColunas(intOrdem);

            this.clnStrFiltroNome.intOrdem = ++intOrdem;
            this.clnStrFiltroDescricao.intOrdem = ++intOrdem;
            this.clnStrFiltroTabelaNome.intOrdem = ++intOrdem;
            this.clnStrFiltroItemColunaNome.intOrdem = ++intOrdem;
            this.clnIntFiltroItemOperador.intOrdem = ++intOrdem;
            this.clnStrUsuarioCadastroLogin.intOrdem = ++intOrdem;
            this.clnStrUsuarioAlteracaoLogin.intOrdem = ++intOrdem;
            this.clnBooFiltroItemAnd.intOrdem = ++intOrdem;
            this.clnDttFiltroItemCadastro.intOrdem = ++intOrdem;
            this.clnDttFiltroItemAlteracao.intOrdem = ++intOrdem;
            this.clnIntFiltroItemUsuarioCadastroId.intOrdem = ++intOrdem;
            this.clnIntFiltroItemUsuarioAlteracaoId.intOrdem = ++intOrdem;
            this.clnIntFiltroItemFiltroId.intOrdem = ++intOrdem;

            return intOrdem;
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}