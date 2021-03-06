﻿using NetZ.Web.Html.Componente.Botao;
using NetZ.Web.Server.Arquivo.Css;

namespace NetZ.Web.Html.Componente.Tab
{
    public class TabHtml : ComponenteHtmlBase, ITagNivel
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private BotaoCircular _btnAdicionar; // TODO: Colocar o comando dentro do item.
        private BotaoCircular _btnAlterar;
        private BotaoCircular _btnApagar;
        private Div _divCabecalho;
        private Div _divComando;
        private Div _divConteudo;
        private int _intNivel;
        private int _intTabQuantidade;

        private int _intTamanhoVertical;

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

        public int intTamanhoVertical
        {
            get
            {
                return _intTamanhoVertical;
            }

            set
            {
                _intTamanhoVertical = value;
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

        protected override void setStrId(string strId)
        {
            base.setStrId(strId);

            if (string.IsNullOrEmpty(strId))
            {
                return;
            }

            this.btnAdicionar.strId = (strId + "_btnAdicionar");
            this.btnAlterar.strId = (strId + "_btnAlterar");
            this.btnApagar.strId = (strId + "_btnApagar");
            this.divComando.strId = (strId + "_divComando");
        }

        protected override void inicializar()
        {
            base.inicializar();

            this.btnAdicionar.enmTamanho = BotaoCircular.EnmTamanho.PEQUENO;

            this.btnAlterar.enmTamanho = BotaoCircular.EnmTamanho.PEQUENO;

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

        protected override void setCss(CssArquivoBase css)
        {
            base.setCss(css);

            this.addCss(css.setHeight(200));
            this.addCss(css.setPosition("relative"));

            this.btnAdicionar.addCss(css.setBackgroundImage("/res/media/png/btn_adicionar_30x30.png"));

            this.btnAlterar.addCss(css.setBackgroundImage("/res/media/png/btn_alterar_30x30.png"));
            this.btnAlterar.addCss(css.setBottom(40));
            this.btnAlterar.addCss(css.setDisplay("none"));
            this.btnAlterar.addCss(css.setPosition("absolute"));
            this.btnAlterar.addCss(css.setRight(0));

            this.divCabecalho.addCss(css.setHeight(0));
            this.divCabecalho.addCss(css.setPosition("absolute"));
            this.divCabecalho.addCss(css.setTop(0));

            this.divComando.addCss(css.setBottom(10));
            this.divComando.addCss(css.setDisplay("none"));
            this.divComando.addCss(css.setPosition("absolute"));
            this.divComando.addCss(css.setRight(5));

            this.divConteudo.addCss(css.setBottom(0));
            this.divConteudo.addCss(css.setBackgroundColor(AppWebBase.i.objTema.corFundo));
            this.divConteudo.addCss(css.setOverflow("auto"));
            this.divConteudo.addCss(css.setPosition("absolute"));
            this.divConteudo.addCss(css.setTop(30));
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