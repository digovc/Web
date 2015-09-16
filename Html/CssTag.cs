using System;

namespace NetZ.Web.Html
{
    public class CssTag : Tag
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private CssTag _i;
        private CssTag _iImpressao;

        public CssTag i
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

        public CssTag iImpressao
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

        #endregion Atributos

        #region Construtores

        public CssTag(string strNome) : base(strNome)
        {
        }

        #endregion Construtores

        #region Métodos

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}