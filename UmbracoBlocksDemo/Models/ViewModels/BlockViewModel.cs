using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UmbracoBlocksDemo.Models.ViewModels
{
    public class BlockViewModel<T>
    {
        public T CurrentBlock { get; set; }

        public BlockViewModel(T currentBlock)
        {
            CurrentBlock = currentBlock;
        }
    }
}