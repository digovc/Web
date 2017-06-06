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

            if (this.getBooJs())
            {
                lstJs.Add(new JavaScriptTag(this.GetType(), this.getIntJsOrdem()));
            }
        }

        protected virtual bool getBooJs()
        {
            return false;
        }

        protected virtual int getIntJsOrdem()
        {
            return 200;
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}