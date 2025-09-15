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
        // PUT: api/employees/{id}
        [HttpPut("{id}")]
        public IActionResult Update(int id, Employee emp)
        {
            var existing = employees.FirstOrDefault(e=>e.Id==id);
            if (existing == null) return NotFound();
            existing.Name = emp.Name;
            existing.Department = emp.Department;
            existing.Salary = emp.Salary;
           
            return NoContent();
        }

        // DELETE: api/employees/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existing = employees.FirstOrDefault(e => e.Id == id);
            if (existing == null) return NotFound();
               employees.Remove(existing); 
            return NoContent();
        }
    }
}

