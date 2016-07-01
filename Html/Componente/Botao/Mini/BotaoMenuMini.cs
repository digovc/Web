using System;
using NetZ.Web.Server.Arquivo.Css;

namespace NetZ.Web.Html.Componente.Botao.Mini
{
    public class BotaoMenuMini : BotaoMini
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

            lstJs.Add(new JavaScriptTag(typeof(BotaoMenuMini), 120));
        }

        protected override void inicializar()
        {
            base.inicializar();

            this.strConteudo = "...";
            this.strTitle = "Menu";
        }

        protected override void setCss(CssArquivo css)
        {
            base.setCss(css);

            this.addCss(css.setBackgroundColor(AppWeb.i.objTema.corTema));
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}