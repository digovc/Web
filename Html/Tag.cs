using DigoFramework;
using NetZ.Web.Html.Pagina;
using NetZ.Web.Server.Arquivo.Css;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetZ.Web.Html
{
    public class Tag : Objeto
    {
        #region Constantes

        public enum EnmLinkTipo
        {
            /// <summary>
            /// Abre o link numa nova aba do navegador.
            /// </summary>
            BLANK,

            /// <summary>
            /// Abre o link num frame nomeado.
            /// </summary>
            FRAMENAME,

            /// <summary>
            /// Abre o link no parent do documento.
            /// </summary>
            PARENT,

            /// <summary>
            /// Abre o link na mesma aba que a localização atual.
            /// </summary>
            SELF,

            /// <summary>
            /// Abre o link numa janela nova do navegador.
            /// </summary>
            TOP,
        }

        #endregion Constantes

        #region Atributos

        private Atributo _attClass;
        private Atributo _attId;
        private Atributo _attName;
        private Atributo _attSrc;
        private Atributo _attTabIndex;
        private Atributo _attTitle;
        private Atributo _attType;
        private bool _booBarraFinal = true;
        private bool _booClazz;
        private bool _booDupla = true;
        private EnmLinkTipo _enmLinkTipo = EnmLinkTipo.SELF;
        private int _intTabStop;
        private object _lckLstAtt;
        private List<Atributo> _lstAtt;
        private List<Tag> _lstTag;
        private PaginaHtmlBase _pag;
        private string _src;
        private string _strAbertura = "<";
        private string _strConteudo;
        private string _strFechamento = ">";
        private string _strId;
        private string _strName;
        private string _strTitle;
        private Tag _tagPai;
        private string _urlLink;

        public Atributo attClass
        {
            get
            {
                if (_attClass != null)
                {
                    return _attClass;
                }

                _attClass = this.getAttClass();

                return _attClass;
            }
        }

        /// <summary>
        /// Atributo "type" desta tag.
        /// </summary>
        public Atributo attType
        {
            get
            {
                if (_attType != null)
                {
                    return _attType;
                }

                _attType = new Atributo("type");

                this.addAtt(_attType);

                return _attType;
            }
        }

        /// <summary>
        /// Indica se conterá uma "/" (barra) na tag de fechamento.
        /// </summary>
        public bool booBarraFinal
        {
            get
            {
                return _booBarraFinal;
            }

            set
            {
                _booBarraFinal = value;
            }
        }

        /// <summary>
        /// Indica se um atributo chamado "clazz" será adicionado para esta tag para indicar o tipo a
        /// qual ela pertence. Este atributo dará a chance às classes em TypeScript de inicializar
        /// propriedades, comportamentos ou eventos dessas tags quando a página for carregada no
        /// browser do usuário.
        /// </summary>
        public bool booClazz
        {
            get
            {
                return _booClazz;
            }

            set
            {
                _booClazz = value;
            }
        }

        /// <summary>
        /// Indica se esta tag possuirá uma tag e abertura e outra de fechamento, mesmo não tendo
        /// nenhum <see cref="strConteudo"/>.
        /// </summary>
        public bool booDupla
        {
            get
            {
                return _booDupla;
            }

            set
            {
                _booDupla = value;
            }
        }

        /// <summary>
        /// Indica o tipo do link, caso esta tag possua algum.
        /// <para>Para mais detalhes consulte a documentação dos possíveis valores de <see cref="EnmLinkTipo"/>.</para>
        /// </summary>
        public EnmLinkTipo enmLinkTipo
        {
            get
            {
                return _enmLinkTipo;
            }

            set
            {
                _enmLinkTipo = value;
            }
        }

        /// <summary>
        /// Caso seja setado com um valor acima de 0, esta tag poderá receber o foco.
        /// </summary>
        public int intTabStop
        {
            get
            {
                return _intTabStop;
            }

            set
            {
                _intTabStop = value;

                this.setIntTabStop(_intTabStop);
            }
        }

        public PaginaHtmlBase pag
        {
            get
            {
                return _pag;
            }

            set
            {
                _pag = value;
            }
        }

        /// <summary>
        /// Atributo "src" que pode identificar um arquivo estático do servidor que esta tag representa.
        /// </summary>
        public string src
        {
            get
            {
                return _src;
            }

            set
            {
                _src = value;

                if (string.IsNullOrEmpty(_src))
                {
                    return;
                }

                this.attSrc.strValor = _src;
            }
        }

        /// <summary>
        /// Conteúdo interno desta tag.
        /// </summary>
        public virtual string strConteudo
        {
            get
            {
                return _strConteudo;
            }

            set
            {
                _strConteudo = value;
            }
        }

        /// <summary>
        /// Texto do atributo id desta tag que pode ser utilizado para identificá-la dentro da página.
        /// </summary>
        public string strId
        {
            get
            {
                if (_strId != null)
                {
                    return _strId;
                }

                _strId = this.getStrId();

                this.attId.strValor = _strId;

                return _strId;
            }

            set
            {
                if (_strId == value)
                {
                    return;
                }

                _strId = value;

                this.setStrId(_strId);
            }
        }

        /// <summary>
        /// Indica o valor que será apresentado ao usuário ao manter o mouse em cima desta tag.
        /// </summary>
        public string strTitle
        {
            get
            {
                return _strTitle;
            }

            set
            {
                if (_strTitle == value)
                {
                    return;
                }

                _strTitle = value;

                this.setStrTitle(_strTitle);
            }
        }

        /// <summary>
        /// Link para onde o usuário será direcionado caso click nesta tag.
        /// </summary>
        public string urlLink
        {
            get
            {
                return _urlLink;
            }

            set
            {
                _urlLink = value;
            }
        }

        internal Tag tagPai
        {
            get
            {
                return _tagPai;
            }

            set
            {
                if (_tagPai == value)
                {
                    return;
                }

                _tagPai = value;

                this.setPagPai(_tagPai);
            }
        }

        private Atributo attId
        {
            get
            {
                if (_attId != null)
                {
                    return _attId;
                }

                _attId = this.getAttId();

                return _attId;
            }
        }

        private Atributo attName
        {
            get
            {
                if (_attName != null)
                {
                    return _attName;
                }

                _attName = this.getAttName();

                return _attName;
            }
        }

        private Atributo attSrc
        {
            get
            {
                if (_attSrc != null)
                {
                    return _attSrc;
                }

                _attSrc = this.getAttSrc();

                return _attSrc;
            }
        }

        private Atributo attTabIndex
        {
            get
            {
                if (_attTabIndex != null)
                {
                    return _attTabIndex;
                }

                _attTabIndex = this.getAttTabIndex();

                return _attTabIndex;
            }
        }

        private Atributo attTitle
        {
            get
            {
                if (_attTitle != null)
                {
                    return _attTitle;
                }

                _attTitle = this.getAttTitle();

                return _attTitle;
            }
        }

        private object lckLstAtt
        {
            get
            {
                if (_lckLstAtt != null)
                {
                    return _lckLstAtt;
                }

                _lckLstAtt = new object();

                return _lckLstAtt;
            }
        }

        private List<Atributo> lstAtt
        {
            get
            {
                if (_lstAtt != null)
                {
                    return _lstAtt;
                }

                _lstAtt = new List<Atributo>();

                return _lstAtt;
            }
        }

        private List<Tag> lstTag
        {
            get
            {
                if (_lstTag != null)
                {
                    return _lstTag;
                }

                _lstTag = new List<Tag>();

                return _lstTag;
            }
        }

        private string strAbertura
        {
            get
            {
                return _strAbertura;
            }

            set
            {
                _strAbertura = value;
            }
        }

        private string strFechamento
        {
            get
            {
                return _strFechamento;
            }

            set
            {
                _strFechamento = value;
            }
        }

        private string strName
        {
            get
            {
                return _strName;
            }

            set
            {
                if (_strName == value)
                {
                    return;
                }

                _strName = value;

                this.setStrName(_strName);
            }
        }

        #endregion Atributos

        #region Construtores

        public Tag(string strNome)
        {
            this.strNome = strNome;
        }

        #endregion Construtores

        #region Métodos

        /// <summary>
        /// Adiciona um atributo para esta tag.
        /// </summary>
        /// <param name="att">Atributo que será adicionado para esta tag.</param>
        public void addAtt(Atributo att)
        {
            if (att == null)
            {
                return;
            }

            if (string.IsNullOrEmpty(att.strNome))
            {
                return;
            }

            lock (this.lckLstAtt)
            {
                foreach (Atributo att2 in this.lstAtt)
                {
                    if (att2 == null)
                    {
                        continue;
                    }

                    if (!att2.strNome.ToLower().Equals(att.strNome.ToLower()))
                    {
                        continue;
                    }

                    this.lstAtt.Remove(att2);
                    break;
                }
            }

            this.lstAtt.Add(att);
        }

        /// <summary>
        /// Link para <see cref="addAtt(Atributo)"/>.
        /// </summary>
        public void addAtt(string strAttNome, string strValor = null)
        {
            if (string.IsNullOrEmpty(strAttNome))
            {
                return;
            }

            this.addAtt(new Atributo(strAttNome, strValor));
        }

        public void addAtt(string strAttNome, decimal decValor)
        {
            this.addAtt(new Atributo(strAttNome, decValor.ToString()));
        }

        public void addAtt(string strAttNome, bool booValor)
        {
            this.addAtt(new Atributo(strAttNome, booValor.ToString()));
        }

        /// <summary>
        /// Link para <see cref="addAtt(Atributo)"/>.
        /// </summary>
        /// <summary>
        /// Link para <see cref="addAtt(Atributo)"/>.
        /// </summary>
        public void addAtt(string strAttNome, int intValor)
        {
            this.addAtt(new Atributo(strAttNome, intValor.ToString()));
        }

        public void addClass(string strClass)
        {
            if (string.IsNullOrEmpty(strClass))
            {
                return;
            }

            this.attClass.addValor(strClass);
        }

        /// <summary>
        /// Adiciona uma classe para lista de classes desta tag que está diretamente vinculada com
        /// uma propriedade CSS da aplicação.
        /// </summary>
        /// <param name="strCssClass">Classe que está ligada à propriedade CSS.</param>
        public void addCss(string strCssClass)
        {
            if (string.IsNullOrEmpty(strCssClass))
            {
                return;
            }

            this.attClass.addValor(strCssClass);
        }

        /// <summary>
        /// Adiciona todos os atributos css que o <paramref name="tag"/> possui.
        /// </summary>
        /// <param name="tag">Tag terá os atributos css copiados.</param>
        public void addCss(Tag tag)
        {
            if (tag == null)
            {
                return;
            }

            this.attClass.copiar(tag.attClass);
        }

        public void apagarAtt(string strAttNome)
        {
            if (string.IsNullOrEmpty(strAttNome))
            {
                return;
            }

            foreach (Atributo att in this.lstAtt)
            {
                if (att == null)
                {
                    continue;
                }

                if (string.IsNullOrEmpty(att.strNome))
                {
                    continue;
                }

                if (!att.strNome.ToLower().Equals(strAttNome.ToLower()))
                {
                    continue;
                }

                this.lstAtt.Remove(att);
                return;
            }
        }

        public void limparClass()
        {
            this.attClass.strValor = null;
        }

        /// <summary>
        /// Indica qual o elemento será o "pai" desta tag. Este elemento pode ser uma <see
        /// cref="Tag"/> (ou um de seus descendentes), ou uma <see cref="PaginaHtmlBase"/> (ou um de
        /// seus descendentes).
        /// </summary>
        public virtual void setPai(Tag tagPai)
        {
            if (tagPai == null)
            {
                return;
            }

            this.tagPai = tagPai;
        }

        /// <summary>
        /// Indica qual o elemento será o "pai" desta tag. Este elemento pode ser uma <see
        /// cref="Tag"/> (ou um de seus descendentes), ou uma <see cref="PaginaHtmlBase"/> (ou um de
        /// seus descendentes).
        /// </summary>
        public void setPai(PaginaHtmlBase pagPai)
        {
            if (pagPai == null)
            {
                return;
            }

            pagPai.addTag(this);
        }

        /// <summary>
        /// Retorna esta TAG formatada em HTML.
        /// </summary>
        /// <returns>Retorna esta TAG formatada em HTML.</returns>
        public virtual string toHtml(PaginaHtmlBase pag = null)
        {
            this.pag = pag;

            this.inicializar();
            this.montarLayout();
            this.setCss(CssMain.i);
            this.finalizar();
            this.finalizarCss(CssMain.i);

            if (this.pag != null)
            {
                this.addLayoutFixo(this.pag.tagJs);
                this.addConstante(this.pag.tagJs);
            }

            return this.getBooTagDupla() ? this.toHtmlTagDupla() : this.toHtmlTagUnica();
        }

        protected virtual void addConstante(JavaScriptTag tagJs)
        {
        }

        /// <summary>
        /// Método que serve para adicionar arquivos CSS estáticos para lista que será carregada pelo
        /// browser do usuário.
        /// </summary>
        /// <param name="lstCss">
        /// Lista de <see cref="CssArquivoBase"/> que será carregada pelo browser do usuário.
        /// </param>
        protected virtual void addCss(LstTag<CssTag> lstCss)
        {
        }

        /// <summary>
        /// Este método deve ser utilizado para adicionar código JavaScript que será executado assim
        /// que o carregamento da página estiver concluído.
        /// </summary>
        /// <param name="js">
        /// É uma tag JavaScript inline que serve para adicionar código que será executado quando o
        /// carregamento da página estiver concluído.
        /// </param>
        protected virtual void addJs(JavaScriptTag js)
        {
        }

        /// <summary>
        /// Método que serve para adicionar arquivos JavaScript estáticos para lista de que será
        /// carregada pelo browser do usuário.
        /// </summary>
        /// <param name="lstJs">
        /// Lista de <see cref="JavaScriptTag"/> que será carregada pelo browser do usuário.
        /// </param>
        protected virtual void addJs(LstTag<JavaScriptTag> lstJs)
        {
        }

        protected virtual void addJsLib(LstTag<JavaScriptTag> lstJsLib)
        {
        }

        protected virtual void addLayoutFixo(JavaScriptTag tagJs)
        {
        }

        /// <summary>
        /// Adiciona uma tag para a lista <see cref="lstTag"/>. Essas são as tags que estarão
        /// contidas por esta.
        /// </summary>
        /// <param name="tag">Tag que será contida por esta tag.</param>
        protected virtual void addTag(Tag tag)
        {
            if (tag == null)
            {
                return;
            }

            this.lstTag.Add(tag);
        }

        /// <summary>
        /// Método que será chamado após <see cref="montarLayout"/> para que os ajustes finais sejam feitos.
        /// </summary>
        protected virtual void finalizar()
        {
            this.finalizarBooClazz();
        }

        /// <summary>
        /// Método que será chamado após <see cref="finalizar"/> e deverá ser utilizado para fazer
        /// ajustes finais no estilo da tag.
        /// </summary>
        /// <param name="css">Tag CssMain utilizada para dar estilo para todas as tags da página.</param>
        protected virtual void finalizarCss(CssArquivoBase css)
        {
        }

        /// <summary>
        /// Método que é chamado antes de montar o HTML desta tag e pode ser utilizado para
        /// inicializar valores diversos das propriedades desta e de outras tags filhas.
        /// </summary>
        protected virtual void inicializar()
        {
            if (this.pag == null)
            {
                return;
            }

            this.addCss(this.pag.lstCss);
            this.addJsLib(this.pag.lstJsLib);
            this.addJs(this.pag.lstJs);
            this.addJs(this.pag.tagJs);
        }

        protected virtual void montarLayout()
        {
        }

        /// <summary>
        /// Método que deve ser utilizado para configurar o design desta tag e de seus filhos.
        /// </summary>
        /// <param name="css">Tag CSS principal da página onde serão adicionado todo o design.</param>
        protected virtual void setCss(CssArquivoBase css)
        {
            this.setCssBooMostrarGrade(css);
        }

        /// <summary>
        /// Disparado toda vez que o atributo <see cref="strId"/> for alterado.
        /// </summary>
        protected virtual void setStrId(string strId)
        {
            this.attId.strValor = strId;
        }

        protected virtual void setStrTitle(string strTitle)
        {
            if (string.IsNullOrEmpty(strTitle))
            {
                return;
            }

            this.attTitle.strValor = strTitle;
        }

        private void finalizarBooClazz()
        {
            if (!this.booClazz)
            {
                return;
            }

            this.addAtt("clazz", this.GetType().Name);
        }

        private Atributo getAttClass()
        {
            Atributo attResultado = new Atributo("class");

            this.addAtt(attResultado);

            return attResultado;
        }

        private Atributo getAttId()
        {
            Atributo attResultado = new Atributo("id");

            this.addAtt(attResultado);

            return attResultado;
        }

        private Atributo getAttName()
        {
            Atributo attResultado = new Atributo("name");

            this.addAtt(attResultado);

            return attResultado;
        }

        private Atributo getAttSrc()
        {
            Atributo attResultado = new Atributo("src");

            this.addAtt(attResultado);

            return attResultado;
        }

        private Atributo getAttTabIndex()
        {
            Atributo attResultado = new Atributo("tabindex");

            this.addAtt(attResultado);

            return attResultado;
        }

        private Atributo getAttTitle()
        {
            Atributo attResultado = new Atributo("title");

            this.addAtt(attResultado);

            return attResultado;
        }

        private bool getBooTagDupla()
        {
            if (this.booDupla)
            {
                return true;
            }

            if (!string.IsNullOrEmpty(this.strConteudo))
            {
                return true;
            }

            if (this.lstTag.Count > 0)
            {
                return true;
            }

            return false;
        }

        private string getStrId()
        {
            return string.Format("i{0}", this.intObjetoId);
        }

        private string getStrLinkTipo()
        {
            switch (this.enmLinkTipo)
            {
                case EnmLinkTipo.BLANK:
                    return "_blank";

                case EnmLinkTipo.FRAMENAME:
                    return "framename";

                case EnmLinkTipo.PARENT:
                    return "_parent";

                case EnmLinkTipo.TOP:
                    return "_top";

                default:
                    return "_self";
            }
        }

        private void setCssBooMostrarGrade(CssArquivoBase css)
        {
            if (!AppWebBase.i.booMostrarGrade)
            {
                return;
            }

            this.addCss(css.setBorder(1, "dashed", "#ababab"));
        }

        private void setIntTabStop(int intTabStop)
        {
            this.attTabIndex.intValor = intTabStop;
        }

        private void setPagPai(Tag tagPai)
        {
            if (tagPai == null)
            {
                return;
            }

            tagPai.addTag(this);
        }

        private void setStrName(string strName)
        {
            if (string.IsNullOrEmpty(strName))
            {
                return;
            }

            this.attName.strValor = strName;
        }

        private string toHtmlAtributo()
        {
            if (this.lstAtt == null)
            {
                return null;
            }

            List<string> lstStrAtrAdicionado = new List<string>();
            List<string> lstStrAtrFormatado = new List<string>();

            List<Atributo> lstAtrOrdenado = this.lstAtt.OrderBy((att) => att.strNome).ToList();

            foreach (Atributo att in lstAtrOrdenado)
            {
                if (att == null)
                {
                    continue;
                }

                if (string.IsNullOrEmpty(att.strNome))
                {
                    continue;
                }

                if (lstStrAtrAdicionado.Contains(att.strNome))
                {
                    continue;
                }

                lstStrAtrFormatado.Add(att.getStrFormatado());
            }

            return string.Join(" ", lstStrAtrFormatado.ToArray());
        }

        private string toHtmlTagDupla()
        {
            var stbResultado = new StringBuilder();

            stbResultado.Append(this.toHtmlTagDuplaLinkIn());
            stbResultado.Append(this.strAbertura);
            stbResultado.Append(this.strNome);
            stbResultado.Append((0.Equals(this.lstAtt.Count)) ? null : " ");
            stbResultado.Append(this.toHtmlAtributo());
            stbResultado.Append(this.strFechamento);
            stbResultado.Append(this.strConteudo);
            stbResultado.Append(this.toHtmlTagFilho());
            stbResultado.Append(this.strAbertura);
            stbResultado.Append((!this.booBarraFinal) ? null : "/");
            stbResultado.Append(this.strNome);
            stbResultado.Append(this.strFechamento);
            stbResultado.Append((!string.IsNullOrEmpty(this.urlLink)) ? "</a>" : null);

            return stbResultado.ToString();
        }

        private string toHtmlTagDuplaLinkIn()
        {
            if (string.IsNullOrEmpty(this.urlLink))
            {
                return null;
            }

            string strResultado = "<a href=\"_link_valor\" target=\"_target_valor\">";

            strResultado = strResultado.Replace("_link_valor", this.urlLink);
            strResultado = strResultado.Replace("_target_valor", this.getStrLinkTipo());

            return strResultado;
        }

        private string toHtmlTagFilho()
        {
            var stbResultado = new StringBuilder();

            foreach (var tag in this.lstTag)
            {
                if (tag == null)
                {
                    continue;
                }

                stbResultado.Append(tag.toHtml(this.pag));
            }

            return stbResultado.ToString();
        }

        private string toHtmlTagUnica()
        {
            var stbResultado = new StringBuilder();

            stbResultado.Append(this.toHtmlTagDuplaLinkIn());
            stbResultado.Append(this.strAbertura);
            stbResultado.Append(this.strNome);
            stbResultado.Append((0.Equals(this.lstAtt.Count)) ? null : " ");
            stbResultado.Append(this.toHtmlAtributo());
            stbResultado.Append((!this.booBarraFinal) ? null : "/");
            stbResultado.Append(this.strFechamento);
            stbResultado.Append((!string.IsNullOrEmpty(this.urlLink)) ? "</a>" : null);

            return stbResultado.ToString();
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}