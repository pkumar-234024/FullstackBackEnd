using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiLearning.Core.ProjectAggregate;

namespace ApiLearning.UseCases.Project.Create;
public class CreateProjectCommand :ICommand<Result<ProjectDto>>
{
 public CreateProjectDto CreateProjectDto { get; }
  public CreateProjectCommand(CreateProjectDto createProjectDto)
  {
    CreateProjectDto = createProjectDto;
  }
}
