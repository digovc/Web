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
                if (_dirWeb != null)
                {
                    return _dirWeb;
                }

                _dirWeb = this.getDirWeb();

                return _dirWeb;
            }
        }

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        private string getDirWeb()
        {
            if (string.IsNullOrEmpty(this.dirCompleto))
            {
                return null;
            }

            string dirWebResultado = "/_dir_completo";

            dirWebResultado = dirWebResultado.Replace("_dir_completo", this.dirCompleto);
            dirWebResultado = dirWebResultado.Replace("\\", "/");

            dirWebResultado = dirWebResultado.Substring(dirWebResultado.IndexOf("/res/"));

            return dirWebResultado;
        }

        private void iniciar()
        {
            this.inicializar();
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}