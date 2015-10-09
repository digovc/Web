using System;
using NetZ.SistemaBase;
using NetZ.Web.Html.Design;
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

        public const string DIR_JS_BOTAO = "res/js/lib/JDigo/html/Botao.js";
        public const string DIR_JS_CAMPO = "res/js/lib/JDigo/html/Campo.js";
        public const string DIR_JS_COMBO_BOX = "res/js/lib/JDigo/html/ComboBox.js";
        public const string DIR_JS_COMPONENTE_MAIN = "res/js/lib/JDigo/html/componente/ComponenteMain.js";
        public const string DIR_JS_FORMULARIO = "res/js/lib/JDigo/html/Formulario.js";
        public const string DIR_JS_FORMULARIO_TBL = "res/js/lib/JDigo/html/componente/FormularioTbl.js";
        public const string DIR_JS_IMAGEM = "res/js/lib/JDigo/html/Imagem.js";
        public const string DIR_JS_ITEM_MAIN = "res/js/lib/JDigo/html/componente/item/ItemMain.js";
        public const string DIR_JS_MOOTOOLS = "res/js/lib/JDigo/lib/mootools-core-1.4.5.js";
        public const string DIR_JS_PAINEL = "res/js/lib/JDigo/html/Painel.js";
        public const string DIR_JS_POPUP = "res/js/lib/JDigo/html/componente/Popup.js";
        public const string DIR_JS_POPUP_ITEM = "res/js/lib/JDigo/html/componente/item/PopupItem.js";
        public const string DIR_JS_QUICKSEARCH = "res/js/lib/JDigo/lib/jquery.quicksearch.min.js";
        public const string DIR_JS_RELATORIO_MAIN = "res/js/lib/JDigo/html/relatorio/RelatorioMain.js";
        public const string DIR_JS_TABELA = "res/js/lib/JDigo/html/componente/Tabela.js";
        public const string DIR_JS_TABLESORTER = "res/js/lib/JDigo/lib/jquery.tablesorter.min.js";
        public const string DIR_JS_TAG = "res/js/lib/JDigo/html/Tag.js";
        public const string DIR_JS_WEBSOCKET_FILE_TRANSFER = "res/js/lib/JDigo/lib/WebSocketFileTransfer.js";

        #endregion Constantes

        #region Atributos

        private static AppWeb _i;

        private Tema _tma;

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

        public Tema tma
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_tma != null)
                    {
                        return _tma;
                    }

                    _tma = Tema.i;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _tma;
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
        /// </summary>
        public void inicializar()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                Server.Server.i.iniciar();
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
                Server.Server.i.parar();
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

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}