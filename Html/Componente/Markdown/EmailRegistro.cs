using NetZ.Web.Html.Componente.Botao;
using NetZ.Web.Server.Arquivo.Css;

namespace NetZ.Web.Html.Componente.Markdown
{
    internal class EmailRegistro : ComponenteHtml
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private BotaoHtml _btnRegistrar;
        private Div _divTitulo;
        private Input _txtEmail;

        private BotaoHtml btnRegistrar
        {
            get
            {
                if (_btnRegistrar != null)
                {
                    return _btnRegistrar;
                }

                _btnRegistrar = new BotaoHtml();

                return _btnRegistrar;
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

        private Input txtEmail
        {
            get
            {
                if (_txtEmail != null)
                {
                    return _txtEmail;
                }

                _txtEmail = new Input();

                return _txtEmail;
            }
        }

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        protected override bool getBooJs()
        {
            return true;
        }

        protected override void inicializar()
        {
            base.inicializar();

            this.strId = this.GetType().Name;

            this.divTitulo.strConteudo = "Receber atualizações";

            this.txtEmail.enmTipo = Input.EnmTipo.EMAIL;
            this.txtEmail.strPlaceHolder = "Digite o seu email aqui";
        }

        protected override void montarLayout()
        {
            base.montarLayout();

            this.divTitulo.setPai(this);
            this.txtEmail.setPai(this);
            this.btnRegistrar.setPai(this);
        }

        protected override void setCss(CssArquivoBase css)
        {
            base.setCss(css);

            this.addCss(css.setBackgroundColor("#cecece"));
            this.addCss(css.setBottom(0));
            this.addCss(css.setLeft(0));
            this.addCss(css.setPadding(10));
            this.addCss(css.setPosition("absolute"));
            this.addCss(css.setRight(0));

            this.btnRegistrar.addCss(css.setBorderRadius(0, 15, 15, 0));
            this.btnRegistrar.addCss(css.setBottom(10));
            this.btnRegistrar.addCss(css.setBoxShadow(0, 0, 0, 0));
            this.btnRegistrar.addCss(css.setHeight(27));
            this.btnRegistrar.addCss(css.setOutline("none"));
            this.btnRegistrar.addCss(css.setPosition("absolute"));
            this.btnRegistrar.addCss(css.setRight(12));

            this.divTitulo.addCss(css.setMarginBottom(10));
            this.divTitulo.addCss(css.setTextAlign("center"));

            this.txtEmail.addCss(css.setBorder(0));
            this.txtEmail.addCss(css.setBorderRadius(15));
            this.txtEmail.addCss(css.setBoxShadow(0, 0, 5, 0));
            this.txtEmail.addCss(css.setLineHeight(25));
            this.txtEmail.addCss(css.setOutline("none"));
            this.txtEmail.addCss(css.setPaddingLeft(10));
            this.txtEmail.addCss(css.setWidth(218));
        }

        protected override void setStrId(string strId)
        {
            base.setStrId(strId);

            this.btnRegistrar.strId = (strId + "_btnRegistrar");
            this.divTitulo.strId = (strId + "_divTitulo");
            this.txtEmail.strId = (strId + "_txtEmail");
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}