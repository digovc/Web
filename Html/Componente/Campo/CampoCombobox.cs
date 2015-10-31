using System;

namespace NetZ.Web.Html.Componente.Campo
{
    public class CampoCombobox : CampoHtml
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private Combobox _cmb;

        private Combobox cmb
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_cmb != null)
                    {
                        return _cmb;
                    }

                    _cmb = (Combobox)this.getTagInput();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _cmb;
            }
        }

        #endregion Atributos

        #region Construtores

        public CampoCombobox()
        {
        }

        #endregion Construtores

        #region Métodos

        protected override Input.EnmTipo getEnmTipo()
        {
            return Input.EnmTipo.TEXT;
        }

        protected override Input getTagInput()
        {
            return new Combobox();
        }

        protected override void montarLayout()
        {
            base.montarLayout();

            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
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