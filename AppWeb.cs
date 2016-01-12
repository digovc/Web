﻿using System;
using System.Collections.Generic;
using DigoFramework.Json;
using NetZ.Persistencia;
using NetZ.Persistencia.Web;
using NetZ.SistemaBase;
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
        private List<Tabela> _lstTbl;
        private List<Usuario> _lstUsr;
        private object _objLstUsrLock;

        public new static AppWeb i
        {
            get
            {
                return _i;
            }

            set
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_i != null)
                    {
                        return;
                    }

                    _i = value;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações
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

        internal List<Usuario> lstUsr
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_lstUsr != null)
                    {
                        return _lstUsr;
                    }

                    _lstUsr = new List<Usuario>();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _lstUsr;
            }
        }

        private List<Tabela> lstTbl
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_lstTbl != null)
                    {
                        return _lstTbl;
                    }

                    _lstTbl = new List<Tabela>();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _lstTbl;
            }
        }

        private object objLstUsrLock
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_objLstUsrLock != null)
                    {
                        return _objLstUsrLock;
                    }

                    _objLstUsrLock = new object();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _objLstUsrLock;
            }
        }

        #endregion Atributos

        #region Construtores

        protected AppWeb(string strNome)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.strNome = strNome;
                AppWeb.i = this;

                this.inicializarLstTbl(this.lstTbl);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion Ações
        }

        #endregion Construtores

        #region Métodos

        /// <summary>
        /// Inicializa a aplicação e o servidor WEB em sí, juntamente com os demais componentes que
        /// ficarão disponíveis para servir esta aplicação para os cliente.
        /// <para>
        /// Estes serviços levarão em consideração as configurações presentes em <seealso cref="ConfigWeb"/>.
        /// </para>
        /// <para>
        /// O servidor der solicitações AJAX do banco de dados <see cref="ServerAjaxDb"/> também
        /// será inicializado, caso a configuração <seealso cref="ConfigWeb.booServerAjaxDbAtivar"/>
        /// esteja marcada.
        /// </para>
        /// </summary>
        public void inicializarServidor()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                ServerHttp.i.iniciar();

                if (ConfigWeb.i.booServerAjaxDbAtivar)
                {
                    ServerAjaxDb.i.iniciar();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion Ações
        }

        /// <summary>
        /// Para o servidor imediatamente.
        /// </summary>
        public void pararServidor()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                Server.ServerHttp.i.parar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion Ações
        }

        /// <summary>
        /// Este método é disparado a acada vez que o cliente fizer uma solicitação de algum recurso
        /// a este WEB server.
        /// </summary>
        /// <param name="objSolicitacao">
        /// Classe que trás todas as informações da solicitação que foi encaminhada pelo servidor.
        /// <para>
        /// Uma das propriedades mais importantes que deve ser verificada é a <see
        /// cref="Solicitacao.dttUltimaModificacao"/>, para evitar que recursos em cache sejam
        /// enviados desnecessariamente para o cliente.
        /// </para>
        /// </param>
        /// <returns></returns>
        public abstract Resposta responder(Solicitacao objSolicitacao);

        /// <summary>
        /// Este método é disparado para todas as solicitações que são encaminhadas para o servidor
        /// <see cref="ServerAjaxDb"/>. Estas solicitações estão diretamente ligadas às ações
        /// relativas ao banco de dados como recuperar dados, salvar registros, etc.
        /// <para>Essas solicitação são enviadas por AJAX para o servidor de forma assíncrona.</para>
        /// </summary>
        /// <param name="objSolicitacaoAjaxDb">
        /// Solicitação contendo as informações da operação aguardada pelo usuário.
        /// </param>
        /// <returns>Retorna a resposta que será processada pelo browser do cliente.</returns>
        public void responderAjaxDb(Solicitacao objSolicitacao, SolicitacaoAjaxDb objSolicitacaoAjaxDb)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (objSolicitacaoAjaxDb == null)
                {
                    return;
                }

                switch (objSolicitacaoAjaxDb.enmMetodo)
                {
                    case SolicitacaoAjaxDb.EnmMetodo.APAGAR:
                        this.apagarRegistro(objSolicitacao, objSolicitacaoAjaxDb);
                        return;

                    case SolicitacaoAjaxDb.EnmMetodo.PESQUISAR:
                        this.pesquisar(objSolicitacao, objSolicitacaoAjaxDb);
                        return;

                    case SolicitacaoAjaxDb.EnmMetodo.RECUPERAR:
                        this.recuperarRegistro(objSolicitacao, objSolicitacaoAjaxDb);
                        return;

                    case SolicitacaoAjaxDb.EnmMetodo.SALVAR:
                        this.salvarRegistro(objSolicitacao, objSolicitacaoAjaxDb);
                        return;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion Ações
        }

        /// <summary>
        /// Adiciona um usuário para a lista de usuários.
        /// </summary>
        internal void addUsr(Usuario usr)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (usr == null)
                {
                    return;
                }

                if (this.lstUsr.Contains(usr))
                {
                    return;
                }

                // TODO: Eliminar os usuários mais antigos.
                this.lstUsr.Add(usr);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion Ações
        }

        /// <summary>
        /// Busca o usuário que pertence a <param name="strSessaoId"/>.
        /// </summary>
        internal Usuario getUsr(string strSessaoId)
        {
            #region Variáveis

            Usuario usrResposta;

            #endregion Variáveis

            #region Ações

            try
            {
                lock (this.objLstUsrLock)
                {
                    if (string.IsNullOrEmpty(strSessaoId))
                    {
                        return null;
                    }

                    foreach (Usuario usr in this.lstUsr)
                    {
                        if (usr == null)
                        {
                            continue;
                        }

                        if (string.IsNullOrEmpty(usr.strSessaoId))
                        {
                            continue;
                        }

                        if (!usr.strSessaoId.Equals(strSessaoId))
                        {
                            continue;
                        }

                        return usr;
                    }

                    usrResposta = new Usuario(strSessaoId);

                    this.addUsr(usrResposta);

                    return usrResposta;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion Ações
        }

        /// <summary>
        /// Este método deve inicializar a lista com todas as tabelas que têm interação (adicionar,
        /// alterar, pesquisar) com o usuário.
        /// </summary>
        /// <param name="lstTbl"></param>
        protected abstract void inicializarLstTbl(List<Tabela> lstTbl);

        private void apagarRegistro(Solicitacao objSolicitacao, SolicitacaoAjaxDb objSolicitacaoAjaxDb)
        {
        }

        private void pesquisar(Solicitacao objSolicitacao, SolicitacaoAjaxDb objSolicitacaoAjaxDb)
        {
        }

        private void recuperarRegistro(Solicitacao objSolicitacao, SolicitacaoAjaxDb objSolicitacaoAjaxDb)
        {
        }

        private void salvarRegistro(Solicitacao objSolicitacao, SolicitacaoAjaxDb objSolicitacaoAjaxDb)
        {
            #region Variáveis

            TabelaWeb tblWeb;

            #endregion Variáveis

            #region Ações

            try
            {
                if (string.IsNullOrEmpty(objSolicitacaoAjaxDb.jsn))
                {
                    return;
                }

                tblWeb = Json.i.fromJson<TabelaWeb>(objSolicitacaoAjaxDb.jsn);

                this.salvarRegistro(objSolicitacao, tblWeb);

                objSolicitacaoAjaxDb.jsn = Json.i.toJson(tblWeb);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion Ações
        }

        private void salvarRegistro(Solicitacao objSolicitacao, TabelaWeb tblWeb)
        {
            #region Variáveis

            Resposta objResposta;

            #endregion Variáveis

            #region Ações

            try
            {
                if (tblWeb == null)
                {
                    return;
                }

                if (tblWeb.arrClnWeb == null)
                {
                    return;
                }

                if (this.lstTbl == null)
                {
                    return;
                }

                // TODO: Analisar a possibilidade de usar uma instância de para cada usuário,
                //       tornando o sistema mais rápido. Atrelado apenas a aplicação do jeito que
                // está, pode ocorrer problemas com concorrência.
                foreach (Tabela tbl in this.lstTbl)
                {
                    if (!this.salvarRegistro(objSolicitacao, tblWeb, tbl))
                    {
                        continue;
                    }

                    return;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion Ações
        }

        private bool salvarRegistro(Solicitacao objSolicitacao, TabelaWeb tblWeb, Tabela tbl)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (tbl == null)
                {
                    return false;
                }

                if (string.IsNullOrEmpty(tbl.strNomeSql))
                {
                    return false;
                }

                if (tblWeb == null)
                {
                    return false;
                }

                if (string.IsNullOrEmpty(tblWeb.strNome))
                {
                    return false;
                }

                if (!tbl.strNomeSql.ToLower().Equals(tblWeb.strNome.ToLower()))
                {
                    return false;
                }

                tbl.salvarWeb(tblWeb);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion Ações
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}