using System;
using NetZ.Persistencia;
using NetZ.Web.Html.Componente.Circulo;

namespace NetZ.Web.Html.Componente.Menu
{
    public class MainMenuItem : ComponenteHtml
    {
        #region Constantes

        private const int INT_HEIGHT = 50;

        #endregion Constantes

        #region Atributos

        private DivCirculo _divIcone;
        private Div _divItemConteudo;
        private Div _divTitulo;
        private string _strTitulo;

        private Tabela _tbl;

        /// <summary>
        /// Texto que será apresentado para o usuário.
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

        public Tabela tbl
        {
            get
            {
                return _tbl;
            }

            set
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    _tbl = value;

                    this.atualizarTbl();
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
        }

        private DivCirculo divIcone
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_divIcone != null)
                    {
                        return _divIcone;
                    }

                    _divIcone = new DivCirculo();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _divIcone;
            }
        }

        private Div divItemConteudo
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_divItemConteudo != null)
                    {
                        return _divItemConteudo;
                    }

                    _divItemConteudo = new Div();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _divItemConteudo;
            }
        }

        private Div divTitulo
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_divTitulo != null)
                    {
                        return _divTitulo;
                    }

                    _divTitulo = new Div();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _divTitulo;
            }
        }

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        protected override void addJs(LstTag<JavaScriptTag> lstJs)
        {
            base.addJs(lstJs);

            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                lstJs.Add(new JavaScriptTag(typeof(MainMenuItem), 151));

                lstJs.Add(new JavaScriptTag("res/js/Web.TypeScript/persistencia/TabelaWeb.js"));
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

        protected override void addTag(Tag tag)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (tag == null)
                {
                    return;
                }

                if (!typeof(MainMenuItem).IsAssignableFrom(tag.GetType()))
                {
                    base.addTag(tag);
                    return;
                }

                tag.setPai(this.divItemConteudo);
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

        protected override void atualizarStrId()
        {
            base.atualizarStrId();

            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.divItemConteudo.strId = this.strId + "_itemConteudo";
                this.divTitulo.strId = this.strId + "_titulo";
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

        protected override void finalizar()
        {
            base.finalizar();

            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.divTitulo.strConteudo = this.strTitulo;
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

        protected override void inicializar()
        {
            base.inicializar();

            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.intTabStop = 1;
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

        protected override void montarLayout()
        {
            base.montarLayout();

            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.divIcone.setPai(this);
                this.divTitulo.setPai(this);
                this.divItemConteudo.setPai(this);
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

        protected override void setCss(CssTag css)
        {
            base.setCss(css);

            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.addCss(css.setCursor("pointer"));
                this.addCss(css.setMarginBottom(10));
                this.addCss(css.setMinHeight(INT_HEIGHT));
                this.addCss(css.setOutLine("none"));

                this.divTitulo.addCss(css.setLineHeight(INT_HEIGHT));

                this.divIcone.addCss(css.setBackgroundColor(AppWeb.i.objTema.corTema));
                this.divIcone.addCss(css.setFloat("left"));
                this.divIcone.addCss(css.setMarginRight(10));

                this.divItemConteudo.addCss(css.setDisplay("none"));
                this.divItemConteudo.addCss(css.setPadding(20));
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

        private void atualizarTbl()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (this.tbl == null)
                {
                    return;
                }

                this.strTitulo = this.tbl.strNomeExibicao;

                this.addAtt("tbl_web_nome", this.tbl.strNomeSql);
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