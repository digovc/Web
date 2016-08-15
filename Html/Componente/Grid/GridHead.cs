using NetZ.Persistencia;
using NetZ.Web.Server.Arquivo.Css;

namespace NetZ.Web.Html.Componente.Grid
{
    internal class GridHead : Tag
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private Coluna _cln;

        protected Coluna cln
        {
            get
            {
                return _cln;
            }

            set
            {
                _cln = value;
            }
        }

        #endregion Atributos

        #region Construtores

        public GridHead(Coluna cln) : base("th")
        {
            this.cln = cln;
        }

        #endregion Construtores

        #region Métodos

        protected override void inicializar()
        {
            base.inicializar();

            if (this.cln == null)
            {
                return;
            }

            this.strConteudo = this.cln.strNomeExibicao;
        }

        protected override void setCss(CssArquivo css)
        {
            base.setCss(css);

            this.addCss(css.setBackgroundColor(AppWeb.i.objTema.corFundo));
            this.addCss(css.setBorderBottom(1, "solid", AppWeb.i.objTema.corFundoBorda));
            this.addCss(css.setFontWeight("normal"));
            this.addCss(css.setPaddingLeft(10));
            this.addCss(css.setPaddingRight(10));

            this.setCssCln(css);
        }

        private void setCssCln(CssArquivo css)
        {
            if (this.cln == null)
            {
                return;
            }

            if (this.cln.lstKvpOpcao.Count > 0)
            {
                this.setCssClnAlfanumerico(css);
                return;
            }

            switch (this.cln.enmGrupo)
            {
                case Coluna.EnmGrupo.ALFANUMERICO:
                    this.setCssClnAlfanumerico(css);
                    return;

                case Coluna.EnmGrupo.NUMERICO_INTEIRO:
                case Coluna.EnmGrupo.NUMERICO_PONTO_FLUTUANTE:
                    this.setCssClnNumerico(css);
                    return;
            }
        }

        private void setCssClnAlfanumerico(CssArquivo css)
        {
            this.addCss(css.setTextAlign("left"));
        }

        private void setCssClnNumerico(CssArquivo css)
        {
            this.addCss(css.setTextAlign("right"));
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}