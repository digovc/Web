using System.Collections;
using System.Collections.Generic;

namespace NetZ.Web.Html
{
    public class LstTag<T> : IList<T> where T : Tag
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private List<T> _lst;

        public int Count
        {
            get
            {
                return this.lst.Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        private List<T> lst
        {
            get
            {
                if (_lst != null)
                {
                    return _lst;
                }

                _lst = new List<T>();

                return _lst;
            }
        }

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        public void Add(T tag)
        {
            if (tag == null)
            {
                return;
            }

            if (!string.IsNullOrEmpty(tag.src) && (this.lst.FindIndex(i => tag.src.Equals(i.src)) > -1))
            {
                return;
            }

            this.lst.Add(tag);
        }

        public void Clear()
        {
            this.lst.Clear();
        }

        public bool Contains(T tag)
        {
            return this.lst.Contains(tag);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            this.lst.CopyTo(array, arrayIndex);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.lst.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.lst.GetEnumerator();
        }

        public int IndexOf(T tag)
        {
            return this.lst.IndexOf(tag);
        }

        public void Insert(int index, T tag)
        {
            this.Add(tag);
        }

        public bool Remove(T tag)
        {
            return this.Remove(tag);
        }

        public void RemoveAt(int index)
        {
            this.RemoveAt(index);
        }

        public T this[int index]
        {
            get
            {
                return this.lst[index];
            }

            set
            {
                this.Add(value);
            }
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}