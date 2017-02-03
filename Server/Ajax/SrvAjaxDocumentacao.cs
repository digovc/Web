using DigoFramework.Json;
using NetZ.Web.DataBase.Dominio.Documentacao;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;

namespace NetZ.Web.Server.Ajax
{
    public sealed class SrvAjaxDocumentacao : SrvAjaxBase
    {
        #region Constantes

        public const string DIR_MARKDOWN = "res\\markdown";

        private const string DIR_ARQUIVO_EMAIL_REGISTRO_DOCUMENTACAO = (AppWebBase.DIR_JSON_CONFIG + "documentacao_email_registro.json");

        private const string STR_METODO_EMAIL_DESINSCREVER = "STR_METODO_EMAIL_DESINSCREVER";
        private const string STR_METODO_EMAIL_REGISTRAR = "STR_METODO_EMAIL_REGISTRAR";

        private const string URL_MARKDOWN_FOLDER = "/url-md";

        #endregion Constantes

        #region Atributos

        private List<EmailRegistroDominio> _lstObjEmailRegistro;
        private List<MarkdownDominio> _lstObjMd;

        public List<EmailRegistroDominio> lstObjEmailRegistro
        {
            get
            {
                if (_lstObjEmailRegistro != null)
                {
                    return _lstObjEmailRegistro;
                }

                _lstObjEmailRegistro = this.getLstObjEmailRegistro();

                return _lstObjEmailRegistro;
            }
        }

        private List<MarkdownDominio> lstObjMd
        {
            get
            {
                if (_lstObjMd != null)
                {
                    return _lstObjMd;
                }

                _lstObjMd = this.getLstObjMd();

                return _lstObjMd;
            }
        }

        #endregion Atributos

        #region Construtores

        public SrvAjaxDocumentacao() : base("Servidor AJAX (Documentação)")
        {
        }

        #endregion Construtores

        #region Métodos

        protected override int getIntPorta()
        {
            return ConfigWebBase.i.intSrvAjaxDocumentacao;
        }

        protected override void inicializar()
        {
            base.inicializar();

            if (AppWebBase.i.objSmtpClient == null)
            {
                this.booParar = true;
                return;
            }

            if (this.lstObjMd == null || (this.lstObjMd.Count < 1))
            {
                this.booParar = true;
                return;
            }

            this.inicializarAlertar();
        }

        protected override bool responder(Solicitacao objSolicitacao, Interlocutor objInterlocutor)
        {
            if (base.responder(objSolicitacao, objInterlocutor))
            {
                return true;
            }

            if (objInterlocutor == null)
            {
                return false;
            }

            switch (objInterlocutor.strMetodo)
            {
                case STR_METODO_EMAIL_DESINSCREVER:
                    this.cancelarEmail(objInterlocutor);
                    return true;

                case STR_METODO_EMAIL_REGISTRAR:
                    this.registrarEmail(objInterlocutor);
                    return true;
            }

            return false;
        }

        private void alertar(EmailRegistroDominio objEmailRegistro, List<MarkdownDominio> lstMdAlterado)
        {
            if (lstMdAlterado == null)
            {
                return;
            }

            var stbBodyItem = new StringBuilder();

            foreach (var objMdAlterado in lstMdAlterado)
            {
                this.alertar(objEmailRegistro, objMdAlterado, stbBodyItem);
            }

            var stbBody = new StringBuilder(Properties.Resource.documentacao_email);

            stbBody.Replace("_doc_nome", objEmailRegistro.strDocumentacaoTitulo);
            stbBody.Replace("_url_documentacao", objEmailRegistro.urlDocumentacao);
            stbBody.Replace("_email_conteudo", stbBodyItem.ToString());
            stbBody.Replace("_link_cancelar", string.Format("{0}?acao=desinscrever&email={1}", objEmailRegistro.urlDocumentacao, objEmailRegistro.strEmail));

            if (lstMdAlterado.Count < 2)
            {
                stbBody.Replace("_email_descricao", string.Format("O seguinte artigo da documentação \"{0}\" foi atualizado:", objEmailRegistro.strDocumentacaoTitulo));
            }
            else
            {
                stbBody.Replace("_email_descricao", string.Format("Os seguintes artigos da documentação \"{0}\" foram atualizados:", objEmailRegistro.strDocumentacaoTitulo));
            }

            var objEmail = new MailMessage();

            objEmail.Body = stbBody.ToString();
            objEmail.From = new MailAddress(AppWebBase.i.strEmail, AppWebBase.i.strNome);
            objEmail.IsBodyHtml = true;
            objEmail.Subject = string.Format("Atualização da documentação \"{0}\"", objEmailRegistro.strDocumentacaoTitulo);
            objEmail.To.Add(new MailAddress(objEmailRegistro.strEmail));

            AppWebBase.i.objSmtpClient.Send(objEmail);
        }

        private void alertar(EmailRegistroDominio objEmailRegistro, MarkdownDominio objMdAlterado, StringBuilder stbBodyItem)
        {
            var strBodyItem = Properties.Resource.documentacao_email_item;

            strBodyItem = strBodyItem.Replace("_artigo_link", (objEmailRegistro.urlDocumentacao + URL_MARKDOWN_FOLDER + "/" + objMdAlterado.dir.Replace("\\", "/")));
            strBodyItem = strBodyItem.Replace("_artigo_nome", objMdAlterado.strNome);

            stbBodyItem.Append(strBodyItem);
        }

        private void cancelarEmail(Interlocutor objInterlocutor)
        {
            var objEmailRegistro = objInterlocutor.getObjJson<EmailRegistroDominio>();

            if (objEmailRegistro == null)
            {
                return;
            }

            if (string.IsNullOrEmpty(objEmailRegistro.strEmail))
            {
                return;
            }

            if (string.IsNullOrEmpty(objEmailRegistro.dirDocumentacao))
            {
                return;
            }

            if (this.lstObjEmailRegistro == null)
            {
                return;
            }

            if (this.lstObjEmailRegistro.Count < 1)
            {
                return;
            }

            foreach (var objEmailRegistroLocal in this.lstObjEmailRegistro)
            {
                if (this.cancelarEmail(objInterlocutor, objEmailRegistro, objEmailRegistroLocal))
                {
                    return;
                }
            }
        }

        private bool cancelarEmail(Interlocutor objInterlocutor, EmailRegistroDominio objEmailRegistro, EmailRegistroDominio objEmailRegistroLocal)
        {
            if (objEmailRegistroLocal == null)
            {
                return false;
            }

            if (string.IsNullOrEmpty(objEmailRegistroLocal.strEmail))
            {
                return false;
            }

            if (string.IsNullOrEmpty(objEmailRegistroLocal.dirDocumentacao))
            {
                return false;
            }

            if (!objEmailRegistro.strEmail.ToLower().Equals(objEmailRegistroLocal.strEmail.ToLower()))
            {
                return false;
            }

            if (!objEmailRegistro.dirDocumentacao.ToLower().Equals(objEmailRegistroLocal.dirDocumentacao.ToLower()))
            {
                return false;
            }

            this.lstObjEmailRegistro.Remove(objEmailRegistroLocal);

            objInterlocutor.objData = string.Format("O email \"{0}\" não irá mais receber atualizações da documentação \"{1}\".", objEmailRegistroLocal.strEmail, objEmailRegistroLocal.strDocumentacaoTitulo);

            this.salvarArquivo();

            return true;
        }

        private List<EmailRegistroDominio> getLstObjEmailRegistro()
        {
            Directory.CreateDirectory(Path.GetDirectoryName(DIR_ARQUIVO_EMAIL_REGISTRO_DOCUMENTACAO));

            if (!File.Exists(DIR_ARQUIVO_EMAIL_REGISTRO_DOCUMENTACAO))
            {
                File.Create(DIR_ARQUIVO_EMAIL_REGISTRO_DOCUMENTACAO).Close();
            }

            if (string.IsNullOrEmpty(File.ReadAllText(DIR_ARQUIVO_EMAIL_REGISTRO_DOCUMENTACAO)))
            {
                return new List<EmailRegistroDominio>();
            }

            return Json.i.fromJson<List<EmailRegistroDominio>>(File.ReadAllText(DIR_ARQUIVO_EMAIL_REGISTRO_DOCUMENTACAO));
        }

        private List<MarkdownDominio> getLstObjMd()
        {
            if (!Directory.Exists(DIR_MARKDOWN))
            {
                return null;
            }

            var lstObjMdMd5Resultado = new List<MarkdownDominio>();

            this.getLstObjMdMd5(lstObjMdMd5Resultado, DIR_MARKDOWN);

            return lstObjMdMd5Resultado;
        }

        private void getLstObjMdMd5(List<MarkdownDominio> lstObjMdMd5, string dir)
        {
            foreach (string dirFile in Directory.GetFiles(dir))
            {
                this.getLstObjMdMd5Arquivo(lstObjMdMd5, dirFile);
            }

            foreach (string dirFolder in Directory.GetDirectories(dir))
            {
                this.getLstObjMdMd5(lstObjMdMd5, dirFolder);
            }
        }

        private void getLstObjMdMd5Arquivo(List<MarkdownDominio> lstObjMd, string dirFile)
        {
            if (string.IsNullOrEmpty(dirFile))
            {
                return;
            }

            if (!".md".Equals(Path.GetExtension(dirFile)))
            {
                return;
            }

            var objMarkdown = new MarkdownDominio();

            objMarkdown.dir = dirFile;
            objMarkdown.dttAlteracao = File.GetLastWriteTime(dirFile);
            objMarkdown.dttCadastro = File.GetCreationTime(dirFile);

            this.getLstObjMdMd5ArquivoTitulo(objMarkdown);

            lstObjMd.Add(objMarkdown);
        }

        private void getLstObjMdMd5ArquivoTitulo(MarkdownDominio objMarkdown)
        {
            var strTitulo = File.ReadAllText(objMarkdown.dir);

            if (string.IsNullOrEmpty(strTitulo))
            {
                return;
            }

            strTitulo = strTitulo.Split(new[] { '\r', '\n' }).FirstOrDefault();

            if (string.IsNullOrEmpty(strTitulo))
            {
                return;
            }

            objMarkdown.strNome = strTitulo.Substring(2);
        }

        private void inicializarAlertar()
        {
            if (this.lstObjEmailRegistro == null)
            {
                return;
            }

            foreach (var objEmailRegistro in this.lstObjEmailRegistro)
            {
                this.inicializarAlertar(objEmailRegistro);
            }
        }

        private void inicializarAlertar(EmailRegistroDominio objEmailRegistro)
        {
            List<MarkdownDominio> lstMdAlterado = new List<MarkdownDominio>();

            foreach (var objMd in this.lstObjMd)
            {
                this.inicializarAlertar(objEmailRegistro, objMd, lstMdAlterado);
            }

            if (lstMdAlterado.Count < 1)
            {
                return;
            }

            this.alertar(objEmailRegistro, lstMdAlterado);
        }

        private void inicializarAlertar(EmailRegistroDominio objEmailRegistro, MarkdownDominio objMd, List<MarkdownDominio> lstMdAlterado)
        {
            if (objEmailRegistro == null)
            {
                return;
            }

            if (objMd == null)
            {
                return;
            }

            if (string.IsNullOrEmpty(objMd.dir))
            {
                return;
            }

            if (!objMd.dir.StartsWith(objEmailRegistro.dirDocumentacao))
            {
                return;
            }

            if (objMd.dttAlteracao <= objEmailRegistro.dttAtualizacao)
            {
                return;
            }

            lstMdAlterado.Add(objMd);
        }

        private void registrarEmail(Interlocutor objInterlocutor)
        {
            var objEmailRegistro = objInterlocutor.getObjJson<EmailRegistroDominio>();

            if (objEmailRegistro == null)
            {
                return;
            }

            if (string.IsNullOrEmpty(objEmailRegistro.strEmail))
            {
                return;
            }

            if (!objEmailRegistro.strEmail.Contains("@"))
            {
                return;
            }

            foreach (var objEmailRegistroLocal in this.lstObjEmailRegistro)
            {
                if (!this.registrarEmailValidar(objInterlocutor, objEmailRegistro, objEmailRegistroLocal))
                {
                    return;
                }
            }

            objEmailRegistro.dttAtualizacao = DateTime.Now;
            objEmailRegistro.dttCadastro = DateTime.Now;

            this.lstObjEmailRegistro.Add(objEmailRegistro);

            this.salvarArquivo();

            objInterlocutor.objData = string.Format("Email \"{0}\" cadastrado com sucesso!", objEmailRegistro.strEmail);
        }

        private bool registrarEmailValidar(Interlocutor objInterlocutor, EmailRegistroDominio objEmailRegistro, EmailRegistroDominio objEmailRegistroLocal)
        {
            if (!objEmailRegistro.strEmail.ToLower().Equals(objEmailRegistroLocal.strEmail.ToLower()))
            {
                return true;
            }

            if (!objEmailRegistro.dirDocumentacao.ToLower().Equals(objEmailRegistroLocal.dirDocumentacao.ToLower()))
            {
                return true;
            }

            objInterlocutor.strErro = string.Format("O email \"{0}\" já está cadastrado para receber as atualizações da documentação \"{1}\".", objEmailRegistro.strEmail, objEmailRegistro.strDocumentacaoTitulo);

            return false;
        }

        private void salvarArquivo()
        {
            if (this.lstObjEmailRegistro == null)
            {
                return;
            }

            if (this.lstObjEmailRegistro.Count < 1)
            {
                return;
            }

            File.Delete(DIR_ARQUIVO_EMAIL_REGISTRO_DOCUMENTACAO);

            File.WriteAllText(DIR_ARQUIVO_EMAIL_REGISTRO_DOCUMENTACAO, Json.i.toJson(this.lstObjEmailRegistro));
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}