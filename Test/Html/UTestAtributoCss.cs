using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetZ.Web.Html;

namespace NetZ.WebTest.Html
{
    [TestClass]
    public class UTestAtributoCss
    {
        [TestMethod]
        public void getStrFormatadoTest()
        {
            AtributoCss attCss = new AtributoCss("c100", "backgroundcolor", "blue");

            Assert.AreEqual(".c100{backgroundcolor:blue}", attCss.getStrFormatado());

            attCss = new AtributoCss("c101", "margin", "10px");

            attCss.addValor("11px");
            attCss.addValor("12px");
            attCss.addValor("13px");

            Assert.AreEqual(".c101{margin:10px 11px 12px 13px}", attCss.getStrFormatado());
        }
    }
}