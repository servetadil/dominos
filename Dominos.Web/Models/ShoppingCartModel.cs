using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dominos.Web.Models
{
    public class ShoppingCartModel
    {

        public ShoppingCartModel()
        {
            Items = new List<ShoppingCartItemModel>();
        }
        public decimal TotalPrice { get; set; }

        public string FormattedTotalPrice {
            get
            {
                return string.Format("{0:C}", TotalPrice);
            }
        }

        public List<ShoppingCartItemModel> Items { get; set; }
    }
}