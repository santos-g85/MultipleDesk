using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;
 
namespace MultipleDesk.Models
{
    public class UserRegistration
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        [BsonElement("FirstName")]
        [Required(ErrorMessage = "First name is required")]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters")]
        public string FirstName { get; set; } = string.Empty;

        [BsonElement("LastName")]
        [Required(ErrorMessage = "Last name is required")]
        [StringLength(50, ErrorMessage = "Last name cannot be longer than 50 characters")]
        public string LastName { get; set; } = string.Empty;

        [BsonElement("MobileNumber")]
        [Required(ErrorMessage = "Mobile number is required")]
        [Phone(ErrorMessage = "Invalid phone number")]
        [MaxLength(10, ErrorMessage = "Mobile number cannot be longer than 10 characters")]
        [MinLength(10, ErrorMessage = "Mobile number cannot be less than 10 characters")]
        public string MobileNumber { get; set; } = string.Empty;

        [BsonElement("Email")]
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; } = string.Empty;

        [BsonElement("RegistrationDate")]
        public DateTime RegistrationDate { get; set; } = DateTime.UtcNow;
    }
}