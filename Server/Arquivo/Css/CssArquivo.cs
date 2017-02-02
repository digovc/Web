using NetZ.Web.Html;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Text;

namespace NetZ.Web.Server.Arquivo.Css
{
    public abstract class CssArquivo : ArquivoEstatico
    {
        #region Constantes

        private const string STR_CLASS_NOME_SUFIXO = "c";

        #endregion Constantes

        #region Atributos

        private CultureInfo _ctiUsa;
        private object _lckLstAttCss;
        private List<AtributoCss> _lstAttCss;
        private StringBuilder _stbConteudo;
        private string _strHref;

        public string strHref
        {
            get
            {
                return _strHref;
            }

            set
            {
                if (_strHref == value)
                {
                    return;
                }

                _strHref = value;

                this.setStrHref(_strHref);
            }
        }

        private CultureInfo ctiUsa
        {
            get
            {
                if (_ctiUsa != null)
                {
                    return _ctiUsa;
                }

                // TODO: Centralizar as possíveis culturas que os sistemas geralmente utilizam.
                _ctiUsa = CultureInfo.CreateSpecificCulture("en-US");

                return _ctiUsa;
            }
        }

        private object lckLstAttCss
        {
            get
            {
                if (_lckLstAttCss != null)
                {
                    return _lckLstAttCss;
                }

                _lckLstAttCss = new object();

                return _lckLstAttCss;
            }
        }

        private List<AtributoCss> lstAttCss
        {
            get
            {
                if (_lstAttCss != null)
                {
                    return _lstAttCss;
                }

                _lstAttCss = new List<AtributoCss>();

                return _lstAttCss;
            }
        }

        private StringBuilder stbConteudo
        {
            get
            {
                if (_stbConteudo != null)
                {
                    return _stbConteudo;
                }

                _stbConteudo = new StringBuilder();

                return _stbConteudo;
            }
        }

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        /// <summary>
        /// Este método pode ser usado para atributos CSS que são pouco usuais e que não possuem
        /// métodos específicos implementados.
        /// </summary>
        /// <param name="strNome">Nome do atributo CSS que se deseja adicionar.</param>
        /// <param name="strValor">Valor do atributo CSS que se deseja adicionar.</param>
        /// <returns>Classe atribuída a este atributo CSS.</returns>
        public string addCss(string strNome, string strValor)
        {
            if (string.IsNullOrEmpty(strNome))
            {
                return null;
            }

            if (string.IsNullOrEmpty(strValor))
            {
                return null;
            }

            lock (this.lckLstAttCss)
            {
                foreach (AtributoCss attCss in this.lstAttCss)
                {
                    if (attCss == null)
                    {
                        continue;
                    }

                    if (!strNome.Equals(attCss.strNome))
                    {
                        continue;
                    }

                    if (!strValor.Equals(attCss.strValor))
                    {
                        continue;
                    }

                    return attCss.strClass;
                }

                return this.addCssNovo(strNome, strValor);
            }
        }

        public override string getStrConteudo()
        {
            return this.stbConteudo.ToString();
        }

        public string setBackground(string css)
        {
            return this.addCss("background", css);
        }

        public string setBackgroundAttachment(string css)
        {
            return this.addCss("background-attachment", css);
        }

        public string setBackgroundColor(string cor)
        {
            return this.addCss("background-color", cor);
        }

        public string setBackgroundColor(Color cor)
        {
            return this.setBackgroundColor(this.corToRgba(cor));
        }

        public string setBackgroundGradiente(string cor, string cor2)
        {
            if (string.IsNullOrEmpty(cor))
            {
                return null;
            }

            if (string.IsNullOrEmpty(cor2))
            {
                return null;
            }

            return this.addCss("background", string.Format("linear-gradient(to bottom,{0},{1})", cor, cor2));
        }

        public string setBackgroundImage(string srcImagem)
        {
            if (string.IsNullOrEmpty(srcImagem))
            {
                return null;
            }

            return this.addCss("background-image", string.Format("url('{0}')", srcImagem));
        }

        public string setBackgroundPosition(string css)
        {
            return this.addCss("background-position", css);
        }

        public string setBackgroundRepeat(string css)
        {
            return this.addCss("background-repeat", css);
        }

        public string setBackgroundSize(string css)
        {
            return this.addCss("background-size", css);
        }

        public string setBorder(int intBorderPx, string strTipo = "solid", string cor = "grey")
        {
            return this.addCss("border", string.Format("{0}px {1} {2}", intBorderPx, strTipo, cor));
        }

        public string setBorder(int intBorderPx, string strTipo, Color cor)
        {
            return this.setBorder(intBorderPx, strTipo = "solid", this.corToRgba(cor));
        }

        public string setBorderBottom(int intBottomPx, string strTipo = "solid", string cor = "grey")
        {
            return this.addCss("border-bottom", string.Format("{0}px {1} {2}", intBottomPx, strTipo, cor));
        }

        public string setBorderBottom(int intRightPx, string strTipo, Color cor)
        {
            return this.setBorderBottom(intRightPx, strTipo, this.corToRgba(cor));
        }

        public string setBorderLeft(int intLeftPx, string strTipo = "solid", string cor = "grey")
        {
            return this.addCss("border-left", string.Format("{0}px {1} {2}", intLeftPx, strTipo, cor));
        }

        public string setBorderLeft(int intRightPx, string strTipo, Color cor)
        {
            return this.setBorderLeft(intRightPx, strTipo, this.corToRgba(cor));
        }

        public string setBorderRadius(int intTopLeftPx, int intTopRightPx, int intBottomRightPx, int intBottomLeftPx)
        {
            return this.addCss("border-radius", string.Format("{0}px {1}px {2}px {3}px", intTopLeftPx, intTopRightPx, intBottomRightPx, intBottomLeftPx));
        }

        public string setBorderRadius(int intBorderRadius, string strGrandeza = "px")
        {
            return this.addCss("border-radius", string.Format("{0}{1}", intBorderRadius, strGrandeza));
        }

        public string setBorderRight(int intRightPx, string strTipo = "solid", string cor = "grey")
        {
            return this.addCss("border-right", string.Format("{0}px {1} {2}", intRightPx, strTipo, cor));
        }

        public string setBorderRight(int intRightPx, string strTipo, Color cor)
        {
            return this.setBorderRight(intRightPx, strTipo, this.corToRgba(cor));
        }

        public string setBorderTop(int intRightPx, string strTipo, Color cor)
        {
            return this.setBorderTop(intRightPx, strTipo, this.corToRgba(cor));
        }

        public string setBorderTop(int intTopPx, string strTipo = "solid", string cor = "grey")
        {
            return this.addCss("border-top", string.Format("{0}px {1} {2}", intTopPx, strTipo, cor));
        }

        public string setBottom(int intBottom, string strGrandeza = "px")
        {
            return this.addCss("bottom", string.Format("{0}{1}", intBottom, strGrandeza));
        }

        public string setBoxShadow(int intHorizontalPx, int intVerticalPx, int intBlurPx, int intSpreadPx, string cor = "grey")
        {
            return this.addCss("box-shadow", string.Format("{0}px {1}px {2}px {3}px {4}", intHorizontalPx, intVerticalPx, intBlurPx, intSpreadPx, cor));
        }

        public string setBoxShadow(int intHorizontalPx, int intVerticalPx, int intBlurPx, int intSpreadPx, Color cor)
        {
            return this.setBoxShadow(intHorizontalPx, intVerticalPx, intBlurPx, intSpreadPx, this.corToRgba(cor));
        }

        public string setCenter()
        {
            return this.addCss("margin", "auto");
        }

        public string setClearBoth()
        {
            return this.addCss("clear", "both");
        }

        public string setColor(string cor)
        {
            return this.addCss("color", cor);
        }

        public string setColor(Color cor)
        {
            return this.setColor(this.corToRgba(cor));
        }

        public string setCursor(string strCursor)
        {
            return this.addCss("cursor", strCursor);
        }

        public string setDisplay(string strDisplay)
        {
            return this.addCss("display", strDisplay);
        }

        public string setFilter(string strFilter)
        {
            return this.addCss("filter", strFilter);
        }

        public string setFloat(string strFloat)
        {
            return this.addCss("float", strFloat);
        }

        public string setFontFamily(string strFontFamily)
        {
            return this.addCss("font-family", strFontFamily);
        }

        public string setFontSize(decimal decFontSize, string strGrandeza = "px")
        {
            return this.addCss("font-size", string.Format("{0}{1}", decFontSize.ToString(this.ctiUsa), strGrandeza));
        }

        public string setFontStyle(string strFontStyle)
        {
            return this.addCss("font-style", strFontStyle);
        }

        public string setFontWeight(string strFontWeight)
        {
            return this.addCss("font-weight", strFontWeight);
        }

        public string setHeight(decimal decHeight, string strGrandeza = "px")
        {
            return this.addCss("height", string.Format("{0}{1}", decHeight.ToString(this.ctiUsa), strGrandeza));
        }

        public string setLeft(int intLeft, string strGrandeza = "px")
        {
            return this.addCss("left", string.Format("{0}{1}", intLeft, strGrandeza));
        }

        public string setLineHeight(decimal decLineHeight, string strGrandeza = "px")
        {
            return this.addCss("line-height", string.Format("{0}{1}", decLineHeight.ToString(this.ctiUsa), strGrandeza));
        }

        public string setMargin(decimal decMargin, string strGrandeza = "px")
        {
            return this.addCss("margin", string.Format("{0}{1}", decMargin.ToString(this.ctiUsa), strGrandeza));
        }

        public string setMargin(string strMargin)
        {
            return this.addCss("margin", strMargin);
        }

        public string setMarginBottom(int intMarginBottom, string strGrandeza = "px")
        {
            return this.addCss("margin-bottom", string.Format("{0}{1}", intMarginBottom, strGrandeza));
        }

        public string setMarginLeft(int intMarginLeft, string strGrandeza = "px")
        {
            return this.addCss("margin-left", string.Format("{0}{1}", intMarginLeft, strGrandeza));
        }

        public string setMarginRight(int intMarginRight, string strGrandeza = "px")
        {
            return this.addCss("margin-right", string.Format("{0}{1}", intMarginRight, strGrandeza));
        }

        public string setMarginTop(int intMarginTop, string strGrandeza = "px")
        {
            return this.addCss("margin-top", string.Format("{0}{1}", intMarginTop, strGrandeza));
        }

        public string setMaxHeight(decimal decHeight, string strGrandeza = "px")
        {
            return this.addCss("max-height", string.Format("{0}{1}", decHeight.ToString(this.ctiUsa), strGrandeza));
        }

        public string setMaxWidth(int intMaxWidth, string strGrandeza = "px")
        {
            return this.addCss("max-width", string.Format("{0}{1}", intMaxWidth, strGrandeza));
        }

        public string setMinHeight(decimal decMinHeight)
        {
            return this.addCss("min-height", string.Format("{0}px", decMinHeight.ToString(this.ctiUsa)));
        }

        public string setMinWidth(decimal decMinWidth)
        {
            return this.addCss("min-width", string.Format("{0}px", decMinWidth.ToString(this.ctiUsa)));
        }

        public string setNegrito()
        {
            return this.addCss("font-weight", "bold");
        }

        public string setOpacity(decimal decOpacity)
        {
            return this.addCss("opacity", decOpacity.ToString(this.ctiUsa));
        }

        public string setOutline(string strOutLine)
        {
            return this.addCss("outline", strOutLine);
        }

        public string setOverflow(string strOverflow)
        {
            return this.addCss("overflow", strOverflow);
        }

        public string setOverflowX(string strOverflowX)
        {
            return this.addCss("overflow-x", strOverflowX);
        }

        public string setOverflowY(string strOverflowY)
        {
            return this.addCss("overflow-y", strOverflowY);
        }

        public string setPadding(int intPadding, string strGrandeza = "px")
        {
            return this.addCss("padding", string.Format("{0}{1}", intPadding, strGrandeza));
        }

        public string setPaddingBottom(int intPaddingBottom, string strGrandeza = "px")
        {
            return this.addCss("padding-bottom", string.Format("{0}{1}", intPaddingBottom, strGrandeza));
        }

        public string setPaddingLeft(int intPaddingLeft, string strGrandeza = "px")
        {
            return this.addCss("padding-left", string.Format("{0}{1}", intPaddingLeft, strGrandeza));
        }

        public string setPaddingRight(int intPaddingRight, string strGrandeza = "px")
        {
            return this.addCss("padding-right", string.Format("{0}{1}", intPaddingRight, strGrandeza));
        }

        public string setPaddingTop(int intPaddingTop, string strGrandeza = "px")
        {
            return this.addCss("padding-top", string.Format("{0}{1}", intPaddingTop, strGrandeza));
        }

        public string setPosition(string strPosition)
        {
            return this.addCss("position", strPosition);
        }

        public string setResize(string strResize)
        {
            return this.addCss("resize", strResize);
        }

        public string setRight(int intRight, string strGrandeza = "px")
        {
            return this.addCss("right", string.Format("{0}{1}", intRight, strGrandeza));
        }

        public string setTextAlign(string strTextAlign)
        {
            return this.addCss("text-align", strTextAlign);
        }

        public string setTextDecoration(string strTextDecoration)
        {
            return this.addCss("text-decoration", strTextDecoration);
        }

        public string setTextShadow(int intX, int intY, int intBlur, string cor)
        {
            return this.addCss("text-shadow", string.Format("{0}px {1}px {2}px {3}", intX, intY, intBlur, cor));
        }

        public string setTextShadow(int intX, int intY, int intBlur, Color cor)
        {
            return this.addCss("text-shadow", string.Format("{0}px {1}px {2}px {3}", intX, intY, intBlur, this.corToRgba(cor)));
        }

        public string setTop(int intTop, string strGrandeza = "px")
        {
            return this.addCss("top", string.Format("{0}{1}", intTop, strGrandeza));
        }

        public string setVisibility(string strVisibility)
        {
            return this.addCss("visibility", strVisibility);
        }

        public string setWhiteSpace(string strWhiteSpace)
        {
            return this.addCss("white-space", strWhiteSpace);
        }

        public string setWidth(decimal decWidth, string strGrandeza = "px")
        {
            return this.addCss("width", string.Format("{0}{1}", decWidth.ToString(this.ctiUsa), strGrandeza));
        }

        public string setZIndex(int intZIndex)
        {
            return this.addCss("z-index", intZIndex.ToString());
        }

        protected void addCssPuro(string css)
        {
            if (string.IsNullOrEmpty(css))
            {
                return;
            }

            this.stbConteudo.Append(css);

            this.arrBteConteudo = null;
            this.dttUltimaModificacao = DateTime.Now;
        }

        protected override byte[] getArrBteConteudo()
        {
            return Encoding.UTF8.GetBytes(this.stbConteudo.ToString());
        }

        protected override void inicializar()
        {
            base.inicializar();

            this.booNaoCriarDiretorio = true;
        }

        private string addCssNovo(string strNome, string strValor)
        {
            if (string.IsNullOrEmpty(strNome))
            {
                return null;
            }

            if (string.IsNullOrEmpty(strValor))
            {
                return null;
            }

            AtributoCss atrCss = new AtributoCss((STR_CLASS_NOME_SUFIXO + this.lstAttCss.Count), strNome, strValor);

            this.lstAttCss.Add(atrCss);
            this.stbConteudo.Append(atrCss.getStrFormatado());

            this.arrBteConteudo = null;
            this.dttUltimaModificacao = DateTime.Now;

            return atrCss.strClass;
        }

        private string corToRgba(Color cor)
        {
            double dblAlpha = (cor.A < 255) ? (cor.A / 255d) : 1;

            return string.Format("rgba({0},{1},{2},{3})", cor.R, cor.G, cor.B, dblAlpha.ToString(this.ctiUsa));
        }

        private void setStrHref(string strHref)
        {
            this.dirCompleto = strHref;
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}