using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace MVC_Database.Models
{
    public partial class Dept
    {
        public Dept()
        {
            Emps = new HashSet<Emp>();
        }

        [Display(Name = "Department Code")]
        public int Id { get; set; }

        [Display(Name = "Department Name")]
        public string Name { get; set; }

        [Display(Name = "Department Location")]
        public string Location { get; set; }

        public virtual ICollection<Emp> Emps { get; set; }
    }
}
