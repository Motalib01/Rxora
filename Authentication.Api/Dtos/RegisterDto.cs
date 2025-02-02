using System.ComponentModel.DataAnnotations;

namespace Authentication.Api.Dtos
{
    public class RegisterDto
    {
        [Required] public string FullName { get; set; }
        [Required][EmailAddress] public string Email { get; set; }
        [Required] public string Password { get; set; }
        [Required] public string Role { get; set; }
    }
}
