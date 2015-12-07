using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class HomeController : Controller
    {

        #region 展示界面
        /// <summary>
        /// 主界面
        /// </summary>
        [HttpGet]
        public ActionResult Index()
        {
            return PartialView(Common.Data.ViewPath + "Index.cshtml");
        }

        #region 栏目
        [HttpGet]
        public ActionResult Column(int id)
        {
            var model = Services.Database.Entiyies.Columns.FirstOrDefault(d => d.Id == id);
            ViewBag.Col = model;
            if (model == null)
                return new HttpStatusCodeResult(404);
            if (model.Type == Areas.Admin.Models.ColumnType.UrlPage)
                return Redirect(model.Url);
            try
            {
                var indexPage = Common.Data.IsMobile ? model.TemplateSmallIndex.Trim() : model.TemplateBigIndex.Trim();
                return PartialView(Common.Data.ViewPath + indexPage + ".cshtml", model);
            }
            catch (Exception e)
            {
                return new HttpStatusCodeResult(500);
            }
        }

        [HttpGet]
        public ActionResult ColumnList(int id)
        {
            var model = Services.Database.Entiyies.Columns.FirstOrDefault(d => d.Id == id);
            ViewBag.Col = model;
            if (model == null)
                return new HttpStatusCodeResult(404);
            try
            {
                var parModel = Services.Database.Entiyies.Columns.FirstOrDefault(d=>d.Id == model.ParentId);
                var indexPage = Common.Data.IsMobile ? parModel.TemplateSmallList.Trim() : parModel.TemplateBigList.Trim();
                return PartialView(Common.Data.ViewPath + indexPage + ".cshtml", model);
            }
            catch (Exception e)
            {
                return new HttpStatusCodeResult(500);
            }
        }
        #endregion

        #region 内容

        /// <summary>
        /// 内容详细界面
        /// </summary>
        [HttpGet]
        public ActionResult Content(int id)
        {
            var model = Services.Database.Entiyies.DataLists.FirstOrDefault(d => d.Id == id);
            if (model == null)
                return new HttpStatusCodeResult(404);
            var col = Services.Database.Entiyies.Columns.FirstOrDefault(d => d.Id == model.ColumnId);
            try
            {
                ViewBag.Col = col;
                var indexPage = Common.Data.IsMobile ? col.TemplateSmallContent.Trim() : col.TemplateBigContent.Trim();
                return PartialView(Common.Data.ViewPath + indexPage + ".cshtml", model);
            }
            catch (Exception e)
            {
                return new HttpStatusCodeResult(500);
            }
        }
        #endregion

        #region 产品

        /// <summary>
        /// 产品详细信息
        /// </summary>
        [HttpGet]
        public ActionResult Product(int id)
        {
            var model = Services.Database.Entiyies.DataLists.FirstOrDefault(d => d.Id == id);
            if (model == null)
                return new HttpStatusCodeResult(404);
            var col = Services.Database.Entiyies.Columns.FirstOrDefault(d => d.Id == model.ColumnId);
            try
            {
                ViewBag.Col = col;
                var indexPage = Common.Data.IsMobile ? col.TemplateSmallContent.Trim() : col.TemplateBigContent.Trim();
                return PartialView(Common.Data.ViewPath + indexPage + ".cshtml", model);
            }
            catch (Exception e)
            {
                return new HttpStatusCodeResult(500);
            }
        }
        #endregion

        #region 招聘
        /// <summary>
        /// 获取招聘详细
        /// </summary>
        [HttpGet]
        public ActionResult Hiring(int id)
        {
            var model = Services.Database.Entiyies.Hirings.FirstOrDefault(d => d.Id == id);
            if (model == null)
                return new HttpStatusCodeResult(404);
            var col = Services.Database.Entiyies.Columns.FirstOrDefault(d => d.Id == model.ColumnId);
            try
            {
                ViewBag.Col = col;
                var indexPage = Common.Data.IsMobile ? col.TemplateSmallContent.Trim() : col.TemplateBigContent.Trim();
                return PartialView(Common.Data.ViewPath + indexPage + ".cshtml", model);
            }
            catch (Exception e)
            {
                return new HttpStatusCodeResult(500);
            }
        }
        #endregion
        #endregion

        #region 提交数据
        [HttpPost]
        public void SetMessage(Model.Message msg)
        {
            msg.IsSee = false;
            msg.CreateTime = DateTime.Now;
            Services.Database.Entiyies.Messages.Add(msg);
            Services.Database.Entiyies.SaveChanges();
        }

        [HttpGet]
        public ActionResult SetMobile(bool state, string url)
        {
            HttpCookie mobile = Request.Cookies[Common.Const.Mobile];
            if (mobile == null)
                mobile = new HttpCookie(Common.Const.Mobile, state.ToString());
            else
                mobile.Value = state.ToString();
            HttpContext.Response.Cookies.Set(mobile);
            return Redirect(url);
        }
        #endregion
    }
}
