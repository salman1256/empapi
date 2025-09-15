using Microsoft.AspNetCore.Mvc;
using EmployeeApi.Models;

namespace EmployeeApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private static List<Employee> employees = new List<Employee>
        {
            new Employee { Id = 1, Name = "Sam", Department = "HR", Salary = 99000 },
            new Employee { Id = 2, Name = "Ravi", Department = "IT", Salary = 86000 },
        };

        [HttpGet]
        public ActionResult<IEnumerable<Employee>> GetAll()
        {
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public ActionResult<Employee> GetById(int id)
        {
            var emp = employees.FirstOrDefault(e => e.Id == id);
            if (emp == null) return NotFound();
            return Ok(emp);
        }

        [HttpPost]
        public ActionResult<Employee> Create(Employee emp)
        {
            emp.Id = employees.Max(e => e.Id) + 1;
            employees.Add(emp);
            return CreatedAtAction(nameof(GetById), new { id = emp.Id }, emp);
        }
    }
}
