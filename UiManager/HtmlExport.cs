using System;

namespace Web.UiManager
{
    /// <summary>
    /// Indica se a página será exportada para um arquivo contendo o HTML estático da classe.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class HtmlExport : Attribute
    {
        public HtmlExport()
        {
        }
    }
}