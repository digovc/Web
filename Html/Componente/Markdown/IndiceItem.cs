﻿namespace NetZ.Web.Html.Componente.Markdown
{
    internal class IndiceItem : ComponenteHtml
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        protected override bool getBooJs()
        {
            return true;
        }

        protected override void inicializar()
        {
            base.inicializar();

            this.strConteudo = "_conteudo";
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}