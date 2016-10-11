﻿using System;
using NetZ.Web.Server.Arquivo.Css;

namespace NetZ.Web.Html.Componente.Painel
{
    public class PainelAtalho : PainelHtml
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        protected override void setCss(CssArquivo css)
        {
            base.setCss(css);

            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.addCss(css.setBackgroundColor(AppWebBase.i.objTema.corFundo));
                this.addCss(css.setBorderBottom(1, "solid", AppWebBase.i.objTema.corBorda));
                this.addCss(css.setHeight(70));
                this.addCss(css.setPadding(5));
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