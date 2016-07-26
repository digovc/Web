using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using NetZ.SistemaBase;
using NetZ.Web.Html.Componente;
using NetZ.Web.Html.Componente.Grid;
using NetZ.Web.Html.Componente.Janela.Cadastro;
using NetZ.Web.Html.Componente.Menu.Contexto;
using NetZ.Web.Server;
using NetZ.Web.Server.Ajax;
using NetZ.Web.Server.Arquivo.Css;
using NetZ.Web.Server.WebSocket;

namespace NetZ.Web.Html.Pagina
{
    public class PaginaHtml : Objeto
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private static PaginaHtml _i;

        private bool _booPagSimples;
        private Div _divNotificacao;
        private LstTag<CssTag> _lstCss;
        private LstTag<JavaScriptTag> _lstJs;
        private string _srcIcone = "res/media/ico/favicon.ico";
        private string _strTitulo;
        private Tag _tagBody;
        private CssTag _tagCssMain;
        private CssTag _tagCssPrint;
        private Tag _tagDocType;
        private Tag _tagHead;
        private Tag _tagHtml;
        private Tag _tagIcon;
        private JavaScriptTag _tagJs;
        private Tag _tagMetaContent;
        private Tag _tagMetaHttpEquiv;
        private Tag _tagThemaColor;
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

        public Tag tagBody
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

                    _tagJs = new JavaScriptTag(string.Empty, 5000);
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

        protected Tag tagHead
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

        private Div divNotificacao
        {
            get
            {
                if (_divNotificacao != null)
                {
                    return _divNotificacao;
                }

                _divNotificacao = new Div();

                return _divNotificacao;
            }
        }

        private CssTag tagCssMain
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_tagCssMain != null)
                    {
                        return _tagCssMain;
                    }

                    _tagCssMain = new CssTag();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _tagCssMain;
            }
        }

        private CssTag tagCssPrint
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_tagCssPrint != null)
                    {
                        return _tagCssPrint;
                    }

                    _tagCssPrint = new CssTag();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _tagCssPrint;
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

        private Tag tagMetaThemaColor
        {
            get
            {
                if (_tagThemaColor != null)
                {
                    return _tagThemaColor;
                }

                _tagThemaColor = new Tag("meta");

                return _tagThemaColor;
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
                i = this;

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
                this.iniciar();

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

        protected void addConstante(string strNome, string strValor)
        {
            if (string.IsNullOrEmpty(strNome))
            {
                return;
            }

            if (string.IsNullOrEmpty(strValor))
            {
                return;
            }

            string strJq = "NetZ_Web.ConstanteManager.i.addConstante(new NetZ_Web.Constante('_constante_nome', '_constante_valor'));";

            strJq = strJq.Replace("_constante_nome", strNome);
            strJq = strJq.Replace("_constante_valor", strValor);

            this.addJs(strJq);
        }

        /// <summary>
        /// Adiciona uma classe para lista de classes da tag body desta página para fazer referência
        /// a algum estilo CSS.
        /// </summary>
        /// <param name="strClassCss">Classe que faz referência a alguma regar CSS.</param>
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
                lstJs.Add(new JavaScriptTag(typeof(AppWeb), 104));
                lstJs.Add(new JavaScriptTag(typeof(Mensagem), 111));
                lstJs.Add(new JavaScriptTag(typeof(MenuContexto), 111));
                lstJs.Add(new JavaScriptTag(typeof(MenuContextoItem), 111));
                lstJs.Add(new JavaScriptTag(typeof(MenuGrid), 111));
                lstJs.Add(new JavaScriptTag(typeof(Notificacao), 111));
                lstJs.Add(new JavaScriptTag(typeof(PaginaHtml), 103));
                lstJs.Add(new JavaScriptTag(typeof(ServerAjax), 102));
                lstJs.Add(new JavaScriptTag(typeof(ServerAjaxDb), 105));
                lstJs.Add(new JavaScriptTag(typeof(ServerBase), 101));
                lstJs.Add(new JavaScriptTag(typeof(ServerHttp), 102));
                lstJs.Add(new JavaScriptTag(typeof(ServerWs), 102));
                lstJs.Add(new JavaScriptTag(typeof(SolicitacaoAjax), 105));
                lstJs.Add(new JavaScriptTag(typeof(SolicitacaoAjaxDb), 105));

                lstJs.Add(new JavaScriptTag("res/js/lib/jquery-2.2.2.min.js", 0));
                lstJs.Add(new JavaScriptTag("res/js/Web.TypeScript/design/TemaDefault.js", 100));
                lstJs.Add(new JavaScriptTag("res/js/Web.TypeScript/erro/Erro.js", 102));
                lstJs.Add(new JavaScriptTag("res/js/Web.TypeScript/html/Tag.js", 103));
                lstJs.Add(new JavaScriptTag("res/js/Web.TypeScript/Keys.js", 100));
                lstJs.Add(new JavaScriptTag("res/js/Web.TypeScript/Constante.js", 0));
                lstJs.Add(new JavaScriptTag("res/js/Web.TypeScript/ConstanteManager.js", 1));
                lstJs.Add(new JavaScriptTag("res/js/Web.TypeScript/Objeto.js", 100));
                lstJs.Add(new JavaScriptTag("res/js/Web.TypeScript/Utils.js", 101));

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

        /// <summary>
        /// Método que será chamado após <see cref="finalizar"/> e deverá ser utilizado para fazer
        /// ajustes finais no estilo da tag.
        /// </summary>
        /// <param name="css">Tag CssMain utilizada para dar estilo para todas as tags da página.</param>
        protected virtual void finalizarCss(CssArquivo css)
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
                this.divNotificacao.strId = "divNotificacao";

                this.tagBody.booMostrarClazz = false;

                this.tagCssMain.strId = CssMain.STR_CSS_ID;

                this.tagCssMain.addAtt("href", CssMain.i.strHref);

                this.tagCssPrint.strId = CssPrint.STR_CSS_ID;

                this.tagCssPrint.addAtt("href", CssPrint.i.strHref);
                this.tagCssPrint.addAtt("media", "print");

                this.tagDocType.addAtt("html");
                this.tagDocType.booBarraFinal = false;
                this.tagDocType.booMostrarClazz = false;
                this.tagDocType.booDupla = false;

                this.tagHead.booMostrarClazz = false;

                this.tagHtml.addAtt("xmlns", "http://www.w3.org/1999/xhtml");
                this.tagHtml.addAtt("lang", "pt-br");
                this.tagHtml.booMostrarClazz = false;

                this.tagIcon.addAtt("rel", "shortcut icon");
                this.tagIcon.addAtt("href", this.srcIcone);
                this.tagIcon.addAtt("type", "image/x-icon");
                this.tagIcon.booMostrarClazz = false;

                this.tagJs.intOrdem = 100;

                this.tagMetaContent.addAtt("content", this.strNomeExibicao);
                this.tagMetaContent.booMostrarClazz = false;
                this.tagMetaContent.booDupla = false;

                this.tagMetaHttpEquiv.addAtt("http-equiv", "Content-Type");
                this.tagMetaHttpEquiv.booMostrarClazz = false;
                this.tagMetaHttpEquiv.booDupla = false;

                this.tagMetaThemaColor.addAtt("name", "theme-color");
                this.tagMetaThemaColor.addAtt("content", ColorTranslator.ToHtml(AppWeb.i.objTema.corTema));
                this.tagMetaThemaColor.booMostrarClazz = false;
                this.tagMetaThemaColor.booDupla = false;

                this.tagTitle.booMostrarClazz = false;
                this.tagTitle.booDupla = false;
                this.tagTitle.strConteudo = this.getStrTituloFormatado();
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
                this.tagTitle.setPai(this.tagHead);
                this.tagMetaContent.setPai(this.tagHead);
                this.tagMetaHttpEquiv.setPai(this.tagHead);
                this.tagMetaThemaColor.setPai(this.tagHead);
                this.tagIcon.setPai(this.tagHead);
                this.tagCssMain.setPai(this.tagHead);
                this.tagCssPrint.setPai(this.tagHead);

                this.divNotificacao.setPai(this);
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

        protected virtual void setCss(CssArquivo css)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.tagBody.addCss(css.setMargin(0));

                this.divNotificacao.addCss(css.setBottom(20));
                this.divNotificacao.addCss(css.setPosition("absolute"));
                this.divNotificacao.addCss(css.setRight(20));
                this.divNotificacao.addCss(css.setZIndex(100));
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

        protected virtual void addLayoutFixo()
        {
            this.addLayoutFixo(typeof(Mensagem));
            this.addLayoutFixo(typeof(MenuContexto));
            this.addLayoutFixo(typeof(MenuContextoItem));
            this.addLayoutFixo(typeof(MenuGrid));
            this.addLayoutFixo(typeof(Notificacao));
            this.addLayoutFixo(typeof(TagCard));
        }

        protected void addLayoutFixo(Type cls)
        {
            if (cls == null)
            {
                return;
            }

            if (!typeof(ComponenteHtml).IsAssignableFrom(cls))
            {
                return;
            }

            this.addConstante((cls.Name + "_layoutFixo"), (Activator.CreateInstance(cls) as ComponenteHtml).toHtml());
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

        private void iniciar()
        {
            this.inicializar();
            this.montarLayout();
            this.setCss(CssMain.i);
            this.finalizar();
            this.finalizarCss(CssPrint.i);
            this.addLayoutFixo();
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}