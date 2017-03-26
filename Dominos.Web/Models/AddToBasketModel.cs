using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dominos.Web.Models
{
    public class AddToBasketModel
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}