using System;
using System.Collections.Generic;
using NetZ.Persistencia;
using NetZ.Web.Html.Componente.Circulo;
using NetZ.Web.Server.Arquivo.Css;

namespace NetZ.Web.Html.Componente.Menu
{
    public class MenuItem : ComponenteHtml
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private DivCirculo _divIcone;
        private Div _divItemConteudo;
        private Div _divTitulo;
        private List<MenuItem> _lstMni;
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

        private List<MenuItem> lstMni
        {
            get
            {
                if (_lstMni != null)
                {
                    return _lstMni;
                }

                _lstMni = new List<MenuItem>();

                return _lstMni;
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
                lstJs.Add(new JavaScriptTag(typeof(MenuItem), 151));

                lstJs.Add(new JavaScriptTag("res/js/Web.TypeScript/database/TabelaWeb.js"));
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

                if (!typeof(MenuItem).IsAssignableFrom(tag.GetType()))
                {
                    base.addTag(tag);
                    return;
                }

                tag.setPai(this.divItemConteudo);

                this.lstMni.Add(tag as MenuItem);
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
                if (string.IsNullOrEmpty(this.strId))
                {
                    return;
                }

                this.divItemConteudo.strId = this.strId + "_divItemConteudo";
                this.divTitulo.strId = this.strId + "_divTitulo";
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

        protected override void setCss(CssArquivo css)
        {
            base.setCss(css);

            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.addCss(css.setCursor("pointer"));
                this.addCss(css.setFontFamily("ubuntu"));
                this.addCss(css.setFontStyle("ligth"));
                this.addCss(css.setOutLine("none"));

                this.setCssPai(css);
                this.setCssFilho(css);
                                
                this.divItemConteudo.addCss(css.setBackgroundColor(AppWeb.i.objTema.corTelaFundo));
                this.divItemConteudo.addCss(css.setDisplay("none"));
                this.divItemConteudo.addCss(css.setFontSize(14));
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

        private void setCssFilho(CssArquivo css)
        {
            if (this.lstMni.Count > 0)
            {
                return;
            }

            this.addCss(css.setBorder(1, "solid", AppWeb.i.objTema.corSombra));
            this.addCss(css.setBorderBottom(0, "solid", null));
            this.addCss(css.setHeight(40));
            this.addCss(css.setMinHeight(40));
            this.addCss(css.setPaddingLeft(60));
            
            this.divIcone.addCss(css.setDisplay("none"));

            this.divTitulo.addCss(css.setLineHeight(40));
        }

        private void setCssPai(CssArquivo css)
        {
            if (this.lstMni.Count < 1)
            {
                return;
            }

            this.addCss(css.setBorderTop(1, "solid", AppWeb.i.objTema.corSombra));
            this.addCss(css.setFontSize(18));
            this.addCss(css.setLineHeight(50));
            this.addCss(css.setMinHeight(50));

            this.divIcone.addCss(css.setBackgroundColor(AppWeb.i.objTema.corTelaFundo));
            this.divIcone.addCss(css.setBorder(1, "solid", "rgb(130,202,156)"));
            this.divIcone.addCss(css.setFloat("left"));
            this.divIcone.addCss(css.setMarginLeft(5));
            this.divIcone.addCss(css.setMarginRight(15));
            this.divIcone.addCss(css.setMarginTop(4));

            this.divTitulo.addCss(css.setLineHeight(50));
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}