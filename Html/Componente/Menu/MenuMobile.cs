using NetZ.Web.Server.Arquivo.Css;

namespace NetZ.Web.Html.Componente.Menu
{
    public abstract class MenuMobile : ComponenteHtml
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private Div _divCabecalho;
        private Div _divConteudo;
        private Div _divItemConteudo;

        private Div divCabecalho
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

        private Div divConteudo
        {
            get
            {
                if (_divConteudo != null)
                {
                    return _divConteudo;
                }

                _divConteudo = new Div();

                return _divConteudo;
            }
        }

        private Div divItemConteudo
        {
            get
            {
                if (_divItemConteudo != null)
                {
                    return _divItemConteudo;
                }

                _divItemConteudo = new Div();

                return _divItemConteudo;
            }
        }

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        protected override void addJsDebug(LstTag<JavaScriptTag> lstJsDebug)
        {
            base.addJsDebug(lstJsDebug);

            lstJsDebug.Add(new JavaScriptTag(typeof(MenuMobile), 111));
        }

        protected override void addTag(Tag tag)
        {
            if (tag == null)
            {
                return;
            }

            if (!(typeof(MenuMobileItem).IsAssignableFrom(tag.GetType())))
            {
                base.addTag(tag);
                return;
            }

            tag.setPai(this.divItemConteudo);
        }

        protected override void montarLayout()
        {
            base.montarLayout();

            this.divConteudo.setPai(this);
            this.divCabecalho.setPai(this.divConteudo);
            this.divItemConteudo.setPai(this.divConteudo);
        }

        protected override void setCss(CssArquivo css)
        {
            base.setCss(css);

            this.addCss(css.setBackgroundColor("rgba(0,0,0,0.75)"));
            this.addCss(css.setDisplay("none"));
            this.addCss(css.setHeight(100, "%"));
            this.addCss(css.setPosition("fixed"));
            this.addCss(css.setWidth(100, "%"));

            this.divCabecalho.addCss(css.setBackgroundColor(AppWebBase.i.objTema.corTema));
            this.divCabecalho.addCss(css.setBoxShadow(0, 0, 15, 0, "black"));
            this.divCabecalho.addCss(css.setHeight(150));
            this.divCabecalho.addCss(css.setMarginBottom(25));
            this.divCabecalho.addCss(css.setWidth(100, "%"));

            this.divConteudo.addCss(css.setBackgroundColor("white"));
            this.divConteudo.addCss(css.setHeight(100, "%"));
            this.divConteudo.addCss(css.setWidth(90, "%"));

            this.divItemConteudo.addCss(css.setPadding(10));
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}