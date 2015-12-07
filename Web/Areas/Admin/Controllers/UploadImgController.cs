using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Areas.Admin.Controllers
{
    public class UploadImgController : Controller
    {
        [HttpPost]
        public string Index(HttpPostedFileBase fileImg)
        {
            if (fileImg == null || fileImg.ContentLength == 0)
                return string.Empty;
            string filename = Guid.NewGuid().ToString();
            filename += System.IO.Path.GetExtension(fileImg.FileName);
            fileImg.SaveAs(HttpContext.Server.MapPath("/FileImg/") + filename);
            return "/FileImg/" + filename;
        }

    }
}
