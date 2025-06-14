using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiLearning.Core.Models;

namespace ApiLearning.Core.ClientAggregate;
public class ClientDto : ClassByid
{
  public string Name { get; set; } = string.Empty; // Client name
  public string Email { get; set; } = string.Empty; // Client email
  public string PhoneNumber { get; set; } = string.Empty; // Client phone number
  public string Address { get; set; } = string.Empty; // Client address
  public string CompanyName { get; set; } = string.Empty; // Company name if applicable// List of projects associated with the client
}
