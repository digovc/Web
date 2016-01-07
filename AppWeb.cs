using System;
using System.Collections.Generic;
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
        /// <para>
        /// Os dados da solicitação podem ser encontrados dentro da propriedade <see
        /// cref="Solicitacao.jsn"/>, que representa o JSON encaminhado pelo browser do cliente.
        /// </para>
        /// </summary>
        /// <param name="objSolicitacao">Solicitação contendo a operação solicitada pelo usuário.</param>
        /// <returns>
        /// Retorna a resposta que será processada pelo cliente AJAX no browser do cliente.
        /// </returns>
        public virtual Resposta responderAjaxDb(Solicitacao objSolicitacao)
        {
            return new Resposta(objSolicitacao) { intStatus = Resposta.INT_STATUS_CODE_501_NOT_IMPLEMENTED };
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

            return null;
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}