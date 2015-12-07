using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Areas.Admin.Controllers
{
    /// <summary>
    /// 页面介绍
    /// </summary>
    public class PageMessageController : Controller
    {
        #region 展示界面
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = Services.Database.Entiyies.Columns.FirstOrDefault(d => d.Id == id);
            return View(model);
        }
        #endregion

        #region 获取数据
        [HttpPost]
        public ActionResult Index(int iDisplayStart, int iDisplayLength, string sEcho)
        {
            var count = Services.Database.Entiyies.Columns
                .Count(d => d.Type == Models.ColumnType.Page);
            var dataList = Services.Database.Entiyies.Columns
                .Where(d => d.Type == Models.ColumnType.Page)
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
        [HttpPost]
        [ValidateInput(false)]
        public void Edit(int id, string val)
        {
            var model =Services.Database.Entiyies.Columns.FirstOrDefault(d=>d.Id == id);
            if (model == null)
                return;
            model.Introduce = val;
            Services.Database.Entiyies.SaveChanges();
        }
        #endregion

    }
}
