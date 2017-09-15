using NetZ.Web.Server.Arquivo.Css;

namespace NetZ.Web.Html.Componente.Janela.Cadastro
{
    public class TagCard : ComponenteHtmlBase
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private Div _divFechar;
        private Div _divTagNome;

        private Div divFechar
        {
            get
            {
                if (_divFechar != null)
                {
                    return _divFechar;
                }

                _divFechar = new Div();

                return _divFechar;
            }
        }

        private Div divTagNome
        {
            get
            {
                if (_divTagNome != null)
                {
                    return _divTagNome;
                }

                _divTagNome = new Div();

                return _divTagNome;
            }
        }

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        protected override void inicializar()
        {
            base.inicializar();

            this.strId = "_str_id";

            this.divFechar.strId = "_str_div_fechar_id";

            this.divTagNome.strConteudo = "_str_tag_nome";
        }

        protected override void montarLayout()
        {
            base.montarLayout();

            this.divTagNome.setPai(this);
            this.divFechar.setPai(this);
        }

        protected override void setCss(CssArquivoBase css)
        {
            base.setCss(css);

            this.addCss(css.setBackgroundColor("#f7f7f7"));
            this.addCss(css.setBorder(1, "solid", AppWebBase.i.objTema.corFundoBorda));
            this.addCss(css.setDisplay("none"));
            this.addCss(css.setFloat("left"));
            this.addCss(css.setMarginBottom(5));
            this.addCss(css.setMarginRight(5));

            this.divFechar.addCss(css.setBackgroundColor("#dddddd"));
            this.divFechar.addCss(css.setBackgroundImage("/res/media/png/btn_limpar_25x25.png"));
            this.divFechar.addCss(css.setBorderLeft(1, "solid", AppWebBase.i.objTema.corFundoBorda));
            this.divFechar.addCss(css.setCursor("pointer"));
            this.divFechar.addCss(css.setFloat("right"));
            this.divFechar.addCss(css.setHeight(25));
            this.divFechar.addCss(css.setWidth(25));

            this.divTagNome.addCss(css.setFloat("left"));
            this.divTagNome.addCss(css.setLineHeight(22));
            this.divTagNome.addCss(css.setPaddingLeft(10));
            this.divTagNome.addCss(css.setPaddingRight(10));
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}