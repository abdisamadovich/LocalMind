using LocalMind.Server.Models.UserAdditionalDetails;
using LocalMind.Server.Models.Users;
using System.ComponentModel.DataAnnotations;

namespace LocalMind.Server.DTOs;

public class UserDto
{
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

    public UserAdditionalDetail UserAdditionalDetail { get; set; }
}
