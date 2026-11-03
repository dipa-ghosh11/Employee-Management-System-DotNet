namespace EmployeeManagementSystem.DTOs.Employee
{
    public class EmployeeResponseDto
    {

        public string Id { get; set; } = string.Empty;

        public string EmployeeCode { get; set; } = string.Empty;

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string DisplayName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;

        public string Role { get; set; } = string.Empty;

        public string Status { get; set; } = string.Empty;

        public string DepartmentId { get; set; } = string.Empty;

        public string JobTitle { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }

    }
}
