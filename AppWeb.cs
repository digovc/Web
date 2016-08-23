using System;
using System.Collections.Generic;
using NetZ.Persistencia;
using NetZ.Persistencia.Web;
using NetZ.SistemaBase;
using NetZ.Web.DataBase.Dominio;
using NetZ.Web.DataBase.Tabela;
using NetZ.Web.Server;

namespace NetZ.Web
{
    /// <summary>
    /// Classe mais importante para a utilização desta biblioteca. Ele que faz a ligação de toda a
    /// lógica interna do servidor WEB e os clientes que consomem os recursos deste.
    /// <para>
    /// Essa classe deve ser herdada por uma classe do desenvolvedor que represente a sua própria aplicação.
    /// </para>
    /// <para>
    /// Para interceptar e construir as páginas da aplicação WEB, esta classe que herda desta,
    /// obrigatóriamente terá de implementar o método <see cref="responder(Solicitacao)"/>, sendo
    /// capaz através disto, construir as respostas adequadas para os clientes e suas solicitações.
    /// </para>
    /// </summary>
    public abstract class AppWeb : App
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private static AppWeb _i;

        private bool _booMostrarGrade;
        private List<UsuarioDominio> _lstObjUsuario;
        private List<ServerBase> _lstSrv;
        private List<Tabela> _lstTbl;
        private object _objLstObjUsuarioLock;

        public new static AppWeb i
        {
            get
            {
                return _i;
            }

            set
            {
                if (_i != null)
                {
                    return;
                }

                _i = value;
            }
        }

        /// <summary>
        /// Caso esta propriedade seja marcada como true, todas as tags geradas serão marcadas
        /// automaticamente para mostrar uma borda para que fique visível o tamanho de gasto por
        /// todas elas.
        /// <para>Utilize esta função para facilitar a montagem da tela.</para>
        /// <para>
        /// Lembre-se de considerar que a borda que será apresentada consome 1px nos quatro lados do
        /// componente, o que pode "estourar" o layout.
        /// </para>
        /// </summary>
        public bool booMostrarGrade
        {
            get
            {
                return _booMostrarGrade;
            }

            set
            {
                _booMostrarGrade = value;
            }
        }

        public List<Tabela> lstTbl
        {
            get
            {
                if (_lstTbl != null)
                {
                    return _lstTbl;
                }

                _lstTbl = this.getLstTbl();

                return _lstTbl;
            }
        }

        internal List<UsuarioDominio> lstObjUsuario
        {
            get
            {
                if (_lstObjUsuario != null)
                {
                    return _lstObjUsuario;
                }

                _lstObjUsuario = new List<UsuarioDominio>();

                return _lstObjUsuario;
            }
        }

        private List<ServerBase> lstSrv
        {
            get
            {
                if (_lstSrv != null)
                {
                    return _lstSrv;
                }

                _lstSrv = this.getLstSrv();

                return _lstSrv;
            }
        }

        private object objLstObjUsuarioLock
        {
            get
            {
                if (_objLstObjUsuarioLock != null)
                {
                    return _objLstObjUsuarioLock;
                }

                _objLstObjUsuarioLock = new object();

                return _objLstObjUsuarioLock;
            }
        }

        #endregion Atributos

        #region Construtores

        protected AppWeb(string strNome)
        {
            i = this;

            this.strNome = strNome;
        }

        private List<Tabela> getLstTbl()
        {
            List<Tabela> lstTblResultado = new List<Tabela>();

            this.inicializarLstTbl(lstTblResultado);

            return lstTblResultado;
        }

        #endregion Construtores

        #region Métodos

        /// <summary>
        /// Pesquisa na lista de tabelas da aplicação a que corresponde a <paramref name="tblWeb"/>,
        /// segundo o nome dessa.
        /// </summary>
        /// <param name="tblWeb">Tabela web que se pretende encontar a correlativa do lado do servidor.</param>
        /// <returns>Retorna a tabela correlativa à tabela web passada por parâmetro.</returns>
        public Tabela getTbl(TabelaWeb tblWeb)
        {
            if (tblWeb == null)
            {
                return null;
            }

            if (string.IsNullOrEmpty(tblWeb.strNome))
            {
                return null;
            }

            return this.getTbl(tblWeb.strNome);
        }

        /// <summary>
        /// Pesquisa na lista de tabelas da aplicação e retorna a tabela que corresponde a este nome
        /// passado por parâmetro.
        /// </summary>
        /// <param name="strTblNome">Nome da tabela que se pretende encontrar.</param>
        /// <returns>Retorna a tabela que corresponde a este nome passado por parâmetro.</returns>
        public Tabela getTbl(string strTblNome)
        {
            if (string.IsNullOrEmpty(strTblNome))
            {
                return null;
            }

            if (this.lstTbl == null)
            {
                return null;
            }

            foreach (Tabela tbl in this.lstTbl)
            {
                Tabela tblResultado = this.getTbl(strTblNome, tbl);

                if (tblResultado == null)
                {
                    continue;
                }

                return tblResultado;
            }

            return null;
        }

        /// <summary>
        /// Inicializa a aplicação e o servidor WEB em sí, juntamente com os demais componentes que
        /// ficarão disponíveis para servir esta aplicação para os cliente.
        /// <para>
        /// Estes serviços levarão em consideração as configurações presentes em <seealso cref="ConfigWeb"/>.
        /// </para>
        /// <para>
        /// O servidor der solicitações AJAX do banco de dados <see cref="ServerAjaxDb"/> também será
        /// inicializado, caso a configuração <seealso cref="ConfigWeb.booServerAjaxDbAtivar"/>
        /// esteja marcada.
        /// </para>
        /// </summary>
        public virtual void inicializarServidor()
        {
            this.inicializarConfig();
            this.inicializarLstSrv();
        }

        /// <summary>
        /// Para o servidor imediatamente.
        /// </summary>
        public void pararServidor()
        {
            foreach (ServerBase srv in this.lstSrv)
            {
                this.pararServidor(srv);
            }
        }

        /// <summary>
        /// Adiciona um usuário para a lista de usuários.
        /// </summary>
        internal void addObjUsuario(UsuarioDominio objUsuario)
        {
            if (objUsuario == null)
            {
                return;
            }

            if (string.IsNullOrEmpty(objUsuario.strSessaoId))
            {
                return;
            }

            if (this.lstObjUsuario.Contains(objUsuario))
            {
                return;
            }

            // TODO: Eliminar os usuários mais antigos.
            this.lstObjUsuario.Add(objUsuario);
        }

        public virtual Persistencia.DataBase getObjDbPrincipal()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Busca o usuário que pertence a <param name="strSessaoId"/>.
        /// </summary>
        internal UsuarioDominio getObjUsuario(string strSessaoId)
        {
            lock (this.objLstObjUsuarioLock)
            {
                if (string.IsNullOrEmpty(strSessaoId))
                {
                    return null;
                }

                foreach (UsuarioDominio objUsuario in this.lstObjUsuario)
                {
                    if (objUsuario == null)
                    {
                        continue;
                    }

                    if (string.IsNullOrEmpty(objUsuario.strSessaoId))
                    {
                        continue;
                    }

                    if (!objUsuario.strSessaoId.Equals(strSessaoId))
                    {
                        continue;
                    }

                    return objUsuario;
                }

                UsuarioDominio objUsuarioNovo = new UsuarioDominio();

                objUsuarioNovo.strSessaoId = strSessaoId;

                this.addObjUsuario(objUsuarioNovo);

                return objUsuarioNovo;
            }
        }

        /// <summary>
        /// Pesquisa na lista de tabelas da aplicação e retorna a tabela que o tipo do seu domínio
        /// tem o mesmo nome passado no parâmetro <paramref name="strDominioNome"/>.
        /// </summary>
        /// <param name="strDominioNome">Nome do domínio que pertence a tabela.</param>
        /// <returns>
        /// a tabela que o tipo do seu domínio tem o mesmo nome passado no parâmetro <paramref name="strDominioNome"/>.
        /// </returns>
        internal Tabela getTblPorDominio(string strDominioNome)
        {
            if (string.IsNullOrEmpty(strDominioNome))
            {
                return null;
            }

            foreach (Tabela tbl in this.lstTbl)
            {
                Tabela tblTemp = this.getTblPorDominio(tbl, strDominioNome);

                if (tblTemp != null)
                {
                    return tblTemp;
                }
            }

            return null;
        }

        protected abstract ConfigWeb getObjConfig();

        protected abstract void inicializarLstSrv(List<ServerBase> lstSrv);

        /// <summary>
        /// Este método deve inicializar a lista com todas as tabelas que têm interação (adicionar,
        /// alterar, pesquisar) com o usuário.
        /// </summary>
        /// <param name="lstTbl"></param>
        protected virtual void inicializarLstTbl(List<Tabela> lstTbl)
        {
            lstTbl.Add(TblFiltro.i);
            lstTbl.Add(TblFiltroItem.i);
        }

        private List<ServerBase> getLstSrv()
        {
            var lstSrvResultado = new List<ServerBase>();

            this.inicializarLstSrv(lstSrvResultado);

            return lstSrvResultado;
        }

        private Tabela getTbl(string strTblNome, Tabela tbl)
        {
            if (tbl.strNomeSql.ToLower().Equals(strTblNome.ToLower()))
            {
                return tbl;
            }

            foreach (View viw in tbl.lstViw)
            {
                if (!viw.strNomeSql.ToLower().Equals(strTblNome.ToLower()))
                {
                    continue;
                }

                return viw;
            }

            return null;
        }

        private Tabela getTblPorDominio(Tabela tbl, string strDominioNome)
        {
            if (tbl == null)
            {
                return null;
            }

            if (tbl.clsDominio == null)
            {
                return null;
            }

            if (!tbl.clsDominio.Name.ToLower().Equals(strDominioNome.ToLower()))
            {
                return null;
            }

            return tbl;
        }

        private void inicializarConfig()
        {
            this.getObjConfig();
        }

        private void inicializarLstSrv()
        {
            if (this.lstSrv == null)
            {
                return;
            }

            foreach (ServerBase srv in this.lstSrv)
            {
                this.inicializarLstSrv(srv);
            }
        }

        private void inicializarLstSrv(ServerBase srv)
        {
            if (srv == null)
            {
                return;
            }

            srv.iniciar();
        }

        private void pararServidor(ServerBase srv)
        {
            if (srv == null)
            {
                return;
            }

            srv.parar();
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}