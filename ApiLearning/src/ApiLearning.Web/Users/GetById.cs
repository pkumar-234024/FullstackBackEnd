using ApiLearning.Core.AccountAggregate;
using ApiLearning.UseCases.Users.GetByEmail;
using ApiLearning.UseCases.Users.GetById;

namespace ApiLearning.Web.Users;

public class GetById(IMediator _mediator) :Endpoint<GetUserByIdDto, Result<UserDto>>
{
  public override void Configure()
  {
    Post("/users/getUserById");
    AllowAnonymous();
    Summary(s =>
    {
      s.Summary = "Get User.";
      s.Description = "Get User by Id";
      s.ExampleRequest = new GetUserByIdDto { Id = "edrftgyhujikol" };
    });
  }

  public override async Task HandleAsync(GetUserByIdDto request, CancellationToken cancellationToken)
  {
    var result = await _mediator.Send(new GetUserByIdQuery(request));
    if (result.IsSuccess)
    {
      Response = result.Value;
      return;
    }
  }
}
