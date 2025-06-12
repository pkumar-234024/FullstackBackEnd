using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiLearning.Core.AccountAggregate;
public class GetUserByIdDto
{
  public string Id { get; set; } = string.Empty; // User ID to fetch the user details by ID
}
