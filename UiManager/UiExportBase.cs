using DigoFramework;
using NetZ.Web;
using NetZ.Web.Html.Componente;
using NetZ.Web.Html.Pagina;
using NetZ.Web.Server.Arquivo.Css;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Web.UiManager
{
    public abstract class UiExportBase : Objeto
    {
        #region Constantes

        private const string DIR_FILE_UI_VERSAO = "res/ui_versao.json";

        #endregion Constantes

        #region Atributos

        private bool _booUiAlterada;
        private int _intVersao;
        private int _intVersaoAnterior;
        private List<Assembly> _lstDllUi;

        private bool booUiAlterada
        {
            get
            {
                return _booUiAlterada;
            }

            set
            {
                _booUiAlterada = value;
            }
        }

        private int intVersao
        {
            get
            {
                if (_intVersao != 0)
                {
                    return _intVersao;
                }

                _intVersao = this.getIntVersao();

                return _intVersao;
            }
        }

        private int intVersaoAnterior
        {
            get
            {
                if (_intVersaoAnterior != 0)
                {
                    return _intVersaoAnterior;
                }

                _intVersaoAnterior = this.getIntVersaoAnterior();

                return _intVersaoAnterior;
            }

            set
            {
                if (_intVersaoAnterior == value)
                {
                    return;
                }

                _intVersaoAnterior = value;

                this.setIntVersaoAnterior(_intVersaoAnterior);
            }
        }

        private List<Assembly> lstDllUi
        {
            get
            {
                if (_lstDllUi != null)
                {
                    return _lstDllUi;
                }

                _lstDllUi = this.getLstDllUi();

                return _lstDllUi;
            }
        }

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        public virtual bool getBooExportarCss()
        {
            return false;
        }

        public void iniciar()
        {
            if (this.intVersaoAnterior >= this.intVersao)
            {
                Log.i.info("A versão atual do HTML estático já foi exportada.");
                return;
            }

            this.inicializar();

            this.finalizar();
        }

        protected abstract int getIntVersao();

        protected abstract int getIntVersaoAnterior();

        protected virtual string getUrlPrefixCssMain()
        {
            return null;
        }

        protected abstract void inicializarLstDllUi(List<Assembly> lstDllUi);

        protected abstract void setIntVersaoAnterior(int intVersaoAnterior);

        private void exportarCss()
        {
            if (!this.getBooExportarCss())
            {
                return;
            }

            Log.i.info("Exportando o arquivo CSS ({0}).", CssMain.i.dirCompleto);

            CssMain.i.salvar(this.getUrlPrefixCssMain());
        }

        private void exportarHtml()
        {
            foreach (var dllUi in this.lstDllUi)
            {
                this.exportarHtml(dllUi);
            }
        }

        private void exportarHtml(Assembly dllUi)
        {
            if (dllUi == null)
            {
                return;
            }

            Log.i.info("Procurando páginas estáticas na biblioteca \"{0}\".", dllUi.ManifestModule.Name);

            foreach (var cls in dllUi.GetTypes())
            {
                this.exportarHtml(cls);
            }
        }

        private void exportarHtml(Type cls)
        {
            if (cls == null)
            {
                return;
            }

            if (!(typeof(PaginaHtmlBase).IsAssignableFrom(cls)))
            {
                return;
            }

            var objAttributeHtmlExport = cls.GetCustomAttribute(typeof(HtmlExport));

            if (objAttributeHtmlExport == null)
            {
                return;
            }

            var objHtml = Activator.CreateInstance(cls);

            var dirNamespace = objHtml.GetType().Namespace.ToLower();

            dirNamespace = dirNamespace.Substring((dirNamespace.IndexOf(".html.") + 6));

            dirNamespace = dirNamespace.Replace(".", "/");

            this.booUiAlterada = true;

            this.exportarHtmlPag(objHtml as PaginaHtmlBase, dirNamespace);
        }

        private void exportarHtmlPag(PaginaHtmlBase pag, string dirNamespace)
        {
            pag.salvar(AppWebBase.DIR_HTML + dirNamespace);
        }

        private void exportarHtmlTag(ComponenteHtmlBase tag, string dirNamespace)
        {
            tag.salvar(AppWebBase.DIR_HTML + dirNamespace);
        }

        private void finalizar()
        {
            this.intVersaoAnterior = this.intVersao;
        }

        private List<Assembly> getLstDllUi()
        {
            var lstDllUiResultado = new List<Assembly>();

            this.inicializarLstDllUi(lstDllUiResultado);

            return lstDllUiResultado;
        }

        private void inicializar()
        {
            this.exportarHtml();
            this.exportarCss();
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}