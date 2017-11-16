using NetZ.Persistencia;
using NetZ.Web.Html.Componente.Botao;
using NetZ.Web.Server.Arquivo.Css;

namespace NetZ.Web.Html.Componente.Campo
{
    public class CampoConsulta : CampoComboBox
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private BotaoHtml _btnLimpar;
        private BotaoHtml _btnPesquisar;
        private Div _divIntId;
        private Input _txtPesquisa;

        private BotaoHtml btnLimpar
        {
            get
            {
                if (_btnLimpar != null)
                {
                    return _btnLimpar;
                }

                _btnLimpar = new BotaoHtml();

                return _btnLimpar;
            }
        }

        private BotaoHtml btnPesquisar
        {
            get
            {
                if (_btnPesquisar != null)
                {
                    return _btnPesquisar;
                }

                _btnPesquisar = new BotaoHtml();

                return _btnPesquisar;
            }
        }

        private Div divIntId
        {
            get
            {
                if (_divIntId != null)
                {
                    return _divIntId;
                }

                _divIntId = new Div();

                return _divIntId;
            }
        }

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

            lstJs.Add(new JavaScriptTag(AppWebBase.DIR_JS_WEB + "database/FiltroWeb.js"));
        }

        protected override Input.EnmTipo getEnmTipo()
        {
            return Input.EnmTipo.SEARCH;
        }

        protected override void inicializar()
        {
            base.inicializar();

            this.divIntId.strConteudo = "15";
        }

        protected override void montarLayout()
        {
            base.montarLayout();

            this.divIntId.setPai(this.divAreaEsquerda);

            this.btnLimpar.setPai(this.divAreaDireita);
            this.btnPesquisar.setPai(this.divAreaDireita);
        }

        protected override void montarLayoutDivConteudo()
        {
            base.montarLayoutDivConteudo();

            this.txtPesquisa.setPai(this.divConteudo);
        }

        protected override void setCln(Coluna cln)
        {
            base.setCln(cln);

            if (cln == null)
            {
                return;
            }

            this.setClnClnRef(cln);
        }

        protected override void setCss(CssArquivoBase css)
        {
            base.setCss(css);

            this.btnLimpar.addCss(this.btnAcao);

            this.btnPesquisar.addCss(this.btnAcao);

            this.btnPesquisar.addCss(css.setBackgroundImage(AppWebBase.DIR_MEDIA_SVG + "search.svg"));
            this.btnPesquisar.addCss(css.setDisplay("block"));

            this.cmb.addCss(css.setDisplay("none"));

            this.divIntId.addCss(css.setBorder("none"));
            this.divIntId.addCss(css.setBorderRight(1, "solid", "white"));
            this.divIntId.addCss(css.setDisplay("none"));
            this.divIntId.addCss(css.setLineHeight(30));
            this.divIntId.addCss(css.setMarginTop(5));
            this.divIntId.addCss(css.setOverflow("hidden"));
            this.divIntId.addCss(css.setPaddingLeft(15));
            this.divIntId.addCss(css.setPaddingRight(5));
            this.divIntId.addCss(css.setTextAlign("right"));
            this.divIntId.addCss(css.setWidth(50));

            this.txtPesquisa.addCss(css.setBackground("none"));
            this.txtPesquisa.addCss(css.setBorder(0));
            this.txtPesquisa.addCss(css.setColor("grey"));
            this.txtPesquisa.addCss(css.setColor(AppWebBase.i.objTema.corFonte));
            this.txtPesquisa.addCss(css.setFontSize(15));
            this.txtPesquisa.addCss(css.setLineHeight(37));
            this.txtPesquisa.addCss(css.setOutline("none"));
            this.txtPesquisa.addCss(css.setTextIndent(5));
            this.txtPesquisa.addCss(css.setWidth(245));
        }

        protected override void setCssTagInputWidth(CssArquivoBase css)
        {
            //base.setCssTagInputWidth(css);

            this.tagInput.addCss(css.setWidth(250));
        }

        protected override void setStrId(string strId)
        {
            base.setStrId(strId);

            this.btnLimpar.strId = (strId + "_btnLimpar");
            this.btnPesquisar.strId = (strId + "_btnPesquisar");
            this.divIntId.strId = (strId + "_divIntId");
            this.txtPesquisa.strId = (strId + "_txtPesquisa");
        }

        private void setClnClnRef(Coluna cln)
        {
            if (cln.clnRef == null)
            {
                return;
            }

            if (cln.clnRef.tbl == null)
            {
                return;
            }

            this.setClnClnRefStrTitulo(cln);
            this.setClnClnRefStrValor(cln);

            this.addAtt("cln_ref_nome_exibicao", cln.clnRef.tbl.strNomeExibicao);
            this.addAtt("tbl_web_ref_nome", cln.clnRef.tbl.viwPrincipal.sqlNome);
        }

        private void setClnClnRefStrTitulo(Coluna cln)
        {
            var strTitulo = "_cln_ref_nome_exibicao (_tbl_ref_cln_nome_exibicao)";

            strTitulo = strTitulo.Replace("_cln_ref_nome_exibicao", cln.booNomeExibicaoAutomatico ? cln.clnRef.tbl.strNomeExibicao : cln.strNomeExibicao);
            strTitulo = strTitulo.Replace("_tbl_ref_cln_nome_exibicao", cln.clnRef.tbl.viwPrincipal.clnNome.strNomeExibicao);

            this.strTitulo = strTitulo;
        }

        private void setClnClnRefStrValor(Coluna cln)
        {
            if (this.tagInput.intValor < 1)
            {
                return;
            }

            cln.clnRef.tbl.viwPrincipal.recuperar(this.tagInput.intValor);

            this.cmb.addOpcao(cln.intValor, cln.clnRef.tbl.viwPrincipal.clnNome.strValor);

            cln.clnRef.tbl.viwPrincipal.liberarThread();
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}