using System;
using NetZ.Persistencia;
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

        private Div _divOpcao;

        private Div divOpcao
        {
            get
            {
                if (_divOpcao != null)
                {
                    return _divOpcao;
                }

                _divOpcao = new Div();

                return _divOpcao;
            }
        }

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        protected override void atualizarCln()
        {
            base.atualizarCln();

            if (this.cln == null)
            {
                return;
            }

            this.atualizarClnClnRef();
        }

        private void atualizarClnClnRef()
        {
            if (this.cln.clnRef == null)
            {
                return;
            }

            if (this.cln.clnRef.tbl == null)
            {
                return;
            }

            this.strTitulo = this.cln.clnRef.tbl.strNomeExibicao;

            this.addAtt("cln_web_filtro_nome", this.cln.clnRef.tbl.viwPrincipal.clnNome.strNomeSql);
            this.addAtt("tbl_web_ref_nome", this.cln.clnRef.tbl.viwPrincipal.strNomeSql);
        }

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

        protected override void montarLayout()
        {
            base.montarLayout();

            this.txtPesquisa.setPai(this.divInputContainer);
            this.divOpcao.setPai(this.divInputContainer);
        }

        protected override void setCss(CssArquivo css)
        {
            base.setCss(css);

            this.cmb.addCss(css.setDisplay("none"));

            this.divOpcao.addCss(css.setBackgroundColor("rgba(5,154,149,0.15)"));
            this.divOpcao.addCss(css.setBorder(1, "solid", AppWeb.i.objTema.corBorda));
            this.divOpcao.addCss(css.setBorderRadius(2));
            this.divOpcao.addCss(css.setColor(AppWeb.i.objTema.corTema));
            this.divOpcao.addCss(css.setCursor("pointer"));
            this.divOpcao.addCss(css.setFontSize(20));
            this.divOpcao.addCss(css.setHeight(25));
            this.divOpcao.addCss(css.setLineHeight(15));
            this.divOpcao.addCss(css.setPosition("absolute"));
            this.divOpcao.addCss(css.setRight(5));
            this.divOpcao.addCss(css.setTextAlign("center"));
            this.divOpcao.addCss(css.setTop(-8));
            this.divOpcao.addCss(css.setWidth(25));

            this.txtPesquisa.addCss(css.setBorder(0));
            this.txtPesquisa.addCss(css.setBorderBottom(1, "solid", AppWeb.i.objTema.corTema));
            this.txtPesquisa.addCss(css.setOutLine("none"));
            this.txtPesquisa.addCss(css.setWidth(100, "%"));
        }


        protected override void inicializar()
        {
            base.inicializar();

            this.divOpcao.strConteudo = "...";
        }
        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}