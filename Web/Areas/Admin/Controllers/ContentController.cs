using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Areas.Admin.Controllers
{
    /// <summary>
    /// 内容管理
    /// </summary>
    public class ContentController : Controller
    {
        #region 展示界面
        
        [HttpGet]
        public ActionResult Index()
        {
            var columnTypes = Services.Database.Entiyies.Columns
                .Where(d => d.Type == Models.ColumnType.Content)
                .ToList();
            return View(columnTypes);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var columnTypes = Services.Database.Entiyies.Columns
                .Where(d => d.Type == Models.ColumnType.Content)
                .ToList();
            return View(columnTypes);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = Services.Database.Entiyies.DataLists.FirstOrDefault(d=>d.Id == id);
            ViewBag.Cols = Services.Database.Entiyies.Columns
                .Where(d => d.Type == Models.ColumnType.Content)
                .ToList();
            ViewBag.ColLists = Services.Database.Entiyies.Columns.Where(d => d.ParentId == model.ColumnId).ToList();
            return View(model);
        }
        #endregion

        #region 获取数据
        [HttpPost]
        public ActionResult Index(int iDisplayStart, int iDisplayLength, string sEcho, int? colId)
        {
            var count = Services.Database.Entiyies.DataLists
                .Count(d => (colId == null || d.ColumnId == colId) && d.Type == Models.ColumnType.Content);
            var dataList = Services.Database.Entiyies.DataLists
                .Where(d => (colId == null || d.ColumnId == colId) && d.Type == Models.ColumnType.Content)
                .OrderByDescending(d => d.Id)
                .Skip(iDisplayStart)
                .Take(iDisplayLength)
                .ToList();
            List<Models.DataListAndColumn> datas = new List<Models.DataListAndColumn>();
            foreach (var item in dataList)
            {
                var data = Models.DataListAndColumn.Get(item);
                data.Column = Services.Database.Entiyies.Columns.FirstOrDefault(d=>d.Id == data.ColumnId);
                data.ColumnList = Services.Database.Entiyies.Columns.FirstOrDefault(d => d.Id == data.ColumnListId);
                datas.Add(data);
            }
            return Json(new { 
                sEcho = sEcho,
                iTotalRecords = count,
                iTotalDisplayRecords = count,
                aaData = datas 
            });
        }

        [HttpPost]
        public ActionResult GetColList(int pId)
        {
            var list = Services.Database.Entiyies.Columns.Where(d => d.ParentId == pId).ToList();
            return Json(list);
        }
        #endregion

        #region 提交数据
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Add(Model.DataList context,HttpPostedFileBase fileImg)
        {
            if (fileImg != null && fileImg.ContentLength > 0)
            {
                string filename = Guid.NewGuid().ToString();
                filename += System.IO.Path.GetExtension(fileImg.FileName);
                fileImg.SaveAs(HttpContext.Server.MapPath("/FileImg/") + filename);
                context.Img = filename;
            }
            context.CreateTime = DateTime.Now;
            context.CreateUser = Common.Data.User.Id;
            context.Type = Models.ColumnType.Content;
            Services.Database.Entiyies.DataLists.Add(context);
            Services.Database.Entiyies.SaveChanges();
            return Redirect(Url.Action("Index", "Content"));
        }

        [HttpPost]
        public void Delete(int id)
        {
            Services.Database.Entiyies.DataLists.Where(d => d.Id == id).ToList().ForEach(d => Services.Database.Entiyies.DataLists.Remove(d));
            Services.Database.Entiyies.SaveChanges();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Model.DataList context, HttpPostedFileBase fileImg)
        {
            if (fileImg != null && fileImg.ContentLength > 0)
            {
                string filename = Guid.NewGuid().ToString();
                filename += System.IO.Path.GetExtension(fileImg.FileName);
                fileImg.SaveAs(HttpContext.Server.MapPath("/FileImg/") + filename);
                context.Img = filename;
            }
            System.Data.Entity.Infrastructure.DbEntityEntry entry = Services.Database.Entiyies.Entry(context);
            entry.State = System.Data.EntityState.Modified;
            Services.Database.Entiyies.SaveChanges();
            return Redirect(Url.Action("Index", "Content"));
        }
        #endregion
    }
}
