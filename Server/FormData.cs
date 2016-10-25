using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using DigoFramework;

namespace NetZ.Web.Server
{
    public class FormData : Objeto
    {
        #region Constantes

        private const int INT_BOUNDARY_LENGTH = 40;

        #endregion Constantes

        #region Atributos

        private byte[] _arrBteConteudo;
        private List<FormDataItem> _lstFrmItem;

        private byte[] arrBteConteudo
        {
            get
            {
                return _arrBteConteudo;
            }

            set
            {
                _arrBteConteudo = value;
            }
        }

        private List<FormDataItem> lstFrmItem
        {
            get
            {
                if (_lstFrmItem != null)
                {
                    return _lstFrmItem;
                }

                _lstFrmItem = this.getLstFrmItem();

                return _lstFrmItem;
            }
        }

        #endregion Atributos

        #region Construtores

        internal FormData(byte[] arrBteConteudo)
        {
            this.arrBteConteudo = arrBteConteudo;
        }

        #endregion Construtores

        #region Métodos

        internal byte[] getArrBteFrmItemValor(string strFrmItemNome)
        {
            if (string.IsNullOrEmpty(strFrmItemNome))
            {
                return null;
            }

            if (this.lstFrmItem == null)
            {
                return null;
            }

            foreach (FormDataItem frmItem in this.lstFrmItem)
            {
                if (frmItem == null)
                {
                    continue;
                }

                if (string.IsNullOrEmpty(frmItem.strNome))
                {
                    continue;
                }

                if (!strFrmItemNome.ToLower().Equals(frmItem.strNome.ToLower()))
                {
                    continue;
                }

                return frmItem.arrBteValor;
            }

            return null;
        }

        internal DateTime getDttFrmItemValor(string strFrmItemNome)
        {
            string strFrmItemValor = this.getStrFrmItemValor(strFrmItemNome);

            if (string.IsNullOrEmpty(strFrmItemValor))
            {
                return DateTime.MinValue;
            }

            if (strFrmItemValor.Length < 24)
            {
                return DateTime.MinValue;
            }

            DateTime dttResultado = DateTime.ParseExact(strFrmItemValor.Substring(0, 24), "ddd MMM d yyyy HH:mm:ss", CultureInfo.InvariantCulture);

            return dttResultado;
        }

        internal string getStrFrmItemValor(string strFrmItemNome)
        {
            byte[] arrBteValor = this.getArrBteFrmItemValor(strFrmItemNome);

            if (arrBteValor == null)
            {
                return null;
            }

            return Encoding.UTF8.GetString(arrBteValor);
        }

        private List<FormDataItem> getLstFrmItem()
        {
            if (this.arrBteConteudo == null)
            {
                return null;
            }

            if (this.arrBteConteudo.Length < 1)
            {
                return null;
            }

            List<byte> lstBteConteudo = new List<byte>(this.arrBteConteudo);

            byte[] arrBteBoundary = lstBteConteudo.GetRange(0, INT_BOUNDARY_LENGTH).ToArray();

            lstBteConteudo.RemoveRange(0, INT_BOUNDARY_LENGTH);

            List<FormDataItem> lstFrmItemResultado = new List<FormDataItem>();

            while (true)
            {
                int intIndexOf = Utils.indexOf(lstBteConteudo.ToArray(), arrBteBoundary);

                if (intIndexOf < 0)
                {
                    if (lstBteConteudo.Count > 0)
                    {
                        lstFrmItemResultado.Add(new FormDataItem(lstBteConteudo.ToArray()));
                    }

                    break;
                }

                lstFrmItemResultado.Add(new FormDataItem(lstBteConteudo.Take(intIndexOf).ToArray()));

                if (lstBteConteudo.Count <= (intIndexOf + INT_BOUNDARY_LENGTH))
                {
                    break;
                }

                lstBteConteudo.RemoveRange(0, (intIndexOf + INT_BOUNDARY_LENGTH));
            }

            return lstFrmItemResultado;
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}