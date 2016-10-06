﻿using NetZ.Web.Server.Arquivo.Css;

namespace NetZ.Web.Html.Componente.Botao
{
    public class BotaoMini : BotaoHtml
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        protected override void addJsDebug(LstTag<JavaScriptTag> lstJsDebug)
        {
            base.addJsDebug(lstJsDebug);

            lstJsDebug.Add(new JavaScriptTag(typeof(BotaoMini), 114));
        }

        protected override void setCss(CssArquivo css)
        {
            base.setCss(css);

            this.addCss(css.setFloat("left"));
            this.addCss(css.setHeight(20));
            this.addCss(css.setMarginRight(5));
            this.addCss(css.setWidth(20));
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}