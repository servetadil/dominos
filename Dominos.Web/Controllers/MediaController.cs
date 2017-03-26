using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dominos.Web.Controllers
{
    public class MediaController : Controller
    {
        private ProductWebService _productWebService;
        public MediaController()
        {
            _productWebService = new ProductWebService();
        }
        public ActionResult Index()
        {
            return View();
        }

        [OutputCache(Duration = 2147483647)]
        public ActionResult View(int id)
        {
            var medium = _productWebService.GetProductImageWithoutBinary(id);
            if (medium != null)
            {
                var fileName = Path.GetFileNameWithoutExtension(medium.FileName);
                var path = "/UploadFiles/" + fileName + medium.FileExtension;
                var serverPath = Server.MapPath("~/" + path);
                if (System.IO.File.Exists(serverPath))
                {
                    return RedirectPermanent(path);
                }
                medium = _productWebService.GetProductImageById(id);
                byte[] fileByte = medium.FileBinary;
                string contentType = medium.FileContentType;
                System.IO.File.WriteAllBytes(serverPath, fileByte);
                return RedirectPermanent(path);
            }

            return HttpNotFound();
        }

    }
}
