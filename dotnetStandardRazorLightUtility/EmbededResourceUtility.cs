using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace dotnetStandardRazorLightUtility
{
    public static class EmbededResourceUtility
    {

        public static string ReadAsString(Type t, string relativeFromAssemblyDottedPath)
        {
            relativeFromAssemblyDottedPath = relativeFromAssemblyDottedPath.Trim();
            if( relativeFromAssemblyDottedPath[0] == '.')
            {
                relativeFromAssemblyDottedPath = relativeFromAssemblyDottedPath.Substring(1); // get rid of the . so we can add it later
            }

            // dotnet core embeded resources
            var assembly = t.GetTypeInfo().Assembly;
            //   + https://stackoverflow.com/questions/38762368/embedded-resource-in-net-core-libraries
            string template = new StreamReader(assembly
                                .GetManifestResourceStream($"{assembly.GetName().Name}.{relativeFromAssemblyDottedPath}")
                                   ).ReadToEnd();

            return template;
        }
    }
}
