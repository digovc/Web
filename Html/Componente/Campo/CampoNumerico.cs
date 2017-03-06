﻿using NetZ.Web.Server.Arquivo.Css;

namespace NetZ.Web.Html.Componente.Campo
{
    public class CampoNumerico : CampoAlfanumerico
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        protected override void addJs(LstTag<JavaScriptTag> lstJs)
        {
            base.addJs(lstJs);

            lstJs.Add(new JavaScriptTag(typeof(CampoNumerico), 132));
        }

        protected override Input.EnmTipo getEnmTipo()
        {
            return Input.EnmTipo.NUMBER;
        }

        protected override void setCss(CssArquivo css)
        {
            base.setCss(css);

            this.tagInput.addCss(css.setTextAlign("right"));
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}