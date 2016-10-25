using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DigoFramework;

namespace NetZ.Web.Server
{
    public class FormDataItem : Objeto
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private byte[] _arrBteConteudo;
        private byte[] _arrBteValor;

        internal byte[] arrBteConteudo
        {
            get
            {
                return _arrBteConteudo;
            }

            set
            {
                if (_arrBteConteudo == value)
                {
                    return;
                }

                _arrBteConteudo = value;

                this.atualizarArrBteConteudo();
            }
        }

        internal byte[] arrBteValor
        {
            get
            {
                if (_arrBteValor != null)
                {
                    return _arrBteValor;
                }

                _arrBteValor = this.getArrBteValor();

                return _arrBteValor;
            }
        }

        #endregion Atributos

        #region Construtores

        internal FormDataItem(byte[] arrBteConteudo)
        {
            this.arrBteConteudo = arrBteConteudo;
        }

        #endregion Construtores

        #region Métodos

        private void atualizarArrBteConteudo()
        {
            if (this.arrBteConteudo == null)
            {
                return;
            }

            string strConteudo = Encoding.UTF8.GetString(this.arrBteConteudo);

            if (string.IsNullOrEmpty(strConteudo))
            {
                return;
            }

            int intIndexOfStart = strConteudo.IndexOf("\"");

            if (intIndexOfStart < 0)
            {
                return;
            }

            int intIndexOfEnd = strConteudo.IndexOf("\"", intIndexOfStart + 1);

            if (intIndexOfEnd < 0)
            {
                return;
            }

            this.strNome = strConteudo.Substring((intIndexOfStart + 1), (intIndexOfEnd - intIndexOfStart - 1));
        }

        private byte[] getArrBteValor()
        {
            if (this.arrBteConteudo == null)
            {
                return null;
            }

            List<byte> lstBteConteudo = new List<byte>(this.arrBteConteudo);

            byte[] arrBteInicio = Encoding.UTF8.GetBytes(Environment.NewLine + Environment.NewLine);

            while (true)
            {
                byte[] arrBteInicioTemp = lstBteConteudo.GetRange(0, arrBteInicio.Length).ToArray();

                if (!arrBteInicio.SequenceEqual(arrBteInicioTemp))
                {
                    lstBteConteudo.RemoveAt(0);
                    continue;
                }

                lstBteConteudo.RemoveRange(0, arrBteInicio.Length);
                lstBteConteudo.RemoveRange((lstBteConteudo.Count - 2), 2);
                break;
            }

            return lstBteConteudo.ToArray();
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}