﻿using NetZ.Web.DataBase.Dominio;
using NetZ.Web.DataBase.Dominio.Documentacao;
using NetZ.Web.Html.Componente.Markdown;
using NetZ.Web.Html.Componente.Mobile;
using NetZ.Web.Server.Ajax;
using System;

namespace NetZ.Web.Html.Pagina
{
    public abstract class PagDocumentacaoBase : PagMobile
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private string _dirDocumentacao;
        private ActionBar _divActionBar;
        private Sumario _divSumario;
        private Viewer _divViewer;

        internal string dirDocumentacao
        {
            get
            {
                if (_dirDocumentacao != null)
                {
                    return _dirDocumentacao;
                }

                _dirDocumentacao = this.getDirDocumentacao();

                return _dirDocumentacao;
            }
        }

        private ActionBar divActionBar
        {
            get
            {
                if (_divActionBar != null)
                {
                    return _divActionBar;
                }

                _divActionBar = new ActionBar();

                return _divActionBar;
            }
        }

        private Sumario divSumario
        {
            get
            {
                if (_divSumario != null)
                {
                    return _divSumario;
                }

                _divSumario = new Sumario(this);

                return _divSumario;
            }
        }

        private Viewer divViewer
        {
            get
            {
                if (_divViewer != null)
                {
                    return _divViewer;
                }

                _divViewer = new Viewer();

                return _divViewer;
            }
        }

        #endregion Atributos

        #region Construtores

        protected PagDocumentacaoBase(string strNome) : base(strNome)
        {
        }

        #endregion Construtores

        #region Métodos

        public abstract string getDirDocumentacao();

        protected override void addConstante(JavaScriptTag tagJs)
        {
            base.addConstante(tagJs);

            tagJs.addConstante((typeof(SrvAjaxDocumentacao).Name + "_intPorta"), ConfigWebBase.i.intSrvAjaxDocumentacao);
        }

        protected override void addCss(LstTag<CssTag> lstCss)
        {
            base.addCss(lstCss);

            lstCss.Add(new CssTag(AppWebBase.DIR_CSS + "github-markdown.css"));
        }

        protected override void addJsDebug(LstTag<JavaScriptTag> lstJsDebug)
        {
            base.addJsDebug(lstJsDebug);

            lstJsDebug.Add(new JavaScriptTag(typeof(DocumentacaoDominioBase), 151));
            lstJsDebug.Add(new JavaScriptTag(typeof(DominioWebBase), 150));
            lstJsDebug.Add(new JavaScriptTag(typeof(EmailRegistroDominio), 152));
            lstJsDebug.Add(new JavaScriptTag(typeof(PagDocumentacaoBase), 104));
            lstJsDebug.Add(new JavaScriptTag(typeof(SrvAjaxDocumentacao), 103));

            lstJsDebug.Add(new JavaScriptTag((AppWebBase.DIR_JS_LIB + "marked.min.js")));
        }

        protected override void inicializar()
        {
            base.inicializar();

            if (!this.dirDocumentacao.StartsWith(SrvAjaxDocumentacao.DIR_MARKDOWN))
            {
                throw new Exception(string.Format("O diretório da documentação precisa ser relativo à pasta \"{0}\".", SrvAjaxDocumentacao.DIR_MARKDOWN));
            }

            this.divActionBar.strTitulo = this.strNome;
        }

        protected override void montarLayout()
        {
            base.montarLayout();

            this.divActionBar.setPai(this);
            this.divSumario.setPai(this);

            this.divViewer.setPai(this);
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}