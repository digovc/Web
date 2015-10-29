using System;

namespace NetZ.Web.Html.Componente.Campo
{
    public class CampoAlfanumerico : CampoHtml
    {
        #region Constantes

        #endregion Constantes

        #region Atributos


        private bool _booSenha;

        /// <summary>
        /// Indica se este campo é para inserção de uma senha, o que substituirá os caracteres digitados por uma máscara.
        /// </summary>
        public bool booSenha
        {
            get
            {
                return _booSenha;
            }
            set
            {
                _booSenha = value;
            }
        }

        #endregion Atributos

        #region Construtores

        public CampoAlfanumerico(string strTitulo, int intFrmNivel) : base(strTitulo, intFrmNivel)
        {
        }

        #endregion Construtores

        #region Métodos

        protected override void inicializar()
        {
            base.inicializar();


            #region Variáveis
            #endregion Variáveis

            #region Ações
            try
            {
                this.inicializarBooSenha();
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

        private void inicializarBooSenha()
        {

            #region Variáveis
            #endregion Variáveis

            #region Ações
            try
            {
                if (!this.booSenha)
                {
                    return;
                }

                this.tagInput.enmTipo = Input.EnmTipo.PASSWORD;
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