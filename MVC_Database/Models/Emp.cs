using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
#nullable disable

namespace MVC_Database.Models
{
    public partial class Emp
    {
        [Display(Name = "Emp-Code")]
        public int Id { get; set; }

        [Display(Name = "Emp-Name")]
        [Required(ErrorMessage = "Cannot be empty!")]
        public string Name { get; set; }

        [Display(Name = "Emp-CTC")]
        [Range(200000,10000000, ErrorMessage = "Value should be in range 200000-10000000")]
        public int? Salary { get; set; }

        [Display(Name = "Dept-Code")]
        public int? Deptid { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DOBCheck(ErrorMessage = "You must be atleast 25 years old")]
        public DateTime? Dob { get; set; }

        [Required(ErrorMessage = "Cannot be empty!")]
        [DataType(DataType.EmailAddress)]
        [Remote("EmailCheck","Emp",ErrorMessage = "Duplicate Email")]
        public string Email { get; set; }

        public virtual Dept Dept { get; set; }
    }
}
