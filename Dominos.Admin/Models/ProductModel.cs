using Dominos.Core.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dominos.Admin.Models
{
    public class ProductModel : AdminViewModel
    {
        public string Title { get; set; }
        public decimal Price { get; set; }
        public int? ImageId { get; set; }
    }
}