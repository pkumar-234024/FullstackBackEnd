using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiLearning.Core.AccountAggregate;
public class UserDto
{
  public string UserName { get; set; } = string.Empty;
  public string Email { get; set; } = string.Empty;
  public string Id { get; set; } = string.Empty;
  public string FirtsName { get; set; } = string.Empty;
  public string LastName { get; set; } = string.Empty;

}
