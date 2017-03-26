using Dominos.Web.Models;
using Dominos.Web.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dominos.Web.Controllers
{
    public class ProductController : Controller
    {
        private ProductWebService _productWebService;
        public ProductController()
        {
            _productWebService = new ProductWebService();
        }
        public ActionResult Detail(int id)
        {
            var product = _productWebService.GetProductById(id);
            var model = new ProductModel()
            {
                Id = product.Id,
                ImageId = product.ImageId,
                Price = product.Price,
                Title = product.Title,
            };
            return View(model);
        }
    }
}