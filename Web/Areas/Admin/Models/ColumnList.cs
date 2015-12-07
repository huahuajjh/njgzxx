using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Areas.Admin.Models
{
    public class ColumnList:Model.Column
    {
        public Model.Column Column { get; set; }

        public static ColumnList Get(Model.Column col)
        {
            return new ColumnList()
            {
                Id = col.Id,
                Img = col.Img,
                Introduce = col.Introduce,
                Name = col.Name,
                ParentId = col.ParentId,
                Show = col.Show,
                Sort = col.Sort,
                TemplateBigContent = col.TemplateBigContent,
                TemplateBigIndex = col.TemplateBigIndex,
                TemplateBigList = col.TemplateBigList,
                TemplateSmallContent = col.TemplateSmallContent,
                TemplateSmallIndex = col.TemplateSmallIndex,
                TemplateSmallList = col.TemplateSmallList,
                Type = col.Type,
                Url = col.Url
            };
        }
    }
}