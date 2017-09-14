using System;
using System.Reflection;
using NetZ.Persistencia;
using NetZ.Persistencia.Web;
using NetZ.Web.Html.Componente.Campo;
using NetZ.Web.Html.Componente.Form;
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
        private FormHtml _frm;
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
                if (_tbl == value)
                {
                    return;
                }

                _tbl = value;

                this.setTbl(_tbl);
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

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        protected override void addJs(LstTag<JavaScriptTag> lstJs)
        {
            base.addJs(lstJs);

            lstJs.Add(new JavaScriptTag("/res/js/web/database/TabelaWeb.js"));
            lstJs.Add(new JavaScriptTag("/res/js/web/database/ColunaWeb.js"));
        }

        protected override void addTag(Tag tag)
        {
            if (tag == null)
            {
                return;
            }

            if ((typeof(CampoHtmlBase).IsAssignableFrom(tag.GetType())))
            {
                this.addTagCampoHtml(tag as CampoHtmlBase);
                return;
            }

            if ((typeof(TabItem).IsAssignableFrom(tag.GetType())))
            {
                tag.setPai(this.frm);
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

            this.frm.strId = (strId + "_frm");
        }

        /// <summary>
        /// Este método é chamado de dentro do método <see cref="inicializar"/> e serve para carregar
        /// os dados do banco de dados para os campos.
        /// </summary>
        protected virtual void carregarDados()
        {
        }

        protected override void inicializar()
        {
            base.inicializar();

            this.inicializarCampos();

            this.strId = this.GetType().Name;
            this.strTitulo = this.tbl.strNomeExibicao;

            this.addAtt("src_js", JavaScriptTag.getSrc(this.GetType()));

            this.carregarDados();
        }

        protected override void montarLayout()
        {
            base.montarLayout();

            this.frm.setPai(this);
            this.cmpIntId.setPai(this.frm);
        }

        protected override void setCss(CssArquivoBase css)
        {
            base.setCss(css);

            this.addCss(css.setDisplay("none"));
            this.addCss(css.setMinWidth(500));
        }

        private void addTagCampoHtml(CampoHtmlBase tagCampoHtml)
        {
            if (tagCampoHtml == null)
            {
                return;
            }

            tagCampoHtml.setPai(this.frm);
        }

        private void setTbl(TabelaBase tbl)
        {
            if (tbl == null)
            {
                return;
            }

            this.addAtt("permitir_alterar", tbl.booPermitirAlterar);
            this.addAtt("tbl_web_nome", tbl.sqlNome);
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

            if (this.tblWeb.getCln(tbl.clnIntId.sqlNome).intValor > 0)
            {
                this.tbl.recuperar(this.tblWeb.getCln(tbl.clnIntId.sqlNome).intValor);
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

            if (!(typeof(CampoHtmlBase).IsAssignableFrom(objPropertyInfo.PropertyType)))
            {
                return;
            }

            if ((objPropertyInfo.GetValue(this) as CampoHtmlBase).cln != null)
            {
                return;
            }

            (objPropertyInfo.GetValue(this) as CampoHtmlBase).cln = cln;
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}