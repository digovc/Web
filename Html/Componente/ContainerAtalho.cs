﻿using System;

namespace NetZ.Web.Html.Componente
{
    public class ContainerAtalho : ComponenteHtml
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        protected override void setCss(CssTag css)
        {
            base.setCss(css);

            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.addCss(css.setBackgroundColor(AppWeb.i.tma.corFundo1Normal));
                this.addCss(css.setBorderBottom(1, "solid", AppWeb.i.tma.corBorda1Normal));
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