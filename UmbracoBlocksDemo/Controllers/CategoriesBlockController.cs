using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web.PublishedContentModels;
using Umbraco.Web;
using Umbraco.Web.Mvc;
using UmbracoBlocksDemo.Models.ViewModels;

namespace UmbracoBlocksDemo.Controllers
{
    public class CategoriesBlockController : SurfaceController
    {
        [ChildActionOnly]
        public ActionResult Block(PublishedContentModel model)
        {
            var umbracoHelper = new UmbracoHelper(UmbracoContext.Current);
            var home = new HomePage(umbracoHelper.TypedContentAtRoot()
                .FirstOrDefault(x => x.ContentType.Alias == HomePage.GetModelContentType().Alias));

            var viewModel = new CategoriesBlockViewModel(new CategoriesBlock(model));
            viewModel.Categories = home.Categories;

            return PartialView("~/Views/Blocks/_CategoriesBlock.cshtml", viewModel);
        }
    }
}