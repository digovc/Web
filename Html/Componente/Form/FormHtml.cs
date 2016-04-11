using System.Collections.Generic;
using System.Linq;
using NetZ.Web.Html.Componente.Campo;
using NetZ.Web.Html.Componente.Painel;

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
        private Div _divConteudo;
        private LimiteFloat _divLimiteFloat;
        private EnmMetodo _enmMetodo;
        private List<CampoHtml> _lstCmp;
        private List<PainelNivel> _lstPnlNivel;
        private List<ITagNivel> _lstTagNivel;
        private string _strAction;

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

            base.addTag(tag);
        }

        protected override void finalizar()
        {
            base.finalizar();

            this.finalizarMontarLayoutLstCmp();
            this.finalizarMontarLayoutLstPnlNivel();
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
        }

        private void finalizarMontarLayoutLstCmp()
        {
            foreach (ITagNivel tag in this.lstTagNivel.OrderBy((x) => x.intNivel))
            {
                this.finalizarMontarLayoutLstCmp(tag);
            }
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
                pnlNivel = new PainelNivel();

                pnlNivel.intNivel = tag.intNivel;
                pnlNivel.setPai(this.divConteudo);

                this.lstPnlNivel.Add(pnlNivel);
            }

            (tag as Tag).setPai(pnlNivel);
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}