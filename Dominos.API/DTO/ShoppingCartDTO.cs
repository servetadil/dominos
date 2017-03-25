using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dominos.WCFService.DTO
{
    public class ShoppingCartDTO
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public ProductDTO Product { get; set; }
    }


}