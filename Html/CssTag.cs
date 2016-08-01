namespace NetZ.Web.Html
{
    public class CssTag : Tag
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private Atributo _attHref;
        private string _strHref;

        private Atributo attHref
        {
            get
            {
                if (_attHref != null)
                {
                    return _attHref;
                }

                _attHref = this.getAttHref();

                return _attHref;
            }
        }

        private string strHref
        {
            get
            {
                return _strHref;
            }

            set
            {
                if (_strHref == value)
                {
                    return;
                }

                _strHref = value;

                this.atualizarStrHref();
            }
        }

        #endregion Atributos

        #region Construtores

        public CssTag(string strHref) : base("link")
        {
            this.booMostrarClazz = false;
            this.strHref = strHref;
        }

        #endregion Construtores

        #region Métodos

        protected override void inicializar()
        {
            base.inicializar();

            this.booDupla = false;

            this.addAtt("rel", "stylesheet");
            this.addAtt("type", "text/css");
        }

        private void atualizarStrHref()
        {
            if (string.IsNullOrEmpty(this.strHref))
            {
                return;
            }

            this.attHref.strValor = this.strHref;
        }

        private Atributo getAttHref()
        {
            Atributo attResultado = new Atributo("href");

            this.addAtt(attResultado);

            return attResultado;
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}