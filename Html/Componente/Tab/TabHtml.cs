using System;
using NetZ.Web.Html.Componente.Botao;
using NetZ.Web.Server.Arquivo.Css;

namespace NetZ.Web.Html.Componente.Tab
{
    public class TabHtml : ComponenteHtml, ITagNivel
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private BotaoCircular _btnAdicionar;
        private BotaoCircular _btnAlterar;
        private BotaoCircular _btnApagar;
        private Div _divCabecalho;
        private Div _divComando;
        private Div _divConteudo;
        private int _intNivel;
        private int _intTabQuantidade;

        public int intNivel
        {
            get
            {
                return _intNivel;
            }

            set
            {
                _intNivel = value;
            }
        }

        /// <summary>
        /// Retorna a quantidade de tabs que essa tag possui.
        /// </summary>
        public int intTabQuantidade
        {
            get
            {
                return _intTabQuantidade;
            }

            private set
            {
                _intTabQuantidade = value;
            }
        }

        private BotaoCircular btnAdicionar
        {
            get
            {
                if (_btnAdicionar != null)
                {
                    return _btnAdicionar;
                }

                _btnAdicionar = new BotaoCircular();

                return _btnAdicionar;
            }
        }

        private BotaoCircular btnAlterar
        {
            get
            {
                if (_btnAlterar != null)
                {
                    return _btnAlterar;
                }

                _btnAlterar = new BotaoCircular();

                return _btnAlterar;
            }
        }

        private BotaoCircular btnApagar
        {
            get
            {
                if (_btnApagar != null)
                {
                    return _btnApagar;
                }

                _btnApagar = new BotaoCircular();

                return _btnApagar;
            }
        }

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

        private Div divComando
        {
            get
            {
                if (_divComando != null)
                {
                    return _divComando;
                }

                _divComando = new Div();

                return _divComando;
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

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        protected override void addJs(LstTag<JavaScriptTag> lstJs)
        {
            base.addJs(lstJs);

            lstJs.Add(new JavaScriptTag(typeof(TabHtml), 110));
        }

        protected override void addTag(Tag tag)
        {
            if (tag == null)
            {
                return;
            }

            if ((typeof(TabItem).IsAssignableFrom(tag.GetType())))
            {
                this.addTagTabItem(tag as TabItem);
                return;
            }

            base.addTag(tag);
        }

        protected override void atualizarStrId()
        {
            base.atualizarStrId();

            if (string.IsNullOrEmpty(this.strId))
            {
                return;
            }

            this.btnAdicionar.strId = (this.strId + "_btnAdicionar");
            this.btnAlterar.strId = (this.strId + "_btnAlterar");
            this.btnApagar.strId = (this.strId + "_btnApagar");
            this.divComando.strId = (this.strId + "_divComando");
        }

        protected override void inicializar()
        {
            base.inicializar();

            this.btnAdicionar.enmLado = BotaoCircular.EnmLado.ESQUERDA;
            this.btnAdicionar.enmTamanho = BotaoCircular.EnmTamanho.PEQUENO;

            this.btnAlterar.enmLado = BotaoCircular.EnmLado.ESQUERDA;
            this.btnAlterar.enmTamanho = BotaoCircular.EnmTamanho.PEQUENO;

            this.btnApagar.enmLado = BotaoCircular.EnmLado.ESQUERDA;
            this.btnApagar.enmTamanho = BotaoCircular.EnmTamanho.PEQUENO;
        }

        protected override void montarLayout()
        {
            base.montarLayout();

            this.divCabecalho.setPai(this);
            this.divConteudo.setPai(this);
            this.divComando.setPai(this);

            this.btnAdicionar.setPai(this.divComando);
            this.btnAlterar.setPai(this.divComando);
            //this.btnApagar.setPai(this.divComando);
        }

        protected override void setCss(CssArquivo css)
        {
            base.setCss(css);

            this.addCss(css.setHeight(250));
            this.addCss(css.setPosition("relative"));

            this.btnAdicionar.addCss(css.setBackgroundImage("/res/media/png/btn_adicionar_30x30.png"));

            this.btnAlterar.addCss(css.setBackgroundImage("/res/media/png/btn_alterar_30x30.png"));
            this.btnAlterar.addCss(css.setBottom(40));
            this.btnAlterar.addCss(css.setPosition("absolute"));
            this.btnAlterar.addCss(css.setRight(0));

            this.divCabecalho.addCss(css.setHeight(30));
            this.divCabecalho.addCss(css.setPosition("absolute"));
            this.divCabecalho.addCss(css.setTop(10));

            this.divComando.addCss(css.setBottom(10));
            this.divComando.addCss(css.setDisplay("none"));
            this.divComando.addCss(css.setPosition("absolute"));
            this.divComando.addCss(css.setRight(5));

            this.divConteudo.addCss(css.setBottom(0));
            this.divConteudo.addCss(css.setBackgroundColor(AppWeb.i.objTema.corFundo));
            this.divConteudo.addCss(css.setOverflow("auto"));
            this.divConteudo.addCss(css.setPosition("absolute"));
            this.divConteudo.addCss(css.setTop(40));
            this.divConteudo.addCss(css.setWidth(100, "%"));
        }

        private void addTagTabItem(TabItem tabItem)
        {
            if (tabItem == null)
            {
                return;
            }

            tabItem.setPai(this.divConteudo);

            this.addTagTabItemTabItemHead(tabItem);

            this.intTabQuantidade++;
        }

        private void addTagTabItemTabItemHead(TabItem tabItem)
        {
            TabItemHead tagTabItemHead = new TabItemHead();

            tagTabItemHead.tabItem = tabItem;

            tagTabItemHead.setPai(this.divCabecalho);
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}