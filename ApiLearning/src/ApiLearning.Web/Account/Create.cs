using ApiLearning.Core.AccountAggregate;
using ApiLearning.UseCases.Accounts.Create;
using ApiLearning.UseCases.Contributors.Create;
using ApiLearning.Web.Contributors;

namespace ApiLearning.Web.Account;

public class Create(IMediator _mediator) : Endpoint<RegisterDto, UserDto>
{


  public override void Configure()
  {
    Post("/users/create");
    AllowAnonymous();
    Summary(s =>
    {
      s.Summary = "Create a new User.";
      s.Description = "Creates a new User given registration details.";
      s.ExampleRequest = new RegisterDto { Email = "test@123", FirstName = "FirstName", LastName = "LastName", Password = "Password@123", ConfirmPassword = "Password@123", PhoneNumber = "1234567890", Address = "123 Main St" };
    });
  }

  public override async Task HandleAsync(
    RegisterDto request,
    CancellationToken cancellationToken)
  {
    var result = await _mediator.Send(new CreateUserCommand(request));

    if (result.IsSuccess)
    {
      Response = result;
      return;
    }
    // TODO: Handle other cases as necessary
  }
}
