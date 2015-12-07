using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Areas.Admin.Controllers
{
    /// <summary>
    /// 栏目管理
    /// </summary>
    public class ColumnController : Controller
    {
        #region 展示界面
        /// <summary>
        /// 主界面
        /// </summary>
        [HttpGet]
        public ActionResult Index()
        {
            var columns = Services.Database.Entiyies.Columns.Where(d => d.ParentId == null && d.Type != 1).ToList();
            return View(columns);
        }

        /// <summary>
        /// 新增界面
        /// </summary>
        [HttpGet]
        public ActionResult Add()
        {
            var models = Services.Database.Entiyies.Columns.Where(d => d.Type == Models.ColumnType.Page || d.Type == Models.ColumnType.UrlPage).ToList();
            return View(models);
        }
        [HttpGet]
        [ValidateInput(false)]
        public ActionResult Edit(int id)
        {
            var model = Services.Database.Entiyies.Columns.FirstOrDefault(d => d.Id == id);
            if (model == null)
                return Redirect(Url.Action("Index", "Column"));
            ViewBag.Cols = Services.Database.Entiyies.Columns.Where(d => d.Type == Models.ColumnType.Page || d.Type == Models.ColumnType.UrlPage).ToList();
            return View(model);
        }
        #endregion

        #region 获取数据
        [HttpPost]
        public ActionResult Index(int iDisplayStart, int iDisplayLength, string sEcho, int? parentId)
        {
            var count = Services.Database.Entiyies.Columns
                .Count(d => (d.ParentId == parentId || (parentId == null && d.ParentId == null)) && d.Type != Models.ColumnType.ColumnList);
            var dataList = Services.Database.Entiyies.Columns
                .Where(d => (d.ParentId == parentId || (parentId == null && d.ParentId == null)) && d.Type != Models.ColumnType.ColumnList)
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

        [HttpPost]
        public ActionResult List(int? parentId)
        {
            var datas = Services.Database.Entiyies.Columns.Where(d => (d.ParentId == parentId || (parentId == null && d.ParentId == null)) && d.Type != Models.ColumnType.ColumnList).ToList();
            return Json(datas);
        }

        [HttpPost]
        public ActionResult Templates(byte type)
        {
            switch (type)
            {
                case Models.ColumnType.Content:
                    return Json(new { 
                        Small = Common.Template.SmallScreen.ContentTemplate,
                        Big = Common.Template.BigScreen.ContentTemplate
                    });
                case Models.ColumnType.Hiring:
                    return Json(new
                    {
                        Small = Common.Template.SmallScreen.HiringTemplate,
                        Big = Common.Template.BigScreen.HiringTemplate
                    });
                case Models.ColumnType.Page:
                    return Json(new
                    {
                        Small = Common.Template.SmallScreen.PageTemplate,
                        Big = Common.Template.BigScreen.PageTemplate
                    });
                case Models.ColumnType.Product:
                    return Json(new
                    {
                        Small = Common.Template.SmallScreen.ProductTemplate,
                        Big = Common.Template.BigScreen.ProductTemplate
                    });
            }
            return null;
        }
        #endregion

        #region 提交数据
        [HttpPost]
        public ActionResult Add(Model.Column col, HttpPostedFileBase fileImg)
        {

            if (fileImg != null && fileImg.ContentLength > 0)
            {
                string filename = Guid.NewGuid().ToString();
                filename += System.IO.Path.GetExtension(fileImg.FileName);
                fileImg.SaveAs(HttpContext.Server.MapPath("/FileImg/") + filename);
                col.Img = filename;
            }
            Services.Database.Entiyies.Columns.Add(col);
            Services.Database.Entiyies.SaveChanges();
            return Redirect(Url.Action("Index", "Column"));
        }
        [ValidateInput(false)]
        public ActionResult Edit(Model.Column col, HttpPostedFileBase fileImg)
        {
            if (fileImg != null && fileImg.ContentLength > 0)
            {
                string filename = Guid.NewGuid().ToString();
                filename += System.IO.Path.GetExtension(fileImg.FileName);
                fileImg.SaveAs(HttpContext.Server.MapPath("/FileImg/") + filename);
                col.Img = filename;
            }
            System.Data.Entity.Infrastructure.DbEntityEntry entry = Services.Database.Entiyies.Entry(col);
            entry.State = System.Data.EntityState.Modified;
            Services.Database.Entiyies.SaveChanges();
            return Redirect(Url.Action("Index", "Column"));
        }

        [HttpPost]
        public void Delete(int id)
        {
            Services.Database.Entiyies.Columns.Where(d => d.Id == id).ToList().ForEach(d =>
            {
                Services.Database.Entiyies.Columns.Remove(d);
            });
            Services.Database.Entiyies.SaveChanges();
        }
        #endregion
    }
}
