using NetZ.Web.Server.Arquivo.Css;

namespace NetZ.Web.Html.Componente.Janela
{
    public class JanelaHtml : ComponenteHtml
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private Atributo _attHeight;
        private Atributo _attWidth;
        private Div _divAcao;
        private Div _divBtnFechar;
        private Div _divCabecalho;
        private Div _divInativa;
        private Div _divTitulo;
        private int _intTamanhoHotizontal;
        private string _strTitulo;

        /// <summary>
        /// Indica o tamanho horizontal desta janela. A unidade deste valor são 50 pixels, ou seja, 1
        /// = 50px, 5 = 250px.
        /// </summary>
        public int intTamanhoHotizontal
        {
            get
            {
                return _intTamanhoHotizontal;
            }

            set
            {
                _intTamanhoHotizontal = value;
            }
        }

        /// <summary>
        /// Título da janela.
        /// </summary>
        public string strTitulo
        {
            get
            {
                return _strTitulo;
            }

            set
            {
                if (_strTitulo == value)
                {
                    return;
                }

                _strTitulo = value;

                this.setStrTitulo(_strTitulo);
            }
        }

        protected Div divCabecalho
        {
            get
            {
                if (_divCabecalho != null)
                {
                    return _divCabecalho;
                }

                _divCabecalho = new Div();

                return _divCabecalho;
            }
        }

        private Atributo attHeight
        {
            get
            {
                if (_attHeight != null)
                {
                    return _attHeight;
                }

                _attHeight = new Atributo("height");

                this.addAtt(_attHeight);

                return _attHeight;
            }
        }

        private Atributo attWidth
        {
            get
            {
                if (_attWidth != null)
                {
                    return _attWidth;
                }

                _attWidth = new Atributo("width");

                this.addAtt(_attWidth);

                return _attWidth;
            }
        }

        private Div divAcao
        {
            get
            {
                if (_divAcao != null)
                {
                    return _divAcao;
                }

                _divAcao = new Div();

                return _divAcao;
            }
        }

        private Div divBtnFechar
        {
            get
            {
                if (_divBtnFechar != null)
                {
                    return _divBtnFechar;
                }

                _divBtnFechar = new Div();

                return _divBtnFechar;
            }
        }

        private Div divInativa
        {
            get
            {
                if (_divInativa != null)
                {
                    return _divInativa;
                }

                _divInativa = new Div();

                return _divInativa;
            }
        }

        private Div divTitulo
        {
            get
            {
                if (_divTitulo != null)
                {
                    return _divTitulo;
                }

                _divTitulo = new Div();

                return _divTitulo;
            }
        }

        #endregion Atributos

        #region Construtores

        public JanelaHtml()
        {
            this.strId = "divJnl";
        }

        #endregion Construtores

        #region Métodos

        protected override void addJs(LstTag<JavaScriptTag> lstJs)
        {
            base.addJs(lstJs);

            lstJs.Add(new JavaScriptTag(typeof(JanelaHtml), 111));
        }

        protected override void setStrId(string strId)
        {
            base.setStrId(strId);

            if (string.IsNullOrEmpty(strId))
            {
                return;
            }

            this.divAcao.strId = (strId + "_divAcao");
            this.divBtnFechar.strId = (strId + "_divBtnFechar");
            this.divCabecalho.strId = (strId + "_divCabecalho");
            this.divInativa.strId = (strId + "_divInativa");
            this.divTitulo.strId = (strId + "_divTitulo");
        }

        protected override void finalizar()
        {
            base.finalizar();

            this.divInativa.setPai(this);
        }

        protected override void finalizarCss(CssArquivo css)
        {
            base.finalizarCss(css);

            this.finalizarCssWidth(css);
        }

        protected virtual void finalizarCssWidth(CssArquivo css)
        {
            if (this.intTamanhoHotizontal < 1)
            {
                return;
            }

            this.addCss(css.setWidth(this.intTamanhoHotizontal * 50));
        }

        protected override void inicializar()
        {
            base.inicializar();

            this.strId = this.GetType().Name;
        }

        protected override void montarLayout()
        {
            base.montarLayout();

            this.divCabecalho.setPai(this);
            this.divTitulo.setPai(this.divCabecalho);
            this.divAcao.setPai(this.divCabecalho);
            this.divBtnFechar.setPai(this.divAcao);
        }

        protected override void setCss(CssArquivo css)
        {
            base.setCss(css);

            this.addCss(css.setBackgroundColor(AppWebBase.i.objTema.corFundo));
            this.addCss(css.setBorder(1, "solid", "#2e2e2e"));
            this.addCss(css.setBoxShadow(0, 5, 10, 0, AppWebBase.i.objTema.corSombra));
            this.addCss(css.setCenter());
            this.addCss(css.setPosition("absolute"));

            this.divBtnFechar.addCss(css.setBackgroundColor(AppWebBase.i.objTema.corTelaFundo));
            this.divBtnFechar.addCss(css.setBackgroundImage("/res/media/png/btn_fechar_25x25.png"));
            this.divBtnFechar.addCss(css.setBackgroundPosition("center"));
            this.divBtnFechar.addCss(css.setBackgroundRepeat("no-repeat"));
            this.divBtnFechar.addCss(css.setBorderBottom(1, "solid", AppWebBase.i.objTema.corTema));
            this.divBtnFechar.addCss(css.setBorderLeft(1, "solid", AppWebBase.i.objTema.corTema));
            this.divBtnFechar.addCss(css.setBorderRadius(0, 0, 5, 5));
            this.divBtnFechar.addCss(css.setBorderRight(1, "solid", AppWebBase.i.objTema.corTema));
            this.divBtnFechar.addCss(css.setBoxShadow(0, 1, 5, 0, AppWebBase.i.objTema.corSombra));
            this.divBtnFechar.addCss(css.setHeight(25));
            this.divBtnFechar.addCss(css.setMarginRight(8));
            this.divBtnFechar.addCss(css.setTextAlign("center"));
            this.divBtnFechar.addCss(css.setWidth(55));

            this.divAcao.addCss(css.setBottom(0));
            this.divAcao.addCss(css.setPosition("absolute"));
            this.divAcao.addCss(css.setRight(0));
            this.divAcao.addCss(css.setTop(0));

            this.divCabecalho.addCss(css.setBackgroundColor(AppWebBase.i.objTema.corTelaFundo));
            this.divCabecalho.addCss(css.setCursor("default"));
            this.divCabecalho.addCss(css.setHeight(40));
            this.divCabecalho.addCss(css.setPosition("relative"));

            this.divInativa.addCss(css.setDisplay("none"));
            this.divInativa.addCss(css.setHeight(100, "%"));
            this.divInativa.addCss(css.setPosition("absolute"));
            this.divInativa.addCss(css.setTop(0));
            this.divInativa.addCss(css.setWidth(100, "%"));

            this.divTitulo.addCss(css.setColor("white"));
            this.divTitulo.addCss(css.setLineHeight(40));
            this.divTitulo.addCss(css.setPaddingLeft(10));
        }

        private void setStrTitulo(string strTitulo)
        {
            this.divTitulo.strConteudo = strTitulo;
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}