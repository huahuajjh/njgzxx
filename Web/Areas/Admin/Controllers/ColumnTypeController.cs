using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Areas.Admin.Controllers
{
    /// <summary>
    /// 栏目类型
    /// </summary>
    public class ColumnTypeController : Controller
    {
        #region 展示界面
        /// <summary>
        /// 主界面
        /// </summary>
        [HttpGet]
        public ActionResult Index()
        {
            var model = Services.Database.Entiyies.Columns
                .Where(d => d.Type == Models.ColumnType.Content || d.Type == Models.ColumnType.Product).ToList();
            return View(model);
        }

        /// <summary>
        /// 新增界面
        /// </summary>
        [HttpGet]
        public ActionResult Add()
        {
            var model = Services.Database.Entiyies.Columns
                .Where(d => d.Type == Models.ColumnType.Content || d.Type == Models.ColumnType.Product).ToList();
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = Services.Database.Entiyies.Columns.FirstOrDefault(d=> d.Id == id);
            ViewBag.ColList = Services.Database.Entiyies.Columns
                .Where(d => d.Type == Models.ColumnType.Content || d.Type == Models.ColumnType.Product).ToList();
            return View(model);
        }
        #endregion

        #region 获取数据
        [HttpPost]
        public ActionResult Index(int iDisplayStart, int iDisplayLength, string sEcho, int? parentId)
        {
            var count = Services.Database.Entiyies.Columns
                .Count(d => (d.ParentId == parentId || parentId == null) && d.Type == Models.ColumnType.ColumnList);
            var dataList = Services.Database.Entiyies.Columns
                .Where(d => (d.ParentId == parentId || parentId == null) && d.Type == Models.ColumnType.ColumnList)
                .OrderByDescending(d => d.Id)
                .Skip(iDisplayStart)
                .Take(iDisplayLength)
                .ToList();
            List<Models.ColumnList> datas = new List<Models.ColumnList>();
            foreach (var item in dataList)
            {
                var data = Models.ColumnList.Get(item);
                data.Column = Services.Database.Entiyies.Columns.FirstOrDefault(d => d.Id == item.ParentId);
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
        #endregion

        #region 提交数据
        [HttpPost]
        public ActionResult Add(Model.Column col)
        {
            col.Show = true;
            col.Type = Models.ColumnType.ColumnList;
            Services.Database.Entiyies.Columns.Add(col);
            Services.Database.Entiyies.SaveChanges();
            return Redirect(Url.Action("Index", "ColumnType"));
        }

        [HttpPost]
        public ActionResult Edit(Model.Column col)
        {
            System.Data.Entity.Infrastructure.DbEntityEntry entry = Services.Database.Entiyies.Entry(col);
            entry.State = System.Data.EntityState.Modified;
            Services.Database.Entiyies.SaveChanges();
            return Redirect(Url.Action("Index", "ColumnType"));
        }
        #endregion
    }
}
