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

        private void atualizarTbl()
        {
            if (this.tbl == null)
            {
                return;
            }

            this.tbl = this.tbl.viwPrincipal;

            this.strTitulo = this.tbl.strNomeExibicao;
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}