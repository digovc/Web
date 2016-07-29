namespace NetZ.Web.Html
{
    public class AtributoCss : Atributo
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private string _strClass;

        internal string strClass
        {
            get
            {
                return _strClass;
            }

            set
            {
                _strClass = value;
            }
        }

        #endregion Atributos

        #region Construtores

        public AtributoCss(string strClass, string strNome, string strValor = null) : base(strNome, strValor)
        {
            this.strClass = strClass;
        }

        #endregion Construtores

        #region Métodos

        public override string getStrFormatado()
        {
            if (string.IsNullOrEmpty(this.strClass))
            {
                return null;
            }

            if (string.IsNullOrEmpty(this.strNome))
            {
                return null;
            }

            string strResultado = "._class_nome{_att_nome:_att_valor}";

            strResultado = strResultado.Replace("_class_nome", this.strClass);
            strResultado = strResultado.Replace("_att_nome", this.strNome);
            strResultado = strResultado.Replace("_att_valor", string.Join(this.strSeparador, this.lstStrValor.ToArray()));

            return strResultado;
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}