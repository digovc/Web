using System;
using DigoFramework;

namespace NetZ.Web
{
    /// <summary>
    /// Esta classe mantém uma instância do arquivo AppConfig.xml, localizado na pasta onde fica esta biblioteca.
    /// <para>Este arquivo contém as configurações para que este servidor WEB possa funcionar.</para>
    /// </summary>
    public class ConfigWeb : ConfigMain
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private static ConfigWeb _i;

        private string[] _arrDirIgnorado;
        private string[] _arrStrExtencaoIgnorada;
        private bool _booServerAjaxDbAtivar = true;
        private int _intPorta = 80;
        private int _intServerAjaxDbPorta = 8081;
        private int _intTimeOut = 5;

        public static new ConfigWeb i
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_i != null)
                    {
                        return _i;
                    }

                    _i = new ConfigWeb();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _i;
            }
        }

        /// <summary>
        /// Lista de diretórios ou arquivos estáticos que devem ser ignorados e que não estarão
        /// disponíveis do lado do cliente.
        /// <para>Estes diretórios e arquivos são relativos ao diretório presente em <see cref="dirLocal"/>.</para>
        /// </summary>
        public string[] arrDirIgnorado
        {
            get
            {
                return _arrDirIgnorado;
            }

            set
            {
                _arrDirIgnorado = value;
            }
        }

        /// <summary>
        /// Lista de extenções de arquivos que devem ser ignorados e que não estarão disponíveis do
        /// lado do cliente.
        /// </summary>
        public string[] arrStrExtencaoIgnorada
        {
            get
            {
                return _arrStrExtencaoIgnorada;
            }

            set
            {
                _arrStrExtencaoIgnorada = value;
            }
        }

        /// <summary>
        /// Indica se ao inicializar o servidor HTTP, o servidor de solicitações AJAX do banco de
        /// dados será ativo também.
        /// </summary>
        public bool booServerAjaxDbAtivar
        {
            get
            {
                return _booServerAjaxDbAtivar;
            }

            set
            {
                _booServerAjaxDbAtivar = value;
            }
        }

        /// <summary>
        /// Porta TCP que será utilizada para rodar o servidor WEB.
        /// </summary>
        public int intPorta
        {
            get
            {
                return _intPorta;
            }

            set
            {
                _intPorta = value;
            }
        }

        /// <summary>
        /// Porta que será utilizada pelo servidor <see cref="ServerAjaxDb"/>.
        /// </summary>
        public int intServerAjaxDbPorta
        {
            get
            {
                return _intServerAjaxDbPorta;
            }

            set
            {
                _intServerAjaxDbPorta = value;
            }
        }

        /// <summary>
        /// Tempo em segundos que o servidor esperará pela mensagem vinda do cliente após este ter
        /// começado uma conexão. Caso nada tenha sido enviado pelo cliente neste período a conexão é
        /// cancelada automaticamente.
        /// </summary>
        public int intTimeOut
        {
            get
            {
                return _intTimeOut;
            }

            set
            {
                _intTimeOut = value;
            }
        }

        #endregion Atributos

        #region Construtores

        private ConfigWeb()
        {
        }

        #endregion Construtores

        #region Métodos

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}