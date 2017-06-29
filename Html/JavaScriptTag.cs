using NetZ.Web.Html.Componente;
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
            this.booClazz = false;
            this.intOrdem = intOrdem;
            this.src = src;
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

            string srcResultado = "/res/js/_cls_namespace/_cls_nome_ponto_finaljs";

            srcResultado = srcResultado.Replace("_cls_namespace", cls.Namespace.ToLower());
            srcResultado = srcResultado.Replace("_cls_nome", cls.Name);
            srcResultado = srcResultado.Replace(".", "/");

            srcResultado = srcResultado.Replace("/netz/web/", "/web/");

            srcResultado = srcResultado.Replace("_ponto_final", ".");

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

            string strJs = "Web.ConstanteManager.i.addConstante(new Web.Constante('_constante_nome', '_constante_valor'));";

            strJs = strJs.Replace("_constante_nome", strNome);
            strJs = strJs.Replace("_constante_valor", strValor);

            this.addJsCodigo(strJs);
        }

        public void addJsCodigo(string strJsCodigo)
        {
            if (string.IsNullOrEmpty(strJsCodigo))
            {
                return;
            }

            this.lstStrCodigo.Add(strJsCodigo);
        }

        public void addLayoutFixo(Type cls)
        {
            if (cls == null)
            {
                return;
            }

            if (!typeof(ComponenteHtml).IsAssignableFrom(cls))
            {
                return;
            }

            this.addConstante((cls.Name + "_layoutFixo"), (Activator.CreateInstance(cls) as ComponenteHtml).toHtml(this.pag));
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

            string strResultado = "$(document).ready(function(){_js_codigo});";

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

            //this.addAtt("defer");
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}