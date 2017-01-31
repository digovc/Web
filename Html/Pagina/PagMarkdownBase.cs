using NetZ.Web.Html.Componente;
using NetZ.Web.Html.Componente.Markdown;

namespace NetZ.Web.Html.Pagina
{
    public abstract class PagMarkdownBase : PagMobile
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private string _dirRepositorio;
        private ActionBar _divActionBar;
        private SumarioMarkdown _divSumario;

        internal string dirRepositorio
        {
            get
            {
                if (_dirRepositorio != null)
                {
                    return _dirRepositorio;
                }

                _dirRepositorio = this.getDirRepositorio();

                return _dirRepositorio;
            }
        }

        private ActionBar divActionBar
        {
            get
            {
                if (_divActionBar != null)
                {
                    return _divActionBar;
                }

                _divActionBar = new ActionBar();

                return _divActionBar;
            }
        }

        private SumarioMarkdown divSumario
        {
            get
            {
                if (_divSumario != null)
                {
                    return _divSumario;
                }

                _divSumario = new SumarioMarkdown(this);

                return _divSumario;
            }
        }

        #endregion Atributos

        #region Construtores

        protected PagMarkdownBase(string strNome) : base(strNome)
        {
        }

        #endregion Construtores

        #region Métodos

        protected abstract string getDirRepositorio();

        protected override void montarLayout()
        {
            base.montarLayout();

            this.divActionBar.setPai(this);
            this.divSumario.setPai(this);
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}