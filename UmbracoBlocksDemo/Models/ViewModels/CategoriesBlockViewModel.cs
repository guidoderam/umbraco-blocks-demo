using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Web.PublishedContentModels;

namespace UmbracoBlocksDemo.Models.ViewModels
{
    public class CategoriesBlockViewModel : BlockViewModel<CategoriesBlock>
    {
        public IEnumerable<string> Categories { get; set; }

        public CategoriesBlockViewModel(CategoriesBlock currentBlock) : base(currentBlock)
        {
        }
    }
}