using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace HelperLibrary
{
    public class deptmethods
    {
        MyContext context=new MyContext();
        public deptmethods()
        {
            context = new MyContext();
          }
        public bool adddeptmaster(DeptMaster p){
            try
            {
                DeptMaster k = new DeptMaster();
                k.deptcode = p.deptcode;
                k.deptname = p.deptname;
                context.DeptMasters.Add(k);
                context.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        
        }
        public bool removemaster(int id)
        {
            try
            {
                List<DeptMaster> p = context.DeptMasters.ToList();
                DeptMaster k=p.Find(p1=>p1.deptcode==id);
                context.DeptMasters.Remove(k);
                context.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
        public bool updatemaster(int id,DeptMaster k)
        {
            try
            {
                List<DeptMaster> p = context.DeptMasters.ToList();
                DeptMaster s = p.Find(p1 => p1.deptcode == id);
                s.deptcode = Convert.ToInt32(k.deptcode);
                s.deptname = k.deptname;
                context.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
        public DeptMaster finddept(int id)
        {
            List<DeptMaster> p = context.DeptMasters.ToList();
            DeptMaster k = p.Find(p1 => p1.deptcode == id);
            return k;
        }
        public List<DeptMaster> getdeptMasters()
        {
       
            return context.DeptMasters.ToList();
        }
    }
    public class empmethods
    {
        MyContext context = null;
        public empmethods()
        {
            context = new MyContext();
        }
        public bool AddEmployee(EmpProfile m)
        {
            try
            {
                context.EmpProfiles.Add(m);
                context.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
        public bool UpdateEmployee(int id,EmpProfile m)
        {
            try
            {
                List<EmpProfile> s = context.EmpProfiles.ToList();
                EmpProfile p = s.Find(s1=>s1.EmpCode==id);
                p.EmpCode = m.EmpCode;
                p.EmpName = m.EmpName;
                p.deptcode = m.deptcode;
                p.email = m.email;
                p.DOB = m.DOB;
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public EmpProfile FindEmployee(int id)
        {
            List<EmpProfile> s = context.EmpProfiles.ToList();
            EmpProfile p = s.Find(s1 => s1.EmpCode == id);
            return p;

        }
        public bool Removeemployee(int id)
        {
            try
            {
                List<EmpProfile> s = context.EmpProfiles.ToList();
                EmpProfile p = s.Find(s1 => s1.EmpCode == id);
                context.EmpProfiles.Remove(p);
                context.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
        public List<EmpProfile> GetEmpProfilesall()
        {
            return context.EmpProfiles.ToList();
        }
    }
}
