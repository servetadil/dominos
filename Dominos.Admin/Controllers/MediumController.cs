using Dominos.Core.Domain;
using Dominos.Infrastructure.Service;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dominos.Admin.Controllers
{

    //[AuthorizeUser]
    public class MediumController : Controller
    {
        private IMediumService _mediumService;
        public MediumController(IMediumService mediumService)
        {
            _mediumService = mediumService;
        }
        public ActionResult Index()
        {
            return View();
        }

        [OutputCache(Duration = 9201421)]
        public ActionResult View(int id)
        {

            var medium = _mediumService.GetById(id);
            if (medium != null)
            {
                MemoryStream ms = new MemoryStream(medium.FileBinary);
                var image = Image.FromStream(ms);

                var ratioX = (double)100 / image.Width;
                var ratioY = (double)100 / image.Height;
                var ratio = Math.Min(ratioX, ratioY);

                var width = (int)(image.Width * ratio);
                var height = (int)(image.Height * ratio);

                var newImage = new Bitmap(width, height);
                Graphics.FromImage(newImage).DrawImage(image, 0, 0, width, height);
                Bitmap bmp = new Bitmap(newImage);

                ImageConverter converter = new ImageConverter();

                var data = (byte[])converter.ConvertTo(bmp, typeof(byte[]));

                string contentType = medium.FileContentType;
                return File(data, contentType);
            }

            return HttpNotFound();
        }


        #region Actions

        /// <summary>
        /// Uploads the file.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public virtual ActionResult UploadFile()
        {
            HttpPostedFileBase myFile = Request.Files[0];
            bool isUploaded = false;
            string message = "File upload failed";
            var mediumId = 0;
            
            if (myFile != null && myFile.ContentLength != 0)
            {
                string pathForSaving = Server.MapPath("~/UploadFiles");
                if (this.CreateFolderIfNeeded(pathForSaving))
                {
                    try
                    {
                        var fileName = Guid.NewGuid().ToString() + Path.GetExtension(myFile.FileName);
                        myFile.SaveAs(Path.Combine(pathForSaving, fileName));

                        var mediumEntity = new Media();
                        mediumEntity.IsActive = true;
                        mediumEntity.FileName = fileName;
                        mediumEntity.FileExtension = Path.GetExtension(myFile.FileName);
                        mediumEntity.FileSize = myFile.ContentLength;
                        mediumEntity.FileContentType = MimeMapping.GetMimeMapping(fileName);

                        MemoryStream target = new MemoryStream();
                        myFile.InputStream.CopyTo(target);
                        byte[] fileByte = target.ToArray();

                        mediumEntity.FileBinary = fileByte;

                        _mediumService.Insert(mediumEntity);
                        mediumId = mediumEntity.Id;
                        isUploaded = true;
                        message = "File uploaded successfully!";
                    }
                    catch (Exception ex)
                    {
                        message = string.Format("File upload failed: {0}", ex.Message + " - " + ex.InnerException);
                    }
                }
            }
            return Json(new { isUploaded = isUploaded, message = message, mediumId = mediumId }, "text/html");
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Creates the folder if needed.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        private bool CreateFolderIfNeeded(string path)
        {
            bool result = true;
            if (!Directory.Exists(path))
            {
                try
                {
                    Directory.CreateDirectory(path);
                }
                catch (Exception)
                {
                    /*TODO: You must process this exception.*/
                    result = false;
                }
            }
            return result;
        }

        #endregion
    }
}