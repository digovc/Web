using System;
using System.Reflection;
using NetZ.Persistencia;
using NetZ.Web.Html.Componente.Campo;
using NetZ.Web.Html.Componente.Form;
using NetZ.Web.Html.Componente.Tab;
using NetZ.Web.Server.Arquivo.Css;

namespace NetZ.Web.Html.Componente.Janela.Cadastro
{
    public abstract class JnlCadastro : JanelaHtml
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private CampoNumerico _cmpIntId;
        private DivComando _divComando;
        private FormHtml _frm;
        private int _intComandoNivel = 1;
        private int _intRegistroId;
        private TabHtml _tabHtml;
        private Tabela _tbl;

        public int intRegistroId
        {
            get
            {
                return _intRegistroId;
            }

            set
            {
                _intRegistroId = value;
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
                _tbl = value;
            }
        }

        private CampoNumerico cmpIntId
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_cmpIntId != null)
                    {
                        return _cmpIntId;
                    }

                    _cmpIntId = new CampoNumerico();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _cmpIntId;
            }
        }

        private DivComando divComando
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_divComando != null)
                    {
                        return _divComando;
                    }

                    _divComando = new DivComando();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _divComando;
            }
        }

        private FormHtml frm
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_frm != null)
                    {
                        return _frm;
                    }

                    _frm = new FormHtml();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _frm;
            }
        }

        private int intComandoNivel
        {
            get
            {
                return _intComandoNivel;
            }

            set
            {
                _intComandoNivel = value;
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
                lstJs.Add(new JavaScriptTag(typeof(JnlCadastro), 112));
                lstJs.Add(new JavaScriptTag(this.GetType(), 112));

                lstJs.Add(new JavaScriptTag("res/js/Web.TypeScript/persistencia/TabelaWeb.js"));
                lstJs.Add(new JavaScriptTag("res/js/Web.TypeScript/persistencia/ColunaWeb.js"));
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

                if ((typeof(CampoHtml).IsAssignableFrom(tag.GetType())))
                {
                    this.addTagCampoHtml(tag as CampoHtml);
                    return;
                }

                if ((typeof(TabItem).IsAssignableFrom(tag.GetType())))
                {
                    this.addTagTabItem(tag as TabItem);
                    return;
                }

                base.addTag(tag);
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

            this.finalizarTabHtml();

            this.finalizarDivComando();

            this.intTamanhoY = (this.intComandoNivel + 2);
        }

        protected override void inicializar()
        {
            base.inicializar();

            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.inicializarCampos();

                this.intTamanhoX = 10;
                this.strId = this.GetType().Name;

                this.addAtt("js_src", JavaScriptTag.getSrc(this.GetType()));
                this.addAtt("tbl_web_nome", this.tbl.strNomeSql);

                this.cmpIntId.enmTamanho = CampoHtml.EnmTamanho.PEQUENO;
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
                this.frm.setPai(this);
                this.cmpIntId.setPai(this.frm);
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

            this.tabHtml.addCss(css.setDisplay("none"));
        }

        private void addTagCampoHtml(CampoHtml tagCampoHtml)
        {
            if (tagCampoHtml == null)
            {
                return;
            }

            tagCampoHtml.setPai(this.frm);

            this.intComandoNivel = ((tagCampoHtml.intNivel + 1) > this.intComandoNivel) ? (tagCampoHtml.intNivel + 1) : this.intComandoNivel;
        }

        private void addTagTabItem(TabItem tabItem)
        {
            if (tabItem == null)
            {
                return;
            }

            tabItem.setPai(this.tabHtml);
        }

        private void finalizarDivComando()
        {
            this.divComando.intNivel = this.intComandoNivel;

            this.divComando.setPai(this.frm);
        }

        private void finalizarTabHtml()
        {
            if (this.tabHtml.intTabQuantidade < 1)
            {
                return;
            }

            this.tabHtml.setPai(this);
        }

        private void inicializarCampos()
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

                this.tbl.recuperar(this.intRegistroId);

                this.inicializarCampos(this.GetType());
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

        private void inicializarCampos(Type cls)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (cls == null)
                {
                    return;
                }

                if (cls.BaseType != null)
                {
                    this.inicializarCampos(cls.BaseType);
                }

                foreach (Coluna cln in this.tbl.lstCln)
                {
                    this.inicializarCampos(cls, cln);
                }
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

        private void inicializarCampos(Type cls, Coluna cln)
        {
            #region Variáveis

            PropertyInfo objPropertyInfo;

            #endregion Variáveis

            #region Ações

            try
            {
                if (cls == null)
                {
                    return;
                }

                if (cln == null)
                {
                    return;
                }

                if (string.IsNullOrEmpty(cln.strCampoNome))
                {
                    return;
                }

                objPropertyInfo = cls.GetProperty(cln.strCampoNome, BindingFlags.IgnoreCase | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);

                if (objPropertyInfo == null)
                {
                    return;
                }

                if (!(typeof(CampoHtml).IsAssignableFrom(objPropertyInfo.PropertyType)))
                {
                    return;
                }

                if ((objPropertyInfo.GetValue(this) as CampoHtml).cln != null)
                {
                    return;
                }

                (objPropertyInfo.GetValue(this) as CampoHtml).cln = cln;
                (objPropertyInfo.GetValue(this) as CampoHtml).tagInput.strValor = cln.strValor;
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