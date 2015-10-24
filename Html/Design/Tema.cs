using System;
using NetZ.SistemaBase;

namespace NetZ.Web.Html.Design
{
    public class Tema : Objeto
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private static Tema _i;

        private string _corBorda1Inativo;
        private string _corBorda1Normal;
        private string _corBorda1Selecionado;
        private string _corBorda2Normal;
        private string _corBorda2Selecionado;
        private string _corBorda3Normal;
        private string _corBorda3Selecionado;
        private string _corFonte1Inativo;
        private string _corFonte1Normal;
        private string _corFonte1Selecionado;
        private string _corFonte2Normal;
        private string _corFonte2Selecionado;
        private string _corFonte3Normal;
        private string _corFonte3Selecionado;
        private string _corFundo1Inativo;
        private string _corFundo1Normal;
        private string _corFundo1Selecionado;
        private string _corFundo2Normal;
        private string _corFundo2Selecionado;
        private string _corFundo3Normal;
        private string _corFundo3Selecionado;
        private string _corSombra1;
        private string _corSombra2;
        private string _corSombra3;

        public static Tema i
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_i != null)
                    {
                        return _i;
                    }

                    _i = new Tema("Default");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _i;
            }
        }

        public string corBorda1Inativo
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_corBorda1Inativo != null)
                    {
                        return _corBorda1Inativo;
                    }

                    _corBorda1Inativo = this.getCorBorda1Inativo();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _corBorda1Inativo;
            }
        }

        public string corBorda1Normal
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_corBorda1Normal != null)
                    {
                        return _corBorda1Normal;
                    }

                    _corBorda1Normal = this.getCorBorda1Normal();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _corBorda1Normal;
            }
        }

        public string corBorda1Selecionado
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_corBorda1Selecionado != null)
                    {
                        return _corBorda1Selecionado;
                    }

                    _corBorda1Selecionado = this.getCorBorda1Selecionado();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _corBorda1Selecionado;
            }
        }

        public string corBorda2Normal
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_corBorda2Normal != null)
                    {
                        return _corBorda2Normal;
                    }

                    _corBorda2Normal = this.getCorBorda2Normal();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _corBorda2Normal;
            }
        }

        public string corBorda2Selecionado
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_corBorda2Selecionado != null)
                    {
                        return _corBorda2Selecionado;
                    }

                    _corBorda2Selecionado = this.getCorBorda2Selecionado();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _corBorda2Selecionado;
            }
        }

        public string corBorda3Normal
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_corBorda3Normal != null)
                    {
                        return _corBorda3Normal;
                    }

                    _corBorda3Normal = this.getCorBorda3Normal();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _corBorda3Normal;
            }
        }

        public string corBorda3Selecionado
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_corBorda3Selecionado != null)
                    {
                        return _corBorda3Selecionado;
                    }

                    _corBorda3Selecionado = this.getCorBorda3Selecionado();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _corBorda3Selecionado;
            }
        }

        public string corFonte1Inativo
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_corFonte1Inativo != null)
                    {
                        return _corFonte1Inativo;
                    }

                    _corFonte1Inativo = this.getCorFonte1Inativo();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _corFonte1Inativo;
            }
        }

        public string corFonte1Normal
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_corFonte1Normal != null)
                    {
                        return _corFonte1Normal;
                    }

                    _corFonte1Normal = this.getCorFonte1Normal();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _corFonte1Normal;
            }
        }

        public string corFonte1Selecionado
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_corFonte1Selecionado != null)
                    {
                        return _corFonte1Selecionado;
                    }

                    _corFonte1Selecionado = this.getCorFonte1Selecionado();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _corFonte1Selecionado;
            }
        }

        public string corFonte2Normal
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_corFonte2Normal != null)
                    {
                        return _corFonte2Normal;
                    }

                    _corFonte2Normal = this.getCorFonte2Normal();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _corFonte2Normal;
            }
        }

        public string corFonte2Selecionado
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_corFonte2Selecionado != null)
                    {
                        return _corFonte2Selecionado;
                    }

                    _corFonte2Selecionado = this.getCorFonte2Selecionado();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _corFonte2Selecionado;
            }
        }

        public string corFonte3Normal
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_corFonte3Normal != null)
                    {
                        return _corFonte3Normal;
                    }

                    _corFonte3Normal = this.getCorFonte3Normal();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _corFonte3Normal;
            }
        }

        public string corFonte3Selecionado
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_corFonte3Selecionado != null)
                    {
                        return _corFonte3Selecionado;
                    }

                    _corFonte3Selecionado = this.getCorFonte3Selecionado();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _corFonte3Selecionado;
            }
        }

        public string corFundo1Inativo
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_corFundo1Inativo != null)
                    {
                        return _corFundo1Inativo;
                    }

                    _corFundo1Inativo = this.getCorFundo1Inativo();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _corFundo1Inativo;
            }
        }

        public string corFundo1Normal
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_corFundo1Normal != null)
                    {
                        return _corFundo1Normal;
                    }

                    _corFundo1Normal = this.getCorFundo1Normal();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _corFundo1Normal;
            }
        }

        public string corFundo1Selecionado
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_corFundo1Selecionado != null)
                    {
                        return _corFundo1Selecionado;
                    }

                    _corFundo1Selecionado = this.getCorFundo1Selecionado();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _corFundo1Selecionado;
            }
        }

        public string corFundo2Normal
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_corFundo2Normal != null)
                    {
                        return _corFundo2Normal;
                    }

                    _corFundo2Normal = this.getCorFundo2Normal();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _corFundo2Normal;
            }
        }

        public string corFundo2Selecionado
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_corFundo2Selecionado != null)
                    {
                        return _corFundo2Selecionado;
                    }

                    _corFundo2Selecionado = this.getCorFundo2Selecionado();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _corFundo2Selecionado;
            }
        }

        public string corFundo3Normal
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_corFundo3Normal != null)
                    {
                        return _corFundo3Normal;
                    }

                    _corFundo3Normal = this.getCorFundo3Normal();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _corFundo3Normal;
            }
        }

        public string corFundo3Selecionado
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_corFundo3Selecionado != null)
                    {
                        return _corFundo3Selecionado;
                    }

                    _corFundo3Selecionado = this.getCorFundo3Selecionado();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _corFundo3Selecionado;
            }
        }

        public string corSombra1
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_corSombra1 != null)
                    {
                        return _corSombra1;
                    }

                    _corSombra1 = this.getCorSombra1();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _corSombra1;
            }
        }

        public string corSombra2
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_corSombra2 != null)
                    {
                        return _corSombra2;
                    }

                    _corSombra2 = this.getCorSombra2();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _corSombra2;
            }
        }

        public string corSombra3
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_corSombra3 != null)
                    {
                        return _corSombra3;
                    }

                    _corSombra3 = this.getCorSombra3();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _corSombra3;
            }
        }

        #endregion Atributos

        #region Construtores

        protected Tema(string strNome)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.strNome = strNome;
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

        protected virtual string getCorBorda1Inativo()
        {
            return "#BDBDBD"; // Grey 400
        }

        protected virtual string getCorBorda1Normal()
        {
            return "#424242"; // Grey 800
        }

        protected virtual string getCorBorda1Selecionado()
        {
            return "#616161"; // Grey 700
        }

        protected virtual string getCorBorda2Normal()
        {
            return "#000000"; // Black
        }

        protected virtual string getCorBorda2Selecionado()
        {
            return "#212121"; // Grey 900
        }

        protected virtual string getCorBorda3Normal()
        {
            throw new NotImplementedException();
        }

        protected virtual string getCorBorda3Selecionado()
        {
            throw new NotImplementedException();
        }

        protected virtual string getCorFonte1Inativo()
        {
            return "#757575"; // Grey 600
        }

        protected virtual string getCorFonte1Normal()
        {
            return "#212121"; // Grey 900
        }

        protected virtual string getCorFonte1Selecionado()
        {
            return "#212121"; // Grey 900
        }

        protected virtual string getCorFonte2Normal()
        {
            return "#E0E0E0"; // Grey 300
        }

        protected virtual string getCorFonte2Selecionado()
        {
            return "#E0E0E0"; // Grey 300
        }

        protected virtual string getCorFonte3Normal()
        {
            throw new NotImplementedException();
        }

        protected virtual string getCorFonte3Selecionado()
        {
            throw new NotImplementedException();
        }

        protected virtual string getCorFundo1Inativo()
        {
            return "#EEEEEE"; // Grey 200
        }

        protected virtual string getCorFundo1Normal()
        {
            return "#E0E0E0"; // Grey 300
        }

        protected virtual string getCorFundo1Selecionado()
        {
            return "#EEEEEE"; // Grey 200
        }

        protected virtual string getCorFundo2Normal()
        {
            return "#9E9E9E"; // Grey 500
        }

        protected virtual string getCorFundo2Selecionado()
        {
            return "#BDBDBD"; // Grey 400
        }

        protected virtual string getCorFundo3Normal()
        {
            throw new NotImplementedException();
        }

        protected virtual string getCorFundo3Selecionado()
        {
            throw new NotImplementedException();
        }

        protected virtual string getCorSombra1()
        {
            return "#BDBDBD"; // Grey 400
        }

        protected virtual string getCorSombra2()
        {
            return "#444444";
        }

        protected virtual string getCorSombra3()
        {
            return "#424242"; // Grey 800
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}