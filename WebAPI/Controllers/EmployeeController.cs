using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPIDemo.Models;

namespace WebAPIDemo.Controllers
{
    public class EmployeeController : ApiController
    {

        Employee[] employees = new Employee[]{
         new Employee { ID = 1, Name = "Mark", JoiningDate =
            DateTime.Parse(DateTime.Today.ToString()), Age = 30 },
         new Employee { ID = 2, Name = "Allan", JoiningDate =
            DateTime.Parse(DateTime.Today.ToString()), Age = 35 },
         new Employee { ID = 3, Name = "Johny", JoiningDate =
            DateTime.Parse(DateTime.Today.ToString()), Age = 21 }
      };

        public IEnumerable<Employee> GetAllEmployees()
        {
            return employees;
        }

        public IHttpActionResult GetEmployee(int id)
        {
            var employee = employees.FirstOrDefault((p) => p.ID == id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }
    }
}
