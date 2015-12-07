using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Areas.Admin.Controllers
{
    /// <summary>
    /// 轮播图
    /// </summary>
    public class ShufflingController : Controller
    {
        #region 展示界面
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = Services.Database.Entiyies.Shufflings.FirstOrDefault(d=> d.Id == id);
            return View(model);
        }
        #endregion

        #region 获取数据
        [HttpPost]
        public ActionResult Index(int iDisplayStart, int iDisplayLength, string sEcho)
        {
            var count = Services.Database.Entiyies.Shufflings
                .Count();
            var dataList = Services.Database.Entiyies.Shufflings
                .OrderByDescending(d => d.Id)
                .Skip(iDisplayStart)
                .Take(iDisplayLength)
                .ToList();
            return Json(new
            {
                sEcho = sEcho,
                iTotalRecords = count,
                iTotalDisplayRecords = count,
                aaData = dataList
            });
        }
        #endregion

        #region 提交数据
        public void Delete(int id)
        {
            Services.Database.Entiyies.Shufflings.Where(d => d.Id == id).ToList()
                .ForEach(d => Services.Database.Entiyies.Shufflings.Remove(d));
            Services.Database.Entiyies.SaveChanges();
        }

        [HttpPost]
        public ActionResult Add(Model.Shuffling shu, HttpPostedFileBase fileImg)
        {
            if (fileImg != null && fileImg.ContentLength > 0)
            {
                string filename = Guid.NewGuid().ToString();
                filename += System.IO.Path.GetExtension(fileImg.FileName);
                fileImg.SaveAs(HttpContext.Server.MapPath("/FileImg/") + filename);
                shu.Img = filename;
            }
            Services.Database.Entiyies.Shufflings.Add(shu);
            Services.Database.Entiyies.SaveChanges();
            return Redirect(Url.Action("Index", "Shuffling"));
        }

        [HttpPost]
        public ActionResult Edit(Model.Shuffling shu, HttpPostedFileBase fileImg)
        {
            if (fileImg != null && fileImg.ContentLength > 0)
            {
                string filename = Guid.NewGuid().ToString();
                filename += System.IO.Path.GetExtension(fileImg.FileName);
                fileImg.SaveAs(HttpContext.Server.MapPath("/FileImg/") + filename);
                shu.Img = filename;
            }
            System.Data.Entity.Infrastructure.DbEntityEntry entry = Services.Database.Entiyies.Entry(shu);
            entry.State = System.Data.EntityState.Modified;
            Services.Database.Entiyies.SaveChanges();
            return Redirect(Url.Action("Index", "Shuffling"));
        }
        #endregion
    }
}
