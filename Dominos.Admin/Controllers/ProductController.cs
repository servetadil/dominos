using Dominos.Admin.Models;
using Dominos.Core.Domain;
using Dominos.Infrastructure.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dominos.Admin.Controllers
{
    public class ProductController : Controller
    {


        private IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }



        public ActionResult Index()
        {
            var productList = _productService.GetProducts()
                .Select(s => new ProductModel()
                {
                    Id = s.Id,
                    Title = s.Title,
                    ImageId = s.ImageId,
                    Price = s.Price
                }).ToList();

            return View(productList);
        }


        public ActionResult Create()
        {
            return View("_CreateOrUpdate", new ProductModel());
        }


        [HttpPost]
        public ActionResult Create(ProductModel model)
        {
            var product = new Product();
            product.Title = model.Title;
            product.ImageId = model.ImageId;
            product.Price = model.Price;
            try
            {
                _productService.AddProduct(product);
            }
            catch (Exception ex)
            {
                model.ErrorMessage = ex.Message;
            }

            return RedirectToAction("Index");
        }


        public ActionResult Delete(int id)
        {
            try
            {
                var entity = _productService.GetById(id);
                _productService.Delete(entity);
            }
            catch(Exception ex)
            {
                //logger
            }

            return RedirectToAction("Index");
        }
    }
}