using System;
using NetZ.Web.Server.Arquivo.Css;

namespace NetZ.Web.Html.Pagina
{
    // TODO: Melhorar o layout da página de erro.
    // TODO: Dar a possibilidade da aplicação ter uma página específica para erros.
    public class PagError : PaginaHtml
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private Div _divError;
        private Div _divMensagem;
        private Exception _ex;

        private Div divError
        {
            get
            {
                if (_divError != null)
                {
                    return _divError;
                }

                _divError = new Div();

                return _divError;
            }
        }

        private Div divMensagem
        {
            get
            {
                if (_divMensagem != null)
                {
                    return _divMensagem;
                }

                _divMensagem = new Div();

                return _divMensagem;
            }
        }

        private Exception ex
        {
            get
            {
                return _ex;
            }

            set
            {
                _ex = value;
            }
        }

        #endregion Atributos

        #region Construtores

        public PagError(Exception ex) : base("Ops! Algo deu errado.")
        {
            this.ex = ex;
        }

        #endregion Construtores

        #region Métodos

        protected override void inicializar()
        {
            base.inicializar();

            this.divMensagem.strConteudo = "Algo deu errado no servidor. Se o problema persistir entre em contato com o administrador do sistema.";

            this.inicializarDivError();
        }

        protected override void montarLayout()
        {
            base.montarLayout();

            this.divMensagem.setPai(this);
            this.divError.setPai(this);
        }

        private void inicializarDivError()
        {
            if (this.ex == null)
            {
                return;
            }

            if (string.IsNullOrEmpty(this.ex.StackTrace))
            {
                return;
            }

            string strStack = this.ex?.StackTrace.Replace(Environment.NewLine, "<br/>");

            this.divError.strConteudo = string.Format("{0} ({1})<br/><br/>{2}", this.ex.Message, this.ex.GetType().Name, strStack);
        }

        protected override void setCss(CssArquivo css)
        {
            base.setCss(css);

            this.divError.addCss(css.setPadding(25));
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}