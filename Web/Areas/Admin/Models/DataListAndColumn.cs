using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Areas.Admin.Models
{
    public class DataListAndColumn : Model.DataList
    {
        public Model.Column Column { get; set; }

        public Model.Column ColumnList { get; set; }

        public static DataListAndColumn Get(Model.DataList data)
        {
            return new DataListAndColumn() {
                ColumnId = data.ColumnId,
                ColumnListId = data.ColumnListId,
                Contents = data.Contents,
                CreateTime = data.CreateTime,
                CreateUser = data.CreateUser,
                Describe = data.Describe,
                Id = data.Id,
                Img = data.Img,
                Name = data.Name,
                Other = data.Other,
                Type = data.Type
            };
        }
    }
}