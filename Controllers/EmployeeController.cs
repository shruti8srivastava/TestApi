using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TestApi.DataBase;
using TestApi.DTO;
using TestApi.Model;
using TestApi.Service;

namespace TestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly EmployeeService _employeeService;
        public EmployeeController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            // Fetch all employees from the database
            var employees = _employeeService.GetAllEmployees();
            return Ok(employees);
        }
        [HttpPost]
        public IActionResult EmpDetails(EmployeeDTO employeeDTO){
            if(string.IsNullOrEmpty(employeeDTO.USER_NAME)){
                return BadRequest("User Name cannot be Null");
            }
            EmployeeModel employeeModel = new EmployeeModel {
                ID = employeeDTO.ID,
                USER_NAME = $"Hello {employeeDTO.USER_NAME}!" };
            
            return Ok(employeeDTO);

        }
    }
}
