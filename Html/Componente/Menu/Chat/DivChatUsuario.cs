using NetZ.Web.Server.Arquivo.Css;

namespace NetZ.Web.Html.Componente.Menu.Chat
{
    public class DivChatUsuario : ComponenteHtml
    {
        #region Constantes

        private const int INT_TAMANHO = 50;

        #endregion Constantes

        #region Atributos

        private Div _divUsuarioNome;
        private Imagem _imgPerfil;

        private Div divUsuarioNome
        {
            get
            {
                if (_divUsuarioNome != null)
                {
                    return _divUsuarioNome;
                }

                _divUsuarioNome = new Div();

                return _divUsuarioNome;
            }
        }

        private Imagem imgPerfil
        {
            get
            {
                if (_imgPerfil != null)
                {
                    return _imgPerfil;
                }

                _imgPerfil = new Imagem();

                return _imgPerfil;
            }
        }

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        protected override void montarLayout()
        {
            base.montarLayout();

            this.imgPerfil.setPai(this);
            this.divUsuarioNome.setPai(this);
        }

        protected override void setCss(CssArquivoBase css)
        {
            base.setCss(css);

            this.addCss(css.setHeight(INT_TAMANHO));
            this.addCss(css.setMarginTop(10));
            this.addCss(css.setPosition("relative"));

            this.divUsuarioNome.addCss(css.setBackgroundColor("#58b296"));
            this.divUsuarioNome.addCss(css.setCursor("pointer"));
            this.divUsuarioNome.addCss(css.setHeight(100, "%"));
            this.divUsuarioNome.addCss(css.setLeft(25));
            this.divUsuarioNome.addCss(css.setPosition("absolute"));
            this.divUsuarioNome.addCss(css.setRight(0));

            this.imgPerfil.addCss(css.setBackgroundColor("#009688"));
            this.imgPerfil.addCss(css.setBorderRadius(50, "%"));
            this.imgPerfil.addCss(css.setCursor("pointer"));
            this.imgPerfil.addCss(css.setHeight(INT_TAMANHO));
            this.imgPerfil.addCss(css.setPosition("absolute"));
            this.imgPerfil.addCss(css.setWidth(INT_TAMANHO));
            this.imgPerfil.addCss(css.setZIndex(1));
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}