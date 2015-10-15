using System;
using DigoFramework;

namespace NetZ.Web
{
    /// <summary>
    /// Esta classe mantém uma instância do arquivo AppConfig.xml, localizado na pasta onde fica
    /// esta biblioteca.
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
        private int _intPorta = 8000;

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