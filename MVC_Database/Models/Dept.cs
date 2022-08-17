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

        [Required(ErrorMessage = "Id is required!")]
        [Display(Name = "Department Code")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name cannot be null!")]
        [Display(Name = "Department Name")]
        public string Name { get; set; }

        [StringLength(25,ErrorMessage = "3 chars",MinimumLength=3)]
        [Display(Name = "Department Location")]
        public string Location { get; set; }

        public virtual ICollection<Emp> Emps { get; set; }
    }
}
