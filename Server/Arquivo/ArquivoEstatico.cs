using System;
using System.IO;
using DigoFramework.Arquivo;

namespace NetZ.Web.Server.Arquivo
{
    public class ArquivoEstatico : ArquivoDiverso
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

                    _dirWeb = _dirWeb.Substring(_dirWeb.IndexOf("/res/"));
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
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.iniciar();
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

        internal virtual byte[] getArrBte()
        {
            return File.ReadAllBytes(this.dirCompleto); // TODO: Manter o arquivo na memória RAM.
        }

        protected virtual void inicializar()
        {
        }

        private void iniciar()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.inicializar();
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