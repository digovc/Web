﻿using NetZ.Web.DataBase.Dominio;
using NetZ.Web.DataBase.Dominio.Documentacao;
using NetZ.Web.Html.Componente.Documentacao;
using NetZ.Web.Server;
using NetZ.Web.Server.Ajax;
using System;

namespace NetZ.Web.Html.Pagina.Documentacao
{
    public abstract class PagDocumentacaoBase : PagMobile
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private string _dirDocumentacao;
        private ActionBarDocumentacao _divActionBarDocumentacao;
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

        private ActionBarDocumentacao divActionBarDocumentacao
        {
            get
            {
                if (_divActionBarDocumentacao != null)
                {
                    return _divActionBarDocumentacao;
                }

                _divActionBarDocumentacao = new ActionBarDocumentacao();

                return _divActionBarDocumentacao;
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

            tagJs.addConstante((typeof(SrvAjaxDocumentacao).Name + "_intPorta"), this.getIntSrvAjaxDocumentacaoPorta());
        }

        protected override void addJs(LstTag<JavaScriptTag> lstJs)
        {
            base.addJs(lstJs);

            lstJs.Add(new JavaScriptTag(typeof(DocumentacaoDominioBase), 151));
            lstJs.Add(new JavaScriptTag(typeof(DominioWebBase), 150));
            lstJs.Add(new JavaScriptTag(typeof(EmailRegistroDominio), 152));
            lstJs.Add(new JavaScriptTag(typeof(Interlocutor)));
            lstJs.Add(new JavaScriptTag(typeof(SrvAjaxBase), 102));
            lstJs.Add(new JavaScriptTag(typeof(SrvAjaxDocumentacao), 103));
        }

        protected abstract decimal getIntSrvAjaxDocumentacaoPorta();

        protected override void inicializar()
        {
            base.inicializar();

            if (!this.dirDocumentacao.StartsWith(AppWebBase.DIR_MARKDOWN))
            {
                throw new Exception(string.Format("O diretório da documentação precisa ser relativo à pasta \"{0}\".", AppWebBase.DIR_MARKDOWN));
            }

            this.divActionBarDocumentacao.strTitulo = this.strNome;
        }

        protected override void montarLayout()
        {
            base.montarLayout();

            this.divActionBarDocumentacao.setPai(this);
            this.divSumario.setPai(this);

            this.divViewer.setPai(this);
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}