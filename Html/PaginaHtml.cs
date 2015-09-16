using System;
using System.Collections.Generic;

namespace NetZ.Web.Html
{
    public class PaginaHtml
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

        private static PaginaHtml _i;

        public static PaginaHtml i
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_i != null)
                    {
                        return _i;
                    }

                    _i = new PaginaHtml();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _i;
            }

            set
            {
                _i = value;
            }
        }


        private bool _booPagSimples;
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


        private List<CssTag> _lstCss;
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


        private List<JavaScriptTag> _lstJs;
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


        private string _srcIcone = "res/media/ico/favicon.ico";
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


        private string _strTitulo;
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

                    this.tagTitle.strConteudo _strTitulo;
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

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}