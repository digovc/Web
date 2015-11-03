using System;
using System.Threading;

namespace NetZ.Web.Server
{
    /// <summary>
    /// Classe base para todos os serviços assíncronos que precisam funcionar sem atrapalhar os
    /// outros, como por exemplo a classe <see cref="Server"/> que se mantém ativa aguardando
    /// chamadas de entrada dos clientes, ou a classe <see cref="Cliente"/> que é um processo que
    /// processa a solicitação de cada um cliente que solicitar algum recurso deste servidor.
    /// </summary>
    public abstract class Servico
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private bool _booParar;
        private Thread _thr;

        protected bool booParar
        {
            get
            {
                return _booParar;
            }

            set
            {
                _booParar = value;
            }
        }

        private Thread thr
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_thr != null)
                    {
                        return _thr;
                    }

                    _thr = new Thread(this.inicializarServio);

                    _thr.IsBackground = true;
                    //_thr.Priority = ThreadPriority.Normal;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _thr;
            }

            set
            {
                _thr = value;
            }
        }

        #endregion Atributos

        #region Construtores

        protected Servico(string strNome)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.thr.Name = strNome;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion Ações
        }

        #endregion Construtores

        #region Métodos

        /// <summary>
        /// Inicia o serciço, neste momento uma thread em segundo plano executa a lógica contida
        /// dentro do método <see cref="servico"/>.
        /// </summary>
        public void iniciar()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.inicializar();
                this.thr.Start();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion Ações
        }

        /// <summary>
        /// Marca o serviço para parar na próxima vez que executar a lógica dentro de seu loop.
        /// Também envia um sinal para a thread que está rodando em segundo plano para que seja abortada.
        /// </summary>
        public void parar()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.booParar = true;

                if (this.thr.IsAlive)
                {
                    this.thr.Abort();
                }

                this.thr = null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion Ações
        }

        /// <summary>
        /// Método que é chamado quando o método <see cref="iniciar"/> é chamado e pode ser
        /// sobescrito para inicializar algum valor antes que a thread seja ativa e o processo em
        /// segundo plano seja inicializado efetivamente.
        /// </summary>
        protected virtual void inicializar()
        {
        }

        /// <summary>
        /// Método que deve ser implementado pela classe que herda desta. A lógica que deverá ser
        /// executada deverá ser chamada por este método. Caso esta lógica estaja dentro de um loop,
        /// a propriedade <see cref="booParar"/> deve ser verificada a cada laço, para garantir que
        /// este serviço seja interrompido assim que solicitado.
        /// </summary>
        protected abstract void servico();

        private void inicializarServio(object obj)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.servico();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion Ações
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}