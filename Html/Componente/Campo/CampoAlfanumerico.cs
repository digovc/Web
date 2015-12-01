using System;

namespace NetZ.Web.Html.Componente.Campo
{
    /// <summary>
    /// Campo para a inserção de valores de qualquer espécie, como letras, números e até mesmo pontuação.
    /// </summary>
    public class CampoAlfanumerico : CampoHtml
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private Input _txt;

        private Input txt
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_txt != null)
                    {
                        return _txt;
                    }

                    _txt = new Input();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _txt;
            }
        }

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        protected override void addJs(LstTag<JavaScriptTag> lstJs)
        {
            base.addJs(lstJs);

            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                lstJs.Add(new JavaScriptTag(typeof(CampoAlfanumerico), 130));
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

        protected override Input.EnmTipo getEnmTipo()
        {
            return Input.EnmTipo.TEXT;
        }

        protected override Input getTagInput()
        {
            return this.txt;
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}