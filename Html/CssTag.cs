namespace NetZ.Web.Html
{
    public class CssTag : Tag
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private Atributo _attHref;
        private string _strHref;

        public string strHref
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

        #endregion Atributos

        #region Construtores

        public CssTag() : base("link")
        {
            this.booMostrarClazz = false;
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