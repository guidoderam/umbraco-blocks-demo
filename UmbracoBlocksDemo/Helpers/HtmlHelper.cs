using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using Umbraco.Core;
using Umbraco.Core.Models;

namespace UmbracoBlocksDemo.Helpers
{
    public static class HtmlHelperExtensions
    {
        public static bool ViewExists(this HtmlHelper html, string viewName)
        {
            var controllerContext = html.ViewContext.Controller.ControllerContext;
            var view = ViewEngines.Engines.FindView(controllerContext, viewName, null);

            return view.View != null;
        }

        public static void RenderBlock(this HtmlHelper html, IPublishedContent block)
        {
            var blockName = block.DocumentTypeAlias.ToCleanString(Umbraco.Core.Strings.CleanStringType.Alias);
            var viewName = $"Blocks/{blockName}";

            var viewExists = html.ViewExists(viewName);

            if (viewExists)
            {
                html.RenderPartial(viewName, block);
                return;
            }

            try
            {
                html.RenderAction("Block", blockName, new { model = block });
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e);
            }
        }

        public static void RenderBlocks(this HtmlHelper html, IEnumerable<IPublishedContent> blocks)
        {
            var blocksList = blocks as IList<IPublishedContent> ?? blocks.ToList();

            if (!blocksList.Any())
            {
                return;
            }

            foreach (var block in blocksList)
            {
                html.RenderBlock(block);
            }
        }
    }
}