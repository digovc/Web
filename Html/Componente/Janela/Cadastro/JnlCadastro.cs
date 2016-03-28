using System;
using System.Reflection;
using NetZ.Persistencia;
using NetZ.Web.Html.Componente.Campo;
using NetZ.Web.Html.Componente.Form;

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

                if (!(typeof(CampoHtml).IsAssignableFrom(tag.GetType())))
                {
                    base.addTag(tag);
                    return;
                }

                tag.setPai(this.frm);
                this.intComandoNivel = (((tag as CampoHtml).intNivel + 1) > this.intComandoNivel) ? ((tag as CampoHtml).intNivel + 1) : this.intComandoNivel;
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
                this.divComando.intNivel = this.intComandoNivel; // TODO: Parei no problema do tamanho das janelas.

                this.divComando.setPai(this.frm);

                this.intTamanhoY = (this.intComandoNivel + 2);
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