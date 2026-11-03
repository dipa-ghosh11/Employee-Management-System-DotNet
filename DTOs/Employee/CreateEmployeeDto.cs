using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.DTOs.Employee
{
    public class CreateEmployeeDto
    {
        [Required]
        [StringLength(20)]
        public string EmployeeCode { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Phone]
        public string? Phone { get; set; }

        [Required]
        [MinLength(8)]
        public string Password { get; set; } = string.Empty;

        [Required]
        public string Role { get; set; } = "employee";

        public string Status { get; set; } = "active";

        [Required]
        [RegularExpression(
            "^[a-fA-F0-9]{24}$",
            ErrorMessage = "DepartmentId must be a valid MongoDB ObjectId."
        )]
        public string DepartmentId { get; set; } = string.Empty;

        [StringLength(100)]
        public string? JobTitle { get; set; }

        [RegularExpression(
            "^[a-fA-F0-9]{24}$",
            ErrorMessage = "ManagerId must be a valid MongoDB ObjectId."
        )]
        public string? ManagerId { get; set; }
    }
}
