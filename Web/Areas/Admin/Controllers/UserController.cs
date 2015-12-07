using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Areas.Admin.Controllers
{
    /// <summary>
    /// 用户管理
    /// </summary>
    public class UserController : Controller
    {
        #region 展示
        /// <summary>
        /// 用户管理界面
        /// </summary>
        public ActionResult Index()
        {
            return View();
        }
        #endregion

        #region 获取数据
        [HttpPost]
        public ActionResult Index(int iDisplayStart, int iDisplayLength, string sEcho)
        {
            var count = Services.Database.Entiyies.Users
                .Count();
            var dataList = Services.Database.Entiyies.Users
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
        public void Delete(int id)
        {
            Services.Database.Entiyies.Users.Where(d => d.Id == id).ToList().ForEach(d =>
            {
                if (d.Username != "admin")
                    Services.Database.Entiyies.Users.Remove(d);
            });
            Services.Database.Entiyies.SaveChanges();
        }

        [HttpPost]
        public ActionResult Add(Model.User user)
        {
            if (Services.Database.Entiyies.Users.Any(d => d.Username == user.Username))
                return Content("false");
            Services.Database.Entiyies.Users.Add(user);
            Services.Database.Entiyies.SaveChanges();
            return Content("true");
        }

        [HttpPost]
        public ActionResult EditPassword(string oldPassword,string newPassword)
        {
            if (Common.Data.User.Password != oldPassword)
                return Content("false");
            Common.Data.User.Password = newPassword;
            Services.Database.Entiyies.SaveChanges();
            return Content("true");
        }
        #endregion
    }
}
