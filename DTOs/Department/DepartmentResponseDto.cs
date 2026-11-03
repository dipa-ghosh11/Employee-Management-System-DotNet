namespace EmployeeManagementSystem.DTOs.Department
{
    public class DepartmentResponseDto
    {

        public string Id { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string Code { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public DepartmentBudgetDto? Budget { get; set; }

        public string Status { get; set; } = string.Empty;

        public DepartmentSettingsDto? Settings { get; set; }

        public DepartmentMetadataDto? Metadata { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public int Version { get; set; }
    }

    public class DepartmentBudgetDto
    {
        public int Annual { get; set; }

        public string Currency { get; set; } = string.Empty;
    }

    public class DepartmentSettingsDto
    {
        public bool RemoteAllowed { get; set; }

        public int MaxWorkingHoursPerWeek { get; set; }
    }

    public class DepartmentMetadataDto
    {
        public string CostCenter { get; set; } = string.Empty;

        public string Region { get; set; } = string.Empty;
    }

}
