﻿using NetZ.Web.Server.Arquivo.Css;

namespace NetZ.Web.Html.Componente.Menu.Contexto
{
    public class MenuContexto : ComponenteHtml
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        protected override void inicializar()
        {
            base.inicializar();

            this.strConteudo = "_conteudo";
            this.strId = "_id";
        }

        protected override void setCss(CssArquivo css)
        {
            base.setCss(css);

            this.addCss(css.setBackgroundColor(AppWeb.i.objTema.corTelaFundo));
            this.addCss(css.setBoxShadow(0, 0, 10, 0, AppWeb.i.objTema.corBorda));
            this.addCss(css.setDisplay("none"));
            this.addCss(css.setMaxHeight(250));
            this.addCss(css.setOverflowY("auto"));
            this.addCss(css.setPosition("absolute"));
            this.addCss(css.setWidth(275));
            this.addCss(css.setZIndex(1000));
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}