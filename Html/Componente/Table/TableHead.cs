using NetZ.Persistencia;
using NetZ.Web.Server.Arquivo.Css;

namespace NetZ.Web.Html.Componente.Table
{
    internal class TableHead : ComponenteHtml
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

        internal TableHead(Coluna cln)
        {
            this.cln = cln;
        }

        #endregion Construtores

        #region Métodos

        protected override void inicializar()
        {
            base.inicializar();

            this.strNome = "th";

            if (this.cln == null)
            {
                return;
            }

            this.strConteudo = this.cln.strNomeExibicao;
        }

        protected override void setCss(CssArquivoBase css)
        {
            base.setCss(css);

            this.addCss(css.setBackgroundColor(AppWebBase.i.objTema.corFundo));
            this.addCss(css.setBorderBottom(1, "solid", AppWebBase.i.objTema.corFundoBorda));
            this.addCss(css.setFontWeight("normal"));
            this.addCss(css.setPaddingLeft(10));
            this.addCss(css.setPaddingRight(10));

            this.setCssCln(css);
        }

        private void setCssCln(CssArquivoBase css)
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

        private void setCssClnAlfanumerico(CssArquivoBase css)
        {
            this.addCss(css.setTextAlign("left"));
        }

        private void setCssClnNumerico(CssArquivoBase css)
        {
            this.addCss(css.setTextAlign("right"));
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}