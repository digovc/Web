using System;
using System.IO;
using System.Text;

namespace NetZ.Web.Html.Componente
{
    public abstract class ComponenteHtml : Div
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

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

            lstJs.Add(new JavaScriptTag(typeof(ComponenteHtml), 110));

            this.addJsAutomatico(lstJs);
        }

        private void addJsAutomatico(LstTag<JavaScriptTag> lstJs)
        {
            this.addJsAutomatico(lstJs, this.GetType());
        }

        private void addJsAutomatico(LstTag<JavaScriptTag> lstJs, Type cls)
        {
            if (typeof(ComponenteHtml).Equals(cls))
            {
                return;
            }

            if (cls.BaseType != null)
            {
                this.addJsAutomatico(lstJs, cls.BaseType);
            }

            var intOrdem = 111;

            if (!this.GetType().Assembly.FullName.Equals(typeof(ComponenteHtml).Assembly.FullName))
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