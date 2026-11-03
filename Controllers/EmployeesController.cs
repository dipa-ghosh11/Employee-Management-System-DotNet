using EmployeeManagementSystem.DTOs.Employee;
using EmployeeManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;


namespace EmployeeManagementSystem.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeeService _employeeService;

        public EmployeesController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        // GET: api/employees
        [HttpGet]
        [ProducesResponseType(typeof(List<EmployeeResponseDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<EmployeeResponseDto>>> GetAllEmployees(
            CancellationToken cancellationToken)
        {
            var employees = await _employeeService.GetAllEmployeesAsync(
                cancellationToken);

            return Ok(employees);
        }

        // GET: api/employees/{id}
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(EmployeeResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EmployeeResponseDto>> GetEmployeeById(
            string id,
            CancellationToken cancellationToken)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(
                id,
                cancellationToken);

            if (employee == null)
            {
                return NotFound(new
                {
                    message = "Employee not found."
                });
            }

            return Ok(employee);
        }


        //POST: api/
        [HttpPost]
        [ProducesResponseType(typeof(EmployeeResponseDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<EmployeeResponseDto>> CreateEmployee(
            [FromBody] CreateEmployeeDto dto,
            CancellationToken cancellationToken)
        {
            try
            {
                var employee = await _employeeService.CreateEmployeeAsync(
                    dto,
                    cancellationToken);

                return CreatedAtAction(
                    nameof(GetEmployeeById),
                    new { id = employee.Id },
                    employee);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // PUT: api/employees/{id}
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(EmployeeResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EmployeeResponseDto>> UpdateEmployee(
            string id,
            [FromBody] UpdateEmployeeDto dto,
            CancellationToken cancellationToken)
        {
            try
            {
                var employee = await _employeeService.UpdateEmployeeAsync(
                    id,
                    dto,
                    cancellationToken);

                if (employee == null)
                {
                    return NotFound(new { message = "Employee not found." });
                }

                return Ok(employee);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }


        // DELETE: api/employees/{id}

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteEmployee(
            string id,
            CancellationToken cancellationToken)
        {
            var isDeleted = await _employeeService.DeleteEmployeeAsync(
                id,
                cancellationToken);

            if (!isDeleted)
            {
                return NotFound(new { message = "Employee not found." });
            }

            return NoContent();
        }



    }
}
