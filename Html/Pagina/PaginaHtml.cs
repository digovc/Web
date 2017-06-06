using DigoFramework;
using NetZ.Web.Html.Componente;
using NetZ.Web.Html.Componente.Janela.Cadastro;
using NetZ.Web.Html.Componente.Menu.Contexto;
using NetZ.Web.Server;
using NetZ.Web.Server.Arquivo.Css;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace NetZ.Web.Html.Pagina
{
    public class PaginaHtml : Objeto
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private static PaginaHtml _i;

        private bool _booEstatica = true;
        private bool _booPagSimples;
        private Div _divNotificacao;
        private LstTag<CssTag> _lstCss;
        private LstTag<JavaScriptTag> _lstJs;
        private LstTag<JavaScriptTag> _lstJsLib;
        private string _srcIcone;
        private string _strHtmlEstatico;
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
                if (_tagBody != null)
                {
                    return _tagBody;
                }

                _tagBody = this.getTagBody();

                return _tagBody;
            }
        }

        internal LstTag<CssTag> lstCss
        {
            get
            {
                if (_lstCss != null)
                {
                    return _lstCss;
                }

                _lstCss = new LstTag<CssTag>();

                return _lstCss;
            }
        }

        internal LstTag<JavaScriptTag> lstJs
        {
            get
            {
                if (_lstJs != null)
                {
                    return _lstJs;
                }

                _lstJs = new LstTag<JavaScriptTag>();

                return _lstJs;
            }
        }

        internal LstTag<JavaScriptTag> lstJsLib
        {
            get
            {
                if (_lstJsLib != null)
                {
                    return _lstJsLib;
                }

                _lstJsLib = new LstTag<JavaScriptTag>();

                return _lstJsLib;
            }
        }

        internal JavaScriptTag tagJs
        {
            get
            {
                if (_tagJs != null)
                {
                    return _tagJs;
                }

                _tagJs = new JavaScriptTag(string.Empty, 100);

                return _tagJs;
            }
        }

        protected bool booPagSimples
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
                if (_strTitulo != null)
                {
                    return _strTitulo;
                }

                _strTitulo = this.getStrTitulo();

                return _strTitulo;
            }

            set
            {
                if (_strTitulo == value)
                {
                    return;
                }

                _strTitulo = value;

                this.setStrTitulo(_strTitulo);
            }
        }

        protected Tag tagHead
        {
            get
            {
                if (_tagHead != null)
                {
                    return _tagHead;
                }

                _tagHead = this.getTagHead();

                return _tagHead;
            }
        }

        private bool booEstatica
        {
            get
            {
                return _booEstatica;
            }

            set
            {
                _booEstatica = value;
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

                _divNotificacao = this.getDivNotificacao();

                return _divNotificacao;
            }
        }

        private string strHtmlEstatico
        {
            get
            {
                return _strHtmlEstatico;
            }

            set
            {
                _strHtmlEstatico = value;
            }
        }

        private CssTag tagCssMain
        {
            get
            {
                if (_tagCssMain != null)
                {
                    return _tagCssMain;
                }

                _tagCssMain = this.getTagCssMain();

                return _tagCssMain;
            }
        }

        private CssTag tagCssPrint
        {
            get
            {
                if (_tagCssPrint != null)
                {
                    return _tagCssPrint;
                }

                _tagCssPrint = this.getTagCssPrint();

                return _tagCssPrint;
            }
        }

        private Tag tagDocType
        {
            get
            {
                if (_tagDocType != null)
                {
                    return _tagDocType;
                }

                _tagDocType = this.getTagDocType();

                return _tagDocType;
            }
        }

        private Tag tagHtml
        {
            get
            {
                if (_tagHtml != null)
                {
                    return _tagHtml;
                }

                _tagHtml = this.getTagHtml();

                return _tagHtml;
            }
        }

        private Tag tagIcon
        {
            get
            {
                if (_tagIcon != null)
                {
                    return _tagIcon;
                }

                _tagIcon = this.getTagIcon();

                return _tagIcon;
            }
        }

        private Tag tagMetaContent
        {
            get
            {
                if (_tagMetaContent != null)
                {
                    return _tagMetaContent;
                }

                _tagMetaContent = this.getTagMetaContent();

                return _tagMetaContent;
            }
        }

        private Tag tagMetaHttpEquiv
        {
            get
            {
                if (_tagMetaHttpEquiv != null)
                {
                    return _tagMetaHttpEquiv;
                }

                _tagMetaHttpEquiv = this.getTagMetaHttpEquiv();

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

                _tagThemaColor = this.getTagThemaColor();

                return _tagThemaColor;
            }
        }

        private Tag tagTitle
        {
            get
            {
                if (_tagTitle != null)
                {
                    return _tagTitle;
                }

                _tagTitle = this.getTagTitle();

                return _tagTitle;
            }
        }

        #endregion Atributos

        #region Construtores

        public PaginaHtml(string strNome)
        {
            i = this;

            this.strNome = strNome;
            this.strTitulo = this.strNome;
        }

        #endregion Construtores

        #region Métodos

        public void salvar(string dir)
        {
            if (string.IsNullOrEmpty(dir))
            {
                return;
            }

            Directory.CreateDirectory(dir);

            var strPagNome = string.Format("pag_{0}.html", this.strNomeSimplificado);

            var dirCompleto = Path.Combine(dir, strPagNome);

            var strHtml = this.toHtml();

            var objUtf8Encoding = new UTF8Encoding(true);

            using (var objStreamWriter = new StreamWriter(dirCompleto, false, objUtf8Encoding))
            {
                objStreamWriter.Write(strHtml);
            }
        }

        public string toHtml()
        {
            string strResultado = this.toHtmlEstatico();

            if (!string.IsNullOrEmpty(strResultado))
            {
                return strResultado;
            }

            return this.toHtmlDinamico();
        }

        protected virtual void addConstante(JavaScriptTag tagJs)
        {
            tagJs.addConstante(AppWebBase.STR_CONSTANTE_DESENVOLVIMENTO, AppWebBase.i.booDesenvolvimento);
        }

        /// <summary>
        /// Adiciona uma classe para lista de classes da tag body desta página para fazer referência
        /// a algum estilo CSS.
        /// </summary>
        /// <param name="strClassCss">Classe que faz referência a alguma regar CSS.</param>
        protected void addCss(string strClassCss)
        {
            if (string.IsNullOrEmpty(strClassCss))
            {
                return;
            }

            this.tagBody.addCss(strClassCss);
        }

        protected virtual void addCss(LstTag<CssTag> lstCss)
        {
        }

        protected void addJs(JavaScriptTag tagJs)
        {
            this.tagJs.setPai(this.tagHead);
        }

        protected virtual void addJs(LstTag<JavaScriptTag> lstJs)
        {
            lstJs.Add(new JavaScriptTag(typeof(AppWebBase), 104));
            lstJs.Add(new JavaScriptTag(typeof(Mensagem), 111));
            lstJs.Add(new JavaScriptTag(typeof(MenuContexto), 111));
            lstJs.Add(new JavaScriptTag(typeof(MenuContextoItem), 111));
            lstJs.Add(new JavaScriptTag(typeof(Notificacao), 111));
            lstJs.Add(new JavaScriptTag(typeof(PaginaHtml), 103));
            lstJs.Add(new JavaScriptTag(typeof(ServerBase), 101));
            lstJs.Add(new JavaScriptTag(typeof(SrvHttpBase), 102));
            lstJs.Add(new JavaScriptTag(typeof(Tag), 103));

            lstJs.Add(new JavaScriptTag("/res/js/web/Constante.js", 0));
            lstJs.Add(new JavaScriptTag("/res/js/web/ConstanteManager.js", 1));
            lstJs.Add(new JavaScriptTag("/res/js/web/design/TemaDefault.js", 100));
            lstJs.Add(new JavaScriptTag("/res/js/web/erro/Erro.js", 102));
            lstJs.Add(new JavaScriptTag("/res/js/web/Historico.js", 101));
            lstJs.Add(new JavaScriptTag("/res/js/web/html/Animator.js", 101));
            lstJs.Add(new JavaScriptTag("/res/js/web/Keys.js", 100));
            lstJs.Add(new JavaScriptTag("/res/js/web/Loop.js", 101));
            lstJs.Add(new JavaScriptTag("/res/js/web/Objeto.js", 100));
            lstJs.Add(new JavaScriptTag("/res/js/web/Utils.js", 101));

            if (this.getBooJs())
            {
                lstJs.Add(new JavaScriptTag(this.GetType(), 1000));
            }
        }

        protected virtual void addJsCodigo(JavaScriptTag tagJs)
        {
            if (this.getBooJsAutoInicializavel())
            {
                tagJs.addJsCodigo(string.Format(this.getStrJsNamespace() + ".{0}.i.iniciar();", this.GetType().Name));
            }
        }

        protected virtual void addJsLib(LstTag<JavaScriptTag> lstJsLib)
        {
            lstJsLib.Add(new JavaScriptTag("/res/js/lib/jquery-3.1.0.min.js", 0));
        }

        protected virtual void addLayoutFixo(JavaScriptTag tagJs)
        {
            // Revisar a real necessidade de enviar esses layouts sempre.
            tagJs.addLayoutFixo(typeof(Mensagem));
            tagJs.addLayoutFixo(typeof(MenuContexto));
            tagJs.addLayoutFixo(typeof(MenuContextoItem));
            tagJs.addLayoutFixo(typeof(Notificacao));
            tagJs.addLayoutFixo(typeof(TagCard));
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
        protected virtual void finalizarCss(CssArquivoBase css)
        {
        }

        protected virtual bool getBooJs()
        {
            return false;
        }

        protected virtual bool getBooJsAutoInicializavel()
        {
            return false;
        }

        protected virtual string getSrcJsBoot()
        {
            return null;
        }

        protected virtual string getStrJsNamespace()
        {
            return AppWebBase.i.GetType().Namespace;
        }

        /// <summary>
        /// Este método é chamado antes da montagem do HTML desta página e pode ser utilizado para a
        /// inicialização das propriedades dessa ou das tags filhas.
        /// </summary>
        protected virtual void inicializar()
        {
        }

        protected virtual void montarLayout()
        {
            this.tagTitle.setPai(this.tagHead);
            this.tagMetaContent.setPai(this.tagHead);
            this.tagMetaHttpEquiv.setPai(this.tagHead);
            this.tagMetaThemaColor.setPai(this.tagHead);
            this.tagCssMain.setPai(this.tagHead);

            this.montarLayoutTagCssPrint();

            this.montarLayoutTagIcon();

            this.divNotificacao.setPai(this);
        }

        protected virtual void setCss(CssArquivoBase css)
        {
            this.tagBody.addCss(css.setMargin(0));

            this.divNotificacao.addCss(css.setBottom(20));
            this.divNotificacao.addCss(css.setPosition("absolute"));
            this.divNotificacao.addCss(css.setRight(20));
            this.divNotificacao.addCss(css.setZIndex(100));
        }

        private void addCss()
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

        private void addJs()
        {
            if (this.booPagSimples)
            {
                return;
            }

            this.addJsLib();

            this.addJs(this.lstJs);

            this.addJsLstJs();

            this.addJsCodigo(this.tagJs);

            this.addJs(this.tagJs);
        }

        private void addJsLib()
        {
            this.addJsLib(this.lstJsLib);

            List<JavaScriptTag> lstJsLibOrdenado = this.lstJsLib.OrderBy((o) => o.intOrdem).ToList();

            foreach (JavaScriptTag tagJs in lstJsLibOrdenado)
            {
                if (tagJs == null)
                {
                    continue;
                }

                tagJs.setPai(this.tagHead);
            }
        }

        private void addJsLstJs()
        {
            List<JavaScriptTag> lstJsOrdenado = this.lstJs.OrderBy((o) => o.intOrdem).ToList();

            foreach (JavaScriptTag tagJs in lstJsOrdenado)
            {
                if (tagJs == null)
                {
                    continue;
                }

                tagJs.setPai(this.tagHead);
            }
        }

        private Div getDivNotificacao()
        {
            var divNotificacaoResultado = new Div();

            divNotificacaoResultado.strId = "divNotificacao";

            return divNotificacaoResultado;
        }

        private string getStrTitulo()
        {
            string strResultado = "_titulo - _app_nome";

            strResultado = strResultado.Replace("_titulo", this.strTitulo);
            strResultado = strResultado.Replace("_app_nome", AppWebBase.i.strNome);

            return strResultado;
        }

        private Tag getTagBody()
        {
            var tagBodyResultado = new Tag("body");

            tagBodyResultado.booClazz = false;

            return tagBodyResultado;
        }

        private CssTag getTagCssMain()
        {
            var tagCssMainResultado = new CssTag(CssMain.i.strHref);

            tagCssMainResultado.strId = CssMain.STR_CSS_ID;

            return tagCssMainResultado;
        }

        private CssTag getTagCssPrint()
        {
            var tagCssPrintResultado = new CssTag(CssPrint.i.strHref);

            tagCssPrintResultado.strId = CssPrint.STR_CSS_ID;

            tagCssPrintResultado.addAtt("media", "print");

            return tagCssPrintResultado;
        }

        private Tag getTagDocType()
        {
            var tagDocTypeResultado = new Tag("!DOCTYPE");

            tagDocTypeResultado.addAtt("html");
            tagDocTypeResultado.booBarraFinal = false;
            tagDocTypeResultado.booClazz = false;
            tagDocTypeResultado.booDupla = false;

            return tagDocTypeResultado;
        }

        private Tag getTagHead()
        {
            var tagHeadResultado = new Tag("head");

            tagHeadResultado.booClazz = false;

            return tagHeadResultado;
        }

        private Tag getTagHtml()
        {
            var tagHtmlResultado = new Tag("html");

            tagHtmlResultado.booClazz = false;

            tagHtmlResultado.addAtt("xmlns", "http://www.w3.org/1999/xhtml");
            tagHtmlResultado.addAtt("lang", "pt-br");

            return tagHtmlResultado;
        }

        private Tag getTagIcon()
        {
            var tagIconResultado = new Tag("link");

            tagIconResultado.booClazz = false;

            tagIconResultado.addAtt("href", this.srcIcone);
            tagIconResultado.addAtt("rel", "icon");
            tagIconResultado.addAtt("type", "image/x-icon");
            tagIconResultado.booDupla = false;

            return tagIconResultado;
        }

        private Tag getTagMetaContent()
        {
            var tagMetaContentRsultado = new Tag("meta");

            tagMetaContentRsultado.booClazz = false;
            tagMetaContentRsultado.booDupla = false;

            tagMetaContentRsultado.addAtt("content", this.strNomeExibicao);

            return tagMetaContentRsultado;
        }

        private Tag getTagMetaHttpEquiv()
        {
            var tagMetaHttpEquivResultado = new Tag("meta");

            tagMetaHttpEquivResultado.booClazz = false;
            tagMetaHttpEquivResultado.booDupla = false;

            tagMetaHttpEquivResultado.addAtt("http-equiv", "Content-Type");

            return tagMetaHttpEquivResultado;
        }

        private Tag getTagThemaColor()
        {
            var tagMetaThemaColorResultado = new Tag("meta");

            tagMetaThemaColorResultado.booClazz = false;
            tagMetaThemaColorResultado.booDupla = false;

            tagMetaThemaColorResultado.addAtt("name", "theme-color");
            tagMetaThemaColorResultado.addAtt("content", ColorTranslator.ToHtml(AppWebBase.i.objTema.corTema));

            return tagMetaThemaColorResultado;
        }

        private Tag getTagTitle()
        {
            var tagTitleResultado = new Tag("title");

            tagTitleResultado.booClazz = false;
            tagTitleResultado.booDupla = false;
            tagTitleResultado.strConteudo = this.strTitulo;

            return tagTitleResultado;
        }

        private void iniciar()
        {
            this.inicializar();
            this.montarLayout();
            this.setCss(CssMain.i);
            this.finalizar();
            this.finalizarCss(CssPrint.i);
            this.addLayoutFixo(this.tagJs);
            this.addConstante(this.tagJs);
        }

        private void montarLayoutTagCssPrint()
        {
            if (DateTime.MinValue.Equals(CssPrint.i.dttAlteracao))
            {
                return;
            }

            this.tagCssPrint.setPai(this.tagHead);
        }

        private void montarLayoutTagIcon()
        {
            if (string.IsNullOrEmpty(this.srcIcone))
            {
                return;
            }

            this.tagIcon.setPai(this.tagHead);
        }

        private void setStrTitulo(string strTitulo)
        {
            this.tagTitle.strConteudo = strTitulo;
        }

        private string toHtmlDinamico()
        {
            this.iniciar();

            string strBody = this.tagBody.toHtml();

            this.addCss();
            this.addJs();

            string strHead = this.tagHead.toHtml();

            StringBuilder stbConteudo = new StringBuilder();

            stbConteudo.Append("_head_body");

            stbConteudo.Replace("_head", strHead);
            stbConteudo.Replace("_body", strBody);

            this.tagHtml.strConteudo = stbConteudo.ToString();

            StringBuilder stbResultado = new StringBuilder();

            stbResultado.Append("_tag_doc_type_tag_html");

            stbResultado.Replace("_tag_doc_type", this.tagDocType.toHtml());
            stbResultado.Replace("_tag_html", this.tagHtml.toHtml());

            this.strHtmlEstatico = stbResultado.ToString();

            return this.strHtmlEstatico;
        }

        private string toHtmlEstatico()
        {
            if (!this.booEstatica)
            {
                return null;
            }

            if (string.IsNullOrEmpty(this.strHtmlEstatico))
            {
                return null;
            }

            return this.strHtmlEstatico;
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}