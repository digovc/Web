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
        private Coluna _clnStrSessaoId;

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

                _clnBooAdministrador = new Coluna("boo_administrador", this, Coluna.EnmTipo.BOOLEAN);

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

                _clnDttLogin = new Coluna("dtt_login", this, Coluna.EnmTipo.TIMESTAMP_WITHOUT_TIME_ZONE);

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

                _clnDttUltimoAcesso = new Coluna("dtt_ultimo_acesso", this, Coluna.EnmTipo.TIMESTAMP_WITHOUT_TIME_ZONE);

                return _clnDttUltimoAcesso;
            }
        }

        public Coluna clnStrSessaoId
        {
            get
            {
                if (_clnStrSessaoId != null)
                {
                    return _clnStrSessaoId;
                }

                _clnStrSessaoId = new Coluna("str_sessao_id", this, Coluna.EnmTipo.TEXT);

                return _clnStrSessaoId;
            }
        }

        #endregion Atributos

        #region Construtores

        protected TblUsuarioBase() : base(AppWebBase.i.dbe)
        {
            i = this;
        }

        #endregion Construtores

        #region Métodos

        internal UsuarioDominio getObjUsuario(string strSessaoId)
        {
            if (string.IsNullOrEmpty(strSessaoId))
            {
                return null;
            }

            UsuarioDominio objUsuario = this.recuperarDominio<UsuarioDominio>(this.clnStrSessaoId, strSessaoId);

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
            lstCln.Add(this.clnStrSessaoId);
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}