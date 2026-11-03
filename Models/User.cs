using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace EmployeeManagementSystem.Models
{
    [BsonIgnoreExtraElements]
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        [BsonElement("employeeCode")]
        public string EmployeeCode { get; set; } = string.Empty;

        [BsonElement("firstName")]
        public string FirstName { get; set; } = string.Empty;

        [BsonElement("lastName")]
        public string LastName { get; set; } = string.Empty;

        [BsonElement("displayName")]
        public string DisplayName { get; set; } = string.Empty;

        [BsonElement("email")]
        public string Email { get; set; } = string.Empty;

        [BsonElement("phone")]
        public string Phone { get; set; } = string.Empty;

        [BsonElement("passwordHash")]
        public string PasswordHash { get; set; } = string.Empty;

        [BsonElement("role")]
        public string Role { get; set; } = string.Empty;

        [BsonElement("status")]
        public string Status { get; set; } = string.Empty;

        [BsonElement("departmentId")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string DepartmentId { get; set; } = string.Empty;

        [BsonElement("managerId")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? ManagerId { get; set; }

        [BsonElement("profile")]
        public UserProfile? Profile { get; set; }

        [BsonElement("address")]
        public UserAddress? Address { get; set; }

        [BsonElement("preferences")]
        public UserPreferences? Preferences { get; set; }

        [BsonElement("security")]
        public UserSecurity? Security { get; set; }

        [BsonElement("tags")]
        public List<string> Tags { get; set; } = new();

        [BsonElement("metadata")]
        public UserMetadata? Metadata { get; set; }

        [BsonElement("createdAt")]
        public DateTime CreatedAt { get; set; }

        [BsonElement("updatedAt")]
        public DateTime UpdatedAt { get; set; }

        [BsonElement("deletedAt")]
        public DateTime? DeletedAt { get; set; }

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
    public class UserProfile
    {
        [BsonElement("jobTitle")]
        public string JobTitle { get; set; } = string.Empty;

        [BsonElement("avatarUrl")]
        public string AvatarUrl { get; set; } = string.Empty;

        [BsonElement("timezone")]
        public string Timezone { get; set; } = string.Empty;
    }

    [BsonIgnoreExtraElements]
    public class UserAddress
    {
        [BsonElement("country")]
        public string Country { get; set; } = string.Empty;

        [BsonElement("countryCode")]
        public string CountryCode { get; set; } = string.Empty;

        [BsonElement("city")]
        public string City { get; set; } = string.Empty;

        [BsonElement("postalCode")]
        public string PostalCode { get; set; } = string.Empty;
    }

    [BsonIgnoreExtraElements]
    public class UserPreferences
    {
        [BsonElement("language")]
        public string Language { get; set; } = string.Empty;

        [BsonElement("theme")]
        public string Theme { get; set; } = string.Empty;

        [BsonElement("notifications")]
        public UserNotifications? Notifications { get; set; }
    }

    [BsonIgnoreExtraElements]
    public class UserNotifications
    {
        [BsonElement("email")]
        public bool Email { get; set; }

        [BsonElement("push")]
        public bool Push { get; set; }

        [BsonElement("sms")]
        public bool Sms { get; set; }
    }

    [BsonIgnoreExtraElements]
    public class UserSecurity
    {
        [BsonElement("emailVerified")]
        public bool EmailVerified { get; set; }

        [BsonElement("mfaEnabled")]
        public bool MfaEnabled { get; set; }

        [BsonElement("failedLoginAttempts")]
        public int FailedLoginAttempts { get; set; }

        [BsonElement("lastLoginAt")]
        public DateTime? LastLoginAt { get; set; }

        [BsonElement("passwordChangedAt")]
        public DateTime? PasswordChangedAt { get; set; }
    }

    [BsonIgnoreExtraElements]
    public class UserMetadata
    {
        [BsonElement("source")]
        public string Source { get; set; } = string.Empty;

        [BsonElement("imported")]
        public bool Imported { get; set; }

        [BsonElement("employeeLevel")]
        public int EmployeeLevel { get; set; }
    }
}
