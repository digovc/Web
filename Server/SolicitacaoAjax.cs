using System;
using DigoFramework.Json;

namespace NetZ.Web.Server
{
    public class SolicitacaoAjax
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private string _jsn;

        /// <summary>
        /// Objeto serializado em JSON para ser transportado por esta solicitação.
        /// </summary>
        public string jsn
        {
            get
            {
                return _jsn;
            }

            set
            {
                _jsn = value;
            }
        }

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        /// <summary>
        /// Retorna o objeto que foi enviado pelo browser do tipo indicado em T.
        /// <para>Caso a propriedade <see cref="SolicitacaoAjax.jsn"/> esteja vazia retorna null.</para>
        /// </summary>
        public T getObjJson<T>()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (string.IsNullOrEmpty(this.jsn))
                {
                    return default(T);
                }

                return Json.i.fromJson<T>(this.jsn);
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