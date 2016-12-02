using NetZ.Web.Server.Arquivo.Css;

namespace NetZ.Web.Html.Componente.Painel
{
    public class PainelHtml : ComponenteHtml
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private bool _booMarkdown;
        private int _intTamanhoHorizontal;
        private int _intTamanhoVertical = 1;

        /// <summary>
        /// Indica se o conteúdo deste painel será convertido de Markdown para HTML.
        /// </summary>
        public bool booMarkdown
        {
            get
            {
                return _booMarkdown;
            }

            set
            {
                _booMarkdown = value;
            }
        }

        /// <summary>
        /// Indica o tamanho horizontal deste painel, tendo 200 pixels de largura cada unidade.
        /// <para>Esta propriedade adicionará o atributo CSS.width e o atributo CSS.float para tanto.</para>
        /// </summary>
        public int intTamanhoHorizontal
        {
            get
            {
                return _intTamanhoHorizontal;
            }

            set
            {
                _intTamanhoHorizontal = value;
            }
        }

        /// <summary>
        /// Indica o tamanho vertical deste painel, tendo 50 pixels de altura cada unidade.
        /// <para>Esta propriedade adicionará o atributo CSS.min-height para tanto.</para>
        /// </summary>
        public int intTamanhoVertical
        {
            get
            {
                return _intTamanhoVertical;
            }

            set
            {
                _intTamanhoVertical = value;
            }
        }

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        protected override void addCss(LstTag<CssTag> lstCss)
        {
            base.addCss(lstCss);

            this.addCssMarkdown(lstCss);
        }

        protected override void addJs(JavaScriptTag js)
        {
            base.addJs(js);

            this.addJsMarkdown(js);
        }

        protected override void addJsDebug(LstTag<JavaScriptTag> lstJsDebug)
        {
            base.addJsDebug(lstJsDebug);

            lstJsDebug.Add(new JavaScriptTag(typeof(PainelHtml), 114));

            this.addJsMarkdown(lstJsDebug);
        }

        protected override void setCss(CssArquivo css)
        {
            base.setCss(css);

            this.setCssWidth(css);

            this.setCssMinHeight(css);

            this.addCss(css.setTextAlign("center"));
        }

        private void addCssMarkdown(LstTag<CssTag> lstCss)
        {
            if (!this.booMarkdown)
            {
                return;
            }

            CssTag cssMarkdown = new CssTag("res/css/markdown.css");

            CssTag cssMarkdownMonoBlue = new CssTag("res/css/markdown-mono-blue.css");

            lstCss.Add(cssMarkdown);
            lstCss.Add(cssMarkdownMonoBlue);
        }

        private void addJsMarkdown(LstTag<JavaScriptTag> lstJs)
        {
            if (!this.booMarkdown)
            {
                return;
            }

            lstJs.Add(new JavaScriptTag("res/js/lib/JDigo/lib/Markdown.Converter.js"));
            lstJs.Add(new JavaScriptTag("res/js/lib/JDigo/lib/Markdown.Extra.js"));
            lstJs.Add(new JavaScriptTag("res/js/lib/JDigo/lib/highlight.pack.js"));
        }

        private void addJsMarkdown(JavaScriptTag js)
        {
            if (!this.booMarkdown)
            {
                return;
            }

            string strJs = string.Empty;

            strJs += "var objMdConverter = new Markdown.Converter();";
            strJs += "Markdown.Extra.init(objMdConverter);";
            strJs += "var strHtml = objMdConverter.makeHtml($('#_pnl_id').html());";
            strJs += "$('#_pnl_id').html(strHtml);";
            strJs += "hljs.initHighlightingOnLoad();";

            strJs = strJs.Replace("_pnl_id", this.strId);

            js.addJs(strJs);
        }

        private void setCssMinHeight(CssArquivo css)
        {
            if (this.intTamanhoVertical < 1)
            {
                return;
            }

            this.addCss(css.setMinHeight(50 * this.intTamanhoVertical));
        }

        private void setCssWidth(CssArquivo css)
        {
            if (this.intTamanhoHorizontal < 1)
            {
                return;
            }

            this.addCss(css.setFloat("left"));
            this.addCss(css.setWidth(200 * this.intTamanhoHorizontal));
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}