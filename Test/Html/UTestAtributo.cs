using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetZ.Web.Html;

namespace NetZ.WebTest.Html
{
    [TestClass]
    public class UTestAtributo
    {
        [TestMethod]
        public void addValorTest()
        {
            Atributo att = new Atributo("test_att");

            att.addValor(10);
            att.addValor(15);
            att.addValor("texto");

            Assert.AreEqual("test_att=\"10 15 texto\"", att.getStrFormatado());
        }

        [TestMethod]
        public void getStrFormatado2Test()
        {
            Atributo att = new Atributo("atributo_teste", "atributo_valor");

            att.addValor("atributo_valor_1");
            att.addValor("atributo_valor_2");

            Assert.AreEqual("atributo_teste=\"atributo_valor atributo_valor_1 atributo_valor_2\"", att.getStrFormatado());

            att = new Atributo("atributo_sem_valor");

            Assert.AreEqual("atributo_sem_valor", att.getStrFormatado());

            att = new Atributo("atributo_varios_valores");

            att.strSeparador = ";";

            att.addValor(150.50m);
            att.addValor(10);

            Assert.AreEqual("atributo_varios_valores=\"150.50;10\"", att.getStrFormatado());
        }

        [TestMethod]
        public void getStrFormatadoTest()
        {
            Atributo att = new Atributo("test_att", "valor");
            Assert.AreEqual("test_att=\"valor\"", att.getStrFormatado());

            att = new Atributo("test_att");
            Assert.AreEqual("test_att", att.getStrFormatado());
        }

        [TestMethod]
        public void strSeparadorTest()
        {
            Atributo att = new Atributo("test_att", "valor");

            att.addValor("valor2");

            att.strSeparador = ";";
            Assert.AreEqual("test_att=\"valor;valor2\"", att.getStrFormatado());
        }

        [TestMethod]
        public void strValorTest()
        {
            Atributo att = new Atributo("test_att");

            att.strValor = "valor fixo";

            Assert.AreEqual("test_att=\"valor fixo\"", att.getStrFormatado());
        }
    }
}