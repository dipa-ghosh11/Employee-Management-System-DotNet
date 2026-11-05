using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.DTOs.Department
{
    public class UpdateDepartmentDto
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(10)]
        public string Code { get; set; } = string.Empty;

        [StringLength(500)]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Range(0, 1000000000)]
        public int AnnualBudget { get; set; }

        [Required]
        [StringLength(3, MinimumLength = 3)]
        public string Currency { get; set; } = "USD";

        public bool RemoteAllowed { get; set; }

        [Range(1, 168)]
        public int MaxWorkingHoursPerWeek { get; set; } = 40;

        [StringLength(50)]
        public string CostCenter { get; set; } = string.Empty;

        [StringLength(50)]
        public string Region { get; set; } = string.Empty;

        [Required]
        public string Status { get; set; } = "active"; 
    }
}
