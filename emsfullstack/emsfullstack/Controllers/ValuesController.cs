using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using bal;
using dal;
using emsfullstack.Models;


namespace emsfullstack.Controllers
{
   
    public class ValuesController : ApiController
    {
        // GET api/values
      
            // GET api/<controller>
            DAL obj = null;
            public ValuesController()
            {
                obj = new DAL();
            }

        //[Route("GetAllEmps")]
        [HttpGet]
        public List<empmodel> Get()
          
            {
            //return new string[] 
            //{ "value1", "value2" };

            List<EmpProfiles> empbal = new List<EmpProfiles>(); empbal = obj.GetCustomers();
            List<empmodel> emps = new List<empmodel>();
            foreach (var item in empbal)
            {
                //Employees emp = new Employees();
                emps.Add(new empmodel
                {
                    EmpCode = item.EmpCode,
                    Email = item.Email,
                    EmpName = item.EmpName,
                    //    DateOfBirth = item.DateOfBirth,
                    DeptCode = item.DeptCode
                });
            }
            return emps;

        }

            // GET api/values/5
            public string Get(int id)
            {
                return "value";
            }

        // POST api/values
        public void Post([FromBody] empmodel empdata)
        {
            EmpProfiles empbal = new EmpProfiles();
            empbal.EmpCode = empdata.EmpCode;
            empbal.Email = empdata.Email;
            empbal.EmpName = empdata.EmpName;
            empbal.DeptCode = empdata.DeptCode;



            obj.Insertcustomer(empbal);




        }
        //[Route("SavingEmployeeDetails")]
        //public HttpResponseMessage Post([FromBody] empmodel value)
        //{
        //    EmpProfiles empbal = new EmpProfiles();
        //    empbal.EmpCode = value.EmpCode;
        //    r.DateOfBirth = value.DateOfBirth;
        //    empbal.EmpName = value.EmpName;
        //    empbal.Email = value.Email;
        //    empbal.DeptCode = value.DeptCode;

        //    bool k = obj.Insertcustomer(empbal);
        //    if (k)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.OK);
        //    }
        //    else
        //    {
        //        return Request.CreateResponse(HttpStatusCode.NotAcceptable);
        //    }
        //}


        // PUT api/values/5
        [HttpPut]
        public void Put( [FromBody] empmodel empdata)
        {

            EmpProfiles empbal = new EmpProfiles();
            empbal.EmpCode = empdata.EmpCode;
            empbal.Email = empdata.Email;
            empbal.EmpName = empdata.EmpName;
            empbal.DeptCode = empdata.DeptCode;

           obj.UpdateCustomer(empbal);
         
        }

            
        // DELETE api/values/5
        public void Delete(int id)
        {
            
            obj.Remove(id);
           

        }
        [Route("FindById/{id:int?}")]
        public empmodel GetMarkByID(int id)
        {
            EmpProfiles empbal = new EmpProfiles();
            empbal = obj.search(id);
            empmodel emp = new empmodel();
           
            emp.EmpCode = id;
            emp.EmpName = empbal.EmpName;
            emp.Email = empbal.Email;
            emp.DeptCode = empbal.DeptCode;
           

            return emp;

        }



    }
}

