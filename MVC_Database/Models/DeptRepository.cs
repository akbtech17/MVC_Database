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
            // 1: add to the collection Depts
            db.Depts.Add(dept);
            
            // 2: context.SaveChanges()
            db.SaveChanges();
        }

        public void DeleteDept(int id)
        {
            // 1: fetch the record
            Dept dp = FindDept(id);
            
            // 2: remove the reocrd
            db.Depts.Remove(dp);
            
            // 3: context.SaveChanges()
            db.SaveChanges();
        }

        public void EditDept(Dept new_dept)
        {
            // 1: fetch the record
            Dept old_dept = db.Depts.Find(dept.Id);

            // 2: make the changes
            old_dept.Name = new_dept.Name;
            old_dept.Location = new_dept.Location;
            

            // 3: context.SaveChanges()
            db.SaveChanges();
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
