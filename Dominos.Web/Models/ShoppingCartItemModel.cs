using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dominos.Web.Models
{
    public class ShoppingCartItemModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Title { get; set; }

        public int? ImageId { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public string FormattedPrice
        {
            get
            {
                return string.Format("{0:C}", Price);
            }
        }

        public decimal TotalPrice
        {
            get
            {
                return Price * Quantity;
            }
        }


        public string FormattedTotalPrice
        {
            get
            {
                return string.Format("{0:C}", TotalPrice);
            }
        }


    }
}