﻿namespace NetZ.Web.Html.Componente.TreeView
{
    public class TreeViewHtml : ComponenteHtml
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private Div _divComando;
        private Div _divNodeContainer;

        private Div divComando
        {
            get
            {
                if (_divComando != null)
                {
                    return _divComando;
                }

                _divComando = new Div();

                return _divComando;
            }
        }

        private Div divNodeContainer
        {
            get
            {
                if (_divNodeContainer != null)
                {
                    return _divNodeContainer;
                }

                _divNodeContainer = new Div();

                return _divNodeContainer;
            }
        }

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        protected override void addJsDebug(LstTag<JavaScriptTag> lstJsDebug)
        {
            base.addJsDebug(lstJsDebug);

            lstJsDebug.Add(new JavaScriptTag(typeof(TreeViewHtml), 111));
            lstJsDebug.Add(new JavaScriptTag(typeof(TreeViewNode), 112));
        }

        protected override void addLayoutFixo(JavaScriptTag tagJs)
        {
            base.addLayoutFixo(tagJs);

            tagJs.addLayoutFixo(typeof(TreeViewNode));
        }

        protected override void atualizarStrId()
        {
            base.atualizarStrId();

            if (string.IsNullOrEmpty(this.strId))
            {
                return;
            }

            this.divNodeContainer.strId = (this.strId + "_divNodeContainer");
        }

        protected override void montarLayout()
        {
            base.montarLayout();

            this.divComando.setPai(this);
            this.divNodeContainer.setPai(this);
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}