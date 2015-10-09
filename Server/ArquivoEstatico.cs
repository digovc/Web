using System;
using DigoFramework.Arquivo;

namespace NetZ.Web.Server
{
    internal class ArquivoEstatico : ArquivoDiverso
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private string _dirWeb;

        internal string dirWeb
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_dirWeb != null)
                    {
                        return _dirWeb;
                    }

                    if (string.IsNullOrEmpty(this.dirCompleto))
                    {
                        return null;
                    }

                    _dirWeb = "/_dir_completo";

                    _dirWeb = _dirWeb.Replace("_dir_completo", this.dirCompleto);
                    _dirWeb = _dirWeb.Replace("\\", "/");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _dirWeb;
            }
        }

        #endregion Atributos

        #region Construtores

        public ArquivoEstatico() : base(EnmMimeTipo.TEXT_PLAIN)
        {
        }

        #endregion Construtores

        #region Métodos

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}