using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Common
{
    public class LoginAuthorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            //判断当前访问的是否是后台
            if (filterContext.Controller.ControllerContext.RouteData.DataTokens["area"] == Web.Areas.Admin.AdminAreaRegistration.Name)
            {
                if (!filterContext.ActionDescriptor.IsDefined(typeof(NoLoginAuthorizeAttribute), false) &&
                    !filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(NoLoginAuthorizeAttribute), false))
                    base.OnAuthorization(filterContext);
            }
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            httpContext.User = new UserPrincipal(httpContext);
            return httpContext.User.Identity.IsAuthenticated;
        }
    }


    public class NoLoginAuthorizeAttribute : Attribute { }


    public class UserPrincipal : System.Security.Principal.IPrincipal
    {
        HttpContextBase httpContext;

        System.Security.Principal.IIdentity _Identity;

        public UserPrincipal(HttpContextBase httpContext)
        {
            this.httpContext = httpContext;
            this._Identity = new UserIIdentity(this.httpContext);
        }

        public System.Security.Principal.IIdentity Identity
        {
            get { 
                return _Identity; 
            }
        }

        public bool IsInRole(string role)
        {
            return true;
        }
    }

    public class UserIIdentity : System.Security.Principal.IIdentity
    {
        HttpContextBase httpContext;

        public UserIIdentity(HttpContextBase httpContext)
        {
            this.httpContext = httpContext;
        }

        public string AuthenticationType
        {
            get
            {
                return "";
            }
        }

        public bool IsAuthenticated
        {
            get
            {
                return httpContext.Request.Cookies[Common.Const.UserKey]!=null && !string.IsNullOrEmpty(httpContext.Request.Cookies[Common.Const.UserKey].Value);
            }
        }

        public string Name
        {
            get { return httpContext.Request.Cookies[Common.Const.UserKey].Value; }
        }
    }
}