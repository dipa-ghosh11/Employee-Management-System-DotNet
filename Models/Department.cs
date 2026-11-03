using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EmployeeManagementSystem.Models
{
    [BsonIgnoreExtraElements]
    public class Department
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        [BsonElement("name")]
        public string Name { get; set; } = string.Empty;

        [BsonElement("code")]
        public string Code { get; set; } = string.Empty;

        [BsonElement("description")]
        public string Description { get; set; } = string.Empty;

        [BsonElement("budget")]
        public DepartmentBudget? Budget { get; set; }

        [BsonElement("status")]
        public string Status { get; set; } = string.Empty;

        [BsonElement("settings")]
        public DepartmentSettings? Settings { get; set; }

        [BsonElement("metadata")]
        public DepartmentMetadata? Metadata { get; set; }

        [BsonElement("createdAt")]
        public DateTime CreatedAt { get; set; }

        [BsonElement("updatedAt")]
        public DateTime UpdatedAt { get; set; }

        [BsonElement("createdBy")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? CreatedBy { get; set; }

        [BsonElement("updatedBy")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? UpdatedBy { get; set; }

        [BsonElement("version")]
        public int Version { get; set; }
    }

    [BsonIgnoreExtraElements]
    public class DepartmentBudget
    {
        [BsonElement("annual")]
        public int Annual { get; set; }

        [BsonElement("currency")]
        public string Currency { get; set; } = string.Empty;
    }

    [BsonIgnoreExtraElements]
    public class DepartmentSettings
    {
        [BsonElement("remoteAllowed")]
        public bool RemoteAllowed { get; set; }

        [BsonElement("maxWorkingHoursPerWeek")]
        public int MaxWorkingHoursPerWeek { get; set; }
    }

    [BsonIgnoreExtraElements]
    public class DepartmentMetadata
    {
        [BsonElement("costCenter")]
        public string CostCenter { get; set; } = string.Empty;

        [BsonElement("region")]
        public string Region { get; set; } = string.Empty;
    }
}
