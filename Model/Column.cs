using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public partial class Column
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public string Img { get; set; }
        public string Url { get; set; }
        public string TemplateBigIndex { get; set; }
        public string TemplateBigList { get; set; }
        public string TemplateBigContent { get; set; }
        public string TemplateSmallIndex { get; set; }
        public string TemplateSmallList { get; set; }
        public string TemplateSmallContent { get; set; }
        public string Introduce { get; set; }
        public byte Type { get; set; }
        public bool Show { get; set; }
        public byte Sort { get; set; }
    }
}
