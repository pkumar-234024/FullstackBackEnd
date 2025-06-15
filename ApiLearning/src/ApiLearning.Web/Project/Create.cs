using ApiLearning.Core.AccountAggregate;
using ApiLearning.Core.ProjectAggregate;
using ApiLearning.UseCases.Accounts.Create;
using ApiLearning.UseCases.Project.Create;
using Microsoft.AspNetCore.Authorization;

namespace ApiLearning.Web.Project;

public class Create(IMediator _mediator) : Endpoint<CreateProjectDto, Result<ProjectDto>>
{
  public override void Configure()
  {
    Post("/project/create");
    Roles("Admin", "SuperAdmin");
    Summary(s =>
    {
      s.Summary = "Create a new Project.";
      s.Description = "Creates a new project with project details.";
      s.ExampleRequest = new CreateProjectDto { Name="project name", Description="project description", WebsiteUrl="https://project.com", RepositoryUrl= "https://projectrepo.com", IsPublic=true};
    });
  }

  public override async Task HandleAsync(
    CreateProjectDto request,
    CancellationToken cancellationToken)
  {
    var result = await _mediator.Send(new CreateProjectCommand(request));

    if (result.IsSuccess)
    {
      Response = result;
      return;
    }
    // TODO: Handle other cases as necessary
  }
}
