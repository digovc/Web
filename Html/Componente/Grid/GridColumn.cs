using System;
using System.Data;
using NetZ.Persistencia;
using NetZ.Web.Server.Arquivo.Css;

namespace NetZ.Web.Html.Componente.Grid
{
    internal class GridColumn : Tag
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private Coluna _cln;
        private DataRow _row;

        private Coluna cln
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

        private DataRow row
        {
            get
            {
                return _row;
            }

            set
            {
                _row = value;
            }
        }

        #endregion Atributos

        #region Construtores

        public GridColumn(Coluna cln, DataRow row) : base("td")
        {
            this.cln = cln;
            this.row = row;
        }

        #endregion Construtores

        #region Métodos

        protected override void inicializar()
        {
            base.inicializar();

            this.inicializarStrConteudo();
        }

        private void inicializarStrConteudo()
        {
            if (this.cln == null)
            {
                return;
            }

            if (this.row == null)
            {
                return;
            }

            if (this.row[this.cln.sqlNome] == null)
            {
                return;
            }

            this.cln.strValor = this.row[this.cln.sqlNome].ToString();
            this.strConteudo = this.cln.strValorExibicao;
        }

        protected override void setCss(CssArquivo css)
        {
            base.setCss(css);

            this.addCss(css.setOverflowX("hidden"));
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