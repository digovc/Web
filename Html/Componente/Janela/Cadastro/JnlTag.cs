using NetZ.Persistencia;
using NetZ.Persistencia.Web;
using NetZ.Web.Server.Arquivo.Css;

namespace NetZ.Web.Html.Componente.Janela.Cadastro
{
    public class JnlTag : JanelaHtml
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private Div _divContainer;
        private Div _divTagConteudo;
        private Input _tagInputTag;
        private TabelaBase _tbl;
        private TabelaWeb _tblWeb;

        public TabelaBase tbl
        {
            get
            {
                return _tbl;
            }

            set
            {
                _tbl = value;
            }
        }

        public TabelaWeb tblWeb
        {
            get
            {
                return _tblWeb;
            }

            set
            {
                _tblWeb = value;
            }
        }

        private Div divContainer
        {
            get
            {
                if (_divContainer != null)
                {
                    return _divContainer;
                }

                _divContainer = new Div();

                return _divContainer;
            }
        }

        private Div divTagConteudo
        {
            get
            {
                if (_divTagConteudo != null)
                {
                    return _divTagConteudo;
                }

                _divTagConteudo = new Div();

                return _divTagConteudo;
            }
        }

        private Input tagInputTag
        {
            get
            {
                if (_tagInputTag != null)
                {
                    return _tagInputTag;
                }

                _tagInputTag = new Input();

                return _tagInputTag;
            }
        }

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        protected override void setStrId(string strId)
        {
            base.setStrId(strId);

            if (string.IsNullOrEmpty(strId))
            {
                return;
            }

            this.tagInputTag.strId = (strId + "_tagInputTag");
        }

        protected override void inicializar()
        {
            base.inicializar();

            this.intTamanhoHotizontal = 8;

            this.inicializarStrId();
            this.inicializarStrTitulo();
            this.inicializarStrTag();
        }

        protected override void montarLayout()
        {
            base.montarLayout();

            this.divContainer.setPai(this);

            this.divTagConteudo.setPai(this.divContainer);

            this.tagInputTag.setPai(this.divTagConteudo);
        }

        protected override void setCss(CssArquivo css)
        {
            base.setCss(css);

            this.divContainer.addCss(css.setHeight(150));
            this.divContainer.addCss(css.setPadding(10));
            this.divContainer.addCss(css.setPosition("relative"));
            this.divContainer.addCss(css.setWidth(380));

            this.divTagConteudo.addCss(css.setBackgroundColor("white"));
            this.divTagConteudo.addCss(css.setBorder(1, "solid", AppWebBase.i.objTema.corFundoBorda));
            this.divTagConteudo.addCss(css.setBottom(10));
            this.divTagConteudo.addCss(css.setLeft(10));
            this.divTagConteudo.addCss(css.setOverflowX("auto"));
            this.divTagConteudo.addCss(css.setPadding(5));
            this.divTagConteudo.addCss(css.setPosition("absolute"));
            this.divTagConteudo.addCss(css.setRight(10));
            this.divTagConteudo.addCss(css.setTop(10));

            this.tagInputTag.addCss(css.setBorder(0));
            this.tagInputTag.addCss(css.setHeight(15));
            this.tagInputTag.addCss(css.setMinWidth(50));
            this.tagInputTag.addCss(css.setOutLine("none"));
            this.tagInputTag.addCss(css.setPadding(7));
            this.tagInputTag.addCss(css.setPaddingLeft(10));
            this.tagInputTag.addCss(css.setPaddingRight(10));
        }

        private void inicializarStrId()
        {
            if (this.tbl == null)
            {
                return;
            }

            if (this.tblWeb == null)
            {
                return;
            }

            ColunaWeb clnWebIntId = this.tblWeb.getClnWeb(this.tbl.clnIntId.sqlNome);

            if (clnWebIntId == null)
            {
                return;
            }

            string strId = "jnlTag__tbl_nome__int_registro_id";

            strId = strId.Replace("_tbl_nome", this.tbl.sqlNome);
            strId = strId.Replace("_int_registro_id", clnWebIntId.strValor);

            this.strId = strId;
        }

        private void inicializarStrTag()
        {
            if (this.tbl == null)
            {
                return;
            }

            if (this.tblWeb.clnWebIntId.intValor < 1)
            {
                return;
            }

            this.tbl.recuperar(this.tblWeb.clnWebIntId.intValor);

            if (string.IsNullOrEmpty(this.tbl.clnStrTag.strValor))
            {
                return;
            }

            this.addAtt("str_tag", this.tbl.clnStrTag.strValor);
        }

        private void inicializarStrTitulo()
        {
            if (this.tbl == null)
            {
                return;
            }

            this.strTitulo = string.Format("{0} (tags)", this.tbl.strNomeExibicao);
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}