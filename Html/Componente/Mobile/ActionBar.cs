using NetZ.Web.Html.Componente.Botao.ActionBar;
using NetZ.Web.Server.Arquivo.Css;

namespace NetZ.Web.Html.Componente.Mobile
{
    public class ActionBar : ComponenteHtml
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private BotaoActionBar _btnMenu;
        private BotaoActionBar _btnVoltar;
        private Div _divTitulo;
        private string _strTitulo;

        public string strTitulo
        {
            get
            {
                return _strTitulo;
            }

            set
            {
                _strTitulo = value;

                this.setStrTitulo(_strTitulo);
            }
        }

        private BotaoActionBar btnMenu
        {
            get
            {
                if (_btnMenu != null)
                {
                    return _btnMenu;
                }

                _btnMenu = new BotaoActionBar();

                return _btnMenu;
            }
        }

        private BotaoActionBar btnVoltar
        {
            get
            {
                if (_btnVoltar != null)
                {
                    return _btnVoltar;
                }

                _btnVoltar = new BotaoActionBar();

                return _btnVoltar;
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

        #endregion Construtores

        #region Métodos

        protected override void addJsDebug(LstTag<JavaScriptTag> lstJsDebug)
        {
            base.addJsDebug(lstJsDebug);

            lstJsDebug.Add(new JavaScriptTag(typeof(ActionBar), 111));
        }

        protected override void inicializar()
        {
            base.inicializar();

            this.strId = this.GetType().Name;

            this.btnMenu.strId = (this.strId + "_btnMenu");
            this.btnVoltar.strId = (this.strId + "_btnVoltar");
            this.divTitulo.strId = (this.strId + "_divTitulo");
        }

        protected override void montarLayout()
        {
            base.montarLayout();

            this.btnMenu.setPai(this);
            this.btnVoltar.setPai(this);
            this.divTitulo.setPai(this);
        }

        protected override void setCss(CssArquivo css)
        {
            base.setCss(css);

            this.addCss(css.setBackgroundColor(AppWebBase.i.objTema.corTema));
            this.addCss(css.setBoxShadow(0, 0, 15, 0, "black"));
            this.addCss(css.setColor(AppWebBase.i.objTema.corFonte));
            this.addCss(css.setHeight(50, "px"));
            this.addCss(css.setPosition("fixed"));
            this.addCss(css.setWidth(100, "%"));

            this.btnMenu.addCss(css.setFloat("left"));

            this.btnVoltar.addCss(css.setDisplay("none"));
            this.btnVoltar.addCss(css.setFloat("left"));

            this.divTitulo.addCss(css.setFontSize(25));
            this.divTitulo.addCss(css.setLineHeight(50));
            this.divTitulo.addCss(css.setPaddingLeft(65));
            this.divTitulo.addCss(css.setWidth(100, "%"));
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