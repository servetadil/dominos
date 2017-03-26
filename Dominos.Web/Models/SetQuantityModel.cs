using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dominos.Web.Models
{
    public class SetQuantityModel
    {
        public int ShoppingCartItemId { get; set; }
        public int Quantity { get; set; }
    }
}