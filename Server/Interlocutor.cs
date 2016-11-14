using DigoFramework.Json;

namespace NetZ.Web.Server
{
    public class Interlocutor
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private object _objData;
        private string _strClazz;
        private string _strErro;
        private string _strMetodo;

        /// <summary>
        /// Propriedade que serve para intercâmbio de informações entre o servidor e o cliente.
        /// </summary>
        public object objData
        {
            get
            {
                return _objData;
            }

            set
            {
                _objData = value;
            }
        }

        /// <summary>
        /// Indica o nome do tipo do objeto que a propriedade <see cref="objData"/> possui.
        /// </summary>
        public string strClazz
        {
            get
            {
                return _strClazz;
            }

            set
            {
                _strClazz = value;
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

            this.objData = Json.i.toJson(obj);
        }

        /// <summary>
        /// Retorna o objeto que foi enviado pelo browser do tipo indicado em T.
        /// <para>
        /// Caso a propriedade <see cref="InterlocutorAjax.strData"/> esteja vazia retorna null.
        /// </para>
        /// </summary>
        public T getObjJson<T>()
        {
            if (this.objData == null)
            {
                return default(T);
            }

            return Json.i.fromJson<T>(this.objData.ToString());
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}