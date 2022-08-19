using MVC_Database.Models;
using System.Collections.Generic;

namespace MVC_Database.ViewModel
{
    public class EmpDept
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DeptName { get; set; }
        public string Location { get; set; }
        public int? Salary { get; set; }
        public int Bonus { get; set; }

        public virtual ICollection<Emp> Emps { get; set; }
    }
}
