using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Areas.Admin.Models
{
    /// <summary>
    /// 栏目类型
    /// </summary>
    public class ColumnType
    {
        //0为栏目类型，1为内容列表，2为产品列表，3为招聘列表，4为单页面
        public const byte ColumnList = 0;
        public const byte Content = 1;
        public const byte Product = 2;
        public const byte Hiring = 3;
        public const byte Page = 4;
        public const byte UrlPage = 5;
    }
}