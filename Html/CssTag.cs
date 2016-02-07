using System;

namespace NetZ.Web.Html
{
    public class CssTag : Tag
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private Atributo _attHref;
        private string _strHref;

        public string strHref
        {
            get
            {
                return _strHref;
            }

            set
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    _strHref = value;

                    this.atualizarStrHref();
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

        private Atributo attHref
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_attHref != null)
                    {
                        return _attHref;
                    }

                    _attHref = new Atributo("href");

                    this.addAtt(_attHref);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _attHref;
            }
        }

        #endregion Atributos

        #region Construtores

        public CssTag() : base("link")
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.booMostrarClazz = false;
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

        protected override void inicializar()
        {
            base.inicializar();

            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.booTagDupla = false;

                this.addAtt("rel", "stylesheet");
                this.addAtt("type", "text/css");
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

        private void atualizarStrHref()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.attHref.strValor = _strHref;
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