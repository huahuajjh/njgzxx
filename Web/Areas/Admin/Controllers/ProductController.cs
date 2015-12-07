using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Areas.Admin.Controllers
{
    /// <summary>
    /// 产品管理
    /// </summary>
    public class ProductController : Controller
    {
        #region 展示
        /// <summary>
        /// 展示主界面
        /// </summary>
        [HttpGet]
        public ActionResult Index()
        {
            var columnTypes = Services.Database.Entiyies.Columns
                .Where(d => d.Type == Models.ColumnType.Product)
                .ToList();
            return View(columnTypes);
        }

        /// <summary>
        /// 新增界面
        /// </summary>
        [HttpGet]
        public ActionResult Add()
        {
            var columnTypes = Services.Database.Entiyies.Columns
                .Where(d => d.Type == Models.ColumnType.Product)
                .ToList();
            return View(columnTypes);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = Services.Database.Entiyies.DataLists.FirstOrDefault(d => d.Id == id);
            ViewBag.Cols = Services.Database.Entiyies.Columns
                .Where(d => d.Type == Models.ColumnType.Product)
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
                .Count(d => (colId == null || d.ColumnId == colId) && d.Type == Models.ColumnType.Product);
            var dataList = Services.Database.Entiyies.DataLists
                .Where(d => (colId == null || d.ColumnId == colId) && d.Type == Models.ColumnType.Product)
                .OrderByDescending(d => d.Id)
                .Skip(iDisplayStart)
                .Take(iDisplayLength)
                .ToList();
            List<Models.DataListAndColumn> datas = new List<Models.DataListAndColumn>();
            foreach (var item in dataList)
            {
                var data = Models.DataListAndColumn.Get(item);
                data.Column = Services.Database.Entiyies.Columns.FirstOrDefault(d => d.Id == data.ColumnId);
                data.ColumnList = Services.Database.Entiyies.Columns.FirstOrDefault(d => d.Id == data.ColumnListId);
                datas.Add(data);
            }
            return Json(new
            {
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
        public ActionResult Add(Model.DataList product, HttpPostedFileBase fileImg)
        {
            if (fileImg != null && fileImg.ContentLength > 0)
            {
                string filename = Guid.NewGuid().ToString();
                filename += System.IO.Path.GetExtension(fileImg.FileName);
                fileImg.SaveAs(HttpContext.Server.MapPath("/FileImg/") + filename);
                product.Img = filename;
            }
            product.CreateTime = DateTime.Now;
            product.CreateUser = Common.Data.User.Id;
            product.Type = Models.ColumnType.Product;
            Services.Database.Entiyies.DataLists.Add(product);
            Services.Database.Entiyies.SaveChanges();
            return Redirect(Url.Action("Index", "Product"));
        }

        [HttpPost]
        public void Delete(int id)
        {
            Services.Database.Entiyies.DataLists.Where(d => d.Id == id).ToList().ForEach(d => Services.Database.Entiyies.DataLists.Remove(d));
            Services.Database.Entiyies.SaveChanges();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Model.DataList product, HttpPostedFileBase fileImg)
        {
            if (fileImg != null && fileImg.ContentLength > 0)
            {
                string filename = Guid.NewGuid().ToString();
                filename += System.IO.Path.GetExtension(fileImg.FileName);
                fileImg.SaveAs(HttpContext.Server.MapPath("/FileImg/") + filename);
                product.Img = filename;
            }
            System.Data.Entity.Infrastructure.DbEntityEntry entry = Services.Database.Entiyies.Entry(product);
            entry.State = System.Data.EntityState.Modified;
            Services.Database.Entiyies.SaveChanges();
            return Redirect(Url.Action("Index", "Product"));
        }
        #endregion
    }
}
