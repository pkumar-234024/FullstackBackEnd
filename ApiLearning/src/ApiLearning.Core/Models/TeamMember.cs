using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiLearning.Core.Models;
public class TeamMember : BaseClass
{
    public string UserId { get; set; } = string.Empty; // Assuming UserId is a string, could be a User ID or similar
    public string ProjectId { get; set; } = string.Empty; // Assuming ProjectId is a string, could be a Project ID or similar
    public string Role { get; set; } = "Member"; // Default role, can be changed as needed
                                                 // Navigation properties can be added if needed for relationships with User or Project entities
}
