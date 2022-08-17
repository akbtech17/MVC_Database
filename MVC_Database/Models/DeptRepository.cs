using System.Collections.Generic;
using System.Linq;
namespace MVC_Database.Models
{
    public class DeptRepository : IDept
    {
        // create an object of context
        db1045Context db = new db1045Context();

        public void AddDept(Dept dept)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteDept(int id)
        {
            throw new System.NotImplementedException();
        }

        public void EditDept(Dept dept)
        {
            throw new System.NotImplementedException();
        }

        public Dept FindDept(int id)
        {
            //var data = (from dept in db.Depts where dept.Id == id).FirstOrDefault();
            var data = db.Depts.Find(id);
            return data;
        }

        public List<Dept> GetDepts()
        {
            var data = from dept in db.Depts select dept;
            return data.ToList();
        }
    }
}
