using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleAPI.DataAccessLayer.Interface;
using SampleAPI.DataAccessLayer.Models;

namespace SampleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetEmployees()
        {
            return Ok(_employeeRepository.GetEmployees());
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetEmployee([FromQuery] int id)
        {
            Employee employee = _employeeRepository.GetEmployeeById(id);
            if (employee != null)
                return Ok(employee);
            else
                return BadRequest("Employee is not found");
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult AddEmployee(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Employee Model is Invalide");
            }

            if (_employeeRepository.AddEmployee(employee))
            {
                return Ok("Employee added successfully");
            }
            else
            {
                return BadRequest("Employee is not added");
            }
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult UpdateEmployee(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Employee Model is Invalide");
            }

            if (_employeeRepository.UpdateEmployee(employee))
            {
                return Ok("Employee updated successfully");
            }
            else
            {
                return BadRequest("Employee is not updated");
            }
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult DeleteEmployee([FromQuery] int id)
        {
            Employee employee = _employeeRepository.GetEmployeeById(id);

            if (employee == null) { return BadRequest("Employee is not found"); }

            if (_employeeRepository.DeleteEmployee(employee))
            {
                return Ok("Employee deleted successfully");
            }
            else
            {
                return BadRequest("Employee is not updated");
            }
        }
    }
}
