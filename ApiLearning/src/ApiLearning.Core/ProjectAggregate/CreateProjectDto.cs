using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiLearning.Core.ProjectAggregate;
public class CreateProjectDto
{
  [Required]
  public string Name { get; set; } = string.Empty;
  public string Description { get; set; } = string.Empty;
  public string? RepositoryUrl { get; set; } = null;
  public string? WebsiteUrl { get; set; } = null;
  public bool IsPublic { get; set; } = true;
}
