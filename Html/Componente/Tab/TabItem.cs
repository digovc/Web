using NetZ.Persistencia;

namespace NetZ.Web.Html.Componente.Tab
{
    public class TabItem : ComponenteHtml // TODO: Criar uma classe especializada para telas de cadastro.
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private string _strTitulo = "Tab desconhecida";
        private TabelaBase _tbl;

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
        public TabelaBase tbl
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

                this.setTbl(_tbl);
            }
        }

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        protected override void addJs(LstTag<JavaScriptTag> lstJsDebug)
        {
            base.addJs(lstJsDebug);

            lstJsDebug.Add(new JavaScriptTag(typeof(TabItem), 110));
        }

        protected override void montarLayout()
        {
            base.montarLayout();
        }

        private void setTbl(TabelaBase tbl)
        {
            if (tbl == null)
            {
                return;
            }

            tbl = tbl.viwPrincipal;

            this.strId = ("tabItem_" + tbl.sqlNome);

            this.strTitulo = tbl.strNomeExibicao;

            this.addAtt("tbl_web_nome", tbl.sqlNome);
            this.addAtt("tbl_web_principal_nome", tbl.tblPrincipal.sqlNome);
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}