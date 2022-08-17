using System.Collections.Generic;

namespace MVC_Database.Models
{
    public interface IDept
    {
        List<Dept> GetDepts();
        Dept FindDept(int id);
        void AddDept(Dept dept);
        void EditDept(Dept dept);
        void DeleteDept(int id);

    }
}
