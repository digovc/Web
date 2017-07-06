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

        private BotaoMini _btnAcao; // TODO: Trocar este botão por dois botões, um de pesquisar e outro de limpar o campo.
        private Input _txtIntId;
        private Input _txtPesquisa;

        private BotaoMini btnAcao
        {
            get
            {
                if (_btnAcao != null)
                {
                    return _btnAcao;
                }

                _btnAcao = new BotaoMini();

                return _btnAcao;
            }
        }

        private Input txtIntId
        {
            get
            {
                if (_txtIntId != null)
                {
                    return _txtIntId;
                }

                _txtIntId = new Input();

                return _txtIntId;
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

        protected override void setCln(Coluna cln)
        {
            base.setCln(cln);

            if (cln == null)
            {
                return;
            }

            this.setClnClnRef(cln);
        }

        protected override void setStrId(string strId)
        {
            base.setStrId(strId);

            if (string.IsNullOrEmpty(strId))
            {
                return;
            }

            this.btnAcao.strId = (strId + "_btnAcao");
            this.txtIntId.strId = (strId + "_txtIntId");
            this.txtIntId.strId = (strId + "_txtIntId");
            this.txtPesquisa.strId = (strId + "_txtPesquisa");
        }

        protected override Input.EnmTipo getEnmTipo()
        {
            return Input.EnmTipo.SEARCH;
        }

        protected override void inicializar()
        {
            base.inicializar();

            this.btnAcao.intTabStop = -1;

            this.btnAcao.addAtt("type", "button");

            this.txtIntId.booDisabled = true;
        }

        protected override void montarLayout()
        {
            base.montarLayout();

            this.txtPesquisa.setPai(this.divContainer);
            this.txtIntId.setPai(this.divContainer);
            this.btnAcao.setPai(this.divContainer);
        }

        protected override void setCss(CssArquivoBase css)
        {
            base.setCss(css);

            this.btnAcao.addCss(css.setBackgroundImage("/res/media/png/btn_pesquisar_25x25.png"));
            this.btnAcao.addCss(css.setBackgroundPosition("-1px -1px"));
            this.btnAcao.addCss(css.setBorder(1, "solid", AppWebBase.i.objTema.corFundoBorda));
            this.btnAcao.addCss(css.setHeight(25));
            this.btnAcao.addCss(css.setPosition("absolute"));
            this.btnAcao.addCss(css.setRight(-115));
            this.btnAcao.addCss(css.setTop(-3));
            this.btnAcao.addCss(css.setWidth(25));

            this.cmb.addCss(css.setDisplay("none"));

            this.divContainer.addCss(css.setMarginRight(110));

            this.txtIntId.addCss(css.setBorder(1, "solid", AppWebBase.i.objTema.corFundoBorda));
            this.txtIntId.addCss(css.setHeight(19));
            this.txtIntId.addCss(css.setPadding(2));
            this.txtIntId.addCss(css.setPosition("absolute"));
            this.txtIntId.addCss(css.setTextAlign("center"));
            this.txtIntId.addCss(css.setTop(-3));
            this.txtIntId.addCss(css.setWidth(80));

            this.txtPesquisa.addCss(css.setBackgroundColor("rgba(0,0,0,0)"));
            this.txtPesquisa.addCss(css.setBorder(0));
            this.txtPesquisa.addCss(css.setBorderBottom(1, "solid", AppWebBase.i.objTema.corFundoBorda));
            this.txtPesquisa.addCss(css.setFontSize(15));
            this.txtPesquisa.addCss(css.setHeight(19));
            this.txtPesquisa.addCss(css.setOutline("none"));
            this.txtPesquisa.addCss(css.setWidth(100, "%"));
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
            string strTitulo = "_cln_ref_nome_exibicao (_tbl_ref_cln_nome_exibicao)";

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