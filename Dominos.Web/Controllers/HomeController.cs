using Dominos.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dominos.Web.Controllers
{
    public class HomeController : Controller
    {


        private ProductWebService _productWebService;
        public HomeController()
        {
            _productWebService = new ProductWebService();
        }
        public ActionResult Index()
        {
            var products = _productWebService.GetProducts();
            var list = new List<ProductModel>();
            foreach (var product in products)
            {
                var p = new ProductModel();
                p.Id = product.Id;
                p.Title = product.Title;
                p.Price = product.Price;
                p.ImageId = product.ImageId;
                list.Add(p);
            }
            return View(list);
        }
    }
}