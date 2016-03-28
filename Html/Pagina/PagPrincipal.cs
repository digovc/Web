﻿using System;
using System.Drawing;
using NetZ.Web.Html.Componente.Botao;
using NetZ.Web.Html.Componente.Botao.Comando;
using NetZ.Web.Html.Componente.Botao.Mini;
using NetZ.Web.Html.Componente.Campo;
using NetZ.Web.Html.Componente.Form;
using NetZ.Web.Html.Componente.Grid;
using NetZ.Web.Html.Componente.Janela;
using NetZ.Web.Html.Componente.Janela.Cadastro;
using NetZ.Web.Html.Componente.Janela.Consulta;
using NetZ.Web.Html.Componente.Painel;
using NetZ.Web.Server.Arquivo.Css;

namespace NetZ.Web.Html.Pagina
{
    public abstract class PagPrincipal : PaginaHtml
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private Div _divCadastro;
        private Div _divConsulta;

        private Div divCadastro
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_divCadastro != null)
                    {
                        return _divCadastro;
                    }

                    _divCadastro = new Div();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _divCadastro;
            }
        }

        private Div divConsulta
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_divConsulta != null)
                    {
                        return _divConsulta;
                    }

                    _divConsulta = new Div();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _divConsulta;
            }
        }

        #endregion Atributos

        #region Construtores

        public PagPrincipal(string strNome) : base(strNome)
        {
        }

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
                // TODO: Carregar esses scripts separadamente, quando forem necessário, durante a
                //       execução de cada tarefa. O carregamento excessivo na abertura da tela
                // principal diminui a performance neste ponto da aplicação.
                lstJs.Add(new JavaScriptTag(typeof(BotaoAdicionarMini), 118));
                lstJs.Add(new JavaScriptTag(typeof(BotaoAlterarMini), 118));
                lstJs.Add(new JavaScriptTag(typeof(BotaoApagarMini), 119));
                lstJs.Add(new JavaScriptTag(typeof(BotaoCircular), 116));
                lstJs.Add(new JavaScriptTag(typeof(BotaoComando), 114));
                lstJs.Add(new JavaScriptTag(typeof(BotaoFecharMini), 118));
                lstJs.Add(new JavaScriptTag(typeof(BotaoHtml), 113));
                lstJs.Add(new JavaScriptTag(typeof(BotaoMini), 117));
                lstJs.Add(new JavaScriptTag(typeof(BotaoSalvarComando), 115));
                lstJs.Add(new JavaScriptTag(typeof(CampoAlfanumerico), 131));
                lstJs.Add(new JavaScriptTag(typeof(CampoComboBox), 131));
                lstJs.Add(new JavaScriptTag(typeof(CampoHtml), 130));
                lstJs.Add(new JavaScriptTag(typeof(CampoNumerico), 131));
                lstJs.Add(new JavaScriptTag(typeof(DivComando), 116));
                lstJs.Add(new JavaScriptTag(typeof(FormHtml), 111));
                lstJs.Add(new JavaScriptTag(typeof(FrmFiltro), 112));
                lstJs.Add(new JavaScriptTag(typeof(GridHtml), 111));
                lstJs.Add(new JavaScriptTag(typeof(GridRow), 104));
                lstJs.Add(new JavaScriptTag(typeof(JanelaHtml), 121));
                lstJs.Add(new JavaScriptTag(typeof(JnlCadastro), 122));
                lstJs.Add(new JavaScriptTag(typeof(JnlConsulta), 122));
                lstJs.Add(new JavaScriptTag(typeof(PagPrincipal), 103));
                lstJs.Add(new JavaScriptTag(typeof(PainelAcao), 120));
                lstJs.Add(new JavaScriptTag(typeof(PainelAcaoConsulta), 121));
                lstJs.Add(new JavaScriptTag(typeof(PainelFiltro), 115));
                lstJs.Add(new JavaScriptTag(typeof(PainelHtml), 114));
                lstJs.Add(new JavaScriptTag(typeof(PainelNivel), 115));

                lstJs.Add(new JavaScriptTag("res/js/lib/jquery.floatThead.min.js"));

                lstJs.Add(new JavaScriptTag("res/js/Web.TypeScript/persistencia/ColunaWeb.js", 101));
                lstJs.Add(new JavaScriptTag("res/js/Web.TypeScript/persistencia/FiltroWeb.js", 101));
                lstJs.Add(new JavaScriptTag("res/js/Web.TypeScript/persistencia/TabelaWeb.js", 101));
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
                this.divCadastro.strId = "divCadastro";
                this.divConsulta.strId = "divConsulta";
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
                this.divConsulta.setPai(this);
                this.divCadastro.setPai(this);
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
                this.divCadastro.addCss(css.setBackgroundColor(Color.FromArgb(127, AppWeb.i.objTema.corTema)));
                this.divCadastro.addCss(css.setBottom(0));
                this.divCadastro.addCss(css.setDisplay("none"));
                this.divCadastro.addCss(css.setLeft(0));
                this.divCadastro.addCss(css.setPosition("absolute"));
                this.divCadastro.addCss(css.setRight(0));
                this.divCadastro.addCss(css.setTop(50));

                this.divConsulta.addCss(css.setBottom(0));
                this.divConsulta.addCss(css.setDisplay("none"));
                this.divConsulta.addCss(css.setLeft(0));
                this.divConsulta.addCss(css.setPosition("absolute"));
                this.divConsulta.addCss(css.setRight(0));
                this.divConsulta.addCss(css.setTop(50));
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