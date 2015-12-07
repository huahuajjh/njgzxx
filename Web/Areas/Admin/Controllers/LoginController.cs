using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Areas.Admin.Controllers
{
    /// <summary>
    /// 后端用户登陆
    /// </summary>
    [Web.Common.NoLoginAuthorize]
    public class LoginController : Controller
    {
        #region 展示界面
        /// <summary>
        /// 展示界面
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        } 
        #endregion

        #region 获取数据
        
        #endregion

        #region 提交数据
        [HttpPost]
        public ActionResult Index(string userName,string password)
        {
            var entiyies = Services.Database.Entiyies;
            var user = entiyies.Users.FirstOrDefault(d => d.Username == userName);
            if (user == null)
                return Content("not");
            if (user.Password != password)
                return Content("no");
            Common.Data.User = user;
            return Content("yes");
        }
        #endregion
    }
}
