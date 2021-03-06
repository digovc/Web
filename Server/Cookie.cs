﻿using System;
using DigoFramework;

namespace NetZ.Web.Server
{
    public class Cookie : Objeto
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private DateTime _dttValidade;
        private string _strPath = "/";
        private string _strValor;

        /// <summary>
        /// Indica a data e hora de validade deste cookie. Após este período o browser o apaga do seu armazenamento.
        /// </summary>
        public DateTime dttValidade
        {
            get
            {
                return _dttValidade;
            }

            set
            {
                _dttValidade = value;
            }
        }

        /// <summary>
        /// Indica o escopo deste cookie dentro do site. O valor "/" indica que este cookie vale para
        /// todos o âmbito deste site.
        /// </summary>
        public string strPath
        {
            get
            {
                return _strPath;
            }

            set
            {
                _strPath = value;
            }
        }

        /// <summary>
        /// Valor do cookie.
        /// </summary>
        public string strValor
        {
            get
            {
                return _strValor;
            }

            set
            {
                _strValor = value;
            }
        }

        #endregion Atributos

        #region Construtores

        public Cookie(string strNome, string strValor)
        {
            this.dttValidade = DateTime.Now.AddHours(1);
            this.strValor = strValor;
            this.strNome = strNome;
        }

        #endregion Construtores

        #region Métodos

        internal string getStrFormatado()
        {
            if (string.IsNullOrEmpty(this.strNome))
            {
                return null;
            }

            if (string.IsNullOrEmpty(this.strValor))
            {
                return null;
            }

            string strResultado = "Set-Cookie: _cookie_name=_cookie_valor; Path=_cookie_path; expires=_cookie_validade";

            strResultado = strResultado.Replace("_cookie_name", this.strNome);
            strResultado = strResultado.Replace("_cookie_valor", this.strValor);
            strResultado = strResultado.Replace("_cookie_path", this.strPath);
            strResultado = strResultado.Replace("_cookie_validade", this.dttValidade.ToUniversalTime().ToString("r"));

            return strResultado;
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}