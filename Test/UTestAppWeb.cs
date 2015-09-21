using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetZ.Web;
using NetZ.Web.Server;

namespace NetZ.WebTest
{
    [TestClass]
    public class UTestAppWeb
    {
        private AppWebTest _appWebTest;

        private AppWebTest appWebTest
        {
            get
            {
                if (_appWebTest != null)
                {
                    return _appWebTest;
                }

                _appWebTest = new AppWebTest();

                return _appWebTest;
            }
        }

        [TestMethod]
        public void inicializarTest()
        {
            this.appWebTest.inicializar();

            Thread.Sleep(10);

            while (Server.i.lngClienteRespondido < 1)
            {
                continue;
            }
        }
    }

    internal class AppWebTest : AppWeb
    {
        public AppWebTest() : base("AppWebTest")
        {
        }

        public override Resposta responder(Solicitacao objSolicitacao)
        {
            Resposta objResposta = new Resposta(objSolicitacao);

            //objResposta.dttUltimaModificacao = DateTime.MinValue;
            objResposta.addHtml(Resource.html_test);

            return objResposta;
        }
    }
}