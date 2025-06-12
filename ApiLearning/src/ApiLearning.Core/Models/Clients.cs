using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiLearning.Core.Models;
public class Clients:  BaseClass
{
    public string Name { get; set; } = string.Empty; // Client name
    public string Email { get; set; } = string.Empty; // Client email
    public string PhoneNumber { get; set; } = string.Empty; // Client phone number
    public string Address { get; set; } = string.Empty; // Client address
    public string CompanyName { get; set; } = string.Empty; // Company name if applicable
    public List<Projects> Projects { get; set; } = new List<Projects>(); // List of projects associated with the client
                                                                         // Additional properties can be added as needed, such as contact person, notes, etc.
}
