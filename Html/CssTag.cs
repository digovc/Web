using System;
using System.Collections.Generic;

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
        private string _cssPuro = string.Empty;
        private List<AtributoCss> _lstAttCss;

        private string _strConteudo;

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

        public new string strConteudo
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

            private set
            {
                _strConteudo = value;
            }
        }

        private string cssPuro
        {
            get
            {
                return _cssPuro;
            }

            set
            {
                _cssPuro = value;
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

            string strResultado;

            #endregion Variáveis

            #region Ações

            try
            {
                if (!string.IsNullOrEmpty(_strConteudo))
                {
                    return _strConteudo;
                }

                strResultado = string.Empty;

                foreach (AtributoCss atrCss in this.lstAttCss)
                {
                    if (atrCss == null)
                    {
                        continue;
                    }

                    strResultado += atrCss.getStrFormatado();
                }

                strResultado += this.cssPuro;

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

                atrCss = new AtributoCss(strNome, strValor);

                atrCss.strClass = (STR_CLASS_NOME_SUFIXO + this.lstAttCss.Count);

                this.lstAttCss.Add(atrCss);
                this.strConteudo = string.Empty;

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

                this.cssPuro += css;
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