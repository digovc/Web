﻿using NetZ.Web.Html.Componente;
using NetZ.Web.Server.Arquivo.Css;

namespace NetZ.Web.Html
{
    public class CheckBox : Input
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private Div _divContainer;
        private Div _divSeletor;
        private Div _divTitulo;
        private string _strTitulo;

        /// <summary>
        /// Título que ficará visível para o usuário na frente do checkbox.
        /// </summary>
        public string strTitulo
        {
            get
            {
                return _strTitulo;
            }

            set
            {
                _strTitulo = value;
            }
        }

        private Div divContainer
        {
            get
            {
                if (_divContainer != null)
                {
                    return _divContainer;
                }

                _divContainer = new Div();

                return _divContainer;
            }
        }

        private Div divSeletor
        {
            get
            {
                if (_divSeletor != null)
                {
                    return _divSeletor;
                }

                _divSeletor = new Div();

                return _divSeletor;
            }
        }

        private Div divTitulo
        {
            get
            {
                if (_divTitulo != null)
                {
                    return _divTitulo;
                }

                _divTitulo = new Div();

                return _divTitulo;
            }
        }

        #endregion Atributos

        #region Construtores

        public CheckBox()
        {
            this.strNome = "div";
        }

        #endregion Construtores

        #region Métodos

        protected override void addJsDebug(LstTag<JavaScriptTag> lstJsDebug)
        {
            base.addJsDebug(lstJsDebug);

            lstJsDebug.Add(new JavaScriptTag(typeof(CheckBox), 111));
        }

        protected override void montarLayout()
        {
            base.montarLayout();

            this.divContainer.setPai(this);
            this.divSeletor.setPai(this.divContainer);

            this.divTitulo.setPai(this);

            new LimiteFloat().setPai(this);
        }

        protected override void setCss(CssArquivo css)
        {
            base.setCss(css);

            this.addCss(css.setCursor("pointer"));

            this.divContainer.addCss(css.setBackgroundColor("white"));
            this.divContainer.addCss(css.setBorder(1, "solid", "gray"));
            this.divContainer.addCss(css.setBorderRadius(10));
            this.divContainer.addCss(css.setFloat("left"));
            this.divContainer.addCss(css.setHeight(16));
            this.divContainer.addCss(css.setMarginRight(10));
            this.divContainer.addCss(css.setPosition("relative"));
            this.divContainer.addCss(css.setWidth(30));

            this.divSeletor.addCss(css.setBackgroundColor("rgb(160,160,160)"));
            this.divSeletor.addCss(css.setBorderRadius(50, "%"));
            this.divSeletor.addCss(css.setHeight(14));
            this.divSeletor.addCss(css.setLeft(1));
            this.divSeletor.addCss(css.setPosition("absolute"));
            this.divSeletor.addCss(css.setTop(1));
            this.divSeletor.addCss(css.setWidth(14));

            this.divTitulo.addCss(css.setLineHeight(13));
            this.divTitulo.addCss(css.setPaddingLeft(25));
            this.divTitulo.addCss(css.setPaddingTop(2));
            this.divTitulo.addCss(css.setTextAlign("left"));
        }

        protected override void setStrId(string strId)
        {
            base.setStrId(strId);

            if (string.IsNullOrEmpty(strId))
            {
                return;
            }

            this.divSeletor.strId = (strId + "_divSeletor");
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}