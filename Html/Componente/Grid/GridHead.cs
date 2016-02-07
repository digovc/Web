using System;
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
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.cln = cln;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion Ações
        }

        #endregion Construtores

        #region Métodos

        protected override void inicializar()
        {
            base.inicializar();

            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (this.cln == null)
                {
                    return;
                }

                this.strConteudo = this.cln.strNomeExibicao;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion Ações
        }

        protected override void setCss(CssArquivo css)
        {
            base.setCss(css);

            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.addCss(css.setBorderBottom(1, "solid", AppWeb.i.objTema.corBorda));
                this.addCss(css.setPaddingLeft(25));
                this.addCss(css.setPaddingRight(25));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion Ações
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}