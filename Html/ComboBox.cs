using System;
using System.Collections.Generic;
using System.Data;

namespace NetZ.Web.Html
{
    public class Combobox : Input
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private bool _booOpcaoVazia;
        private SortedDictionary<object, string> _dicOpcao;
        private DataTable _objDataTable;

        /// <summary>
        /// Indica se este combobox pode ou não conter uma opção vazia.
        /// </summary>
        public bool booOpcaoVazia
        {
            get
            {
                return _booOpcaoVazia;
            }

            set
            {
                _booOpcaoVazia = value;
            }
        }

        private SortedDictionary<object, string> dicOpcao
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_dicOpcao != null)
                    {
                        return _dicOpcao;
                    }

                    _dicOpcao = new SortedDictionary<object, string>();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _dicOpcao;
            }
        }

        /// <summary>
        /// DataTable que pode ser utilizado para compor os valores que podem ser selecionados
        /// neste combobox.
        /// </summary>
        public DataTable objDataTable
        {
            get
            {
                return _objDataTable;
            }

            set
            {
                _objDataTable = value;
            }
        }

        #endregion Atributos

        #region Construtores

        public Combobox()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.strNome = "select";
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

        public void addOpcao(object objValor, string strNome)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (this.dicOpcao.ContainsKey(objValor))
                {
                    return;
                }

                this.dicOpcao.Add(objValor, strNome);
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

        protected override void addJs(LstTag<JavaScriptTag> lstJs)
        {
            base.addJs(lstJs);

            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                lstJs.Add(new JavaScriptTag(AppWeb.DIR_JS_COMBO_BOX));
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
                this.montarLayoutItens();
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

        private Tag getTagOption(object objValor, string strNome)
        {
            #region Variáveis

            Tag tagResultado;

            #endregion Variáveis

            #region Ações

            try
            {
                if (objValor == null)
                {
                    return null;
                }

                tagResultado = new Tag("option");

                if (this.strValor == objValor.ToString())
                {
                    tagResultado.addAtt("selected", null);
                }

                tagResultado.addAtt("value", objValor.ToString());
                tagResultado.strConteudo = strNome;
                tagResultado.setPai(this);

                return tagResultado;
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

        private void montarLayoutItens()
        {
            #region Variáveis

            Tag tagOption;

            #endregion Variáveis

            #region Ações

            try
            {
                if ((this.dicOpcao.Count < 1) || this.booOpcaoVazia)
                {
                    tagOption = this.getTagOption(-1, null);
                }

                foreach (KeyValuePair<object, string> kpv in this.dicOpcao)
                {
                    if (kpv.Key == null)
                    {
                        continue;
                    }

                    tagOption = this.getTagOption(kpv.Key, kpv.Value);
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

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}