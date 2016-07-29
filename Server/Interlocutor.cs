using DigoFramework.Json;
using NetZ.SistemaBase;

namespace NetZ.Web.Server
{
    public class Interlocutor : Objeto
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private string _strData;
        private string _strErro;
        private string _strJsonTipo;

        private string _strMetodo;

        /// <summary>
        /// Propriedade que serve para intercâmbio de informações entre o servidor e o cliente.
        /// </summary>
        public string strData
        {
            get
            {
                return _strData;
            }

            set
            {
                _strData = value;
            }
        }

        /// <summary>
        /// Caso haja algum erro no processamento desta solicitação.
        /// </summary>
        public string strErro
        {
            get
            {
                return _strErro;
            }

            set
            {
                _strErro = value;
            }
        }

        /// <summary>
        /// Indica o nome do tipo do objeto que a propriedade <see cref="strData"/> possui.
        /// </summary>
        public string strJsonTipo
        {
            get
            {
                return _strJsonTipo;
            }

            set
            {
                _strJsonTipo = value;
            }
        }

        /// <summary>
        /// Enumerado que indica o método que deve ser executado por esta solicitação.
        /// </summary>
        public string strMetodo
        {
            get
            {
                return _strMetodo;
            }

            set
            {
                _strMetodo = value;
            }
        }

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        public void addJson(object obj)
        {
            if (obj == null)
            {
                return;
            }

            this.strData = Json.i.toJson(obj);
        }

        /// <summary>
        /// Retorna o objeto que foi enviado pelo browser do tipo indicado em T.
        /// <para>
        /// Caso a propriedade <see cref="InterlocutorAjax.strData"/> esteja vazia retorna null.
        /// </para>
        /// </summary>
        public T getObjJson<T>()
        {
            if (string.IsNullOrEmpty(this.strData))
            {
                return default(T);
            }

            return Json.i.fromJson<T>(this.strData);
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}