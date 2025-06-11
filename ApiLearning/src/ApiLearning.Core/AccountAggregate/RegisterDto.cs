using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiLearning.Core.AccountAggregate;
public class RegisterDto
{
  [Required]
  public string FirstName { get; set; } = string.Empty;

  [Required]
  public string LastName { get; set; } = string.Empty;

  [Required]
  public string Email { get; set; } = string.Empty;

  [Required]
  public string Password { get; set; } = string.Empty;

  [Required]
  public string ConfirmPassword { get; set; } = string.Empty;

  [Required]
  public string PhoneNumber { get; set; } = string.Empty;

  [Required]
  public string Address { get; set; } = string.Empty;

  public string UserRole { get; set; } = "User"; // Default role is User, can be overridden by the client

}
