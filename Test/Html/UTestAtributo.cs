using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetZ.Web.Html;

namespace NetZ.WebTest.Html
{
    [TestClass]
    public class UTestAtributo
    {
        [TestMethod]
        public void getStrFormatadoTest()
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
    }
}