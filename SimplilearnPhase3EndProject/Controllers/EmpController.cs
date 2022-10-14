using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HelperLibrary;
using DAL;
using SimplilearnPhase3EndProject.Models;

namespace SimplilearnPhase3EndProject.Controllers
{
    public class EmpController : ApiController
    {
        // GET: api/Emp

        empmethods ms1 = null;
        public EmpController()
        {
            ms1 = new empmethods();
        }
        List<Empmodel> mk = new List<Empmodel>();
        [Route("GetAllEmpProfiles")]
        public IEnumerable<Empmodel> Get()
        {
            List<EmpProfile> s1 = ms1.GetEmpProfilesall();
            foreach(var item in s1)
            {
                Empmodel emp = new Empmodel();
                emp.EmpCode = Convert.ToInt32(item.EmpCode);
                emp.EmpName=item.EmpName.ToString();
                emp.DOB = Convert.ToDateTime(item.DOB);
                emp.email = item.email.ToString();
                emp.deptcode = Convert.ToInt32(item.deptcode);
                mk.Add(emp);
            }
            return mk;
        }

        // GET: api/Emp/5
        [Route("Findprofiles/{id}")]
        public Empmodel Get(int id)
        {
            Empmodel emp=new Empmodel();
            EmpProfile item = ms1.FindEmployee(id);
            emp.EmpCode = Convert.ToInt32(item.EmpCode);
            emp.EmpName = item.EmpName.ToString();
            emp.DOB = Convert.ToDateTime(item.DOB);
            emp.email = item.email.ToString();
            emp.deptcode = Convert.ToInt32(item.deptcode);
            return emp;

        }

        // POST: api/Emp
        [Route("AddEmpprofiles")]
        public HttpResponseMessage Post([FromBody]EmpProfile item)
        {
            EmpProfile emp = new EmpProfile();
            emp.EmpCode = Convert.ToInt32(item.EmpCode);
            emp.EmpName = item.EmpName.ToString();
            emp.DOB = Convert.ToDateTime(item.DOB);
            emp.email = item.email.ToString();
            emp.deptcode = Convert.ToInt32(item.deptcode);
            bool k=ms1.AddEmployee(emp);
            if (k)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotAcceptable);

            }

        }

        // PUT: api/Emp/5
        [Route("Updateemp/{id}")]
        public HttpResponseMessage Put(int id, [FromBody]Empmodel item)
        {
            EmpProfile emp = new EmpProfile();
            emp.EmpCode = Convert.ToInt32(item.EmpCode);
            emp.EmpName = item.EmpName.ToString();
            emp.DOB = Convert.ToDateTime(item.DOB);
            emp.email = item.email.ToString();
            emp.deptcode = Convert.ToInt32(item.deptcode);
            bool k = ms1.UpdateEmployee(id,emp);
            if (k)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotAcceptable);

            }
        }

        // DELETE: api/Emp/5
        [Route("RemoveEmp/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            bool k = ms1.Removeemployee(id);
            if (k)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotAcceptable);

            }
        }
    }
}
