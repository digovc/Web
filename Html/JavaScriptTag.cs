using System;
using System.Collections.Generic;

namespace NetZ.Web.Html
{
    public class JavaScriptTag : Tag
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private int _intOrdem;

        private List<string> _lstStrCodigo;

        /// <summary>
        /// Todas as tags de JavaScript são executados pelo browser na ordem que estão dispostas na
        /// página. Utilize esta propriedade para indicar quais dessas tags serão executadas antes
        /// das outras.
        /// </summary>
        public int intOrdem
        {
            get
            {
                return _intOrdem;
            }

            set
            {
                _intOrdem = value;
            }
        }

        private List<string> lstStrCodigo
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_lstStrCodigo != null)
                    {
                        return _lstStrCodigo;
                    }

                    _lstStrCodigo = new List<string>();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _lstStrCodigo;
            }
        }

        #endregion Atributos

        #region Construtores

        public JavaScriptTag(string src = null) : base("script")
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.addAtt("type", "text/javascript");
                this.booTagDupla = true;
                this.src = src;
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

        public void addJs(string strJs)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (string.IsNullOrEmpty(strJs))
                {
                    return;
                }

                this.lstStrCodigo.Add(strJs);
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

        public override string toHtml()
        {
            #region Variáveis

            string strResultado;

            #endregion Variáveis

            #region Ações

            try
            {
                if (this.lstStrCodigo.Count < 1)
                {
                    return base.toHtml();
                }

                strResultado = "$(document).ready(function(){_js_codigo});";

                strResultado = strResultado.Replace("_js_codigo", string.Join(string.Empty, this.lstStrCodigo.ToArray()));

                this.strConteudo = strResultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion Ações

            return base.toHtml();
        }

        /// <summary>
        /// Este método precisa estar vazio para que não ocorra um loop infinito e porque este tag
        /// não necessita de adicionar nenhuma outra tag JavaScript para a página.
        /// </summary>
        protected override void addJs(List<JavaScriptTag> lstJs)
        {
            // Não fazer nada.
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}