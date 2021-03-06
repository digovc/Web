﻿using NetZ.Persistencia;
using NetZ.Web.DataBase.Dominio;
using NetZ.Web.Server;
using System.Collections.Generic;
using System.Linq;

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
        private Coluna _clnStrTitulo;

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

                _clnIntUsuarioId = new Coluna("int_usuario_id", Coluna.EnmTipo.BIGINT);

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

                _clnStrNome = new Coluna("str_nome", Coluna.EnmTipo.TEXT);

                return _clnStrNome;
            }
        }

        public Coluna clnStrTitulo
        {
            get
            {
                if (_clnStrTitulo != null)
                {
                    return _clnStrTitulo;
                }

                _clnStrTitulo = new Coluna("str_titulo", Coluna.EnmTipo.TEXT);

                return _clnStrTitulo;
            }
        }

        #endregion Atributos

        #region Construtores

        private TblFavorito()
        {
        }

        #endregion Construtores

        #region Métodos

        internal void favoritar(Solicitacao objSolicitacao, Interlocutor objInterlocutor, Persistencia.TabelaBase tbl)
        {
            if (!this.favoritarValidar(objSolicitacao, objInterlocutor, tbl))
            {
                return;
            }

            this.limparDados();

            this.clnIntUsuarioId.intValor = objSolicitacao.objUsuario.intId;
            this.clnStrNome.strValor = tbl.sqlNome;
            this.clnStrTitulo.strValor = tbl.strNomeExibicao;

            this.salvar();

            this.liberarThread();
        }

        internal void pesquisarFavorito(int intUsuarioId, Interlocutor objInterlocutor)
        {
            if (intUsuarioId < 1)
            {
                return;
            }

            if (objInterlocutor == null)
            {
                return;
            }

            List<FavoritoDominio> lstObjFavorito = this.pesquisarDominio<FavoritoDominio>(this.clnIntUsuarioId, intUsuarioId);

            if (lstObjFavorito == null)
            {
                return;
            }

            if (lstObjFavorito.Count < 8)
            {
                objInterlocutor.objData = lstObjFavorito;
            }
            else
            {
                objInterlocutor.objData = lstObjFavorito.Take(8);
            }
        }

        internal bool verificarFavorito(int intUsuarioId, string sqlTabelaNome)
        {
            if (intUsuarioId < 1)
            {
                return false;
            }

            if (string.IsNullOrEmpty(sqlTabelaNome))
            {
                return false;
            }

            var lstFil = new List<Filtro>();

            lstFil.Add(new Filtro(this.clnIntUsuarioId, intUsuarioId));
            lstFil.Add(new Filtro(this.clnStrNome, sqlTabelaNome));

            try
            {
                return (this.recuperar(lstFil).clnIntId.intValor > 0);
            }
            finally
            {
                this.liberarThread();
            }
        }

        protected override void inicializarLstCln(List<Coluna> lstCln)
        {
            base.inicializarLstCln(lstCln);

            lstCln.Add(this.clnIntUsuarioId);
            lstCln.Add(this.clnStrNome);
            lstCln.Add(this.clnStrTitulo);
        }

        private bool favoritarValidar(Solicitacao objSolicitacao, Interlocutor objInterlocutor, TabelaBase tbl)
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