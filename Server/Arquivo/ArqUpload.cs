using System;
using System.IO;
using DigoFramework.Arquivo;
using NetZ.Persistencia;
using NetZ.Persistencia.Interface;
using NetZ.Persistencia.Web;

namespace NetZ.Web.Server.Arquivo
{
    public class ArqUpload : ArquivoDiverso
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private DateTime _dttUpload;
        private Solicitacao _objSolicitacao;
        private string _strClnWebNome;
        private string _strTblWebNome;

        public Solicitacao objSolicitacao
        {
            get
            {
                return _objSolicitacao;
            }

            private set
            {
                if (_objSolicitacao == value)
                {
                    return;
                }

                _objSolicitacao = value;

                this.atualizarObjSolicitacao();
            }
        }

        public string strClnWebNome
        {
            get
            {
                if (_strClnWebNome != null)
                {
                    return _strClnWebNome;
                }

                _strClnWebNome = this.getStrClnWebNome();

                return _strClnWebNome;
            }
        }

        public string strTblWebNome
        {
            get
            {
                if (_strTblWebNome != null)
                {
                    return _strTblWebNome;
                }

                _strTblWebNome = this.getStrTblWebNome();

                return _strTblWebNome;
            }
        }

        private DateTime dttUpload
        {
            get
            {
                if (_dttUpload != default(DateTime))
                {
                    return _dttUpload;
                }

                _dttUpload = this.getDttUpload();

                return _dttUpload;
            }
        }

        #endregion Atributos

        #region Construtores

        public ArqUpload(Solicitacao objSolicitacao)
        {
            this.objSolicitacao = objSolicitacao;
        }

        #endregion Construtores

        #region Métodos

        internal bool carregarArquivo(Solicitacao objSolicitacao, Interlocutor objInterlocutor, TabelaWeb tblWeb, Tabela tbl)
        {
            if (!this.carregarArquivoValidar(objSolicitacao, objInterlocutor, tblWeb, tbl))
            {
                return false;
            }

            (tbl as ITblArquivo).getClnArq().arrBteValor = this.arrBteConteudo;
            (tbl as ITblArquivo).getClnDttArquivoModificacao().dttValor = this.dttUpload;
            (tbl as ITblArquivo).getClnIntArquivoTamanho().intValor = this.arrBteConteudo.Length;
            (tbl as ITblArquivo).getClnStrArquivoNome().strValor = this.strNome;

            return true;
        }

        private void atualizarObjSolicitacao()
        {
            if (this.objSolicitacao == null)
            {
                return;
            }

            if (this.objSolicitacao.frmData == null)
            {
                return;
            }

            this.arrBteConteudo = this.objSolicitacao.frmData.getArrBteFrmItemValor("arq_conteudo");
            this.strNome = this.objSolicitacao.frmData.getStrFrmItemValor("arq_nome");
        }

        private DateTime getDttUpload()
        {
            if (this.objSolicitacao == null)
            {
                return DateTime.MinValue;
            }

            if (this.objSolicitacao.frmData == null)
            {
                return DateTime.MinValue;
            }

            return this.objSolicitacao.frmData.getDttFrmItemValor("dtt_upload");
        }

        private string getStrClnWebNome()
        {
            if (this.objSolicitacao == null)
            {
                return null;
            }

            if (this.objSolicitacao.frmData == null)
            {
                return null;
            }

            return this.objSolicitacao.frmData.getStrFrmItemValor("cln_web_nome");
        }

        private string getStrTblWebNome()
        {
            if (this.objSolicitacao == null)
            {
                return null;
            }

            if (this.objSolicitacao.frmData == null)
            {
                return null;
            }

            return this.objSolicitacao.frmData.getStrFrmItemValor("tbl_web_nome");
        }

        private bool carregarArquivoValidar(Solicitacao objSolicitacao, Interlocutor objInterlocutor, TabelaWeb tblWeb, Tabela tbl)
        {
            if (this.objSolicitacao == null)
            {
                return false;
            }

            if (this.objSolicitacao.frmData == null)
            {
                return false;
            }

            if (string.IsNullOrEmpty(this.strNome))
            {
                return false;
            }

            if (this.arrBteConteudo == null)
            {
                return false;
            }

            if (this.arrBteConteudo.Length < 1)
            {
                return false;
            }

            if (!(tbl is ITblArquivo))
            {
                return false;
            }

            if (!tblWeb.strNome.Equals(this.strTblWebNome))
            {
                return false;
            }

            if (tblWeb.dttUpload.Equals(this.dttUpload))
            {
                return false;
            }

            if (string.IsNullOrEmpty(this.strClnWebNome))
            {
                return false;
            }

            if (this.arrBteConteudo == null)
            {
                return false;
            }

            if (this.arrBteConteudo.Length < 1)
            {
                return false;
            }

            return true;
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}