using System;
using System.ComponentModel.DataAnnotations;

namespace LocalMind.Server.Models.Users
{
    public class User
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public Role Role { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
    }

    public enum Role
    {
        Admin,
        Student
    }
}