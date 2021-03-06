﻿using NetZ.Web.Html.Componente.Grid.Coluna;
using NetZ.Web.Server.Arquivo.Css;

namespace NetZ.Web.Html.Componente.Grid
{
    internal class DivGridCabecalho : ComponenteHtmlBase
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        protected override void addLayoutFixo(JavaScriptTag tagJs)
        {
            base.addLayoutFixo(tagJs);

            tagJs.addLayoutFixo(typeof(DivGridColunaCabecalho));
        }

        protected override void inicializar()
        {
            base.inicializar();

            this.strId = (DivGridBase.STR_GRID_ID + "_" + this.GetType().Name);
        }

        protected override void setCss(CssArquivoBase css)
        {
            base.setCss(css);

            this.addCss(css.setBackgroundColor("rgba(255,255,255,.15)"));
            this.addCss(css.setBorderRadius(5, 5, 0, 0));
            this.addCss(css.setDisplay("inline-flex"));
            this.addCss(css.setLineHeight(DivGridBase.INT_LINHA_TAMANHO_VERTICAL));
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}