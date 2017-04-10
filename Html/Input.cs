using System;
using NetZ.Web.Server.Arquivo.Css;

namespace NetZ.Web.Html
{
    public class Input : Tag
    {
        #region Constantes

        public enum EnmTipo
        {
            BUTTON,
            CHECKBOX,
            COLOR,
            DATE,
            DATETIME,
            DATETIME_LOCAL,
            EMAIL,
            FILE,
            HIDDEN,
            IMAGE,
            MONTH,
            NUMBER,
            PASSWORD,
            RADIO,
            RANGE,
            RESET,
            SEARCH,
            SUBMIT,
            TEL,
            TEXT,
            TEXT_AREA,
            TIME,
            URL,
            WEEK,
        }

        #endregion Constantes

        #region Atributos

        private Atributo _attValue;
        private bool _booDisabled;
        private bool _booValor;
        private decimal _decValor;
        private DateTime _dttValor;
        private EnmTipo _enmTipo = EnmTipo.TEXT;
        private int _intValor;
        private string _strPlaceHolder;
        private string _strValor;

        public bool booDisabled
        {
            get
            {
                return _booDisabled;
            }

            set
            {
                _booDisabled = value;
            }
        }

        public bool booValor
        {
            get
            {
                try
                {
                    _booValor = Convert.ToBoolean(this.strValor);
                }
                catch
                {
                    return false;
                }

                return _booValor;
            }

            set
            {
                try
                {
                    _booValor = value;

                    this.strValor = Convert.ToString(_booValor);
                }
                catch
                {
                    this.strValor = null;
                }
            }
        }

        public decimal decValor
        {
            get
            {
                try
                {
                    _decValor = Convert.ToDecimal(this.strValor);
                }
                catch
                {
                    return 0;
                }

                return _decValor;
            }

            set
            {
                try
                {
                    _decValor = value;

                    this.strValor = _decValor.ToString();
                }
                catch
                {
                    this.strValor = null;
                }
            }
        }

        public DateTime dttValor
        {
            get
            {
                try
                {
                    _dttValor = Convert.ToDateTime(this.strValor);
                }
                catch
                {
                    return DateTime.MinValue;
                }

                return _dttValor;
            }

            set
            {
                try
                {
                    _dttValor = value;

                    this.strValor = _dttValor.ToString();
                }
                catch
                {
                    this.strValor = null;
                }
            }
        }

        public EnmTipo enmTipo
        {
            get
            {
                return _enmTipo;
            }

            set
            {
                _enmTipo = value;
            }
        }

        public int intValor
        {
            get
            {
                try
                {
                    _intValor = (int)this.decValor;
                }
                catch
                {
                    return 0;
                }

                return _intValor;
            }

            set
            {
                try
                {
                    _intValor = value;

                    this.decValor = _intValor;
                }
                catch
                {
                    this.decValor = 0;
                }
            }
        }

        public string strPlaceHolder
        {
            get
            {
                return _strPlaceHolder;
            }

            set
            {
                _strPlaceHolder = value;
            }
        }

        public string strValor
        {
            get
            {
                return _strValor;
            }

            set
            {
                if (_strValor == value)
                {
                    return;
                }

                _strValor = value;

                this.setStrValor(_strValor);
            }
        }

        private Atributo attValue
        {
            get
            {
                if (_attValue != null)
                {
                    return _attValue;
                }

                _attValue = this.getAttValue();

                return _attValue;
            }
        }

        #endregion Atributos

        #region Construtores

        public Input() : base("input")
        {
        }

        #endregion Construtores

        #region Métodos

        protected override void addJs(LstTag<JavaScriptTag> lstJs)
        {
            base.addJs(lstJs);

            lstJs.Add(new JavaScriptTag(typeof(Input), 110));

            lstJs.Add(new JavaScriptTag("/res/js/web/OnValorAlteradoArg.js", 110));
        }

        protected void setStrValor(string strValor)
        {
            this.attValue.strValor = strValor;
        }

        protected override void inicializar()
        {
            base.inicializar();

            this.inicializarEnmTipo();
            this.inicializarName();
            this.inicializarStrPlaceHolder();

            this.addAtt((this.booDisabled ? "disabled" : null), (this.booDisabled ? "true" : null));
        }

        protected override void montarLayout()
        {
            base.montarLayout();

            this.montarLayoutValor();
        }

        protected override void setCss(CssArquivoBase css)
        {
            base.setCss(css);

            switch (this.enmTipo)
            {
                case EnmTipo.DATETIME:
                    this.setCssDateTime(css);
                    return;

                case EnmTipo.NUMBER:
                    this.setCssNumber(css);
                    return;

                case EnmTipo.TEXT_AREA:
                    this.setCssTextArea(css);
                    return;
            }
        }

        private Atributo getAttValue()
        {
            Atributo attResultado = new Atributo("value");

            this.addAtt(attResultado);

            return attResultado;
        }

        private void inicializarEnmTipo()
        {
            switch (this.enmTipo)
            {
                case EnmTipo.BUTTON:
                    this.attType.strValor = "button";
                    return;

                case EnmTipo.CHECKBOX:
                    this.attType.strValor = "checkbox";
                    return;

                case EnmTipo.COLOR:
                    this.attType.strValor = "color";
                    return;

                case EnmTipo.DATE:
                    this.inicializarEnmTipoDate();
                    return;

                case EnmTipo.DATETIME:
                    this.inicialziarEnmTipoDateTime();
                    return;

                case EnmTipo.DATETIME_LOCAL:
                    this.attType.strValor = "datetime-local";
                    return;

                case EnmTipo.EMAIL:
                    this.attType.strValor = "email";
                    return;

                case EnmTipo.FILE:
                    this.attType.strValor = "file";
                    return;

                case EnmTipo.HIDDEN:
                    this.attType.strValor = "hidden";
                    return;

                case EnmTipo.IMAGE:
                    this.attType.strValor = "image";
                    return;

                case EnmTipo.MONTH:
                    this.attType.strValor = "month";
                    return;

                case EnmTipo.NUMBER:
                    this.inicialziarEnmTipoNumber();
                    return;

                case EnmTipo.PASSWORD:
                    this.attType.strValor = "password";
                    return;

                case EnmTipo.RADIO:
                    this.attType.strValor = "radio";
                    return;

                case EnmTipo.RANGE:
                    this.attType.strValor = "range";
                    return;

                case EnmTipo.RESET:
                    this.attType.strValor = "reset";
                    return;

                case EnmTipo.SEARCH:
                    this.attType.strValor = "search";
                    return;

                case EnmTipo.SUBMIT:
                    this.attType.strValor = "submit";
                    return;

                case EnmTipo.TEL:
                    this.attType.strValor = "tel";
                    return;

                case EnmTipo.TEXT:
                    this.attType.strValor = "text";
                    return;

                case EnmTipo.TEXT_AREA:
                    this.inicialziarEnmTipoTextArea();
                    return;

                case EnmTipo.TIME:
                    this.attType.strValor = "time";
                    return;

                case EnmTipo.URL:
                    this.attType.strValor = "url";
                    return;

                case EnmTipo.WEEK:
                    this.attType.strValor = "week";
                    return;

                default:
                    this.attType.strValor = "text";
                    return;
            }
        }

        private void inicializarEnmTipoDate()
        {
            this.attType.strValor = "date";
        }

        private void inicializarName()
        {
            if (string.IsNullOrEmpty(this.strId))
            {
                return;
            }

            if (EnmTipo.RADIO.Equals(this.enmTipo))
            {
                return;
            }

            this.addAtt("name", this.strId);
        }

        private void inicializarStrPlaceHolder()
        {
            if (string.IsNullOrEmpty(this.strPlaceHolder))
            {
                return;
            }

            this.addAtt("placeholder", this.strPlaceHolder);
        }

        private void inicialziarEnmTipoDateTime()
        {
            this.attType.strValor = "datetime";
        }

        private void inicialziarEnmTipoNumber()
        {
            this.attType.strValor = "number";
        }

        private void inicialziarEnmTipoTextArea()
        {
            this.strNome = "textarea";
            this.booDupla = true;
            this.addAtt("rows", "7");
        }

        private void montarLayoutValor()
        {
            if (string.IsNullOrEmpty(this.strValor))
            {
                return;
            }

            switch (this.enmTipo)
            {
                case EnmTipo.TEXT_AREA:
                    this.strConteudo = this.strValor;
                    break;

                case EnmTipo.CHECKBOX:
                    this.addAtt((this.booValor ? "checked" : null));
                    break;

                default:
                    this.addAtt("value", this.strValor);
                    break;
            }
        }

        private void setCssDateTime(CssArquivoBase css)
        {
            this.addCss(css.setTextAlign("right"));
        }

        private void setCssNumber(CssArquivoBase css)
        {
            this.addCss(css.setTextAlign("right"));
        }

        private void setCssTextArea(CssArquivoBase css)
        {
            //this.addCss(css.setWidth(100, "%"));
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}