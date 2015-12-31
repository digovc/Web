using System;
using System.Collections.Generic;
using System.Globalization;
using NetZ.SistemaBase;

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

        private List<string> _lstStrValor;
        private string _strSeparador = " ";
        private string _strValor;

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
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    _strValor = string.Join(this.strSeparador, this.lstStrValor.ToArray());
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _strValor;
            }

            set
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    _strValor = value;

                    this.lstStrValor.Clear();
                    this.addValor(_strValor);
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
        }

        /// <summary>
        /// Lista de valores deste atributo.
        /// </summary>
        protected List<string> lstStrValor
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_lstStrValor != null)
                    {
                        return _lstStrValor;
                    }

                    _lstStrValor = new List<string>();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _lstStrValor;
            }
        }

        #endregion Atributos

        #region Construtores

        public Atributo(string strNome, string strValor = null)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.strNome = strNome;
                this.addValor(strValor);
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

        public Atributo(string strNome, int intValor)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.strNome = strNome;
                this.addValor(intValor);
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

        /// <summary>
        /// Adiciona um valor para lista de valores que este atributo pode possuir.
        /// </summary>
        /// <param name="strValor">Valor que será adicionado para lista de valores deste atributo.</param>
        public void addValor(string strValor)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
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
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion Ações
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
            #region Variáveis

            string strResultado;

            #endregion Variáveis

            #region Ações

            try
            {
                if (string.IsNullOrEmpty(this.strNome))
                {
                    return null;
                }

                strResultado = "_atributo_nome=\"_atributo_valor\"";

                strResultado = strResultado.Replace("_atributo_nome", this.strNome);
                strResultado = strResultado.Replace("_atributo_valor", string.Join(this.strSeparador, this.lstStrValor.ToArray()));
                strResultado = strResultado.Replace("=\"\"", null);

                return strResultado;
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