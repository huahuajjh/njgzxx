using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public partial class Hiring
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CreateUser { get; set; }
        public DateTime CreateDate { get; set; }
        public string Department { get; set; }
        public string WorkType { get; set; }
        public string Salary { get; set; }
        public string Introduction { get; set; }
        public int ColumnId { get; set; }
        public string Describe { get; set; }
        public int PersonNum { get; set; }
        public string Address { get; set; }
    }
}
