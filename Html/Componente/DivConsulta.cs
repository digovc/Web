using System;

namespace NetZ.Web.Html.Componente
{
    public class DivConsulta : Div
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private Tag _tagObject;

        private Tag tagObject
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_tagObject != null)
                    {
                        return _tagObject;
                    }

                    _tagObject = new Tag("object");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _tagObject;
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
                lstJs.Add(new JavaScriptTag(typeof(DivConsulta), 110));
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
                this.strId = "divConsulta";
                this.tagObject.strId = "divConsulta_tagObject";
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
                this.tagObject.setPai(this);
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

        protected override void setCss(CssTag css)
        {
            base.setCss(css);

            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.addCss(CssTag.i.setBottom(0));
                this.addCss(CssTag.i.setLeft(0));
                this.addCss(CssTag.i.setPosition("absolute"));
                this.addCss(CssTag.i.setRight(0));
                this.addCss(CssTag.i.setTop(50));
                this.addCss(CssTag.i.setZIndex(-1));

                this.tagObject.addCss(CssTag.i.setHeight(100, "%"));
                this.tagObject.addCss(CssTag.i.setWidth(100, "%"));
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