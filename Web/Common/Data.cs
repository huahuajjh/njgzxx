using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Common
{
    public static class Data
    {
        /// <summary>
        /// 获取当前用户的信息
        /// </summary>
        public static Model.User User
        {
            get
            {
                string userName = System.Web.HttpContext.Current.Request.Cookies[Common.Const.UserKey].Value;
                return Services.Database.Entiyies.Users.FirstOrDefault(d => d.Username == userName);
            }
            set
            {
                HttpCookie cookie = new HttpCookie(Common.Const.UserKey, value.Username);
                System.Web.HttpContext.Current.Response.Cookies.Add(cookie);
            }
        }

        /// <summary>
        /// 获取路径
        /// </summary>
        public static string ViewPath
        {

            get
            {
                string bigScreen = "~/Views/Template/BigScreen/";
                string smallScreen = "~/Views/Template/SmallScreen/";

                return IsMobile ? smallScreen : bigScreen;
            }
        }

        /// <summary>
        /// 判断是否是手机
        /// </summary>
        public static bool IsMobile
        {
            get
            {
                var context = System.Web.HttpContext.Current;

                var mobile = context.Request.Cookies[Common.Const.Mobile];
                if (mobile != null)
                {
                    bool state;
                    return bool.TryParse(mobile.Value, out state) && state;
                }

                if (context.Request.UserAgent == null)
                    return false;

                string userAgent = context.Request.UserAgent.ToLower();
                var deviceNames = new[]
                                  {
                                      "iphone", "ipod", "ipad", "android", "nokia", "symbianos", "symbian", "windows phone"
                                      , "phone", "linux armv71", "maui", "untrusted/1.0", "windows ce", "blackberry",
                                      "iemobile"
                                  };

                return deviceNames.Any(userAgent.Contains);
            }
        }
    }
}