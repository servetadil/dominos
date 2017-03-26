using Dominos.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dominos.Web.Utility
{
    public class WorkContext
    {
        public static UserModel CurrentUser
        {
            get
            {
                if (HttpContext.Current.Session["CurrentUser"] != null)
                {
                    return (UserModel)HttpContext.Current.Session["CurrentUser"];
                }
                return null;
            }
            set
            {
                HttpContext.Current.Session["CurrentUser"] = value;
            }
        }


        public static bool IsAuthenticated
        {
            get
            {
                return CurrentUser != null;
            }
        }
    }
}