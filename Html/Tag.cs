using System;
using System.Collections.Generic;
using System.Text;
using NetZ.SistemaBase;

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
        private Atributo _attTitle;
        private Atributo _attType;
        private bool _booBarraFinal = true;
        private bool _booClicavel;
        private bool _booTagDupla = true;
        private EnmLinkTipo _enmLinkTipo = EnmLinkTipo.SELF;
        private List<Atributo> _lstAtt;
        private List<Tag> _lstTag;
        private string _src;
        private string _strAbertura = "<";
        private string _strCache;
        private string _strConteudo;
        private string _strFechamento = ">";
        private string _strId;
        private string _strLink;
        private string _strName;
        private string _strTitle;
        private Tag _tagPai;

        public Atributo attType
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_attType != null)
                    {
                        return _attType;
                    }

                    _attType = new Atributo("type");

                    this.addAtt(_attType);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _attType;
            }
        }

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

        public bool booTagDupla
        {
            get
            {
                return _booTagDupla;
            }

            set
            {
                _booTagDupla = value;
            }
        }

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
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    _src = value;

                    if (string.IsNullOrEmpty(_src))
                    {
                        return;
                    }

                    // TODO: Avaliar a necessidade de adicionar a versão da aplicação para que
                    // recursos não fiquem defasados por conta do cache do navegador.
                    this.attSrc.strValor = _src;
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
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_strId != null)
                    {
                        return _strId;
                    }

                    _strId = this.getStrId();

                    this.attId.strValor = _strId;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _strId;
            }

            set
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    _strId = value;

                    this.attId.strValor = _strId;
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
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    _strTitle = value;

                    if (string.IsNullOrEmpty(_strTitle))
                    {
                        return;
                    }

                    this.attTitle.strValor = _strTitle;
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

        private Atributo attClass
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_attClass != null)
                    {
                        return _attClass;
                    }

                    _attClass = new Atributo("class");

                    this.addAtt(_attClass);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _attClass;
            }
        }

        private Atributo attId
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_attId != null)
                    {
                        return _attId;
                    }

                    _attId = new Atributo("id");

                    this.addAtt(_attId);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _attId;
            }
        }

        private Atributo attName
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_attName != null)
                    {
                        return _attName;
                    }

                    _attName = new Atributo("name");

                    this.addAtt(_attName);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _attName;
            }
        }

        private Atributo attSrc
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_attSrc != null)
                    {
                        return _attSrc;
                    }

                    _attSrc = new Atributo("src");

                    this.addAtt(_attSrc);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _attSrc;
            }
        }

        private Atributo attTitle
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_attTitle != null)
                    {
                        return _attTitle;
                    }

                    _attTitle = new Atributo("title");

                    this.addAtt(_attTitle);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _attTitle;
            }
        }

        private bool booClicavel
        {
            get
            {
                return _booClicavel;
            }

            set
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    _booClicavel = value;

                    if (!_booClicavel)
                    {
                        return;
                    }

                    // TODO: Descomentar.
                    //this.addCss(CssTag.i.setCursor(CssTag.EnmCursor.POINTER));
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

        private List<Atributo> lstAtt
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_lstAtt != null)
                    {
                        return _lstAtt;
                    }

                    _lstAtt = new List<Atributo>();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _lstAtt;
            }
        }

        private List<Tag> lstTag
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_lstTag != null)
                    {
                        return _lstTag;
                    }

                    _lstTag = new List<Tag>();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

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

        private string strCache
        {
            get
            {
                return _strCache;
            }

            set
            {
                _strCache = value;
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

        private string strLink
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

        private string strName
        {
            get
            {
                return _strName;
            }

            set
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    _strName = value;

                    if (string.IsNullOrEmpty(_strName))
                    {
                        return;
                    }

                    this.attName.strValor = _strName;
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

        private Tag tagPai
        {
            get
            {
                return _tagPai;
            }

            set
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    _tagPai = value;

                    this.atualizarPagPai();
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

        public Tag(string strNome)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.strNome = strNome;
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

        /// <summary>
        /// Adiciona um atributo para esta tag.
        /// </summary>
        /// <param name="att">Atributo que será adicionado para esta tag.</param>
        public void addAtt(Atributo att)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (att == null)
                {
                    return;
                }

                if (string.IsNullOrEmpty(att.strNome))
                {
                    return;
                }

                foreach (Atributo att2 in this.lstAtt)
                {
                    if (att2 == null)
                    {
                        continue;
                    }

                    if (!att2.strNome.Equals(att.strNome))
                    {
                        continue;
                    }

                    this.lstAtt.Remove(att2);
                    break;
                }

                this.lstAtt.Add(att);
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
        /// Link para <see cref="addAtt(Atributo)"/>.
        /// </summary>
        public void addAtt(string strAttNome, string strValor = null)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (string.IsNullOrEmpty(strAttNome))
                {
                    return;
                }

                this.addAtt(new Atributo(strAttNome, strValor));
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

        public void addAtt(string strAttNome, decimal decValor)
        {
            this.addAtt(new Atributo(strAttNome, decValor.ToString()));
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
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (string.IsNullOrEmpty(strCssClass))
                {
                    return;
                }

                this.attClass.addValor(strCssClass);
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

        public void apagarAtt(string strAttNome)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
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

                    if (!strAttNome.Equals(att))
                    {
                        continue;
                    }

                    this.lstAtt.Remove(att);
                    return;
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

        public void limparClass()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.attClass.strValor = null;
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
        /// Indica qual o elemento será o "pai" desta tag. Este elemento pode ser uma <see
        /// cref="Tag"/> (ou um de seus descendentes), ou uma <see cref="PaginaHtml"/> (ou um de
        /// seus descendentes).
        /// </summary>
        public void setPai(Tag tagPai)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (tagPai == null)
                {
                    return;
                }

                this.tagPai = tagPai;
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
        /// Indica qual o elemento será o "pai" desta tag. Este elemento pode ser uma <see
        /// cref="Tag"/> (ou um de seus descendentes), ou uma <see cref="PaginaHtml"/> (ou um de
        /// seus descendentes).
        /// </summary>
        public void setPai(PaginaHtml pagPai)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (pagPai == null)
                {
                    return;
                }

                this.tagPai = pagPai.tagBody;
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
        /// Retorna esta TAG formatada em HTML.
        /// </summary>
        /// <returns>Retorna esta TAG formatada em HTML.</returns>
        public virtual string toHtml()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                //if (!string.IsNullOrEmpty(this.strCache))
                //{
                //    return this.strCache;
                //}

                this.inicializar();
                this.finalizar();

                if (this.getBooTagDupla())
                {
                    this.strCache = this.toHtmlTagDupla();
                }
                else
                {
                    this.strCache = this.toHtmlTagUnica();
                }

                return this.strCache;
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
        /// Método que serve para adicionar arquivos CSS estáticos para lista que será carregada
        /// pelo browser do usuário.
        /// </summary>
        /// <param name="lstCss">
        /// Lista de <see cref="CssTag"/> que será carregada pelo browser do usuário.
        /// </param>
        protected virtual void addCss(LstTag<CssTag> lstCss)
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
        /// Adiciona uma tag para a lista <see cref="lstTag"/>. Essas são as tags que estarão
        /// contidas por esta.
        /// </summary>
        /// <param name="tag">Tag que será contida por esta tag.</param>
        protected virtual void addTag(Tag tag)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (tag == null)
                {
                    return;
                }

                this.lstTag.Add(tag);
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
        /// Método que será chamado após <see cref="montarLayout"/> para que os ajustes finais sejam feitos.
        /// </summary>
        protected virtual void finalizar()
        {
        }

        /// <summary>
        /// Método que é chamado antes de montar o HTML desta tag e pode ser utilizado para
        /// inicializar valores diversos das propriedades desta e de outras tags filhas.
        /// </summary>
        protected virtual void inicializar()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
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
                this.addCss(PaginaHtml.i.lstCss);
                this.addJs(PaginaHtml.i.lstJs);
                this.addJs(PaginaHtml.i.tagJs);

                if (this is CssTag)
                {
                    return;
                }

                this.setCss(CssTag.i);
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
        /// Método que deve ser utilizado para configurar o design desta tag e de seus filhos.
        /// </summary>
        /// <param name="css">Tag CSS principal da página onde serão adicionado todo o design.</param>
        protected virtual void setCss(CssTag css)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.setCssBooMostrarGrade(css);
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

        private void atualizarPagPai()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (this.tagPai == null)
                {
                    return;
                }

                this.tagPai.addTag(this);
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

        private bool getBooTagDupla()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (this.booTagDupla)
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
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion Ações

            return false;
        }

        private string getStrId()
        {
            #region Variáveis

            string strResultado;

            #endregion Variáveis

            #region Ações

            try
            {
                strResultado = "id_int_id";
                strResultado = strResultado.Replace("_int_id", this.intObjetoId.ToString());

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

        private string getStrJsClasse()
        {
            #region Variáveis

            string strResultado;

            #endregion Variáveis

            #region Ações

            try
            {
                strResultado = this.GetType().Namespace;

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

        private string getStrLinkTipo()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
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
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion Ações
        }

        private void setCssBooMostrarGrade(CssTag css)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (!AppWeb.i.booMostrarGrade)
                {
                    return;
                }

                this.addCss(css.setBorder(1, "dashed", "#ababab"));
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

        private string toHtmlAtributo()
        {
            #region Variáveis

            List<string> lstStrAtrAdicionado;
            List<string> lstStrAtrFormatado;

            #endregion Variáveis

            #region Ações

            try
            {
                lstStrAtrAdicionado = new List<string>();
                lstStrAtrFormatado = new List<string>();

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

                    if (lstStrAtrAdicionado.Contains(att.strNome))
                    {
                        continue;
                    }

                    lstStrAtrFormatado.Add(att.getStrFormatado());
                }

                return string.Join(" ", lstStrAtrFormatado.ToArray());
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

        private string toHtmlTagDupla()
        {
            #region Variáveis

            StringBuilder stbResultado;

            #endregion Variáveis

            #region Ações

            try
            {
                stbResultado = new StringBuilder();

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
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion Ações
        }

        private string toHtmlTagDuplaLinkIn()
        {
            #region Variáveis

            string strResultado;

            #endregion Variáveis

            #region Ações

            try
            {
                if (string.IsNullOrEmpty(this.strLink))
                {
                    return null;
                }

                strResultado = "<a href=\"_link_valor\" target=\"_target_valor\">";

                strResultado = strResultado.Replace("_link_valor", this.strLink);
                strResultado = strResultado.Replace("_target_valor", this.getStrLinkTipo());

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

        private string toHtmlTagFilho()
        {
            #region Variáveis

            StringBuilder stbResultado;

            #endregion Variáveis

            #region Ações

            try
            {
                stbResultado = new StringBuilder();

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
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion Ações
        }

        private string toHtmlTagUnica()
        {
            #region Variáveis

            StringBuilder stbResultado;

            #endregion Variáveis

            #region Ações

            try
            {
                stbResultado = new StringBuilder();

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