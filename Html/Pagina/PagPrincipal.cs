using NetZ.Web.Html.Componente;
using NetZ.Web.Html.Componente.Botao;
using NetZ.Web.Html.Componente.Campo;
using NetZ.Web.Html.Componente.Form;
using NetZ.Web.Html.Componente.Grid;
using NetZ.Web.Html.Componente.Janela;
using NetZ.Web.Html.Componente.Janela.Cadastro;
using NetZ.Web.Html.Componente.Janela.Consulta;
using NetZ.Web.Html.Componente.Painel;
using NetZ.Web.Html.Componente.Tab;
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
                if (_divCadastro != null)
                {
                    return _divCadastro;
                }

                _divCadastro = new Div();

                return _divCadastro;
            }
        }

        private Div divConsulta
        {
            get
            {
                if (_divConsulta != null)
                {
                    return _divConsulta;
                }

                _divConsulta = new Div();

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

            // TODO: Carregar esses scripts separadamente, quando forem necessário, durante a
            //       execução de cada tarefa. O carregamento excessivo na abertura da tela principal
            // diminui a performance neste ponto da aplicação.
            lstJs.Add(new JavaScriptTag(typeof(BotaoCircular), 118));
            lstJs.Add(new JavaScriptTag(typeof(BotaoHtml), 113));
            lstJs.Add(new JavaScriptTag(typeof(BtnFavorito), 119));
            lstJs.Add(new JavaScriptTag(typeof(CampoAlfanumerico), 131));
            lstJs.Add(new JavaScriptTag(typeof(CampoAnexo), 132));
            lstJs.Add(new JavaScriptTag(typeof(CampoCheckBox), 131));
            lstJs.Add(new JavaScriptTag(typeof(CampoComboBox), 131));
            lstJs.Add(new JavaScriptTag(typeof(CampoConsulta), 132));
            lstJs.Add(new JavaScriptTag(typeof(CampoDataHora), 131));
            lstJs.Add(new JavaScriptTag(typeof(CampoHtml), 130));
            lstJs.Add(new JavaScriptTag(typeof(CampoMapa), 132));
            lstJs.Add(new JavaScriptTag(typeof(CampoMarkdown), 132));
            lstJs.Add(new JavaScriptTag(typeof(CampoMedia), 131));
            lstJs.Add(new JavaScriptTag(typeof(CampoNumerico), 131));
            lstJs.Add(new JavaScriptTag(typeof(CampoSenha), 132));
            lstJs.Add(new JavaScriptTag(typeof(CampoTexto), 131));
            lstJs.Add(new JavaScriptTag(typeof(CheckBox), 111));
            lstJs.Add(new JavaScriptTag(typeof(ComboBox), 111));
            lstJs.Add(new JavaScriptTag(typeof(DivComando), 116));
            lstJs.Add(new JavaScriptTag(typeof(DivCritica), 112));
            lstJs.Add(new JavaScriptTag(typeof(DivDica), 111));
            lstJs.Add(new JavaScriptTag(typeof(FormHtml), 111));
            lstJs.Add(new JavaScriptTag(typeof(FrmFiltro), 112));
            lstJs.Add(new JavaScriptTag(typeof(FrmFiltroConteudo), 112));
            lstJs.Add(new JavaScriptTag(typeof(GridHtml), 111));
            lstJs.Add(new JavaScriptTag(typeof(GridRow), 111));
            lstJs.Add(new JavaScriptTag(typeof(Input), 110));
            lstJs.Add(new JavaScriptTag(typeof(JanelaHtml), 121));
            lstJs.Add(new JavaScriptTag(typeof(JnlCadastro), 122));
            lstJs.Add(new JavaScriptTag(typeof(JnlConsulta), 122));
            lstJs.Add(new JavaScriptTag(typeof(JnlTag), 122));
            lstJs.Add(new JavaScriptTag(typeof(PagPrincipal), 103));
            lstJs.Add(new JavaScriptTag(typeof(PainelAcao), 120));
            lstJs.Add(new JavaScriptTag(typeof(PainelAcaoConsulta), 121));
            lstJs.Add(new JavaScriptTag(typeof(PainelFiltro), 115));
            lstJs.Add(new JavaScriptTag(typeof(PainelHtml), 114));
            lstJs.Add(new JavaScriptTag(typeof(PainelNivel), 115));
            lstJs.Add(new JavaScriptTag(typeof(ProgressBar), 111));
            lstJs.Add(new JavaScriptTag(typeof(TabHtml), 111));
            lstJs.Add(new JavaScriptTag(typeof(TabItem), 111));
            lstJs.Add(new JavaScriptTag(typeof(TabItemHead), 111));
            lstJs.Add(new JavaScriptTag(typeof(TagCard), 111));

            lstJs.Add(new JavaScriptTag("/res/js/lib/jquery.fixedheadertable.min.js"));
            lstJs.Add(new JavaScriptTag("/res/js/lib/jquery.floatThead.min.js"));

            lstJs.Add(new JavaScriptTag("/res/js/web/database/ColunaWeb.js", 101));
            lstJs.Add(new JavaScriptTag("/res/js/web/database/FiltroWeb.js", 101));
            lstJs.Add(new JavaScriptTag("/res/js/web/database/ParValorNome.js", 300));
            lstJs.Add(new JavaScriptTag("/res/js/web/database/TabelaWeb.js", 102));
            lstJs.Add(new JavaScriptTag("/res/js/web/database/TblFiltro.js", 300));

            lstJs.Add(new JavaScriptTag("/res/js/web/html/componente/grid/OnGridMenuClickArg.js", 300));
        }

        protected override void inicializar()
        {
            base.inicializar();

            this.divCadastro.strId = "divCadastro";
            this.divConsulta.strId = "divConsulta";
        }

        protected override void montarLayout()
        {
            base.montarLayout();

            this.divConsulta.setPai(this);
            this.divCadastro.setPai(this);
        }

        protected override void setCss(CssArquivo css)
        {
            base.setCss(css);

            this.divCadastro.addCss(css.setBackgroundColor("rgba(0,0,0,0.5)"));
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

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}