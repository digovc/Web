using System;

namespace NetZ.Web.DataBase.Dominio.Documentacao
{
    public class EmailRegistroDominio : DocumentacaoDominioBase
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private string _dirDocumentacao;
        private DateTime _dttAtualizacao;
        private string _strDocumentacaoTitulo;
        private string _strEmail;
        private string _urlDocumentacao;

        public string dirDocumentacao
        {
            get
            {
                return _dirDocumentacao;
            }

            set
            {
                _dirDocumentacao = value;
            }
        }

        public DateTime dttAtualizacao
        {
            get
            {
                return _dttAtualizacao;
            }

            set
            {
                _dttAtualizacao = value;
            }
        }

        public string strDocumentacaoTitulo
        {
            get
            {
                return _strDocumentacaoTitulo;
            }

            set
            {
                _strDocumentacaoTitulo = value;
            }
        }

        public string strEmail
        {
            get
            {
                return _strEmail;
            }

            set
            {
                _strEmail = value;
            }
        }

        public string urlDocumentacao
        {
            get
            {
                return _urlDocumentacao;
            }

            set
            {
                _urlDocumentacao = value;
            }
        }

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}