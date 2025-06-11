using ApiLearning.Core.AccountAggregate;
using ApiLearning.Core.Interfaces;

namespace ApiLearning.UseCases.Accounts.Get;
public class LoginUserHandler : ICommandHandler<LoginUserCommand, Result<TokenResponse>>
{
  private readonly IAccountService _accountService;
  public LoginUserHandler(IAccountService accountService)
  {
    _accountService = accountService;
  }
  public async Task<Result<TokenResponse>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
  {
    try
    {
      var response = await _accountService.LoginAsync(request._loginUserDto);
      return Result<TokenResponse>.Success(response);
    }
    catch (Exception ex)
    {
      // Log the exception (not implemented here)
      throw new Exception(ex.Message);
    }
  }
}
