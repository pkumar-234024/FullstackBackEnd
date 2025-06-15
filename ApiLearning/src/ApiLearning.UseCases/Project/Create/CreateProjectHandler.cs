using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiLearning.Core.Interfaces;
using ApiLearning.Core.ProjectAggregate;

namespace ApiLearning.UseCases.Project.Create;
public class CreateProjectHandler : ICommandHandler<CreateProjectCommand, Result<ProjectDto>>
{
  private readonly IProjectService _projectService;
  public CreateProjectHandler(IProjectService projectService)
  {
    // Constructor logic if needed
    _projectService = projectService;
  }
  public async Task<Result<ProjectDto>> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
  {
    var projectResult = await _projectService.CreateProjectAsync(request.CreateProjectDto);
    if (projectResult == null)
    {
      return Result<ProjectDto>.Error("Failed to create the project.");
    }
    return Result<ProjectDto>.Success(projectResult);
  }
}
