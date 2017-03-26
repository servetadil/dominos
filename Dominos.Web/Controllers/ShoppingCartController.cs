using Dominos.Web.Attributes;
using Dominos.Web.Models;
using Dominos.Web.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dominos.Web.Controllers
{

    [AuthorizeUser]
    public class ShoppingCartController : Controller
    {
        private ProductWebService _productWebService;
        public ShoppingCartController()
        {
            _productWebService = new ProductWebService();
        }
        public ActionResult Index()
        {
            var items = new List<ShoppingCartItemModel>();
            var cartItems = _productWebService.GetShoppingCartItems(WorkContext.CurrentUser.Id);
            foreach (var cartItem in cartItems)
            {
                var item = new ShoppingCartItemModel();
                item.Id = cartItem.Id;
                item.ProductId = cartItem.ProductId;
                item.Quantity = cartItem.Quantity;
                item.Price = cartItem.ProductPrice;
                item.ImageId = cartItem.ProductImageId;
                item.Title = cartItem.ProductTitle;
                items.Add(item);
            }
            var model = new ShoppingCartModel();
            model.Items = items;
            model.TotalPrice = items.Sum(s => s.TotalPrice);
            return View(model);
        }


        [HttpPost]
        public ActionResult AddToBasket(AddToBasketModel model)
        {
            try
            {
                var success = _productWebService.AddShoppingCart(model.ProductId, WorkContext.CurrentUser.Id, model.Quantity);
                return Json(new { Success = success });
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, Message = ex.Message });
            }
        }


        [HttpPost]
        public ActionResult SetQuantitiy(SetQuantityModel model)
        {
            try
            {
                var success = _productWebService.SetShoppingCartQuantityById(model.ShoppingCartItemId, model.Quantity);
                return Json(new { Success = success });
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, Message = ex.Message });
            }
        }
    }
}