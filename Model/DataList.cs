using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public partial class DataList
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Img { get; set; }
        public int CreateUser { get; set; }
        public DateTime CreateTime { get; set; }
        public string Contents { get; set; }
        public int ColumnId { get; set; }
        public int? ColumnListId { get; set; }
        public byte Type { get; set; }
        public string Describe { get; set; }
        public string Other { get; set; }
    }
}
