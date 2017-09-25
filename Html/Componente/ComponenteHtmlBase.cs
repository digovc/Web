using NetZ.Web.Server.Arquivo.Css;
using System;
using System.IO;
using System.Text;

namespace NetZ.Web.Html.Componente
{
    public abstract class ComponenteHtmlBase : Div
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private bool _booLayoutFixo;

        internal bool booLayoutFixo
        {
            get
            {
                return _booLayoutFixo;
            }

            set
            {
                _booLayoutFixo = value;
            }
        }

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        public void salvar(string dir)
        {
            if (string.IsNullOrEmpty(dir))
            {
                return;
            }

            Directory.CreateDirectory(dir);

            var strPagNome = string.Format("tag_{0}.html", this.strNomeSimplificado);

            var dirCompleto = Path.Combine(dir, strPagNome);

            var strHtml = this.toHtml();

            var objUtf8Encoding = new UTF8Encoding(true);

            using (var objStreamWriter = new StreamWriter(dirCompleto, false, objUtf8Encoding))
            {
                objStreamWriter.Write(strHtml);
            }
        }

        protected override void addJs(LstTag<JavaScriptTag> lstJs)
        {
            base.addJs(lstJs);

            lstJs.Add(new JavaScriptTag(typeof(ComponenteHtmlBase), 110));

            this.addJsAutomatico(lstJs);
        }

        protected override void inicializar()
        {
            base.inicializar();

            this.booClazz = AppWebBase.i.booDesenvolvimento;

            if (this.booLayoutFixo)
            {
                this.inicializarLayoutFixo();
            }
        }

        protected virtual void inicializarLayoutFixo()
        {
        }

        protected override void setCss(CssArquivoBase css)
        {
            base.setCss(css);

            if (this.booLayoutFixo)
            {
                this.setCssLayoutFixo(css);
            }
        }

        protected virtual void setCssLayoutFixo(CssArquivoBase css)
        {
        }

        private void addJsAutomatico(LstTag<JavaScriptTag> lstJs)
        {
            this.addJsAutomatico(lstJs, this.GetType());
        }

        private void addJsAutomatico(LstTag<JavaScriptTag> lstJs, Type cls)
        {
            if (typeof(ComponenteHtmlBase).Equals(cls))
            {
                return;
            }

            if (cls.BaseType != null)
            {
                this.addJsAutomatico(lstJs, cls.BaseType);
            }

            var intOrdem = 111;

            if (!this.GetType().Assembly.FullName.Equals(typeof(ComponenteHtmlBase).Assembly.FullName))
            {
                intOrdem = 200;
            }

            lstJs.Add(new JavaScriptTag(cls, intOrdem));
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}