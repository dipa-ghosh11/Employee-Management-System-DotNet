
using EmployeeManagementSystem.DTOs.Department;
using EmployeeManagementSystem.Models;
using MongoDB.Driver;

namespace EmployeeManagementSystem.Services
{
    public class DepartmentService
    {

        private readonly IMongoCollection<Department> _departments;

        public DepartmentService(IMongoDatabase database)
        {
            _departments = database.GetCollection<Department>("departments");
        }

        // Get all departments
        public async Task<List<DepartmentResponseDto>> GetAllDepartmentsAsync(
            CancellationToken cancellationToken = default)
        {
            var departments = await _departments
                .Find(_ => true)
                .ToListAsync(cancellationToken);

            return departments.Select(MapToResponse).ToList();
        }

        // Get department by ID
        public async Task<DepartmentResponseDto?> GetDepartmentByIdAsync(
            string id,
            CancellationToken cancellationToken = default)
        {
            if (!MongoDB.Bson.ObjectId.TryParse(id, out _))
            {
                return null;
            }

            var department = await _departments
                .Find(dept => dept.Id == id)
                .FirstOrDefaultAsync(cancellationToken);

            return department == null ? null : MapToResponse(department);
        }

        // Create a new department
        public async Task<DepartmentResponseDto> CreateDepartmentAsync(
    CreateDepartmentDto dto,
    CancellationToken cancellationToken = default)
        {
            // Check whether department name already exists
            var existingDepartment = await _departments
                .Find(dept =>
                    dept.Name.ToLower() == dto.Name.ToLower() ||
                    dept.Code.ToLower() == dto.Code.ToLower())
                .FirstOrDefaultAsync(cancellationToken);

            if (existingDepartment != null)
            {
                throw new InvalidOperationException(
                    "A department with this name or code already exists.");
            }

            var department = new Department
            {
                Id = MongoDB.Bson.ObjectId.GenerateNewId().ToString(),

                Name = dto.Name.Trim(),
                Code = dto.Code.Trim().ToUpper(),
                Description = dto.Description,

                Budget = new DepartmentBudget
                {
                    Annual = dto.AnnualBudget,
                    Currency = dto.Currency.ToUpper()
                },

                Status = "active",

                Settings = new DepartmentSettings
                {
                    RemoteAllowed = dto.RemoteAllowed,
                    MaxWorkingHoursPerWeek = dto.MaxWorkingHoursPerWeek
                },

                Metadata = new DepartmentMetadata
                {
                    CostCenter = dto.CostCenter,
                    Region = dto.Region
                },

                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Version = 1
            };

            await _departments.InsertOneAsync(
                department,
                cancellationToken: cancellationToken);

            return MapToResponse(department);
        }

        // Update an existing department
        public async Task<DepartmentResponseDto?> UpdateDepartmentAsync(
    string id,
    UpdateDepartmentDto dto,
    CancellationToken cancellationToken = default)
        {
            // Validate MongoDB ObjectId
            if (!MongoDB.Bson.ObjectId.TryParse(id, out _))
            {
                return null;
            }

            // Find existing department
            var department = await _departments
                .Find(dept => dept.Id == id)
                .FirstOrDefaultAsync(cancellationToken);

            if (department == null)
            {
                return null;
            }

            // Check whether another department uses the same name or code
            var duplicateDepartment = await _departments
                .Find(dept =>
                    dept.Id != id &&
                    (dept.Name.ToLower() == dto.Name.ToLower() ||
                     dept.Code.ToLower() == dto.Code.ToLower()))
                .FirstOrDefaultAsync(cancellationToken);

            if (duplicateDepartment != null)
            {
                throw new InvalidOperationException(
                    "Another department with this name or code already exists.");
            }

            // Update department fields
            department.Name = dto.Name.Trim();
            department.Code = dto.Code.Trim().ToUpper();
            department.Description = dto.Description;

            department.Budget = new DepartmentBudget
            {
                Annual = dto.AnnualBudget,
                Currency = dto.Currency.ToUpper()
            };

            department.Status = dto.Status.ToLower();

            department.Settings = new DepartmentSettings
            {
                RemoteAllowed = dto.RemoteAllowed,
                MaxWorkingHoursPerWeek = dto.MaxWorkingHoursPerWeek
            };

            department.Metadata = new DepartmentMetadata
            {
                CostCenter = dto.CostCenter,
                Region = dto.Region
            };

            department.UpdatedAt = DateTime.UtcNow;
            department.Version++;

            // Save changes
            await _departments.ReplaceOneAsync(
                dept => dept.Id == id,
                department,
                cancellationToken: cancellationToken);

            return MapToResponse(department);
        }

        // Delete Department
        public async Task<bool> DeleteDepartmentAsync(
    string id,
    CancellationToken cancellationToken = default)
        {
            // Validate MongoDB ObjectId
            if (!MongoDB.Bson.ObjectId.TryParse(id, out _))
            {
                return false;
            }

            // Delete department
            var result = await _departments.DeleteOneAsync(
                dept => dept.Id == id,
                cancellationToken);

            return result.DeletedCount > 0;
        }

        // Map Department model to response DTO
        private static DepartmentResponseDto MapToResponse(Department department)
        {
            return new DepartmentResponseDto
            {
                Id = department.Id,
                Name = department.Name,
                Code = department.Code,
                Description = department.Description,

                Budget = department.Budget == null ? null : new DepartmentBudgetDto
                {
                    Annual = department.Budget.Annual,
                    Currency = department.Budget.Currency
                },

                Status = department.Status,

                Settings = department.Settings == null ? null : new DepartmentSettingsDto
                {
                    RemoteAllowed = department.Settings.RemoteAllowed,
                    MaxWorkingHoursPerWeek = department.Settings.MaxWorkingHoursPerWeek
                },

                Metadata = department.Metadata == null ? null : new DepartmentMetadataDto
                {
                    CostCenter = department.Metadata.CostCenter,
                    Region = department.Metadata.Region
                },

                CreatedAt = department.CreatedAt,
                UpdatedAt = department.UpdatedAt,
                Version = department.Version
            };
        }
    }
}
