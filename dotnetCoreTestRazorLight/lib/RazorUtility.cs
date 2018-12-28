using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RazorLight;

namespace dotnetCoreTestRazorLight.lib
{
    public static class RazorUtility
    {
        public static async Task<string> renderTemplate(string templateText, string templateName, object model)
        {
            var engine = new RazorLightEngineBuilder()
              .UseMemoryCachingProvider()
              .Build();

            // see if we've already built the template
            var cacheResult = engine.TemplateCache.RetrieveTemplate(templateName);
            if(cacheResult.Success)
            {
                return await engine.RenderTemplateAsync(cacheResult.Template.TemplatePageFactory(), model);
            }else
            {
                return await engine.CompileRenderAsync(key: templateName,content: templateText,model: model);
            }
        }
    }
}
