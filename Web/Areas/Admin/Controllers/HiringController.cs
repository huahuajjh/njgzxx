using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Areas.Admin.Controllers
{
    /// <summary>
    /// 招聘
    /// </summary>
    public class HiringController : Controller
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
            var model = Services.Database.Entiyies.Columns.Where(d => d.Type == Models.ColumnType.Hiring).ToList();
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = Services.Database.Entiyies.Hirings.FirstOrDefault(d=>d.Id == id);
            ViewBag.Cols = Services.Database.Entiyies.Columns.Where(d => d.Type == Models.ColumnType.Hiring).ToList();
            return View(model);
        }
        #endregion

        #region 获取数据
        [HttpPost]
        public ActionResult Index(int iDisplayStart, int iDisplayLength, string sEcho)
        {
            var count = Services.Database.Entiyies.Hirings
                .Count();
            var dataList = Services.Database.Entiyies.Hirings
                .OrderByDescending(d => d.Id)
                .Skip(iDisplayStart)
                .Take(iDisplayLength)
                .ToList();
            List<Models.HiringsAndCol> datas = new List<Models.HiringsAndCol>();
            foreach (var item in dataList)
            {
                var data = Models.HiringsAndCol.Get(item);
                data.Column = Services.Database.Entiyies.Columns.FirstOrDefault(d=>d.Id == item.ColumnId);
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
        public void Delete(int id)
        {
            Services.Database.Entiyies.Hirings.Where(d=>d.Id == id).ToList()
                .ForEach(d=> Services.Database.Entiyies.Hirings.Remove(d));
            Services.Database.Entiyies.SaveChanges();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Add(Model.Hiring hir)
        {
            hir.CreateDate = DateTime.Now;
            hir.CreateUser = Common.Data.User.Id;
            Services.Database.Entiyies.Hirings.Add(hir);
            Services.Database.Entiyies.SaveChanges();
            return Redirect(Url.Action("Index", "Hiring"));
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Model.Hiring hir)
        {
            System.Data.Entity.Infrastructure.DbEntityEntry entry = Services.Database.Entiyies.Entry(hir);
            entry.State = System.Data.EntityState.Modified;
            Services.Database.Entiyies.SaveChanges();
            return Redirect(Url.Action("Index", "Hiring"));
        }
        #endregion
    }
}
