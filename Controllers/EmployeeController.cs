using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Basic_Authentication_Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        
        /// <summary>
        /// Get Employees
        /// </summary>
        /// <remarks>
        /// Sample Request:
        /// Get api/GetEmployee
        /// </remarks>
        /// <returns></returns>
        /// <returns>List of Employees</returns>
        /// <response code="201">List of Employees</response>
        /// <response code="400">If the item is null</response> 
        [HttpGet(Name = "GetEmployee")]
        [Produces("application/json")]
        public IEnumerable<Employee> GetEmployee()
        {
            return GetEmployees();
        }


        /// <summary>
        /// Creates an Employee.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST api/Employee
        ///     {        
        ///       "firstName": "Mike",
        ///       "lastName": "Andrew",
        ///       "emailId": "Mike.Andrew@gmail.com"        
        ///     }
        /// </remarks>
        /// <param name="employee"></param>
        /// <returns>A newly created employee</returns>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>  
        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public Employee Post([FromBody] Employee employee)
        {
           
            return employee;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private List<Employee> GetEmployees()
        {
            return new List<Employee>()
            {
                new Employee()
                {
                    Id = 1,
                    FirstName= "John",
                    LastName = "Smith",
                    EmailId ="John.Smith@gmail.com"
                },
                new Employee()
                {
                    Id = 2,
                    FirstName= "Jane",
                    LastName = "Doe",
                    EmailId ="Jane.Doe@gmail.com"
                }
            };
        }
    }
}
