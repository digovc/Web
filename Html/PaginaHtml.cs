using System;
using System.Collections.Generic;
using System.Linq;
using NetZ.SistemaBase;

namespace NetZ.Web.Html
{
    public class PaginaHtml : Objeto
    {
        #region Constantes

        public const string DIR_JS_APP_WEB = "res/js/lib/JDigo/AppWeb.js";
        public const string DIR_JS_ERRO = "res/js/lib/JDigo/erro/Erro.js";
        public const string DIR_JS_LIB_DATE = "res/js/lib/JDigo/lib/date.js";
        public const string DIR_JS_LIB_JQUERY = "res/js/lib/JDigo/lib/jquery-2.1.3.min.js";
        public const string DIR_JS_LIB_JQUERY_UI = "res/js/lib/JDigo/lib/jquery-ui.min.js";
        public const string DIR_JS_LIB_MD5 = "res/js/lib/JDigo/lib/md5.js";
        public const string DIR_JS_LST_ERRO = "res/js/lib/JDigo/lista/LstStrErro.js";
        public const string DIR_JS_MENSAGEM = "res/js/lib/JDigo/html/componente/Mensagem.js";
        public const string DIR_JS_OBJ_WS_INTERLOCUTOR = "res/js/lib/JDigo/websocket/ObjWsInterlocutor.js";
        public const string DIR_JS_OBJETO = "res/js/lib/JDigo/Objeto.js";
        public const string DIR_JS_PAG_HTML = "res/js/lib/JDigo/html/PaginaHtml.js";
        public const string DIR_JS_USUARIO = "res/js/lib/JDigo/Usuario.js";
        public const string DIR_JS_UTILS = "res/js/lib/JDigo/Utils.js";
        public const string DIR_JS_WEB_SOCKET = "res/js/lib/JDigo/websocket/WebSocketMain.js";

        #endregion Constantes

        #region Atributos

        private bool _booPagSimples;
        private List<CssTag> _lstCss;
        private List<JavaScriptTag> _lstJs;
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

        private List<CssTag> lstCss
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

                    _lstCss = new List<CssTag>();
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

        private List<JavaScriptTag> lstJs
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

                    _lstJs = new List<JavaScriptTag>();
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

        private string srcIcone
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

        private string strTitulo
        {
            get
            {
                return _strTitulo;
            }

            set
            {
                #region Variáveis

                string strTituloFormatado;

                #endregion Variáveis

                #region Ações

                try
                {
                    _strTitulo = value;

                    if (string.IsNullOrEmpty(_strTitulo))
                    {
                        return;
                    }

                    strTituloFormatado = "_titulo - _app_nome";

                    strTituloFormatado = strTituloFormatado.Replace("_titulo", _strTitulo);
                    strTituloFormatado = strTituloFormatado.Replace("_app_nome", AppWeb.i.strNome);

                    this.tagTitle.strConteudo = strTituloFormatado;
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
        }

        protected Tag tagBody
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

                    _tagBody.addCss(CssTag.i.);
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

                    _tagDocType.addAtt("html");
                    _tagDocType.booBarraFinal = false;
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

                    _tagHtml.addAtt("xmlns", "http://www.w3.org/1999/xhtml");
                    _tagHtml.addAtt("lang", "pt-br");
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

                    _tagIcon.addAtt("rel", "shortcut icon");
                    _tagIcon.addAtt("href", this.srcIcone);
                    _tagIcon.addAtt("type", "image/x-icon");
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

        private JavaScriptTag tagJs
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

                    _tagJs.intOrdem = 100;

                    this.lstJs.Add(_tagJs);
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

                    _tagMetaContent.addAtt("content", this.strNomeExibicao);
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

                    _tagMetaHttpEquiv.addAtt("http-equiv", "Content-Type");
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

                    _tagTitle.strConteudo = "Página sem nome";
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

        public void addJsCodigo(string strJsCodigo)
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
            string strConteudo;
            string strHead;
            string strResultado;

            #endregion Variáveis

            #region Ações

            try
            {
                this.montarLayout();

                strBody = this.tagBody.toHtml();

                this.addCss();
                this.addJs();

                strHead = this.tagHead.toHtml();

                strConteudo = "_head_body";

                strConteudo = strConteudo.Replace("_head", strHead);
                strConteudo = strConteudo.Replace("_body", strBody);

                this.tagHtml.strConteudo = strConteudo;

                strResultado = "_tag_doc_type_tag_html";

                strResultado = strResultado.Replace("_tag_doc_type", this.tagDocType.toHtml());
                strResultado = strResultado.Replace("_tag_html", this.tagHtml.toHtml());

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

        protected virtual void addCss(List<CssTag> lstCss)
        {
        }

        protected void addJs(List<JavaScriptTag> lstJs)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                lstJs.Add(new JavaScriptTag(DIR_JS_LIB_JQUERY));
                lstJs.Add(new JavaScriptTag(DIR_JS_LIB_JQUERY_UI));
                lstJs.Add(new JavaScriptTag(DIR_JS_LIB_MD5));
                lstJs.Add(new JavaScriptTag(DIR_JS_LIB_DATE));
                lstJs.Add(new JavaScriptTag(DIR_JS_LST_ERRO));
                lstJs.Add(new JavaScriptTag(DIR_JS_OBJETO));
                lstJs.Add(new JavaScriptTag(DIR_JS_ERRO));
                lstJs.Add(new JavaScriptTag(DIR_JS_UTILS));
                lstJs.Add(new JavaScriptTag(DIR_JS_APP_WEB));
                lstJs.Add(new JavaScriptTag(DIR_JS_WEB_SOCKET));
                lstJs.Add(new JavaScriptTag(DIR_JS_OBJ_WS_INTERLOCUTOR));
                lstJs.Add(new JavaScriptTag(DIR_JS_USUARIO));
                lstJs.Add(new JavaScriptTag(DIR_JS_PAG_HTML));
                lstJs.Add(new JavaScriptTag(DIR_JS_MENSAGEM));
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

        protected void addJsCodigo(JavaScriptTag tagJs)
        {
            // TODO: É necessário as informações dos objetos básicos do lado do cliente (exemplo:
            //       appWeb, usr, msgInformacao, msgLoad, msgErro, msgSucesso).
        }

        protected virtual void montarLayout()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.tagTitle.tagPai = this.tagHead;
                this.tagMetaContent.tagPai = this.tagHead;
                this.tagMetaHttpEquiv.tagPai = this.tagHead;
                this.tagIcon.tagPai = this.tagHead;

                CssTag.i.tagPai = this.tagHead;
                CssTag.iImpressao.tagPai = this.tagHead;
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

                    cssTag.tagPai = this.tagHead;
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
                this.addJsCodigo(this.tagJs);

                lstJsOrdenado = this.lstJs.OrderBy((o) => o.intOrdem).ToList();

                foreach (JavaScriptTag tagJs in lstJsOrdenado)
                {
                    if (tagJs == null)
                    {
                        continue;
                    }

                    tagJs.tagPai = this.tagHead;
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

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}