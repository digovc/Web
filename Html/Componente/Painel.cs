using System;

namespace NetZ.Web.Html.Componente
{
    public class Painel : ComponenteHtml
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private bool _booMarkdown;

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

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        protected override void addCss(LstTag<CssTag> lstCss)
        {
            base.addCss(lstCss);

            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.addCssMarkdown(lstCss);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion Ações
        }

        protected override void addJs(LstTag<JavaScriptTag> lstJs)
        {
            base.addJs(lstJs);

            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                lstJs.Add(new JavaScriptTag(AppWeb.DIR_JS_PAINEL));

                this.addJsMarkdown(lstJs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion Ações
        }

        protected override void addJs(JavaScriptTag js)
        {
            base.addJs(js);

            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.addJsMarkdown(js);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion Ações
        }

        protected override void setCss(CssTag css)
        {
            base.setCss(css);

            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.addCss(css.setTextAlign("center"));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion Ações
        }

        private void addCssMarkdown(LstTag<CssTag> lstCss)
        {
            #region Variáveis

            CssTag cssMarkdown;
            CssTag cssMarkdownMonoBlue;

            #endregion Variáveis

            #region Ações

            try
            {
                if (!this.booMarkdown)
                {
                    return;
                }

                cssMarkdown = new CssTag();

                cssMarkdown.strHref = "res/css/markdown.css";

                cssMarkdownMonoBlue = new CssTag();

                cssMarkdownMonoBlue.strHref = "res/css/markdown-mono-blue.css";

                lstCss.Add(cssMarkdown);
                lstCss.Add(cssMarkdownMonoBlue);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion Ações
        }

        private void addJsMarkdown(LstTag<JavaScriptTag> lstJs)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (!this.booMarkdown)
                {
                    return;
                }

                lstJs.Add(new JavaScriptTag("res/js/lib/JDigo/lib/Markdown.Converter.js"));
                lstJs.Add(new JavaScriptTag("res/js/lib/JDigo/lib/Markdown.Extra.js"));
                lstJs.Add(new JavaScriptTag("res/js/lib/JDigo/lib/highlight.pack.js"));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion Ações
        }

        private void addJsMarkdown(JavaScriptTag js)
        {
            string strJs;

            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (!this.booMarkdown)
                {
                    return;
                }

                strJs = string.Empty;

                strJs += "var objMdConverter = new Markdown.Converter();";
                strJs += "Markdown.Extra.init(objMdConverter);";
                strJs += "var strHtml = objMdConverter.makeHtml($('#_pnl_id').html());";
                strJs += "$('#_pnl_id').html(strHtml);";
                strJs += "hljs.initHighlightingOnLoad();";

                strJs = strJs.Replace("_pnl_id", this.strId);

                js.addJs(strJs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion Ações
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}