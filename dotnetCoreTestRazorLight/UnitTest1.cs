using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace dotnetCoreTestRazorLight
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task TestMethod1()
        {
            string template = dotnetStandardRazorLightUtility.EmbededResourceUtility
                                .ReadAsString(typeof(UnitTest1), "testTemplates.1_Simple.cshtml");

            string result = await dotnetStandardRazorLightUtility.RazorUtility.renderTemplate(template, "simple1", new Models.Simple1
            {
                Prop1="Hello World!",
                Prop2 = "United States"
            });
        }
    }
}
