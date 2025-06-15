using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiLearning.Core.ProjectAggregate;
public class ProjectDto
{
    public int Id { get; set; } // Assuming Id is required for the DTO
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string? RepositoryUrl { get; set; } = null;
    public string? WebsiteUrl { get; set; } = null;
    public bool IsPublic { get; set; } = true;
}
