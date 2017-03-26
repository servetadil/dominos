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
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (model.Email == "tugrul@alpdogan.co" && model.Password == "alpdogan")
            {
                WorkContext.CurrentUser = new UserModel()
                {
                    Id = 1,
                    Email = "tugrul@alpdogan.co"
                };
            }
            return RedirectToAction("Index", "Home");
        }
    }
}