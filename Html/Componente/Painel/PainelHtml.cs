using System;
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
                lstJs.Add(new JavaScriptTag(typeof(PainelHtml), 114));

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

        protected override void setCss(CssArquivo css)
        {
            base.setCss(css);

            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.setCssWidth(css);

                this.setCssMinHeight(css);

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
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (this.intTamanhoHorizontal < 1)
                {
                    return;
                }

                this.addCss(css.setFloat("left"));
                this.addCss(css.setWidth(200 * this.intTamanhoHorizontal));
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