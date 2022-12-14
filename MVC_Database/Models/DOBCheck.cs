using System;
using System.ComponentModel.DataAnnotations;

namespace MVC_Database.Models
{
    public class DOBCheck : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime birthdate = Convert.ToDateTime(value);
            int birthyear = birthdate.Year;
            int todayyear = DateTime.Now.Year;

            if (todayyear - birthyear < 25) return false;
            return true;
        }
    }
}
