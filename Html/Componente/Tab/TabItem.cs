using NetZ.Persistencia;

namespace NetZ.Web.Html.Componente.Tab
{
    public class TabItem : ComponenteHtml
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private string _strTitulo = "Tab desconhecida";
        private Tabela _tbl;

        /// <summary>
        /// Título que ficará visível para o usuário e identificará esta tab na tela.
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

        /// <summary>
        /// Tabela que esta tab representa.
        /// </summary>
        public Tabela tbl
        {
            get
            {
                return _tbl;
            }

            set
            {
                if (value == tbl)
                {
                    return;
                }

                _tbl = value;

                this.atualizarTbl();
            }
        }

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        protected override void addJs(LstTag<JavaScriptTag> lstJs)
        {
            base.addJs(lstJs);

            lstJs.Add(new JavaScriptTag(typeof(TabItem), 110));
        }

        protected override void montarLayout()
        {
            base.montarLayout();
        }

        private void atualizarTbl()
        {
            if (this.tbl == null)
            {
                return;
            }

            this.tbl = this.tbl.viwPrincipal;

            this.strId = ("tabItem_" + this.tbl.strNomeSql);
            this.strTitulo = this.tbl.strNomeExibicao;

            this.addAtt("tbl_web_nome", this.tbl.strNomeSql);
            this.addAtt("tbl_web_principal_nome", this.tbl.tblPrincipal.strNomeSql);
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}