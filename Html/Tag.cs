using System.Collections.Generic;
using System.Linq;
using System.Text;
using DigoFramework;
using NetZ.Web.Html.Pagina;
using NetZ.Web.Server.Arquivo.Css;

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
        private bool _booDupla = true;
        private bool _booMostrarClazz = true;
        private EnmLinkTipo _enmLinkTipo = EnmLinkTipo.SELF;
        private int _intTabStop;
        private object _lckLstAtt;
        private List<Atributo> _lstAtt;
        private List<Tag> _lstTag;
        private string _src;
        private string _strAbertura = "<";
        private string _strConteudo;
        private string _strFechamento = ">";
        private string _strId;
        private string _strLink;
        private string _strName;
        private string _strTitle;
        private Tag _tagPai;

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
        /// Indica se um atributo chamado "clazz" será adicionado para esta tag para indicar o tipo a
        /// qual ela pertence. Este atributo dará a chance às classes em TypeScript de inicializar
        /// propriedades, comportamentos ou eventos dessas tags quando a página for carregada no
        /// browser do usuário.
        /// </summary>
        public bool booMostrarClazz
        {
            get
            {
                return _booMostrarClazz;
            }

            set
            {
                _booMostrarClazz = value;
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

                this.atualizarIntTabStop();
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

                // TODO: Avaliar a necessidade de adicionar a versão da aplicação para que recursos
                // não fiquem defasados por conta do cache do navegador.
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

                this.atualizarStrId();
            }
        }

        /// <summary>
        /// Link para onde o usuário será direcionado caso click nesta tag.
        /// </summary>
        public string strLink
        {
            get
            {
                return _strLink;
            }

            set
            {
                _strLink = value;
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

                this.atualizarStrTitle();
            }
        }

        private Atributo attClass
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

                this.atualizarStrName();
            }
        }

        private Tag tagPai
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

                this.atualizarPagPai();
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
        /// cref="Tag"/> (ou um de seus descendentes), ou uma <see cref="PaginaHtml"/> (ou um de seus descendentes).
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
        /// cref="Tag"/> (ou um de seus descendentes), ou uma <see cref="PaginaHtml"/> (ou um de seus descendentes).
        /// </summary>
        public void setPai(PaginaHtml pagPai)
        {
            if (pagPai == null)
            {
                return;
            }

            this.tagPai = pagPai.tagBody;
        }

        /// <summary>
        /// Retorna esta TAG formatada em HTML.
        /// </summary>
        /// <returns>Retorna esta TAG formatada em HTML.</returns>
        public virtual string toHtml()
        {
            // TODO: Criar processo para persistir as tags que não mudam durante o ciclo de uso da aplicação.

            this.inicializar();
            this.montarLayout();
            this.setCss(CssMain.i);
            this.finalizar();
            this.finalizarCss(CssMain.i);
            this.addLayoutFixo(PaginaHtml.i.tagJs);
            this.addConstante(PaginaHtml.i.tagJs);

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
        /// Lista de <see cref="CssArquivo"/> que será carregada pelo browser do usuário.
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
        protected virtual void addJsDebug(LstTag<JavaScriptTag> lstJsDebug)
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
        /// Disparado toda vez que o atributo <see cref="strId"/> for alterado.
        /// </summary>
        protected virtual void atualizarStrId()
        {
            this.attId.strValor = this.strId;
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

        /// <summary>
        /// Método que é chamado antes de montar o HTML desta tag e pode ser utilizado para
        /// inicializar valores diversos das propriedades desta e de outras tags filhas.
        /// </summary>
        protected virtual void inicializar()
        {
            this.addCss(PaginaHtml.i.lstCss);
            this.addJsLib(PaginaHtml.i.lstJsLib);
            this.addJsDebug(PaginaHtml.i.lstJsDebug);
            this.addJs(PaginaHtml.i.tagJs);

            this.inicializarClazz();
        }

        protected virtual void montarLayout()
        {
        }

        /// <summary>
        /// Método que deve ser utilizado para configurar o design desta tag e de seus filhos.
        /// </summary>
        /// <param name="css">Tag CSS principal da página onde serão adicionado todo o design.</param>
        protected virtual void setCss(CssArquivo css)
        {
            this.setCssBooMostrarGrade(css);
        }

        private void atualizarIntTabStop()
        {
            this.attTabIndex.intValor = this.intTabStop;
        }

        private void atualizarPagPai()
        {
            if (this.tagPai == null)
            {
                return;
            }

            this.tagPai.addTag(this);
        }

        private void atualizarStrName()
        {
            if (string.IsNullOrEmpty(this.strName))
            {
                return;
            }

            this.attName.strValor = this.strName;
        }

        private void atualizarStrTitle()
        {
            if (string.IsNullOrEmpty(this.strTitle))
            {
                return;
            }

            this.attTitle.strValor = this.strTitle;
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

        private void inicializarClazz()
        {
            if (!this.booMostrarClazz)
            {
                return;
            }

            this.addAtt("clazz", this.GetType().Name);
        }

        private void setCssBooMostrarGrade(CssArquivo css)
        {
            if (!AppWebBase.i.booMostrarGrade)
            {
                return;
            }

            this.addCss(css.setBorder(1, "dashed", "#ababab"));
        }

        private string toHtmlAtributo()
        {
            if (this.lstAtt == null)
            {
                return null;
            }

            List<string> lstStrAtrAdicionado = new List<string>();
            List<string> lstStrAtrFormatado = new List<string>();

            foreach (Atributo att in this.lstAtt.OrderBy((o) => o.strNome))
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
            StringBuilder stbResultado = new StringBuilder();

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
            stbResultado.Append((!string.IsNullOrEmpty(this.strLink)) ? "</a>" : null);

            return stbResultado.ToString();
        }

        private string toHtmlTagDuplaLinkIn()
        {
            if (string.IsNullOrEmpty(this.strLink))
            {
                return null;
            }

            string strResultado = "<a href=\"_link_valor\" target=\"_target_valor\">";

            strResultado = strResultado.Replace("_link_valor", this.strLink);
            strResultado = strResultado.Replace("_target_valor", this.getStrLinkTipo());

            return strResultado;
        }

        private string toHtmlTagFilho()
        {
            StringBuilder stbResultado = new StringBuilder();

            foreach (Tag tag in this.lstTag)
            {
                if (tag == null)
                {
                    continue;
                }

                stbResultado.Append(tag.toHtml());
            }

            return stbResultado.ToString();
        }

        private string toHtmlTagUnica()
        {
            StringBuilder stbResultado = new StringBuilder();

            stbResultado.Append(this.toHtmlTagDuplaLinkIn());
            stbResultado.Append(this.strAbertura);
            stbResultado.Append(this.strNome);
            stbResultado.Append((0.Equals(this.lstAtt.Count)) ? null : " ");
            stbResultado.Append(this.toHtmlAtributo());
            stbResultado.Append((!this.booBarraFinal) ? null : "/");
            stbResultado.Append(this.strFechamento);
            stbResultado.Append((!string.IsNullOrEmpty(this.strLink)) ? "</a>" : null);

            return stbResultado.ToString();
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}