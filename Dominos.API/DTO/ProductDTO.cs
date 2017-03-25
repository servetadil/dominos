using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dominos.WCFService.DTO
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }

        public int? ImageId { get; set; }

        public string ImageUrl { get; set; }
    }
}