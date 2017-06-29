using NetZ.Persistencia;
using NetZ.Web.DataBase.Dominio;
using System;
using System.Collections.Generic;

namespace NetZ.Web.DataBase.Tabela
{
    public abstract class TblUsuarioBase : TblWebBase
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private static TblUsuarioBase _i;

        private Coluna _clnBooAdministrador;
        private Coluna _clnDttLogin;
        private Coluna _clnDttUltimoAcesso;
        private Coluna _clnStrSessao;

        public static TblUsuarioBase i
        {
            get
            {
                return _i;
            }

            private set
            {
                if (_i != null)
                {
                    return;
                }

                _i = value;
            }
        }

        public Coluna clnBooAdministrador
        {
            get
            {
                if (_clnBooAdministrador != null)
                {
                    return _clnBooAdministrador;
                }

                _clnBooAdministrador = new Coluna("boo_administrador", Coluna.EnmTipo.BOOLEAN);

                return _clnBooAdministrador;
            }
        }

        public Coluna clnDttLogin
        {
            get
            {
                if (_clnDttLogin != null)
                {
                    return _clnDttLogin;
                }

                _clnDttLogin = new Coluna("dtt_login", Coluna.EnmTipo.TIMESTAMP_WITHOUT_TIME_ZONE);

                return _clnDttLogin;
            }
        }

        public Coluna clnDttUltimoAcesso
        {
            get
            {
                if (_clnDttUltimoAcesso != null)
                {
                    return _clnDttUltimoAcesso;
                }

                _clnDttUltimoAcesso = new Coluna("dtt_ultimo_acesso", Coluna.EnmTipo.TIMESTAMP_WITHOUT_TIME_ZONE);

                return _clnDttUltimoAcesso;
            }
        }

        public Coluna clnStrSessao
        {
            get
            {
                if (_clnStrSessao != null)
                {
                    return _clnStrSessao;
                }

                _clnStrSessao = new Coluna("str_sessao", Coluna.EnmTipo.TEXT);

                return _clnStrSessao;
            }
        }

        #endregion Atributos

        #region Construtores

        protected TblUsuarioBase()
        {
            i = this;
        }

        #endregion Construtores

        #region Métodos

        internal UsuarioDominio getObjUsuario(string strSessao)
        {
            if (string.IsNullOrEmpty(strSessao))
            {
                return null;
            }

            var objUsuario = this.recuperarDominio<UsuarioDominio>(this.clnStrSessao, strSessao);

            if (objUsuario == null)
            {
                return null;
            }

            if (objUsuario.dttUltimoAcesso < DateTime.Now.AddHours(-8))
            {
                return null;
            }

            return objUsuario;
        }

        protected override void inicializarLstCln(List<Coluna> lstCln)
        {
            base.inicializarLstCln(lstCln);

            lstCln.Add(this.clnBooAdministrador);
            lstCln.Add(this.clnDttLogin);
            lstCln.Add(this.clnDttUltimoAcesso);
            lstCln.Add(this.clnStrSessao);
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}