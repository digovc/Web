using System;
using System.Reflection;
using NetZ.Persistencia;
using NetZ.Persistencia.Web;
using NetZ.Web.Html.Componente.Campo;
using NetZ.Web.Html.Componente.Form;
using NetZ.Web.Html.Componente.Painel;
using NetZ.Web.Html.Componente.Tab;
using NetZ.Web.Server.Arquivo.Css;

namespace NetZ.Web.Html.Componente.Janela.Cadastro
{
    public abstract class JnlCadastro : JanelaHtml
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private CampoNumerico _cmpIntId;
        private DivComando _divComando;
        private FormHtml _frm;
        private int _intDicaNivel = 1;
        private PainelNivel _pnlDica;
        private TabHtml _tabHtml;
        private Tabela _tbl;
        private Tabela _tblPai;
        private TabelaWeb _tblWeb;

        public Tabela tbl
        {
            get
            {
                return _tbl;
            }

            set
            {
                if (_tbl == value)
                {
                    return;
                }

                _tbl = value;

                this.atualizarTbl();
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

        protected Tabela tblPai
        {
            get
            {
                if (_tblPai != null)
                {
                    return _tblPai;
                }

                _tblPai = this.getTblPai();

                return _tblPai;
            }
        }

        private CampoNumerico cmpIntId
        {
            get
            {
                if (_cmpIntId != null)
                {
                    return _cmpIntId;
                }

                _cmpIntId = new CampoNumerico();

                return _cmpIntId;
            }
        }

        private DivComando divComando
        {
            get
            {
                if (_divComando != null)
                {
                    return _divComando;
                }

                _divComando = new DivComando();

                return _divComando;
            }
        }

        private FormHtml frm
        {
            get
            {
                if (_frm != null)
                {
                    return _frm;
                }

                _frm = new FormHtml();

                return _frm;
            }
        }

        private int intDicaNivel
        {
            get
            {
                return _intDicaNivel;
            }

            set
            {
                _intDicaNivel = value;
            }
        }

        private PainelNivel pnlDica
        {
            get
            {
                if (_pnlDica != null)
                {
                    return _pnlDica;
                }

                _pnlDica = new PainelNivel();

                return _pnlDica;
            }
        }

        private TabHtml tabHtml
        {
            get
            {
                if (_tabHtml != null)
                {
                    return _tabHtml;
                }

                _tabHtml = new TabHtml();

                return _tabHtml;
            }
        }

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        protected override void addJs(LstTag<JavaScriptTag> lstJs)
        {
            base.addJs(lstJs);

            lstJs.Add(new JavaScriptTag(typeof(JnlCadastro), 112));
            lstJs.Add(new JavaScriptTag(this.GetType(), 112));

            lstJs.Add(new JavaScriptTag("res/js/Web.TypeScript/database/TabelaWeb.js"));
            lstJs.Add(new JavaScriptTag("res/js/Web.TypeScript/database/ColunaWeb.js"));
        }

        protected override void addTag(Tag tag)
        {
            if (tag == null)
            {
                return;
            }

            if ((typeof(CampoHtml).IsAssignableFrom(tag.GetType())))
            {
                this.addTagCampoHtml(tag as CampoHtml);
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

            this.divComando.strId = (this.strId + "_divComando");
            this.frm.strId = (this.strId + "_frm");
            this.pnlDica.strId = (this.strId + "_pnlDica");
            this.tabHtml.strId = (this.strId + "_tabHtml");
        }

        /// <summary>
        /// Este método é chamado de dentro do método <see cref="inicializar"/> e serve para carregar
        /// os dados do banco de dados para os campos.
        /// </summary>
        protected virtual void carregarDados()
        {
        }

        protected override void finalizar()
        {
            this.finalizarTabHtml();

            base.finalizar();

            this.finalizarPnlDica();
            this.finalizarDivComando();

            this.intTamanhoY = (this.intDicaNivel + 3);
        }

        protected override void inicializar()
        {
            base.inicializar();

            this.inicializarCampos();

            this.intTamanhoX = 10;
            this.strId = this.GetType().Name;
            this.strTitulo = this.tbl.strNomeExibicao;

            this.addAtt("src_js", JavaScriptTag.getSrc(this.GetType()));

            this.cmpIntId.enmTamanho = CampoHtml.EnmTamanho.PEQUENO;

            this.frm.booComandoCinza = true;

            this.carregarDados();
        }

        protected override void montarLayout()
        {
            base.montarLayout();

            this.frm.setPai(this);
            this.cmpIntId.setPai(this.frm);
        }

        protected override void setCss(CssArquivo css)
        {
            base.setCss(css);

            this.addCss(css.setDisplay("none"));

            this.pnlDica.addCss(css.setBackgroundColor("rgba(220,220,220,0.6)"));
            this.pnlDica.addCss(css.setBorderRadius(0));
            this.pnlDica.addCss(css.setColor("rgb(120,120,120)"));
            this.pnlDica.addCss(css.setHeight(20));
            this.pnlDica.addCss(css.setLeft(-5));
            this.pnlDica.addCss(css.setPadding(5));
            this.pnlDica.addCss(css.setTextAlign("left"));
            this.pnlDica.addCss(css.setTop(20));
            this.pnlDica.addCss(css.setWidth(100, "%"));
            
            this.tabHtml.addCss(css.setDisplay("none"));
        }

        private void addTagCampoHtml(CampoHtml tagCampoHtml)
        {
            if (tagCampoHtml == null)
            {
                return;
            }

            tagCampoHtml.setPai(this.frm);

            this.intDicaNivel = ((tagCampoHtml.intNivel + 1) > this.intDicaNivel) ? (tagCampoHtml.intNivel + 1) : this.intDicaNivel;
        }

        private void addTagTabItem(TabItem tabItem)
        {
            if (tabItem == null)
            {
                return;
            }

            tabItem.setPai(this.tabHtml);
        }

        private void atualizarTbl()
        {
            if (this.tbl == null)
            {
                return;
            }

            this.addAtt("tbl_web_nome", this.tbl.strNomeSql);
        }

        private void finalizarDivComando()
        {
            this.divComando.intNivel = (this.intDicaNivel + 1);

            this.divComando.setPai(this.frm);
        }

        private void finalizarPnlDica()
        {
            this.pnlDica.intNivel = this.intDicaNivel;

            this.pnlDica.setPai(this.frm);
        }

        private void finalizarTabHtml()
        {
            if (this.tabHtml.intTabQuantidade < 1)
            {
                return;
            }

            this.tabHtml.setPai(this);
        }

        private Tabela getTblPai()
        {
            if (this.tblWeb == null)
            {
                return null;
            }

            if (string.IsNullOrEmpty(this.tblWeb.strTblPaiNome))
            {
                return null;
            }

            return AppWeb.i.getTbl(this.tblWeb.strTblPaiNome);
        }

        private void inicializarCampos()
        {
            if (this.tbl == null)
            {
                return;
            }

            if (this.tblWeb == null)
            {
                return;
            }

            if (this.tblWeb.getClnWeb(tbl.clnIntId.strNomeSql).intValor > 0)
            {
                this.tbl.recuperar(this.tblWeb.getClnWeb(tbl.clnIntId.strNomeSql).intValor);
            }
            else
            {
                this.tbl.limparDados();
            }

            this.inicializarCampos(this.GetType());
        }

        private void inicializarCampos(Type cls)
        {
            if (cls == null)
            {
                return;
            }

            if (cls.BaseType != null)
            {
                this.inicializarCampos(cls.BaseType);
            }

            foreach (Coluna cln in this.tbl.lstCln)
            {
                this.inicializarCampos(cls, cln);
            }
        }

        private void inicializarCampos(Type cls, Coluna cln)
        {
            if (cls == null)
            {
                return;
            }

            if (cln == null)
            {
                return;
            }

            if (string.IsNullOrEmpty(cln.strCampoNome))
            {
                return;
            }

            PropertyInfo objPropertyInfo = cls.GetProperty(cln.strCampoNome, BindingFlags.IgnoreCase | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);

            if (objPropertyInfo == null)
            {
                return;
            }

            if (!(typeof(CampoHtml).IsAssignableFrom(objPropertyInfo.PropertyType)))
            {
                return;
            }

            if ((objPropertyInfo.GetValue(this) as CampoHtml).cln != null)
            {
                return;
            }

            (objPropertyInfo.GetValue(this) as CampoHtml).cln = cln;
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}