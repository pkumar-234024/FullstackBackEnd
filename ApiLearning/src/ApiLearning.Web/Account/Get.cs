using ApiLearning.Core.AccountAggregate;
using ApiLearning.UseCases.Accounts.Get;

namespace ApiLearning.Web.Account;

public class Get(IMediator _mediator) : Endpoint<LoginDto, TokenResponse>
{
  public override void Configure()
  {
    Post("/users/login");
    AllowAnonymous();
    Summary(s =>
    {
      s.Summary = "Login a User.";
      s.Description = "Logs in a User given login details.";
      s.ExampleRequest = new LoginDto { Email = "test@123", Password = "Password@123" };
    });
  }

  public override async Task HandleAsync(LoginDto request, CancellationToken cancellationToken)
  {
    var result = await _mediator.Send(new LoginUserCommand(request));
    if (result.IsSuccess)
    {
      Response = result;
      return;
    }
  }
}
