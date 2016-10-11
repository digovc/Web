using NetZ.Persistencia;
using NetZ.Web.DataBase;
using NetZ.Web.DataBase.Tabela;
using NetZ.Web.Html.Componente.Campo;

namespace NetZ.Web.Html.Componente.Janela.Cadastro
{
    public class JnlFiltroItemCadastro : JnlCadastro
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private CampoCheckBox _cmpBooAnd;
        private CampoComboBox _cmpIntOperador;
        private CampoComboBox _cmpStrColunaNome;

        private CampoCheckBox cmpBooAnd
        {
            get
            {
                if (_cmpBooAnd != null)
                {
                    return _cmpBooAnd;
                }

                _cmpBooAnd = new CampoCheckBox();

                return _cmpBooAnd;
            }
        }

        private CampoComboBox cmpIntOperador
        {
            get
            {
                if (_cmpIntOperador != null)
                {
                    return _cmpIntOperador;
                }

                _cmpIntOperador = new CampoComboBox();

                return _cmpIntOperador;
            }
        }

        private CampoComboBox cmpStrColunaNome
        {
            get
            {
                if (_cmpStrColunaNome != null)
                {
                    return _cmpStrColunaNome;
                }

                _cmpStrColunaNome = new CampoComboBox();

                return _cmpStrColunaNome;
            }
        }

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        protected override void carregarDados()
        {
            base.carregarDados();

            this.carregarDadosCmpStrColunaNome();
        }

        protected override void inicializar()
        {
            base.inicializar();

            this.intTamanhoHotizontal = 7;

            this.cmpStrColunaNome.enmTamanho = CampoHtml.EnmTamanho.TOTAL;
            this.cmpStrColunaNome.intNivel = 1;

            this.cmpIntOperador.enmTamanho = CampoHtml.EnmTamanho.MEDIO;
            this.cmpIntOperador.intNivel = 2;

            this.cmpBooAnd.booDireita = true;
            this.cmpBooAnd.intNivel = 2;
        }

        protected override void montarLayout()
        {
            base.montarLayout();

            this.intTamanhoHotizontal = 10;

            this.cmpStrColunaNome.setPai(this);
            this.cmpIntOperador.setPai(this);
            this.cmpBooAnd.setPai(this);
        }

        private void carregarDados(Coluna cln)
        {
            if (cln == null)
            {
                return;
            }

            this.cmpStrColunaNome.addOpcao(cln.sqlNome, cln.strNomeExibicao);
        }

        private void carregarDadosCmpStrColunaNome()
        {
            if (AppWebBase.i == null)
            {
                return;
            }

            if (AppWebBase.i.dbe == null)
            {
                return;
            }

            if (this.tblWeb == null)
            {
                return;
            }

            if (this.tblWeb.intRegistroPaiId < 1)
            {
                return;
            }

            TblFiltro.i.recuperar(this.tblWeb.intRegistroPaiId);

            if (string.IsNullOrEmpty(TblFiltro.i.clnStrTabelaNome.strValor))
            {
                return;
            }

            TabelaBase tblFiltrada = AppWebBase.i.dbe[TblFiltro.i.clnStrTabelaNome.strValor];

            if (tblFiltrada == null)
            {
                return;
            }

            foreach (Coluna cln in tblFiltrada.lstClnConsulta)
            {
                this.carregarDados(cln);
            }
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}