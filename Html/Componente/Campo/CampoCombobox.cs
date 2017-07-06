using System.Collections.Generic;
using NetZ.Web.Server.Arquivo.Css;
using NetZ.Persistencia;

namespace NetZ.Web.Html.Componente.Campo
{
    public class CampoComboBox : CampoHtml
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private ComboBox _cmb;

        protected ComboBox cmb
        {
            get
            {
                if (_cmb != null)
                {
                    return _cmb;
                }

                _cmb = new ComboBox();

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

        /// <summary>
        /// Adiciona uma opção para a lista do combobox.
        /// </summary>
        /// <param name="objValor">Valor único que identificará a opção.</param>
        /// <param name="strNome">Nome que ficará visível para o usuário.</param>
        public void addOpcao(object objValor, string strNome)
        {
            if (this.tagInput == null)
            {
                return;
            }

            this.cmb.addOpcao(objValor, strNome);
        }

        internal void addOpcao(List<KeyValuePair<object, string>> lstKvpOpcao)
        {
            if (lstKvpOpcao == null)
            {
                return;
            }

            foreach (KeyValuePair<object, string> kvpOpcao in lstKvpOpcao)
            {
                this.addOpcao(kvpOpcao);
            }
        }

        protected override void setCln(Coluna cln)
        {
            base.setCln(cln);

            this.cmb.cln = cln;
        }

        protected override Input.EnmTipo getEnmTipo()
        {
            return Input.EnmTipo.TEXT;
        }

        protected override Input getTagInput()
        {
            return this.cmb;
        }

        protected override void setCssTagInputHeight(CssArquivoBase css)
        {
            this.tagInput.addCss(css.setHeight(22));
        }

        private void addOpcao(KeyValuePair<object, string> kvpOpcao)
        {
            this.addOpcao(kvpOpcao.Key, kvpOpcao.Value);
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}