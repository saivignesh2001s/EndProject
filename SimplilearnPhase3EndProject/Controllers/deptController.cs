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
    public class deptController : ApiController
    {
        // GET: api/dept

        deptmethods mode = null;
        public deptController()
        {
            mode=new deptmethods();

        }
        List<deptmodel> ms = new List<deptmodel>();
        [Route("Getalldeps")]
        public IEnumerable<deptmodel> Get()
        {
            List<DeptMaster> rs = mode.getdeptMasters();
            foreach(var item in rs)
            {
                deptmodel m = new deptmodel();
                m.deptcode = item.deptcode;
                m.deptname = item.deptname;
                ms.Add(m);
            }
            return ms;
        }

        // GET: api/dept/5
        [Route("finddepts/{id}")]
        public deptmodel Get(int id)
        {
            DeptMaster r = mode.finddept(id);
            deptmodel m = new deptmodel();
            m.deptcode = r.deptcode;
            m.deptname = r.deptname;
            return m;
        }

        // POST: api/dept
        [Route("adddepts")]
        public HttpResponseMessage Post([FromBody]deptmodel value)
        {
            DeptMaster m = new DeptMaster();
            m.deptcode =Convert.ToInt32(value.deptcode);
            m.deptname = value.deptname;
            bool k = mode.adddeptmaster(m);
            if (k)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotAcceptable);
            }
  
            
        }

        // PUT: api/dept/5
        [Route("updatedepts/{id}")]
        public HttpResponseMessage Put(int id, [FromBody]deptmodel value)
        {
            DeptMaster m = new DeptMaster();
            m.deptcode =Convert.ToInt32(value.deptcode);
            m.deptname = value.deptname;
            bool k = mode.updatemaster(id,m);
            if (k)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotAcceptable);
            }
        }

        // DELETE: api/dept/5
        [Route("removedepts/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            bool k = mode.removemaster(id);
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
