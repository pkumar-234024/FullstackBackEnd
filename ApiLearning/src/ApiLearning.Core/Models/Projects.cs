using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiLearning.Core.Models;
public class Projects : BaseClass
{
  public string Name { get; set; } = string.Empty;
  public string Description { get; set; } = string.Empty;
  public DateTime StartDate { get; set; } = DateTime.Now;
  public DateTime EndDate { get; set; } = DateTime.Now.AddDays(30);

  public ProjectStatus ProjectStatus { get; set; } = ProjectStatus.NotStarted;
  public PriorityLevel PriorityLevel { get; set; } = PriorityLevel.Medium;

  public int? ClientId { get; set; } // Optional Client I
  public string? ProjectManagerId { get; set; } // Optional Project Manager ID

  public double TotalTimeLogged { get; set; } = 0;

  public virtual List<TeamMember> TeamMembers { get; set; } = new();
  public virtual List<TasksItems> Tasks { get; set; } = new();
}

public enum ProjectStatus
{
  NotStarted,
  Planned,
  InProgress,
  Completed,
  OnHold
}

public enum PriorityLevel
{
  Low,
  Medium,
  High,
  Critical
}

