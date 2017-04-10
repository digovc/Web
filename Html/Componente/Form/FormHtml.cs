using NetZ.Web.Html.Componente.Campo;
using NetZ.Web.Html.Componente.Janela.Cadastro;
using NetZ.Web.Html.Componente.Painel;
using NetZ.Web.Html.Componente.Tab;
using NetZ.Web.Server.Arquivo.Css;
using System.Collections.Generic;
using System.Linq;

namespace NetZ.Web.Html.Componente.Form
{
    public class FormHtml : ComponenteHtml
    {
        #region Constantes

        public enum EnmMetodo
        {
            GET,
            POST,
        }

        #endregion Constantes

        #region Atributos

        private Atributo _attAction;
        private Atributo _attMetodo;
        private bool _booAutoComplete = true;
        private bool _booJnlCadastro;
        private DivComando _divComando;
        private Div _divConteudo;
        private DivCritica _divCritica;
        private DivDica _divDica;
        private LimiteFloat _divLimiteFloat;
        private EnmMetodo _enmMetodo;
        private int _intUltimoNivel = 1;
        private List<CampoHtml> _lstCmp;
        private List<PainelNivel> _lstPnlNivel;
        private List<ITagNivel> _lstTagNivel;
        private string _strAction;
        private TabHtml _tabHtml;

        /// <summary>
        /// Indica se o browser poderá guardar os valores em cache para auxiliar o usuário.
        /// </summary>
        public bool booAutoComplete
        {
            get
            {
                return _booAutoComplete;
            }

            set
            {
                _booAutoComplete = value;
            }
        }

        /// <summary>
        /// Indica o método que será utilizado para envio dos dados.
        /// </summary>
        public EnmMetodo enmMetodo
        {
            get
            {
                return _enmMetodo;
            }

            set
            {
                _enmMetodo = value;

                this.attMetodo.strValor = EnmMetodo.GET.Equals(_enmMetodo) ? "get" : "post";
            }
        }

        /// <summary>
        /// Lista dos campos que foram adicionados para este formulário.
        /// </summary>
        public List<CampoHtml> lstCmp
        {
            get
            {
                if (_lstCmp != null)
                {
                    return _lstCmp;
                }

                _lstCmp = new List<CampoHtml>();

                return _lstCmp;
            }
        }

        /// <summary>
        /// Define a localização que receberá os dados deste formulário quando ele for submetido ao servidor.
        /// </summary>
        public string strAction
        {
            get
            {
                return _strAction;
            }

            set
            {
                _strAction = value;

                this.attAction.strValor = _strAction;
            }
        }

        private Atributo attAction
        {
            get
            {
                if (_attAction != null)
                {
                    return _attAction;
                }

                _attAction = new Atributo("action");

                this.addAtt(_attAction);

                return _attAction;
            }
        }

        private Atributo attMetodo
        {
            get
            {
                if (_attMetodo != null)
                {
                    return _attMetodo;
                }

                _attMetodo = new Atributo("method");

                this.addAtt(_attMetodo);

                return _attMetodo;
            }
        }

        private bool booJnlCadastro
        {
            get
            {
                return _booJnlCadastro;
            }

            set
            {
                _booJnlCadastro = value;
            }
        }

        private DivComando divComando
        {
            get
            {
                if (_divComando != null)
                {
                    return _divComando;
                }

                _divComando = new DivComando();

                return _divComando;
            }
        }

        private Div divConteudo
        {
            get
            {
                if (_divConteudo != null)
                {
                    return _divConteudo;
                }

                _divConteudo = new Div();

                return _divConteudo;
            }
        }

        private DivCritica divCritica
        {
            get
            {
                if (_divCritica != null)
                {
                    return _divCritica;
                }

                _divCritica = new DivCritica();

                return _divCritica;
            }
        }

        private DivDica divDica
        {
            get
            {
                if (_divDica != null)
                {
                    return _divDica;
                }

                _divDica = new DivDica();

                return _divDica;
            }
        }

        private LimiteFloat divLimiteFloat
        {
            get
            {
                if (_divLimiteFloat != null)
                {
                    return _divLimiteFloat;
                }

                _divLimiteFloat = new LimiteFloat();

                return _divLimiteFloat;
            }
        }

        private int intUltimoNivel
        {
            get
            {
                return _intUltimoNivel;
            }

            set
            {
                _intUltimoNivel = value;
            }
        }

        private List<PainelNivel> lstPnlNivel
        {
            get
            {
                if (_lstPnlNivel != null)
                {
                    return _lstPnlNivel;
                }

                _lstPnlNivel = this.getLstPnlNivel();

                return _lstPnlNivel;
            }
        }

        private List<ITagNivel> lstTagNivel
        {
            get
            {
                if (_lstTagNivel != null)
                {
                    return _lstTagNivel;
                }

                _lstTagNivel = new List<ITagNivel>();

                return _lstTagNivel;
            }
        }

        private TabHtml tabHtml
        {
            get
            {
                if (_tabHtml != null)
                {
                    return _tabHtml;
                }

                _tabHtml = new TabHtml();

                return _tabHtml;
            }
        }

        private List<PainelNivel> getLstPnlNivel()
        {
            List<PainelNivel> lstPnlNivelResultado;
            PainelNivel pnlNivel;

            pnlNivel = new PainelNivel();

            pnlNivel.setPai(this.divConteudo);

            lstPnlNivelResultado = new List<PainelNivel>();

            lstPnlNivelResultado.Add(pnlNivel);

            return lstPnlNivelResultado;
        }

        #endregion Atributos

        #region Construtores

        public FormHtml()
        {
            this.strNome = "form";
        }

        #endregion Construtores

        #region Métodos

        public override void setPai(Tag tagPai)
        {
            base.setPai(tagPai);

            this.booJnlCadastro = (tagPai is JnlCadastro);
        }

        protected override void addJs(LstTag<JavaScriptTag> lstJs)
        {
            base.addJs(lstJs);

            lstJs.Add(new JavaScriptTag(typeof(FormHtml)));
        }

        protected override void addTag(Tag tag)
        {
            if (tag == null)
            {
                return;
            }

            if ((typeof(ITagNivel).IsAssignableFrom(tag.GetType())))
            {
                this.addTagITagNivel(tag as ITagNivel);
                return;
            }

            if ((typeof(TabItem).IsAssignableFrom(tag.GetType())))
            {
                this.addTagTabItem(tag as TabItem);
                return;
            }

            base.addTag(tag);
        }

        protected override void finalizar()
        {
            base.finalizar();

            this.finalizarTabHtml();

            this.finalizarPnlDicaCritica();

            this.finalizarDivComando();

            this.finalizarMontarLayoutLstCmp();

            this.finalizarMontarLayoutLstPnlNivel();

            this.finalizarBooAutoComplete();
        }

        protected override void finalizarCss(CssArquivoBase css)
        {
            base.finalizarCss(css);

            this.finalizarCssNivel(css);
        }

        protected override void inicializar()
        {
            base.inicializar();

            this.divConteudo.strId = "divConteudo";
        }

        protected override void montarLayout()
        {
            base.montarLayout();

            this.divConteudo.setPai(this);
        }

        protected override void setStrId(string strId)
        {
            base.setStrId(strId);

            if (string.IsNullOrEmpty(strId))
            {
                return;
            }

            this.divComando.strId = (strId + "_divComando");
            this.divCritica.strId = (strId + "_divCritica");
            this.divDica.strId = (strId + "_divDica");
            this.tabHtml.strId = (strId + "_tabHtml");
        }

        private void addLstCmp(ITagNivel tag)
        {
            if (tag == null)
            {
                return;
            }

            if (!(typeof(CampoHtml).IsAssignableFrom(tag.GetType())))
            {
                return;
            }

            if (this.lstCmp.Contains((CampoHtml)tag))
            {
                return;
            }

            this.lstCmp.Add((CampoHtml)tag);
        }

        private void addLstTagNivel(ITagNivel tag)
        {
            if (tag == null)
            {
                return;
            }

            if (this.lstTagNivel.Contains(tag))
            {
                return;
            }

            this.lstTagNivel.Add(tag);
        }

        private void addTagITagNivel(ITagNivel tag)
        {
            if (tag == null)
            {
                return;
            }

            this.addLstTagNivel(tag);
            this.addLstCmp(tag);

            this.intUltimoNivel = ((tag.intNivel) > this.intUltimoNivel) ? (tag.intNivel) : this.intUltimoNivel;
        }

        private void addTagTabItem(TabItem tabItem)
        {
            if (tabItem == null)
            {
                return;
            }

            tabItem.setPai(this.tabHtml);
        }

        private void finalizarBooAutoComplete()
        {
            if (this.booAutoComplete)
            {
                return;
            }

            this.addAtt("autocomplete", "off");
        }

        private void finalizarCssNivel(CssArquivoBase css)
        {
            if (!this.booJnlCadastro)
            {
                return;
            }

            if (this.lstPnlNivel.Count < 4)
            {
                return;
            }

            this.finalizarCssNivelTabHtml(css, this.lstPnlNivel[this.lstPnlNivel.Count - 3]);
            this.finalizarCssNivelDica(css, this.lstPnlNivel[this.lstPnlNivel.Count - 2]);
            this.finalizarCssNivelComando(css, this.lstPnlNivel.Last());
        }

        private void finalizarCssNivelComando(CssArquivoBase css, PainelNivel pnlNivelComando)
        {
            pnlNivelComando.addCss(css.setBackgroundColor(AppWebBase.i.objTema.corTema));
        }

        private void finalizarCssNivelDica(CssArquivoBase css, PainelNivel pnlNivelDica)
        {
            pnlNivelDica.addCss(css.setBackgroundColor(AppWebBase.i.objTema.corFundo1));
        }

        private void finalizarCssNivelTabHtml(CssArquivoBase css, PainelNivel pnlNivelTabHtml)
        {
            if (this.tabHtml.intTabQuantidade < 1)
            {
                return;
            }

            pnlNivelTabHtml.addCss(css.setBackgroundColor(AppWebBase.i.objTema.corFundo1));
            pnlNivelTabHtml.addCss(css.setMarginTop(10));
            pnlNivelTabHtml.addCss(css.setPaddingLeft(10));
            pnlNivelTabHtml.addCss(css.setPaddingRight(10));
        }

        private void finalizarDivComando()
        {
            if (!this.booJnlCadastro)
            {
                return;
            }

            this.divComando.intNivel = (this.intUltimoNivel + 3);

            this.divComando.setPai(this);
        }

        private void finalizarMontarLayoutLstCmp()
        {
            foreach (ITagNivel tag in this.lstTagNivel.OrderBy((tag) => tag.intNivel))
            {
                this.finalizarMontarLayoutLstCmp(tag);
            }
        }

        private void finalizarMontarLayoutLstCmp(ITagNivel tag)
        {
            if (tag == null)
            {
                return;
            }

            if (!(typeof(Tag).IsAssignableFrom(tag.GetType())))
            {
                return;
            }

            PainelNivel pnlNivel = this.lstPnlNivel.Last();

            if (tag.intNivel > pnlNivel.intNivel)
            {
                pnlNivel = this.getPnlNivel(tag);
            }

            (tag as Tag).setPai(pnlNivel);
        }

        private void finalizarMontarLayoutLstPnlNivel()
        {
            foreach (PainelNivel pnl in this.lstPnlNivel)
            {
                if (pnl == null)
                {
                    continue;
                }

                this.divLimiteFloat.setPai(pnl);
            }
        }

        private void finalizarPnlDicaCritica()
        {
            if (!this.booJnlCadastro)
            {
                return;
            }

            this.divDica.intNivel = (this.intUltimoNivel + 2);
            this.divCritica.intNivel = (this.intUltimoNivel + 2);

            this.divDica.setPai(this);
            this.divCritica.setPai(this);
        }

        private void finalizarTabHtml()
        {
            if (!this.booJnlCadastro)
            {
                return;
            }

            if (this.tabHtml.intTabQuantidade < 1)
            {
                return;
            }

            this.tabHtml.intNivel = (this.intUltimoNivel + 1);

            this.tabHtml.setPai(this);
        }

        private PainelNivel getPnlNivel(ITagNivel tag)
        {
            PainelNivel pnlNivelResultado = new PainelNivel();

            pnlNivelResultado.intNivel = tag.intNivel;

            if (tag.intTamanhoVertical > 0)
            {
                pnlNivelResultado.intTamanhoVertical = tag.intTamanhoVertical;
            }

            pnlNivelResultado.setPai(this.divConteudo);

            this.lstPnlNivel.Add(pnlNivelResultado);

            return pnlNivelResultado;
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}