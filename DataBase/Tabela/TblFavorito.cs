using System.Collections.Generic;
using NetZ.Persistencia;
using NetZ.Web.Server;

namespace NetZ.Web.DataBase.Tabela
{
    public class TblFavorito : TblWebBase
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private static TblFavorito _i;

        private Coluna _clnIntUsuarioId;
        private Coluna _clnStrNome;

        public static TblFavorito i
        {
            get
            {
                if (_i != null)
                {
                    return _i;
                }

                _i = new TblFavorito();

                return _i;
            }
        }

        public Coluna clnIntUsuarioId
        {
            get
            {
                if (_clnIntUsuarioId != null)
                {
                    return _clnIntUsuarioId;
                }

                _clnIntUsuarioId = new Coluna("int_usuario_id", this, Coluna.EnmTipo.BIGINT);

                return _clnIntUsuarioId;
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

        #endregion Atributos

        #region Construtores

        private TblFavorito() : base("tbl_favorito")
        {
        }

        #endregion Construtores

        #region Métodos

        internal void favoritar(Solicitacao objSolicitacao, Interlocutor objInterlocutor, Persistencia.Tabela tbl)
        {
            if (!this.favoritarValidar(objSolicitacao, objInterlocutor, tbl))
            {
                return;
            }

            this.limparDados();

            this.clnIntUsuarioId.intValor = objSolicitacao.objUsuario.intId;
            this.clnStrNome.strValor = tbl.strNomeSql;

            this.salvar();

            this.liberar();
        }

        internal bool verificarFavorito(int intUsuarioId, string strTblNomeSql)
        {
            if (intUsuarioId < 1)
            {
                return false;
            }

            if (string.IsNullOrEmpty(strTblNomeSql))
            {
                return false;
            }

            List<Filtro> lstFil = new List<Filtro>();

            lstFil.Add(new Filtro(this.clnIntUsuarioId, intUsuarioId));
            lstFil.Add(new Filtro(this.clnStrNome, strTblNomeSql));

            return (this.recuperar(lstFil).clnIntId.intValor > 0);
        }

        protected override int inicializarColunas(int intOrdem)
        {
            intOrdem = base.inicializarColunas(intOrdem);

            this.clnIntUsuarioId.intOrdem += intOrdem;
            this.clnStrNome.intOrdem += intOrdem;

            return intOrdem;
        }

        private bool favoritarValidar(Solicitacao objSolicitacao, Interlocutor objInterlocutor, Persistencia.Tabela tbl)
        {
            if (objSolicitacao == null)
            {
                return false;
            }

            if (objSolicitacao.objUsuario == null)
            {
                return false;
            }

            if (!objSolicitacao.objUsuario.booLogado)
            {
                return false;
            }

            if (objSolicitacao.objUsuario.intId < 1)
            {
                return false;
            }

            return true;
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}