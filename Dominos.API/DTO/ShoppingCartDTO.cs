using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dominos.WCFService.DTO
{
    public class ShoppingCartDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public string ProductTitle { get; set; }
        public int? ProductImageId { get; set; }
        public decimal ProductPrice { get; set; }


    }


}