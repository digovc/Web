using System;
using System.Collections.Generic;
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

                #endregion Variáveis

                #region Ações

                try
                {
                    _strTitulo = value;

                    if (string.IsNullOrEmpty(strTitulo))
                    {
                        return;
                    }

                    _strTitulo = "_titulo - _app_nome";

                    _strTitulo = _strTitulo.Replace("_titulo", strTitulo);
                    _strTitulo = _strTitulo.Replace("_app_nome", AppWeb.i.strNome);

                    this.tagTitle.strConteudo = _strTitulo;
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

        private Tag tagBody
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

        #endregion Construtores

        #region Métodos

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

                if (this.lstCss.Count < 1)
                {
                    return;
                }

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
            #endregion Variáveis

            #region Ações
            try
            {
                if (this.booPagSimples) //TODO: Parei aqui.
                {

                    return;
                }

                this.addJsCodigo(this.getTagJsMain());

                if (AppWeb.getI().getBooDart())
                {

                    return;
                }

                for (JavaScriptTag tagJs : this.getLstTagJsOrdenado())
                {

                    if (tagJs == null)
                    {

                        continue;
                    }

                    tagJs.setTagPai(this.getTagHead());
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