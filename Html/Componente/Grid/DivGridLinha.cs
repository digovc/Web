﻿using NetZ.Web.Html.Componente.Grid.Coluna;
using NetZ.Web.Server.Arquivo.Css;

namespace NetZ.Web.Html.Componente.Grid
{
    internal class DivGridLinha : ComponenteHtml
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

            tagJs.addLayoutFixo(typeof(DivGridColunaLinha));
        }

        protected override void inicializar()
        {
            base.inicializar();

            this.strId = "_div_id";
        }

        protected override void setCss(CssArquivoBase css)
        {
            base.setCss(css);

            this.addCss(css.setDisplay("inline-flex"));
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}