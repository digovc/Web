using System;

namespace NetZ.Web.Html
{
    public class Label : Tag
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private Atributo _atrFor;
        private string _strFor;

        /// <summary>
        /// Indica o ID do input referênte a este label.
        /// </summary>
        public string strFor
        {
            get
            {
                return _strFor;
            }

            set
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    _strFor = value;

                    this.atrFor.strValor = _strFor;
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

        private Atributo atrFor
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_atrFor != null)
                    {
                        return _atrFor;
                    }

                    _atrFor = new Atributo("for");

                    this.addAtt(_atrFor);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _atrFor;
            }
        }

        #endregion Atributos

        #region Construtores

        public Label() : base("label")
        {
        }

        #endregion Construtores

        #region Métodos

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}