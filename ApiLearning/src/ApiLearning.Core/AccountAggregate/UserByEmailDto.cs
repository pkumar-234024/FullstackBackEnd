using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiLearning.Core.AccountAggregate;
public class UserByEmailDto
{
  public string Email { get; set; } = string.Empty;
}
