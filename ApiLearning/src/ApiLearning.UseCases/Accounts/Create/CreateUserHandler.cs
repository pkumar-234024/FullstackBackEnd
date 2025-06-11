using ApiLearning.Core.AccountAggregate;
using ApiLearning.Core.Interfaces;

namespace ApiLearning.UseCases.Accounts.Create;
public class CreateUserHandler : ICommandHandler<CreateUserCommand, Result<UserDto>>
{
    private readonly IAccountService _accountService;
    public CreateUserHandler(IAccountService accountService)
    {
        _accountService = accountService;
    }
    public async Task<Result<UserDto>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var userDto = await _accountService.RegisterAsync(request._registerUserDto);
        return Result<UserDto>.Success(userDto);
    }
}
