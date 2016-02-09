using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Text;
using NetZ.Web.Html;

namespace NetZ.Web.Server.Arquivo.Css
{
    public abstract class CssArquivo : ArquivoEstatico
    {
        #region Constantes

        private const string STR_CLASS_NOME_SUFIXO = "c";

        #endregion Constantes

        #region Atributos

        private CultureInfo _ctiUsa;
        private DateTime _dttCssUltimaAdicao;
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
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    _strHref = value;

                    this.atualizarStrHref();
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

        private CultureInfo ctiUsa
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_ctiUsa != null)
                    {
                        return _ctiUsa;
                    }

                    _ctiUsa = CultureInfo.CreateSpecificCulture("en-US");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _ctiUsa;
            }
        }

        private DateTime dttCssUltimaAdicao
        {
            get
            {
                return _dttCssUltimaAdicao;
            }

            set
            {
                _dttCssUltimaAdicao = value;
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

        private StringBuilder stbConteudo
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_stbConteudo != null)
                    {
                        return _stbConteudo;
                    }

                    _stbConteudo = new StringBuilder();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

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

        public new string getStrConteudo()
        {
            return this.stbConteudo.ToString();
        }

        public string setBackgroundAttachment(string css)
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

                return this.addCss("background-attachment", css);
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

        public string setBackgroundColor(Color cor)
        {
            return this.setBackgroundColor(ColorTranslator.ToHtml(cor));
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

        public string setBackgroundPosition(string css)
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

                return this.addCss("background-position", css);
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

        public string setBorder(int intBorderPx, string strTipo, Color cor)
        {
            return this.setBorder(intBorderPx, strTipo = "solid", ColorTranslator.ToHtml(cor));
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

        public string setBorderBottom(int intRightPx, string strTipo, Color cor)
        {
            return this.setBorderBottom(intRightPx, strTipo, ColorTranslator.ToHtml(cor));
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

        public string setBorderLeft(int intRightPx, string strTipo, Color cor)
        {
            return this.setBorderLeft(intRightPx, strTipo, ColorTranslator.ToHtml(cor));
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

        public string setBorderRight(int intRightPx, string strTipo, Color cor)
        {
            return this.setBorderRight(intRightPx, strTipo, ColorTranslator.ToHtml(cor));
        }

        public string setBorderTop(int intRightPx, string strTipo, Color cor)
        {
            return this.setBorderTop(intRightPx, strTipo, ColorTranslator.ToHtml(cor));
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

        public string setBoxShadow(int intHorizontalPx, int intVerticalPx, int intBlurPx, int intSpreadPx, Color cor)
        {
            return this.setBoxShadow(intHorizontalPx, intVerticalPx, intBlurPx, intSpreadPx, ColorTranslator.ToHtml(cor));
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

        public string setColor(Color cor)
        {
            return this.setColor(ColorTranslator.ToHtml(cor));
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

        public string setFontSize(decimal decFontSize, string strGrandeza = "px")
        {
            #region Variáveis

            string css;

            #endregion Variáveis

            #region Ações

            try
            {
                css = "_font_size_font_grandeza";

                css = css.Replace("_font_size", decFontSize.ToString(this.ctiUsa));
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

        public string setHeight(decimal decHeight, string strGrandeza = "px")
        {
            #region Variáveis

            string css;

            #endregion Variáveis

            #region Ações

            try
            {
                css = "_height_grandeza";

                css = css.Replace("_height", decHeight.ToString(this.ctiUsa));
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

        public string setLineHeight(decimal decLineHeight, string strGrandeza = "px")
        {
            #region Variáveis

            string css;

            #endregion Variáveis

            #region Ações

            try
            {
                css = "_line_height_grandeza";

                css = css.Replace("_line_height", decLineHeight.ToString(this.ctiUsa));
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

        public string setMargin(decimal decMargin, string strGrandeza = "px")
        {
            #region Variáveis

            string css;

            #endregion Variáveis

            #region Ações

            try
            {
                css = "_margin_grandeza";

                css = css.Replace("_margin", decMargin.ToString(this.ctiUsa));
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

        public string setMarginBottom(int intMarginBottom, string strGrandeza = "px")
        {
            #region Variáveis

            string css;

            #endregion Variáveis

            #region Ações

            try
            {
                css = "_margin_bottom_grandeza";

                css = css.Replace("_margin_bottom", intMarginBottom.ToString());
                css = css.Replace("_grandeza", strGrandeza);

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

        public string setMarginLeft(int intMarginLeft, string strGrandeza = "px")
        {
            #region Variáveis

            string css;

            #endregion Variáveis

            #region Ações

            try
            {
                css = "_margin_left_grandeza";

                css = css.Replace("_margin_left", intMarginLeft.ToString());
                css = css.Replace("_grandeza", strGrandeza);

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

        public string setMarginRight(int intMarginRight, string strGrandeza = "px")
        {
            #region Variáveis

            string css;

            #endregion Variáveis

            #region Ações

            try
            {
                css = "_margin_right_grandeza";

                css = css.Replace("_margin_right", intMarginRight.ToString());
                css = css.Replace("_grandeza", strGrandeza);

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

        public string setMarginTop(int intMarginTop, string strGrandeza = "px")
        {
            #region Variáveis

            string css;

            #endregion Variáveis

            #region Ações

            try
            {
                css = "_margin_top_grandeza";

                css = css.Replace("_margin_top", intMarginTop.ToString());
                css = css.Replace("_grandeza", strGrandeza);

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

        public string setMaxHeight(decimal decHeight, string strGrandeza = "px")
        {
            #region Variáveis

            string css;

            #endregion Variáveis

            #region Ações

            try
            {
                css = "_height_grandeza";

                css = css.Replace("_height", decHeight.ToString(this.ctiUsa));
                css = css.Replace("_grandeza", strGrandeza);

                return this.addCss("max-height", css);
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

        public string setMinHeight(decimal decMinHeight)
        {
            #region Variáveis

            string css;

            #endregion Variáveis

            #region Ações

            try
            {
                css = "_min_height_pxpx";
                css = css.Replace("_min_height_px", decMinHeight.ToString(this.ctiUsa));

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

        public string setMinWidth(decimal decMinWidth)
        {
            #region Variáveis

            string css;

            #endregion Variáveis

            #region Ações

            try
            {
                css = "_min_width_pxpx";
                css = css.Replace("_min_width_px", decMinWidth.ToString(this.ctiUsa));

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

        public string setOpacity(decimal decOpacity)
        {
            return this.addCss("opacity", decOpacity.ToString(this.ctiUsa));
        }

        public string setOutLine(string strOutLine)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (string.IsNullOrEmpty(strOutLine))
                {
                    return null;
                }

                return this.addCss("outline", strOutLine);
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

        public string setPaddingBottom(int intPaddingBottom, string strGrandeza = "px")
        {
            #region Variáveis

            string css;

            #endregion Variáveis

            #region Ações

            try
            {
                css = "_padding_bottom_grandeza";

                css = css.Replace("_padding_bottom", intPaddingBottom.ToString());
                css = css.Replace("_grandeza", strGrandeza);

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

        public string setPaddingLeft(int intPaddingLeft, string strGrandeza = "px")
        {
            #region Variáveis

            string css;

            #endregion Variáveis

            #region Ações

            try
            {
                css = "_padding_left_grandeza";

                css = css.Replace("_padding_left", intPaddingLeft.ToString());
                css = css.Replace("_grandeza", strGrandeza);

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

        public string setPaddingRight(int intPaddingRight, string strGrandeza = "px")
        {
            #region Variáveis

            string css;

            #endregion Variáveis

            #region Ações

            try
            {
                css = "_padding_right_grandeza";

                css = css.Replace("_padding_right", intPaddingRight.ToString());
                css = css.Replace("_grandeza", strGrandeza);

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

        public string setPaddingTop(int intPaddingTop, string strGrandeza = "px")
        {
            #region Variáveis

            string css;

            #endregion Variáveis

            #region Ações

            try
            {
                css = "_padding_top_grandeza";

                css = css.Replace("_padding_top", intPaddingTop.ToString());
                css = css.Replace("_grandeza", strGrandeza);

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

        public string setVisibility(string strVisibility)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (string.IsNullOrEmpty(strVisibility))
                {
                    return null;
                }

                return this.addCss("visibility", strVisibility);
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

        public string setWidth(decimal decWidth, string strGrandeza = "px")
        {
            #region Variáveis

            string css;

            #endregion Variáveis

            #region Ações

            try
            {
                css = "_width_grandeza";

                css = css.Replace("_width", decWidth.ToString(this.ctiUsa));
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

        internal override byte[] getArrBte()
        {
            return Encoding.UTF8.GetBytes(this.stbConteudo.ToString());
        }

        protected void addCssPuro(string css)
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

                this.stbConteudo.Append(css);
                this.dttCssUltimaAdicao = DateTime.Now;
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

        protected override DateTime getDttUltimaModificacao()
        {
            return this.dttCssUltimaAdicao;
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
                this.stbConteudo.Append(atrCss.getStrFormatado());
                this.dttCssUltimaAdicao = DateTime.Now;

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

        private void atualizarStrHref()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.dirCompleto = this.strHref;
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