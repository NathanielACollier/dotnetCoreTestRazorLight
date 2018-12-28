using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Reflection;

namespace dotnetCoreTestRazorLight
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // dotnet core embeded resources
            var assembly = typeof(UnitTest1).GetTypeInfo().Assembly;
            //   + https://stackoverflow.com/questions/38762368/embedded-resource-in-net-core-libraries
            string template = new StreamReader(assembly
                                .GetManifestResourceStream($"{assembly.GetName().Name}.testTemplates.1_Simple.cshtml")
                                   ).ReadToEnd();
        }
    }
}
