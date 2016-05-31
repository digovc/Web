using NetZ.Web.Server.Arquivo.Css;

namespace NetZ.Web.Html.Componente.Campo
{
    public class CampoConsulta : CampoComboBox
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private Input _txtPesquisa;

        private Input txtPesquisa
        {
            get
            {
                if (_txtPesquisa != null)
                {
                    return _txtPesquisa;
                }

                _txtPesquisa = new Input();

                return _txtPesquisa;
            }
        }

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        protected override void addJs(LstTag<JavaScriptTag> lstJs)
        {
            base.addJs(lstJs);

            lstJs.Add(new JavaScriptTag(typeof(CampoConsulta), 132));
        }

        protected override void atualizarStrId()
        {
            base.atualizarStrId();

            if (string.IsNullOrEmpty(this.strId))
            {
                return;
            }

            this.txtPesquisa.strId = (this.strId + "_txtPesquisa");
        }

        protected override Input.EnmTipo getEnmTipo()
        {
            return Input.EnmTipo.SEARCH;
        }

        protected override void inicializar()
        {
            base.inicializar();

            this.inicializarAttRef();
        }

        protected override void montarLayout()
        {
            base.montarLayout();

            this.txtPesquisa.setPai(this);
        }

        protected override void setCss(CssArquivo css)
        {
            base.setCss(css);

            this.cmb.addCss(css.setDisplay("none"));

            this.txtPesquisa.addCss(css.setBorder(0));
            this.txtPesquisa.addCss(css.setBorderBottom(1, "solid", AppWeb.i.objTema.corTema));
            this.txtPesquisa.addCss(css.setOutLine("none"));
        }

        private void inicializarAttClnWebRef()
        {
            this.addAtt("cln_web_ref", this.cln.clnRef.strNomeSql);
        }

        private void inicializarAttClnWebRefNome()
        {
            this.addAtt("cln_web_ref_nome", this.cln.clnRef.tbl.clnNome.strNomeSql);
        }

        private void inicializarAttRef()
        {
            if (this.cln == null)
            {
                return;
            }

            if (this.cln.clnRef == null)
            {
                return;
            }

            if (this.cln.clnRef.tbl == null)
            {
                return;
            }

            if (this.cln.clnRef.tbl.clnNome == null)
            {
                return;
            }

            this.inicializarAttTblWebRef();
            this.inicializarAttClnWebRef();
            this.inicializarAttClnWebRefNome();
        }

        private void inicializarAttTblWebRef()
        {
            this.addAtt("tbl_web_ref", this.cln.clnRef.tbl.viwPrincipal.strNomeSql);
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}