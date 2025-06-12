using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiLearning.Core.Models;
public class TasksItems : BaseClass
{
    public string Name { get; set; } = string.Empty; // Task name
    public string Description { get; set; } = string.Empty; // Task description
    public DateTime StartDate { get; set; } = DateTime.Now; // Task start date
    public DateTime EndDate { get; set; } = DateTime.Now.AddDays(7); // Default to 7 days from start date
    public string Status { get; set; } = "Not Started"; // Default status
    public string Priority { get; set; } = "Medium"; // Default priority
    public string ProjectId { get; set; } = string.Empty; // Associated project ID
    public string AssignedToUserId { get; set; } = string.Empty; // User ID of the person assigned to the task
    public double EstimatedHours { get; set; } = 0; // Estimated hours for task completion
    public double LoggedHours { get; set; } = 0; // Hours logged against the task
}
