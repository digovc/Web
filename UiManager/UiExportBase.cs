using DigoFramework;
using NetZ.Web;
using NetZ.Web.Html.Componente;
using NetZ.Web.Html.Pagina;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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
        private Dictionary<string, int> _dicHtmlVersao;
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

        private Dictionary<string, int> dicHtmlVersao
        {
            get
            {
                if (_dicHtmlVersao != null)
                {
                    return _dicHtmlVersao;
                }

                _dicHtmlVersao = this.getDicHtmlVersao();

                return _dicHtmlVersao;
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

        public void iniciar()
        {
            this.inicializar();
            this.finalizar();
        }

        protected abstract void inicializarLstDllUi(List<Assembly> lstDllUi);

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

            if (!(typeof(PaginaHtml).IsAssignableFrom(cls)))
            {
                return;
            }

            var objAttributeHtmlExport = cls.GetCustomAttribute(typeof(HtmlExport));

            if (objAttributeHtmlExport == null)
            {
                return;
            }

            var kpvHtmlVersao = this.getKpvHtmlVersao(cls);

            if (!(objAttributeHtmlExport as HtmlExport).booExportarSempre && ((objAttributeHtmlExport as HtmlExport).intVersao <= kpvHtmlVersao.Value))
            {
                return;
            }

            this.dicHtmlVersao.Remove(kpvHtmlVersao.Key);

            this.dicHtmlVersao.Add(cls.FullName, (objAttributeHtmlExport as HtmlExport).intVersao);

            var objHtml = Activator.CreateInstance(cls);

            var dirNamespace = objHtml.GetType().Namespace.ToLower();

            dirNamespace = dirNamespace.Substring((dirNamespace.IndexOf(".html.") + 6));

            dirNamespace = dirNamespace.Replace(".", "/");

            this.booUiAlterada = true;

            this.exportarHtmlPag(objHtml as PaginaHtml, dirNamespace);
        }

        private void exportarHtmlPag(PaginaHtml pag, string dirNamespace)
        {
            Log.i.info("Exportando a página \"{0}\".", pag.strNome);

            pag.salvar(AppWebBase.DIR_HTML + dirNamespace);
        }

        private void exportarHtmlTag(ComponenteHtml tag, string dirNamespace)
        {
            tag.salvar(AppWebBase.DIR_HTML + dirNamespace);
        }

        private void finalizar()
        {
            this.finalizarSalvarJson();
        }

        private void finalizarSalvarJson()
        {
            if (!this.booUiAlterada)
            {
                Log.i.info("Nenhuma página estática foi alterada.");
                return;
            }

            File.WriteAllText(DIR_FILE_UI_VERSAO, JsonConvert.SerializeObject(this.dicHtmlVersao));
        }

        private Dictionary<string, int> getDicHtmlVersao()
        {
            if (!File.Exists(DIR_FILE_UI_VERSAO))
            {
                return new Dictionary<string, int>();
            }

            return JsonConvert.DeserializeObject<Dictionary<string, int>>(File.ReadAllText(DIR_FILE_UI_VERSAO));
        }

        private KeyValuePair<string, int> getKpvHtmlVersao(Type cls)
        {
            foreach (var kpv in this.dicHtmlVersao)
            {
                if (kpv.Key.Equals(cls.FullName))
                {
                    return kpv;
                }
            }

            return this.getObjHtmlVersaoNovo(cls);
        }

        private List<Assembly> getLstDllUi()
        {
            var lstDllUiResultado = new List<Assembly>();

            this.inicializarLstDllUi(lstDllUiResultado);

            return lstDllUiResultado;
        }

        private KeyValuePair<string, int> getObjHtmlVersaoNovo(Type cls)
        {
            return new KeyValuePair<string, int>(cls.FullName, -1);
        }

        private void inicializar()
        {
            this.exportarHtml();
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}