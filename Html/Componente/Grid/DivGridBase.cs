﻿using NetZ.Web.Server.Arquivo.Css;

namespace NetZ.Web.Html.Componente.Grid
{
    public abstract class DivGridBase : ComponenteHtmlBase
    {
        #region Constantes

        internal const string STR_GRID_ID = "_div_grid_id";
        internal const int INT_LINHA_TAMANHO_VERTICAL = 35;

        #endregion Constantes

        #region Atributos

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        protected override void inicializar()
        {
            base.inicializar();

            this.strId = STR_GRID_ID;
        }

        protected override void montarLayout()
        {
            base.montarLayout();

            new DivGridCabecalho().setPai(this);
            new DivGridConteudo().setPai(this);
            new DivGridRodape().setPai(this);
        }

        protected override void setCss(CssArquivoBase css)
        {
            base.setCss(css);

            this.addCss(css.setBackgroundColor("rgba(255,255,255,.15)"));
            this.addCss(css.setBorderRadius(5));
            this.addCss(css.setDisplay("none"));
            this.addCss(css.setMarginLeft(5));
            this.addCss(css.setMarginRight(5));
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}