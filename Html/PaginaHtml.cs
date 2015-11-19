using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NetZ.SistemaBase;

namespace NetZ.Web.Html
{
    public class PaginaHtml : Objeto
    {
        #region Constantes

        //public const string DIR_JS_LIB_DATE = "res/js/lib/date.js";
        //public const string DIR_JS_LIB_MD5 = "res/js/lib/JDigo/lib/md5.js";
        //public const string DIR_JS_PAG_HTML = "res/js/html/PaginaHtml.js";
        //public const string DIR_JS_USUARIO = "res/js/Usuario.js";

        public const string DIR_JS_APP_WEB = "res/js/Web.TypeScript/AppWeb.js";
        public const string DIR_JS_ERRO = "res/js/Web.TypeScript/erro/Erro.js";
        public const string DIR_JS_LIB_JQUERY = "res/js/lib/jquery-2.1.3.min.js";
        public const string DIR_JS_LIB_JQUERY_UI = "res/js/lib/jquery-ui.min.js";
        public const string DIR_JS_OBJETO = "res/js/Web.TypeScript/Objeto.js";
        public const string DIR_JS_PAGINA_HTML = "res/js/Web.TypeScript/html/PaginaHtml.js";
        public const string DIR_JS_TAG = "res/js/Web.TypeScript/html/Tag.js";
        public const string DIR_JS_UTILS = "res/js/Web.TypeScript/Utils.js";

        #endregion Constantes

        #region Atributos

        private static PaginaHtml _i;

        private bool _booPagSimples;
        private LstTag<CssTag> _lstCss;
        private LstTag<JavaScriptTag> _lstJs;
        private string _srcIcone = "res/media/ico/favicon.ico";
        private string _strTitulo;
        private Tag _tagBody;
        private Tag _tagDocType;
        private Tag _tagHead;
        private Tag _tagHtml;
        private Tag _tagIcon;
        private JavaScriptTag _tagJs;
        private Tag _tagMetaContent;
        private Tag _tagMetaHttpEquiv;
        private Tag _tagTitle;

        public static PaginaHtml i
        {
            get
            {
                return _i;
            }

            set
            {
                _i = value;
            }
        }

        internal LstTag<CssTag> lstCss
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_lstCss != null)
                    {
                        return _lstCss;
                    }

                    _lstCss = new LstTag<CssTag>();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _lstCss;
            }
        }

        internal LstTag<JavaScriptTag> lstJs
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_lstJs != null)
                    {
                        return _lstJs;
                    }

                    _lstJs = new LstTag<JavaScriptTag>();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _lstJs;
            }
        }

        internal Tag tagBody
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_tagBody != null)
                    {
                        return _tagBody;
                    }

                    _tagBody = new Tag("body");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _tagBody;
            }
        }

        internal JavaScriptTag tagJs
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_tagJs != null)
                    {
                        return _tagJs;
                    }

                    _tagJs = new JavaScriptTag();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _tagJs;
            }
        }

        protected string srcIcone
        {
            get
            {
                return _srcIcone;
            }

            set
            {
                _srcIcone = value;
            }
        }

        /// <summary>
        /// Indica o título que será mostrado na aba do navegador para identificar esta página.
        /// </summary>
        protected string strTitulo
        {
            get
            {
                return _strTitulo;
            }

            set
            {
                _strTitulo = value;
            }
        }

        private bool booPagSimples
        {
            get
            {
                return _booPagSimples;
            }

            set
            {
                _booPagSimples = value;
            }
        }

        private Tag tagDocType
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_tagDocType != null)
                    {
                        return _tagDocType;
                    }

                    _tagDocType = new Tag("!DOCTYPE");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _tagDocType;
            }
        }

        private Tag tagHead
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_tagHead != null)
                    {
                        return _tagHead;
                    }

                    _tagHead = new Tag("head");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _tagHead;
            }
        }

        private Tag tagHtml
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_tagHtml != null)
                    {
                        return _tagHtml;
                    }

                    _tagHtml = new Tag("html");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _tagHtml;
            }
        }

        private Tag tagIcon
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_tagIcon != null)
                    {
                        return _tagIcon;
                    }

                    _tagIcon = new Tag("link");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _tagIcon;
            }
        }

        private Tag tagMetaContent
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_tagMetaContent != null)
                    {
                        return _tagMetaContent;
                    }

                    _tagMetaContent = new Tag("meta");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _tagMetaContent;
            }
        }

        private Tag tagMetaHttpEquiv
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_tagMetaHttpEquiv != null)
                    {
                        return _tagMetaHttpEquiv;
                    }

                    _tagMetaHttpEquiv = new Tag("meta");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _tagMetaHttpEquiv;
            }
        }

        private Tag tagTitle
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_tagTitle != null)
                    {
                        return _tagTitle;
                    }

                    _tagTitle = new Tag("title");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _tagTitle;
            }
        }

        #endregion Atributos

        #region Construtores

        public PaginaHtml(string strNome)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                PaginaHtml.i = this;

                this.strNome = strNome;
                this.strTitulo = this.strNome;
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

        #endregion Construtores

        #region Métodos

        public void addJs(string strJsCodigo)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (string.IsNullOrEmpty(strJsCodigo))
                {
                    return;
                }

                this.tagJs.addJs(strJsCodigo);
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

        public string toHtml()
        {
            #region Variáveis

            string strBody;
            string strHead;
            StringBuilder stbConteudo;
            StringBuilder stbResultado;

            #endregion Variáveis

            #region Ações

            try
            {
                this.inicializar();
                this.finalizar();

                strBody = this.tagBody.toHtml();

                this.addCss();
                this.addJs();

                strHead = this.tagHead.toHtml();

                stbConteudo = new StringBuilder();

                stbConteudo.Append("_head_body");

                stbConteudo.Replace("_head", strHead);
                stbConteudo.Replace("_body", strBody);

                this.tagHtml.strConteudo = stbConteudo.ToString();

                stbResultado = new StringBuilder();

                stbResultado.Append("_tag_doc_type_tag_html");

                stbResultado.Replace("_tag_doc_type", this.tagDocType.toHtml());
                stbResultado.Replace("_tag_html", this.tagHtml.toHtml());

                return stbResultado.ToString();
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

        /// <summary>
        /// Adiciona uma classe para lista de classes da tag body desta página para fazer referência
        /// a algum estilo CSS.
        /// </summary>
        /// <param name="strClassCss">Classe que faz referência a alguma regra CSS.</param>
        protected void addCss(string strClassCss)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (string.IsNullOrEmpty(strClassCss))
                {
                    return;
                }

                this.tagBody.addCss(strClassCss);
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

        protected virtual void addCss(LstTag<CssTag> lstCss)
        {
        }

        protected virtual void addJs(LstTag<JavaScriptTag> lstJs)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                lstJs.Add(!(string.IsNullOrEmpty(this.getSrcJsBoot())) ? new JavaScriptTag(this.getSrcJsBoot(), 999) : null);

                lstJs.Add(new JavaScriptTag(DIR_JS_APP_WEB, 104));
                lstJs.Add(new JavaScriptTag(DIR_JS_ERRO, 102));
                lstJs.Add(new JavaScriptTag(DIR_JS_LIB_JQUERY, 0));
                lstJs.Add(new JavaScriptTag(DIR_JS_LIB_JQUERY_UI, 0));
                lstJs.Add(new JavaScriptTag(DIR_JS_OBJETO, 100));
                lstJs.Add(new JavaScriptTag(DIR_JS_PAGINA_HTML, 102));
                lstJs.Add(new JavaScriptTag(DIR_JS_TAG, 103));
                lstJs.Add(new JavaScriptTag(DIR_JS_UTILS, 101));

                lstJs.Add(this.tagJs);
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

        protected void addJs(JavaScriptTag tagJs)
        {
            // TODO: É necessário as informações dos objetos básicos do lado do cliente (exemplo:
            //       appWeb, usr, msgInformacao, msgLoad, msgErro, msgSucesso).
        }

        /// <summary>
        /// Método que será chamado após <see cref="montarLayout"/> para que os ajustes finais sejam feitos.
        /// </summary>
        protected virtual void finalizar()
        {
        }

        protected virtual string getSrcJsBoot()
        {
            return null;
        }

        /// <summary>
        /// Este método é chamado antes da montagem do HTML desta página e pode ser utilizado para a
        /// inicialização das propriedades dessa ou das tags filhas.
        /// </summary>
        protected virtual void inicializar()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.tagDocType.addAtt("html");
                this.tagDocType.booBarraFinal = false;
                this.tagDocType.booTagDupla = false;

                this.tagHtml.addAtt("xmlns", "http://www.w3.org/1999/xhtml");
                this.tagHtml.addAtt("lang", "pt-br");

                this.tagIcon.addAtt("rel", "shortcut icon");
                this.tagIcon.addAtt("href", this.srcIcone);
                this.tagIcon.addAtt("type", "image/x-icon");

                this.tagJs.intOrdem = 100;

                this.tagMetaContent.addAtt("content", this.strNomeExibicao);

                this.tagMetaHttpEquiv.addAtt("http-equiv", "Content-Type");

                this.tagTitle.strConteudo = this.getStrTituloFormatado();

                this.montarLayout();
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

        protected virtual void montarLayout()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.setCss(CssTag.i);

                this.tagTitle.setPai(this.tagHead);
                this.tagMetaContent.setPai(this.tagHead);
                this.tagMetaHttpEquiv.setPai(this.tagHead);
                this.tagIcon.setPai(this.tagHead);

                CssTag.i.setPai(this.tagHead);
                CssTag.iImpressao.setPai(this.tagHead);
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

        protected virtual void setCss(CssTag css)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.tagBody.addCss(css.setMargin(0));
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

        private void addCss()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (this.booPagSimples)
                {
                    return;
                }

                this.addCss(this.lstCss);

                foreach (CssTag cssTag in this.lstCss)
                {
                    if (cssTag == null)
                    {
                        continue;
                    }

                    cssTag.setPai(this.tagHead);
                }
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

        private void addJs()
        {
            #region Variáveis

            List<JavaScriptTag> lstJsOrdenado;

            #endregion Variáveis

            #region Ações

            try
            {
                if (this.booPagSimples)
                {
                    return;
                }

                this.addJs(this.lstJs);
                this.addJs(this.tagJs);

                lstJsOrdenado = this.lstJs.OrderBy((o) => o.intOrdem).ToList();

                foreach (JavaScriptTag tagJs in lstJsOrdenado)
                {
                    if (tagJs == null)
                    {
                        continue;
                    }

                    tagJs.setPai(this.tagHead);
                }
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

        private string getStrTituloFormatado()
        {
            #region Variáveis

            string strResultado;

            #endregion Variáveis

            #region Ações

            try
            {
                strResultado = "_titulo - _app_nome";

                strResultado = strResultado.Replace("_titulo", this.strTitulo);
                strResultado = strResultado.Replace("_app_nome", AppWeb.i.strNome);

                return strResultado;
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