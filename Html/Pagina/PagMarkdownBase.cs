using NetZ.Web.Html.Componente.Markdown;
using NetZ.Web.Html.Componente.Mobile;

namespace NetZ.Web.Html.Pagina
{
    public abstract class PagMarkdownBase : PagMobile
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private string _dirRepositorio;
        private ActionBar _divActionBar;
        private Sumario _divSumario;
        private Viewer _divViwer;

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

        private Sumario divSumario
        {
            get
            {
                if (_divSumario != null)
                {
                    return _divSumario;
                }

                _divSumario = new Sumario(this);

                return _divSumario;
            }
        }

        private Viewer divViwer
        {
            get
            {
                if (_divViwer != null)
                {
                    return _divViwer;
                }

                _divViwer = new Viewer();

                return _divViwer;
            }
        }

        #endregion Atributos

        #region Construtores

        protected PagMarkdownBase(string strNome) : base(strNome)
        {
        }

        #endregion Construtores

        #region Métodos

        protected override void addCss(LstTag<CssTag> lstCss)
        {
            base.addCss(lstCss);

            lstCss.Add(new CssTag(AppWebBase.DIR_CSS + "github-markdown.css"));
        }

        protected override void addJsDebug(LstTag<JavaScriptTag> lstJsDebug)
        {
            base.addJsDebug(lstJsDebug);

            lstJsDebug.Add(new JavaScriptTag(typeof(PagMarkdownBase), 104));

            lstJsDebug.Add(new JavaScriptTag((AppWebBase.DIR_JS_LIB + "marked.min.js")));
        }

        protected abstract string getDirRepositorio();

        protected override void inicializar()
        {
            base.inicializar();

            this.divActionBar.strTitulo = this.strNome;
        }

        protected override void montarLayout()
        {
            base.montarLayout();

            this.divActionBar.setPai(this);
            this.divSumario.setPai(this);

            this.divViwer.setPai(this);
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}