using System;
using System.Collections.Generic;
using System.Globalization;
using DigoFramework;

namespace NetZ.Web.Html
{
    /// <summary>
    /// Atributos que uma tag pode possuir como seu id, name, style, etc.
    /// </summary>
    public class Atributo : Objeto
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private int _intValor;
        private List<string> _lstStrValor;
        private string _strSeparador = " ";
        private string _strValor;

        /// <summary>
        /// Valor deste atributo.
        /// </summary>
        public int intValor
        {
            get
            {
                try
                {
                    _intValor = Convert.ToInt32(this.strValor);
                }
                catch
                {
                    _intValor = 0;
                }

                return _intValor;
            }

            set
            {
                _intValor = value;

                this.strValor = Convert.ToString(_intValor);
            }
        }

        /// <summary>
        /// Letra ou texto que vai separar os valores deste atributo.
        /// </summary>
        public string strSeparador
        {
            get
            {
                return _strSeparador;
            }

            set
            {
                _strSeparador = value;
            }
        }

        /// <summary>
        /// Valor deste atributo.
        /// </summary>
        public string strValor
        {
            get
            {
                _strValor = string.Join(this.strSeparador, this.lstStrValor.ToArray());

                return _strValor;
            }

            set
            {
                if (_strValor == value)
                {
                    return;
                }

                _strValor = value;

                this.atualizarStrValor();
            }
        }

        /// <summary>
        /// Lista de valores deste atributo.
        /// </summary>
        protected List<string> lstStrValor
        {
            get
            {
                if (_lstStrValor != null)
                {
                    return _lstStrValor;
                }

                _lstStrValor = new List<string>();

                return _lstStrValor;
            }
        }

        #endregion Atributos

        #region Construtores

        public Atributo(string strNome, string strValor = null)
        {
            this.strNome = strNome;

            this.addValor(strValor);
        }

        public Atributo(string strNome, int intValor)
        {
            this.strNome = strNome;
            this.addValor(intValor);
        }

        #endregion Construtores

        #region Métodos

        /// <summary>
        /// Adiciona um valor para lista de valores que este atributo pode possuir.
        /// </summary>
        /// <param name="strValor">Valor que será adicionado para lista de valores deste atributo.</param>
        public void addValor(string strValor)
        {
            if (string.IsNullOrEmpty(strValor))
            {
                return;
            }

            if (this.lstStrValor.Contains(strValor))
            {
                return;
            }

            this.lstStrValor.Add(strValor);
        }

        /// <summary>
        /// Atalho para <see cref="addValor(string)"/>.
        /// </summary>
        public void addValor(decimal decValor)
        {
            this.addValor(decValor.ToString(CultureInfo.CreateSpecificCulture("en-USA")));
        }

        /// <summary>
        /// Atalho para <see cref="addValor(string)"/>.
        /// </summary>
        public void addValor(int intValor)
        {
            this.addValor(intValor.ToString());
        }

        /// <summary>
        /// Retorna este atributo formatado e pronto para ser utilizado dentro de uma
        /// </summary>
        /// <returns></returns>
        public virtual string getStrFormatado()
        {
            if (string.IsNullOrEmpty(this.strNome))
            {
                return null;
            }

            string strResultado = "_atributo_nome=\"_atributo_valor\"";

            strResultado = strResultado.Replace("_atributo_nome", this.strNome.ToLower());
            strResultado = strResultado.Replace("_atributo_valor", string.Join(this.strSeparador, this.lstStrValor.ToArray()));
            strResultado = strResultado.Replace("=\"\"", null);

            return strResultado;
        }

        private void atualizarStrValor()
        {
            this.lstStrValor.Clear();

            this.addValor(_strValor);
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}