using NetZ.Persistencia;

namespace NetZ.Web.DataBase.Dominio
{
    // TODO: O namespace do domínio deve ficar na raíz do projeto.
    // TODO: Todas as classes abstratas devem ter o sufixo "base" no nome.
    public abstract class DominioWeb : DominioBase
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private bool _booAtivo = true;

        public bool booAtivo
        {
            get
            {
                return _booAtivo;
            }

            set
            {
                _booAtivo = value;
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