using System;
using System.Collections.Generic;
using System.Text;

namespace NetZ.Web.Html
{
    public class CssTag : Tag
    {
        #region Constantes

        public const string STR_CSS_IMPRESSAO_ID = "cssImp";
        public const string STR_CSS_MAIN_ID = "cssMain";
        private const string STR_CLASS_NOME_SUFIXO = "c";

        #endregion Constantes

        #region Atributos

        private static CssTag _i;
        private static CssTag _iImpressao;
        private List<AtributoCss> _lstAttCss;
        private StringBuilder _stbCssPuro;
        private string _strConteudo;
        private string _strHref;

        public static CssTag i
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

                    _i = new CssTag();

                    _i.strId = CssTag.STR_CSS_MAIN_ID;

                    _i.addCssPuro("::-webkit-scrollbar-corner{background-color:rgb(239,239,239)}");
                    _i.addCssPuro("::-webkit-scrollbar-thumb{background-color:rgb(215, 215, 215);border:1px solid rgb(195,195,195)}");
                    _i.addCssPuro("::-webkit-scrollbar-track{background-color:rgb(239,239,239)}");
                    _i.addCssPuro("::-webkit-scrollbar{height:12px;width:12px}");
                    _i.addCssPuro("a{color:#428bca;text-decoration:none}");
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
        }

        public static CssTag iImpressao
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_iImpressao != null)
                    {
                        return _iImpressao;
                    }

                    _iImpressao = new CssTag();

                    _iImpressao.addAtt("media", "print");
                    _iImpressao.strId = CssTag.STR_CSS_IMPRESSAO_ID;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _iImpressao;
            }
        }

        public override string strConteudo
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (!string.IsNullOrEmpty(_strConteudo))
                    {
                        return _strConteudo;
                    }

                    _strConteudo = this.getStrConteudo();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _strConteudo;
            }

            set
            {
                _strConteudo = null;
            }
        }

        public string strHref
        {
            get
            {
                return _strHref;
            }

            set
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    _strHref = value;

                    if (string.IsNullOrEmpty(_strHref))
                    {
                        return;
                    }

                    this.addAtt("href", _strHref);
                    this.addAtt("rel", "stylesheet");
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

        private List<AtributoCss> lstAttCss
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_lstAttCss != null)
                    {
                        return _lstAttCss;
                    }

                    _lstAttCss = new List<AtributoCss>();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _lstAttCss;
            }
        }

        private StringBuilder stbCssPuro
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_stbCssPuro != null)
                    {
                        return _stbCssPuro;
                    }

                    _stbCssPuro = new StringBuilder();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _stbCssPuro;
            }
        }

        #endregion Atributos

        #region Construtores

        public CssTag() : base("style")
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.booTagDupla = true;
                this.addAtt("type", "text/css");
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

        public string addCss(string strNome, string strValor)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (string.IsNullOrEmpty(strNome))
                {
                    return null;
                }

                if (string.IsNullOrEmpty(strValor))
                {
                    return null;
                }

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
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion Ações
        }

        public string getStrConteudo()
        {
            #region Variáveis

            StringBuilder stResultado;

            #endregion Variáveis

            #region Ações

            try
            {
                if (!string.IsNullOrEmpty(_strConteudo))
                {
                    return _strConteudo;
                }

                stResultado = new StringBuilder();

                foreach (AtributoCss atrCss in this.lstAttCss)
                {
                    if (atrCss == null)
                    {
                        continue;
                    }

                    stResultado.Append(atrCss.getStrFormatado());
                }

                stResultado.Append(this.stbCssPuro);

                return stResultado.ToString();
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

        public string setBackgroundColor(string cor)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (string.IsNullOrEmpty(cor))
                {
                    return null;
                }

                return this.addCss("background-color", cor);
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

        public string setBackgroundGradiente(string cor, string cor2)
        {
            #region Variáveis

            string css;

            #endregion Variáveis

            #region Ações

            try
            {
                if (string.IsNullOrEmpty(cor))
                {
                    return null;
                }

                if (string.IsNullOrEmpty(cor2))
                {
                    return null;
                }

                css = "linear-gradient(to bottom,_cor_1,_cor_2)";

                css = css.Replace("_cor_1", cor);
                css = css.Replace("_cor_2", cor2);

                return this.addCss("background", css);
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

        public string setBackgroundImage(string srcImagem)
        {
            #region Variáveis

            string css;

            #endregion Variáveis

            #region Ações

            try
            {
                if (string.IsNullOrEmpty(srcImagem))
                {
                    return null;
                }
                css = "url('_src_imagem')";

                css = css.Replace("_src_imagem", srcImagem);

                return this.addCss("background-image", css);
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

        public string setBackgroundRepeat(string css)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (string.IsNullOrEmpty(css))
                {
                    return null;
                }

                return this.addCss("background-repeat", css);
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

        public string setBackgroundSize(string css)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (string.IsNullOrEmpty(css))
                {
                    return null;
                }

                return this.addCss("background-size", css);
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

        public string setBorder(int intBorderPx, string strTipo = "solid", string cor = null)
        {
            #region Variáveis

            string css;

            #endregion Variáveis

            #region Ações

            try
            {
                css = "_border_pxpx _tipo _cor";

                css = css.Replace("_border_px", intBorderPx.ToString());
                css = css.Replace("_tipo", strTipo);
                css = css.Replace("_cor", cor);

                return this.addCss("border", css);
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

        public string setBorderBottom(int intBottomPx, string strTipo, string cor)
        {
            #region Variáveis

            string css;

            #endregion Variáveis

            #region Ações

            try
            {
                css = "_border_bottom_pxpx _border_tipo _cor";

                css = css.Replace("_border_bottom_px", intBottomPx.ToString());
                css = css.Replace("_border_tipo", strTipo);
                css = css.Replace("_cor", cor);

                return this.addCss("border-bottom", css);
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

        public string setBorderLeft(int intLeftPx, string strTipo, string cor)
        {
            #region Variáveis

            string css;

            #endregion Variáveis

            #region Ações

            try
            {
                css = "_border_left_pxpx _border_tipo _cor";

                css = css.Replace("_border_left_px", intLeftPx.ToString());
                css = css.Replace("_border_tipo", strTipo);
                css = css.Replace("_cor", cor);

                return this.addCss("border-left", css);
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

        public string setBorderRadius(int intTopLeftPx, int intTopRightPx, int intBottomRightPx, int intBottomLeftPx)
        {
            #region Variáveis

            string css;

            #endregion Variáveis

            #region Ações

            try
            {
                css = "_top_left_pxpx _top_right_pxpx _bottom_right_pxpx _bottom_left_pxpx";

                css = css.Replace("_top_left_px", intTopLeftPx.ToString());
                css = css.Replace("_top_right_px", intTopRightPx.ToString());
                css = css.Replace("_bottom_right_px", intBottomRightPx.ToString());
                css = css.Replace("_bottom_left_px", intBottomLeftPx.ToString());

                return this.addCss("border-radius", css);
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

        public string setBorderRadius(int intBorderRadius, string strGrandeza = "px")
        {
            #region Variáveis

            string css;

            #endregion Variáveis

            #region Ações

            try
            {
                css = "_border_radius_grandeza";

                css = css.Replace("_border_radius", intBorderRadius.ToString());
                css = css.Replace("_grandeza", strGrandeza);

                return this.addCss("border-radius", css);
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

        public string setBorderRight(int intRightPx, string strTipo, string cor)
        {
            #region Variáveis

            string css;

            #endregion Variáveis

            #region Ações

            try
            {
                css = "_border_tight_pxpx _border_tipo _cor";

                css = css.Replace("_border_tight_px", intRightPx.ToString());
                css = css.Replace("_border_tipo", strTipo);
                css = css.Replace("_cor", cor);

                return this.addCss("border-right", css);
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

        public string setBorderTop(int intTopPx, string strTipo, string cor)
        {
            #region Variáveis

            string css;

            #endregion Variáveis

            #region Ações

            try
            {
                css = "_border_top_pxpx _border_tipo _cor";

                css = css.Replace("_border_top_px", intTopPx.ToString());
                css = css.Replace("_border_tipo", strTipo);
                css = css.Replace("_cor", cor);

                return this.addCss("border-top", css);
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

        public string setBottom(int intBottom, string strGrandeza = "px")
        {
            #region Variáveis

            string css;

            #endregion Variáveis

            #region Ações

            try
            {
                css = "_bottom_grandeza";

                css = css.Replace("_bottom", intBottom.ToString());
                css = css.Replace("_grandeza", strGrandeza);

                return this.addCss("bottom", css);
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

        public string setBoxShadow(int intHorizontalPx, int intVerticalPx, int intBlurPx, int intSpreadPx, string cor)
        {
            #region Variáveis

            string css;

            #endregion Variáveis

            #region Ações

            try
            {
                css = "_horizontal_pxpx _vertical_pxpx _blur_pxpx _spread_pxpx _cor";

                css = css.Replace("_horizontal_px", intHorizontalPx.ToString());
                css = css.Replace("_vertical_px", intVerticalPx.ToString());
                css = css.Replace("_blur_px", intBlurPx.ToString());
                css = css.Replace("_spread_px", intSpreadPx.ToString());
                css = css.Replace("_cor", cor);

                return this.addCss("box-shadow", css);
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
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (string.IsNullOrEmpty(cor))
                {
                    return null;
                }

                return this.addCss("color", cor);
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

        public string setCursor(string strCursor)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (string.IsNullOrEmpty(strCursor))
                {
                    return null;
                }

                return this.addCss("cursor", strCursor);
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

        public string setDisplay(string strDisplay)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (string.IsNullOrEmpty(strDisplay))
                {
                    return null;
                }

                return this.addCss("display", strDisplay);
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

        public string setFloat(string strFloat)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (string.IsNullOrEmpty(strFloat))
                {
                    return null;
                }

                return this.addCss("float", strFloat);
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

        public string setFontFamily(string strFontFamily)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (string.IsNullOrEmpty(strFontFamily))
                {
                    return null;
                }

                return this.addCss("font-family", strFontFamily);
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

        public string setFontSize(double dblFontSize, string strGrandeza = "px")
        {
            #region Variáveis

            string css;

            #endregion Variáveis

            #region Ações

            try
            {
                css = "_font_size_font_grandeza";

                css = css.Replace("_font_size", dblFontSize.ToString());
                css = css.Replace("_font_grandeza", strGrandeza);

                return this.addCss("font-size", css);
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

        public string setFontStyle(string strFontStyle)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (string.IsNullOrEmpty(strFontStyle))
                {
                    return null;
                }

                return this.addCss("font-style", strFontStyle);
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

        public string setHeight(double dblHeight, string strGrandeza = "px")
        {
            #region Variáveis

            string css;

            #endregion Variáveis

            #region Ações

            try
            {
                css = "_height_grandeza";

                css = css.Replace("_height", dblHeight.ToString());
                css = css.Replace("_grandeza", strGrandeza);

                return this.addCss("height", css);
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

        public string setLeft(int intLeft, string strGrandeza = "px")
        {
            #region Variáveis

            string css;

            #endregion Variáveis

            #region Ações

            try
            {
                css = "_right_px_grandeza";

                css = css.Replace("_right_px", intLeft.ToString());
                css = css.Replace("_grandeza", strGrandeza);

                return this.addCss("left", css);
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

        public string setLineHeight(double dblLineHeight, string strGrandeza = "px")
        {
            #region Variáveis

            string css;

            #endregion Variáveis

            #region Ações

            try
            {
                css = "_line_height_grandeza";

                css = css.Replace("_line_height", dblLineHeight.ToString());
                css = css.Replace("_grandeza", strGrandeza);

                return this.addCss("line-height", css);
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

        public string setMargin(int intMargin, string strGrandeza = "px")
        {
            #region Variáveis

            string css;

            #endregion Variáveis

            #region Ações

            try
            {
                css = "_margin_grandeza";

                css = css.Replace("_margin", intMargin.ToString());
                css = css.Replace("_grandeza", strGrandeza);

                return this.addCss("margin", css);
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

        public string setMarginBottom(int intMarginBottomPx)
        {
            #region Variáveis

            string css;

            #endregion Variáveis

            #region Ações

            try
            {
                css = "_margin_bottom_pxpx";
                css = css.Replace("_margin_bottom_px", intMarginBottomPx.ToString());

                return this.addCss("margin-bottom", css);
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

        public string setMarginLeft(int intMarginLeftPx)
        {
            #region Variáveis

            string css;

            #endregion Variáveis

            #region Ações

            try
            {
                css = "_margin_left_pxpx";
                css = css.Replace("_margin_left_px", intMarginLeftPx.ToString());

                return this.addCss("margin-left", css);
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

        public string setMarginRight(int intMarginRightPx)
        {
            #region Variáveis

            string css;

            #endregion Variáveis

            #region Ações

            try
            {
                css = "_margin_right_pxpx";
                css = css.Replace("_margin_right_px", intMarginRightPx.ToString());

                return this.addCss("margin-right", css);
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

        public string setMarginTop(int intMarginTopPx)
        {
            #region Variáveis

            string css;

            #endregion Variáveis

            #region Ações

            try
            {
                css = "_margin_top_pxpx";
                css = css.Replace("_margin_top_px", intMarginTopPx.ToString());

                return this.addCss("margin-top", css);
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

        public string setMinHeight(double dblMinHeight)
        {
            #region Variáveis

            string css;

            #endregion Variáveis

            #region Ações

            try
            {
                css = "_min_height_pxpx";
                css = css.Replace("_min_height_px", dblMinHeight.ToString());

                return this.addCss("min-height", css);
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

        public string setMinWidth(double dblMinWidth)
        {
            #region Variáveis

            string css;

            #endregion Variáveis

            #region Ações

            try
            {
                css = "_min_width_pxpx";
                css = css.Replace("_min_width_px", dblMinWidth.ToString());

                return this.addCss("min-width", css);
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

        public string setNegrito()
        {
            return this.addCss("font-weight", "bold");
        }

        public string setOpacity(double dblOpacity)
        {
            return this.addCss("opacity", dblOpacity.ToString());
        }

        public string setOverflow(string strOverflowPx)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (string.IsNullOrEmpty(strOverflowPx))
                {
                    return null;
                }

                return this.addCss("overflow", strOverflowPx);
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

        public string setOverflowX(string strOverflowPx)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (string.IsNullOrEmpty(strOverflowPx))
                {
                    return null;
                }

                return this.addCss("overflow-x", strOverflowPx);
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

        public string setOverflowY(string strOverflowPx)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (string.IsNullOrEmpty(strOverflowPx))
                {
                    return null;
                }

                return this.addCss("overflow-y", strOverflowPx);
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

        public string setPadding(int intPadding, string strGrandeza = "px")
        {
            #region Variáveis

            string css;

            #endregion Variáveis

            #region Ações

            try
            {
                css = "_padding_grandeza";

                css = css.Replace("_padding", intPadding.ToString());
                css = css.Replace("_grandeza", strGrandeza);

                return this.addCss("padding", css);
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

        public string setPaddingBottom(int intPaddingBottomPx)
        {
            #region Variáveis

            string css;

            #endregion Variáveis

            #region Ações

            try
            {
                css = "_padding_bottom_pxpx";
                css = css.Replace("_padding_bottom_px", intPaddingBottomPx.ToString());

                return this.addCss("padding-bottom", css);
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

        public string setPaddingLeft(int intPaddingLeftPx)
        {
            #region Variáveis

            string css;

            #endregion Variáveis

            #region Ações

            try
            {
                css = "_padding_left_pxpx";
                css = css.Replace("_padding_left_px", intPaddingLeftPx.ToString());

                return this.addCss("padding-left", css);
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

        public string setPaddingRight(int intPaddingRightPx)
        {
            #region Variáveis

            string css;

            #endregion Variáveis

            #region Ações

            try
            {
                css = "_padding_right_pxpx";
                css = css.Replace("_padding_right_px", intPaddingRightPx.ToString());

                return this.addCss("padding-right", css);
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

        public string setPaddingTop(int intPaddingTopPx)
        {
            #region Variáveis

            string css;

            #endregion Variáveis

            #region Ações

            try
            {
                css = "_padding_top_pxpx";
                css = css.Replace("_padding_top_px", intPaddingTopPx.ToString());

                return this.addCss("padding-top", css);
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

        public string setPosition(string strPosition)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (string.IsNullOrEmpty(strPosition))
                {
                    return null;
                }

                return this.addCss("position", strPosition);
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

        public string setRight(int intRight, string strGrandeza = "px")
        {
            #region Variáveis

            string css;

            #endregion Variáveis

            #region Ações

            try
            {
                css = "_right_grandeza";

                css = css.Replace("_right", intRight.ToString());
                css = css.Replace("_grandeza", strGrandeza);

                return this.addCss("right", css);
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

        public string setTextAlign(string strTextAlign)
        {
            return this.addCss("text-align", strTextAlign);
        }

        public string setTextDecoration(string strTextDecoration)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (string.IsNullOrEmpty(strTextDecoration))
                {
                    return null;
                }

                return this.addCss("text-decoration", strTextDecoration);
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

        public string setTextShadow(int intX, int intY, int intBlur, string cor)
        {
            #region Variáveis

            string css;

            #endregion Variáveis

            #region Ações

            try
            {
                css = "_x_pxpx _y_pxpx _blur_pxpx _cor";

                css = css.Replace("_x_px", intX.ToString());
                css = css.Replace("_y_px", intY.ToString());
                css = css.Replace("_blur_px", intBlur.ToString());
                css = css.Replace("_cor", cor);

                return this.addCss("text-shadow", css);
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

        public string setTop(int intTop, string strGrandeza = "px")
        {
            #region Variáveis

            string css;

            #endregion Variáveis

            #region Ações

            try
            {
                css = "_top_px_grandeza";

                css = css.Replace("_top_px", intTop.ToString());
                css = css.Replace("_grandeza", strGrandeza);

                return this.addCss("top", css);
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

        public string setWhiteSpace(string strWhiteSpace)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (string.IsNullOrEmpty(strWhiteSpace))
                {
                    return null;
                }

                return this.addCss("white-space", strWhiteSpace);
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

        public string setWidth(double dblWidth, string strGrandeza = "px")
        {
            #region Variáveis

            string css;

            #endregion Variáveis

            #region Ações

            try
            {
                css = "_width_grandeza";

                css = css.Replace("_width", dblWidth.ToString());
                css = css.Replace("_grandeza", strGrandeza);

                return this.addCss("width", css);
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

        public string setZIndex(int intZIndex)
        {
            return this.addCss("z-index", intZIndex.ToString());
        }

        public override string toHtml()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (string.IsNullOrEmpty(this.strConteudo))
                {
                    return null;
                }

                if (CssTag.STR_CSS_MAIN_ID.Equals(this.strId) || CssTag.STR_CSS_IMPRESSAO_ID.Equals(this.strId))
                {
                    return base.toHtml();
                }

                this.strNome = "link";
                this.booTagDupla = false;

                return base.toHtml();
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
        /// Não remover!
        /// <para>
        /// Este método tem de ser sobescrito para que não haja um loop infinito e também porque
        /// esta tag não precisa de layout.
        /// </para>
        /// </summary>
        protected override void setCss(CssTag tagCss)
        {
            // Não fazer nada.
        }

        private string addCssNovo(string strNome, string strValor)
        {
            #region Variáveis

            AtributoCss atrCss;

            #endregion Variáveis

            #region Ações

            try
            {
                if (string.IsNullOrEmpty(strNome))
                {
                    return null;
                }

                if (string.IsNullOrEmpty(strValor))
                {
                    return null;
                }

                atrCss = new AtributoCss((STR_CLASS_NOME_SUFIXO + this.lstAttCss.Count), strNome, strValor);

                this.lstAttCss.Add(atrCss);
                this.strConteudo = null;

                return atrCss.strClass;
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

        private void addCssPuro(string css)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (string.IsNullOrEmpty(css))
                {
                    return;
                }

                this.stbCssPuro.Append(css);
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