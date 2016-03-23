using System;
using NetZ.Web.Server.Arquivo.Css;

namespace NetZ.Web.Html.Componente.Campo
{
    public class CampoComboBox : CampoHtml
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private ComboBox _cmb;

        private ComboBox cmb
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

                    _cmb = new ComboBox();
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

        public CampoComboBox()
        {
        }

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
                lstJs.Add(new JavaScriptTag(typeof(CampoComboBox), 131));
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
            return this.cmb;
        }

        protected override void setCssTagInputHeight(CssArquivo css)
        {
            this.tagInput.addCss(css.setHeight(25));
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}