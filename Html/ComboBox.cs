using System.Collections.Generic;
using System.Data;
using NetZ.Persistencia;

namespace NetZ.Web.Html
{
    public class ComboBox : Input
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private bool _booOpcaoVazia;
        private Coluna _cln;
        private Dictionary<object, string> _dicOpcao;
        private DataTable _objDataTable;

        /// <summary>
        /// Indica se este combobox pode ou não conter uma opção vazia.
        /// </summary>
        public bool booOpcaoVazia
        {
            get
            {
                return _booOpcaoVazia;
            }

            set
            {
                _booOpcaoVazia = value;
            }
        }

        /// <summary>
        /// DataTable que pode ser utilizado para compor os valores que podem ser selecionados neste combobox.
        /// </summary>
        public DataTable objDataTable
        {
            get
            {
                return _objDataTable;
            }

            set
            {
                _objDataTable = value;
            }
        }

        internal Coluna cln
        {
            get
            {
                return _cln;
            }

            set
            {
                if (_cln == value)
                {
                    return;
                }

                _cln = value;

                this.setCln(_cln);
            }
        }

        private Dictionary<object, string> dicOpcao
        {
            get
            {
                if (_dicOpcao != null)
                {
                    return _dicOpcao;
                }

                _dicOpcao = new Dictionary<object, string>();

                return _dicOpcao;
            }
        }

        #endregion Atributos

        #region Construtores

        public ComboBox()
        {
            this.strNome = "select";
        }

        #endregion Construtores

        #region Métodos

        public void addOpcao(object objValor, string strNome)
        {
            if (objValor == null)
            {
                return;
            }

            if (this.dicOpcao.ContainsKey(objValor))
            {
                return;
            }

            this.dicOpcao.Add(objValor, strNome);
        }

        protected override void addJs(LstTag<JavaScriptTag> lstJsDebug)
        {
            base.addJs(lstJsDebug);

            lstJsDebug.Add(new JavaScriptTag(typeof(ComboBox), 111));
        }

        protected override void montarLayout()
        {
            base.montarLayout();

            this.montarLayoutItens();
        }

        private void setCln(Coluna cln)
        {
            if (cln == null)
            {
                return;
            }

            cln.lstKvpOpcao?.ForEach((kpv) => this.addOpcao(kpv.Key, kpv.Value));
        }

        private Tag getTagOption(object objValor, string strNome)
        {
            if (objValor == null)
            {
                return null;
            }

            Tag tagResultado = new Tag("option");

            if (objValor.ToString().Equals(this.strValor))
            {
                tagResultado.addAtt("selected", null);
            }

            tagResultado.addAtt("value", objValor.ToString());
            tagResultado.strConteudo = strNome;
            tagResultado.setPai(this);

            return tagResultado;
        }

        private void montarLayoutItens()
        {
            Tag tagOption = null;

            if ((this.dicOpcao.Count < 1) || this.booOpcaoVazia)
            {
                tagOption = this.getTagOption(-1, null);
            }

            foreach (KeyValuePair<object, string> kpv in this.dicOpcao)
            {
                if (kpv.Key == null)
                {
                    continue;
                }

                tagOption = this.getTagOption(kpv.Key, kpv.Value);
            }
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}