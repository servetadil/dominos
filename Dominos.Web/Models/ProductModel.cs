using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dominos.Web.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public decimal Price { get; set; }

        public string FormattedPrice
        {
            get
            {
                return string.Format("{0:C}", Price);
            }
        }
        public string Url
        {
            get
            {
                return string.Format("/Product/Detail/{0}", Id);
            }
        }

        public int? ImageId { get; set; }

        public string ImageUrl
        {
            get
            {
                if (ImageId.HasValue)
                {
                    return "/Media/View/" + ImageId.Value;
                }
                return "/_assets/img/dummy_p.png";
            }
        }
    }
}