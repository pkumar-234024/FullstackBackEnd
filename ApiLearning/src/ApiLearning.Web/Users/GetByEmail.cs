using ApiLearning.Core.AccountAggregate;
using ApiLearning.UseCases.Users.GetByEmail;

namespace ApiLearning.Web.Users;

public class GetByEmail(IMediator _mediator) : Endpoint<UserByEmailDto, Result<UserDto>>
{
  public override void Configure()
  {
    Get("/users/getUserByEmail");
    Roles("User", "Admin");
    Summary(s =>
    {
      s.Summary = "Get User.";
      s.Description = "Get User By Email";
      s.ExampleRequest = new UserByEmailDto { Email = "user2@123"};
    });
  }

  public override async Task HandleAsync(UserByEmailDto request, CancellationToken cancellationToken)
  {
    var result = await _mediator.Send(new GetUserByEmailQuery(request));
    if (result.IsSuccess)
    {
      Response = result.Value;
      return;
    }
  }
}
