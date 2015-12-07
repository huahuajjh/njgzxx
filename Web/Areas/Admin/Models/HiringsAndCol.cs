using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Areas.Admin.Models
{
    public class HiringsAndCol : Model.Hiring
    {
        public Model.Column Column { get; set; }

        public static HiringsAndCol Get(Model.Hiring hir)
        {
            return new HiringsAndCol()
            {
                ColumnId = hir.ColumnId,
                CreateDate = hir.CreateDate,
                CreateUser = hir.CreateUser,
                Department = hir.Department,
                Describe = hir.Describe,
                Id = hir.Id,
                Introduction = hir.Introduction,
                Name = hir.Name,
                Salary = hir.Salary,
                WorkType = hir.WorkType
            };
        }
    }
}