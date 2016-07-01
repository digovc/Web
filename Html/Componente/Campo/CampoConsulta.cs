﻿using NetZ.Web.Html.Componente.Botao;
using NetZ.Web.Html.Componente.Botao.Mini;
using NetZ.Web.Server.Arquivo.Css;

namespace NetZ.Web.Html.Componente.Campo
{
    public class CampoConsulta : CampoComboBox
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private BotaoMenuMini _btnMenu;
        private Input _txtPesquisa;

        private BotaoCircular btnMenu
        {
            get
            {
                if (_btnMenu != null)
                {
                    return _btnMenu;
                }

                _btnMenu = new BotaoMenuMini();

                return _btnMenu;
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

            lstJs.Add(new JavaScriptTag(typeof(CampoConsulta), 132));
        }

        protected override void atualizarCln()
        {
            base.atualizarCln();

            if (this.cln == null)
            {
                return;
            }

            this.atualizarClnClnRef();
        }

        protected override void atualizarStrId()
        {
            base.atualizarStrId();

            if (string.IsNullOrEmpty(this.strId))
            {
                return;
            }

            this.btnMenu.strId = (this.strId + "_btnMenu");
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
            this.btnMenu.setPai(this.divInputContainer);
        }

        protected override void setCss(CssArquivo css)
        {
            base.setCss(css);

            this.cmb.addCss(css.setDisplay("none"));

            this.btnMenu.addCss(css.setPosition("absolute"));
            this.btnMenu.addCss(css.setRight(-1));
            this.btnMenu.addCss(css.setTop(3));

            this.txtPesquisa.addCss(css.setBorder(0));
            this.txtPesquisa.addCss(css.setBorderBottom(1, "solid", AppWeb.i.objTema.corTema));
            this.txtPesquisa.addCss(css.setOutLine("none"));
            this.txtPesquisa.addCss(css.setWidth(100, "%"));
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

            this.atualizarClnClnRefStrTitulo();

            this.addAtt("tbl_web_ref_nome", this.cln.clnRef.tbl.viwPrincipal.strNomeSql);
        }

        private void atualizarClnClnRefStrTitulo()
        {
            string strTitulo = "_cln_ref_nome (_tbl_ref_cln_nome_exibicao)";

            strTitulo = strTitulo.Replace("_cln_ref_nome", this.cln.clnRef.tbl.strNomeExibicao);
            strTitulo = strTitulo.Replace("_tbl_ref_cln_nome_exibicao", this.cln.clnRef.tbl.clnNome.strNomeExibicao);

            this.strTitulo = strTitulo;
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}