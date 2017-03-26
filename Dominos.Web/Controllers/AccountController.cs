using Dominos.Web.Models;
using Dominos.Web.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dominos.Web.Controllers
{
    public class AccountController : Controller
    {

        private ProductWebService _productWebService;
        public AccountController()
        {
            _productWebService = new ProductWebService();
        }
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            var user = _productWebService.Login(model.Email, model.Password);
            if (user.Success)
            {
                WorkContext.CurrentUser = new UserModel()
                {
                    Id = user.UserId,
                    Email = user.Email
                };
            }
            return RedirectToAction("Index", "Home");
        }
    }
}