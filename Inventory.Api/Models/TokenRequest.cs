using System.ComponentModel.DataAnnotations;

namespace Inventory.Api.Models;

public class TokenRequest
{
    [Required]
    public string Username { get; set; }

    [Required]
    public string Password { get; set; }        

}
