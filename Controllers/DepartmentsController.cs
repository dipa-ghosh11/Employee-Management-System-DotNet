using EmployeeManagementSystem.DTOs.Department;
using EmployeeManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentsController : ControllerBase
    {
        private readonly DepartmentService _departmentService;

        public DepartmentsController(DepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        // GET: api/departments
        [HttpGet]
        [ProducesResponseType(
            typeof(List<DepartmentResponseDto>),
            StatusCodes.Status200OK)]
        public async Task<ActionResult<List<DepartmentResponseDto>>> GetAllDepartments(
            CancellationToken cancellationToken)
        {
            var departments = await _departmentService
                .GetAllDepartmentsAsync(cancellationToken);

            return Ok(departments);
        }

        // GET: api/departments/{id}
        [HttpGet("{id}")]
        [ProducesResponseType(
            typeof(DepartmentResponseDto),
            StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DepartmentResponseDto>> GetDepartmentById(
            string id,
            CancellationToken cancellationToken)
        {
            var department = await _departmentService
                .GetDepartmentByIdAsync(id, cancellationToken);

            if (department == null)
            {
                return NotFound(new
                {
                    message = "Department not found."
                });
            }

            return Ok(department);
        }


        // POST: api/departments

        [HttpPost]
        public async Task<IActionResult> CreateDepartment(
        [FromBody] CreateDepartmentDto dto,
        CancellationToken cancellationToken)
        {
            try
            {
                var department = await _departmentService.CreateDepartmentAsync(
                    dto, cancellationToken);

                return CreatedAtAction(
                    nameof(GetDepartmentById),
                    new { id = department.Id },
                    department);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // PUT: 
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDepartment(
    string id,
    [FromBody] UpdateDepartmentDto dto,
    CancellationToken cancellationToken)
        {
            try
            {
                var department = await _departmentService.UpdateDepartmentAsync(
                    id, dto, cancellationToken);

                if (department == null)
                {
                    return NotFound(new { message = "Department not found." });
                }

                return Ok(department);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // DELETE: api/departments/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(
    string id,
    CancellationToken cancellationToken)
        {
            var isDeleted = await _departmentService.DeleteDepartmentAsync(
                id, cancellationToken);

            if (!isDeleted)
            {
                return NotFound(new { message = "Department not found." });
            }

            return NoContent();
        }

    }
}
