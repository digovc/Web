using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NetZ.Web.Server.WebSocket
{
    internal class Frame
    {
        #region Constantes

        public enum EnmTipo
        {
            BINARY,
            CLOSE,
            CONTINUATION,
            NONE,
            PING,
            PONG,
            TEXT,
        }

        #endregion Constantes

        #region Atributos

        private byte[] _arrBteData;
        private byte[] _arrBteDataOut;
        private byte[] _arrBteKey;
        private byte[] _arrBteMensagem;
        private EnmTipo _enmTipo = EnmTipo.NONE;
        private ulong _intTamanho;
        private string _strMensagem;

        internal byte[] arrBteDataOut
        {
            get
            {
                return _arrBteDataOut;
            }

            set
            {
                _arrBteDataOut = value;
            }
        }

        internal EnmTipo enmTipo
        {
            get
            {
                return _enmTipo;
            }

            set
            {
                _enmTipo = value;
            }
        }

        internal string strMensagem
        {
            get
            {
                if (_strMensagem != null)
                {
                    return _strMensagem;
                }

                _strMensagem = this.getStrMensagem();

                return _strMensagem;
            }
        }

        private byte[] arrBteData
        {
            get
            {
                return _arrBteData;
            }

            set
            {
                _arrBteData = value;
            }
        }

        private byte[] arrBteKey
        {
            get
            {
                return _arrBteKey;
            }

            set
            {
                _arrBteKey = value;
            }
        }

        private byte[] arrBteMensagem
        {
            get
            {
                return _arrBteMensagem;
            }

            set
            {
                _arrBteMensagem = value;
            }
        }

        private ulong intTamanho
        {
            get
            {
                return _intTamanho;
            }

            set
            {
                _intTamanho = value;
            }
        }

        #endregion Atributos

        #region Construtores

        internal Frame(byte[] arrBteData)
        {
            this.arrBteData = arrBteData;
        }

        #endregion Construtores

        #region Métodos

        internal void processarDadosIn()
        {
            if (!this.validar())
            {
                return;
            }

            List<byte> lstBteData = new List<byte>(this.arrBteData);

            this.processarDadosEnmTipo(lstBteData);

            this.processarDadosIntTamanho(lstBteData);

            this.processarDadosArrBteKey(lstBteData);

            this.processarDadosArrBteMensagem(lstBteData);
        }

        internal void processarDadosOut()
        {
            if (!this.validar())
            {
                return;
            }

            MemoryStream mmsOut = new MemoryStream();

            mmsOut.WriteByte(0x81);

            if (this.arrBteData.Length < 126)
            {
                mmsOut.WriteByte((byte)this.arrBteData.Length);
            }
            else if (this.arrBteData.Length <= ushort.MaxValue)
            {
                byte[] arrBteTamanho = BitConverter.GetBytes(Convert.ToUInt16(this.arrBteData.Length));

                Array.Reverse(arrBteTamanho);

                mmsOut.WriteByte(126);
                mmsOut.Write(arrBteTamanho, 0, arrBteTamanho.Length);
            }
            else
            {
                byte[] arrBteTamanho = BitConverter.GetBytes(Convert.ToUInt64(this.arrBteData.Length));

                Array.Reverse(arrBteTamanho);

                mmsOut.WriteByte(127);
                mmsOut.Write(arrBteTamanho, 0, arrBteTamanho.Length);
            }

            mmsOut.Write(this.arrBteData, 0, this.arrBteData.Length);

            this.arrBteDataOut = mmsOut.ToArray();
        }

        private string getStrMensagem()
        {
            if (!EnmTipo.TEXT.Equals(this.enmTipo))
            {
                return null;
            }

            if (this.arrBteMensagem == null)
            {
                return null;
            }

            return Encoding.UTF8.GetString(this.arrBteMensagem);
        }

        private void processarDadosArrBteKey(List<byte> lstBteData)
        {
            if (lstBteData.Count < 4)
            {
                return;
            }

            this.arrBteKey = new byte[4];

            for (int i = 0; i < 4; i++)
            {
                this.arrBteKey[i] = lstBteData[0];

                lstBteData.RemoveAt(0);
            }
        }

        private void processarDadosArrBteMensagem(List<byte> lstBteData)
        {
            if (Convert.ToUInt64(lstBteData.Count) < this.intTamanho)
            {
                return;
            }

            this.arrBteMensagem = new byte[this.intTamanho];

            for (ulong i = 0; i < this.intTamanho; i++)
            {
                this.arrBteMensagem[i] = (byte)(lstBteData[0] ^ this.arrBteKey[i % 4]);

                lstBteData.RemoveAt(0);
            }
        }

        private void processarDadosEnmTipo(List<byte> lstBteData)
        {
            this.enmTipo = EnmTipo.NONE;

            if (lstBteData.Count < 1)
            {
                return;
            }

            byte bte = lstBteData[0];

            lstBteData.RemoveAt(0);

            switch (bte)
            {
                case 128:
                    this.enmTipo = EnmTipo.CONTINUATION;
                    return;

                case 129:
                    this.enmTipo = EnmTipo.TEXT;
                    return;

                case 130:
                    this.enmTipo = EnmTipo.BINARY;
                    return;

                case 136:
                    this.enmTipo = EnmTipo.CLOSE;
                    return;

                case 137:
                    this.enmTipo = EnmTipo.PING;
                    return;

                case 138:
                    this.enmTipo = EnmTipo.PONG;
                    return;

                default:
                    return;
            }
        }

        private void processarDadosIntTamanho(List<byte> lstBteData)
        {
            if (lstBteData.Count < 1)
            {
                return;
            }

            byte bte = lstBteData[0];

            lstBteData.RemoveAt(0);

            if ((bte - 128) < 126)
            {
                this.intTamanho = Convert.ToUInt32(bte - 128);
                return;
            }

            if (126.Equals((bte - 128)))
            {
                this.intTamanho = BitConverter.ToUInt16(new byte[] { lstBteData[1], lstBteData[0] }, 0);
                lstBteData.RemoveRange(0, 2);
                return;
            }

            if (127.Equals((bte - 128)))
            {
                this.intTamanho = BitConverter.ToUInt64(new byte[] { lstBteData[7], lstBteData[6], lstBteData[5], lstBteData[4], lstBteData[3], lstBteData[2], lstBteData[1], lstBteData[0] }, 0);
                lstBteData.RemoveRange(0, 2);
                return;
            }
        }

        private bool validar()
        {
            if (this.arrBteData == null)
            {
                return false;
            }

            return true;
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}