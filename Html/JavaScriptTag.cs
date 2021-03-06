﻿using NetZ.Web.Html.Componente;
using NetZ.Web.Html.Pagina;
using System;
using System.Collections.Generic;

namespace NetZ.Web.Html
{
    public class JavaScriptTag : Tag
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private int _intOrdem;
        private List<Type> _lstClsLayoutFixo;
        private List<string> _lstStrCodigo;

        /// <summary>
        /// Todas as tags de JavaScript são executados pelo browser na ordem que estão dispostas na
        /// página. Utilize esta propriedade para indicar quais dessas tags serão executadas antes
        /// das outras.
        /// <para>Utilize as seguintes faixas: 100 a 150 NetZ.Web.TypeScript.</para>
        /// <para>Utilize as seguintes faixas: 200 a 250 Projetos especializados.</para>
        /// </summary>
        public int intOrdem
        {
            get
            {
                return _intOrdem;
            }

            set
            {
                _intOrdem = value;
            }
        }

        private List<Type> lstClsLayoutFixo
        {
            get
            {
                if (_lstClsLayoutFixo != null)
                {
                    return _lstClsLayoutFixo;
                }

                _lstClsLayoutFixo = new List<Type>();

                return _lstClsLayoutFixo;
            }
        }

        private List<string> lstStrCodigo
        {
            get
            {
                if (_lstStrCodigo != null)
                {
                    return _lstStrCodigo;
                }

                _lstStrCodigo = new List<string>();

                return _lstStrCodigo;
            }
        }

        #endregion Atributos

        #region Construtores

        public JavaScriptTag(string src = null, int intOrdem = 200) : base("script")
        {
            this.intOrdem = intOrdem;
            this.src = this.getSrc(src);
        }

        public JavaScriptTag(Type cls, int intOrdem = 200) : this(getSrc(cls), intOrdem)
        {
        }

        #endregion Construtores

        #region Métodos

        public static string getSrc(Type cls)
        {
            if (cls == null)
            {
                return null;
            }

            var srcResultado = string.Format("/res/js/{0}/{1}.js?v={2}", cls.Namespace.ToLower().Replace(".", "/"), cls.Name, AppWebBase.i.strVersao);

            if (AppWebBase.i.booDesenvolvimento)
            {
                srcResultado = string.Format("/res/js/{0}/{1}.js", cls.Namespace.ToLower().Replace(".", "/"), cls.Name);
            }

            srcResultado = srcResultado.Replace("/netz/web/", "/web/");

            return srcResultado;
        }

        public void addConstante(string strNome, decimal decValor)
        {
            this.addConstante(strNome, decValor.ToString());
        }

        public void addConstante(string strNome, bool booValor)
        {
            this.addConstante(strNome, booValor ? 1 : 0);
        }

        public void addConstante(string strNome, int intValor)
        {
            this.addConstante(strNome, intValor.ToString());
        }

        public void addConstante(string strNome, string strValor)
        {
            if (string.IsNullOrEmpty(strNome))
            {
                return;
            }

            if (string.IsNullOrEmpty(strValor))
            {
                return;
            }

            this.addJsCodigo("Web.ConstanteManager.i.addConstante(new Web.Constante('{0}', '{1}'));", strNome, strValor);
        }

        public void addJsCodigo(string strJsCodigo, params string[] arrStrArg)
        {
            if (string.IsNullOrEmpty(strJsCodigo))
            {
                return;
            }

            if (arrStrArg != null)
            {
                strJsCodigo = string.Format(strJsCodigo, arrStrArg);
            }

            this.lstStrCodigo.Add(strJsCodigo);
        }

        public void addLayoutFixo(Type cls)
        {
            if (cls == null)
            {
                return;
            }

            if (!typeof(ComponenteHtmlBase).IsAssignableFrom(cls))
            {
                return;
            }

            if (this.lstClsLayoutFixo.Contains(cls))
            {
                return;
            }

            this.lstClsLayoutFixo.Add(cls);

            var tagLayoutFixo = (Activator.CreateInstance(cls) as ComponenteHtmlBase);

            tagLayoutFixo.booLayoutFixo = true;

            this.addConstante((cls.Name + "_layoutFixo"), tagLayoutFixo.toHtml(this.pag));
        }

        public override string toHtml(PaginaHtmlBase pag)
        {
            if (this.lstStrCodigo.Count < 1 && string.IsNullOrEmpty(this.src))
            {
                return null;
            }

            if (this.lstStrCodigo.Count < 1)
            {
                return base.toHtml(pag);
            }

            var strResultado = "$(document).ready(function(){_js_codigo});";

            strResultado = strResultado.Replace("_js_codigo", string.Join(string.Empty, this.lstStrCodigo.ToArray()));

            this.strConteudo = strResultado;

            return base.toHtml(pag);
        }

        /// <summary>
        /// Este método precisa estar vazio para que não ocorra um loop infinito e porque este tag
        /// não necessita de adicionar nenhuma outra tag JavaScript para a página.
        /// </summary>
        protected override void addJs(LstTag<JavaScriptTag> lstJs)
        {
            // Não fazer nada.
        }

        protected override void inicializar()
        {
            base.inicializar();

            this.addAtt("type", "text/javascript");
        }

        private string getSrc(string src)
        {
            if (string.IsNullOrWhiteSpace(src))
            {
                return null;
            }

            if (AppWebBase.i.booDesenvolvimento)
            {
                return src;
            }

            if (src.Contains("?"))
            {
                return src;
            }

            return string.Format("{0}?v={1}", src, AppWebBase.i.strVersao);
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}