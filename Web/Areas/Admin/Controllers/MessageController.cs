using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Areas.Admin.Controllers
{
    /// <summary>
    /// 留言管理
    /// </summary>
    public class MessageController : Controller
    {
        #region 展示界面
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Dispose(int id)
        {
            var model = Services.Database.Entiyies.Messages.FirstOrDefault(d => d.Id == id);
            return View(model);
        }
        #endregion

        #region 获取数据
        [HttpPost]
        public ActionResult Index(int iDisplayStart, int iDisplayLength, string sEcho, bool? state)
        {
            var count = Services.Database.Entiyies.Messages
                .Count(d => d.IsSee == state || state == null);
            var dataList = Services.Database.Entiyies.Messages
                .Where(d => d.IsSee == state || state == null)
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
        public void DisposeMsg(int id)
        {
            var model = Services.Database.Entiyies.Messages.FirstOrDefault(d=>d.Id == id);
            if(model == null)
                return;
            model.IsSee = true;
            Services.Database.Entiyies.SaveChanges();
        }
        #endregion
    }
}
