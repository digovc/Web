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
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    _booValor = Convert.ToBoolean(this.strValor);
                }
                catch
                {
                    return false;
                }
                finally
                {
                }

                #endregion Ações

                return _booValor;
            }

            set
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    _booValor = value;

                    this.strValor = Convert.ToString(_booValor);
                }
                catch
                {
                    this.strValor = null;
                }
                finally
                {
                }

                #endregion Ações
            }
        }

        public decimal decValor
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    _decValor = Convert.ToDecimal(this.strValor);
                }
                catch
                {
                    return 0;
                }
                finally
                {
                }

                #endregion Ações

                return _decValor;
            }

            set
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    _decValor = value;

                    this.strValor = _decValor.ToString();
                }
                catch
                {
                    this.strValor = null;
                }
                finally
                {
                }

                #endregion Ações
            }
        }

        public DateTime dttValor
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    _dttValor = Convert.ToDateTime(this.strValor);
                }
                catch
                {
                    return DateTime.MinValue;
                }
                finally
                {
                }

                #endregion Ações

                return _dttValor;
            }

            set
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    _dttValor = value;

                    this.strValor = _dttValor.ToString();
                }
                catch
                {
                    this.strValor = null;
                }
                finally
                {
                }

                #endregion Ações
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
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    _intValor = (int)this.decValor;
                }
                catch
                {
                    return 0;
                }
                finally
                {
                }

                #endregion Ações

                return _intValor;
            }

            set
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    _intValor = value;

                    this.decValor = _intValor;
                }
                catch
                {
                    this.decValor = 0;
                }
                finally
                {
                }

                #endregion Ações
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
                _strValor = value;
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

            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                lstJs.Add(new JavaScriptTag(typeof(Input), 110));

                lstJs.Add(new JavaScriptTag("res/js/Web.TypeScript/OnValorAlteradoArg.js", 110));
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

        protected override void inicializar()
        {
            base.inicializar();

            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.inicializarEnmTipo();
                this.inicializarName();
                this.inicializarStrPlaceHolder();

                this.addAtt(this.booDisabled ? "disabled" : null);
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

        protected override void montarLayout()
        {
            base.montarLayout();

            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.montarLayoutValor();
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

        protected override void setCss(CssArquivo css)
        {
            base.setCss(css);

            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.setCssDateTime(css);
                this.setCssNumber(css);
                this.setCssTextArea(css);
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

        private void inicializarEnmTipo()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
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
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion Ações
        }

        private void inicializarEnmTipoDate()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.attType.strValor = "date";
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

        private void inicializarName()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
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
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion Ações
        }

        private void inicializarStrPlaceHolder()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (string.IsNullOrEmpty(this.strPlaceHolder))
                {
                    return;
                }

                this.addAtt("placeholder", this.strPlaceHolder);
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

        private void inicialziarEnmTipoDateTime()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.attType.strValor = "datetime";
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

        private void inicialziarEnmTipoNumber()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.attType.strValor = "number";
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

        private void inicialziarEnmTipoTextArea()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.strNome = "textarea";
                this.booTagDupla = true;
                this.addAtt("rows", "7");
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

        private void montarLayoutValor()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
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
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion Ações
        }

        private void setCssDateTime(CssArquivo css)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (!EnmTipo.DATETIME.Equals(this.enmTipo))
                {
                    return;
                }

                this.addCss(css.setTextAlign("right"));
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

        private void setCssNumber(CssArquivo css)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (!EnmTipo.NUMBER.Equals(this.enmTipo))
                {
                    return;
                }

                this.addCss(css.setTextAlign("right"));
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

        private void setCssTextArea(CssArquivo css)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (!EnmTipo.TEXT_AREA.Equals(this.enmTipo))
                {
                    return;
                }

                this.addCss(css.setWidth(100, "%"));
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