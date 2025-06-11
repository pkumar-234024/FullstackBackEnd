using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiLearning.Core.AccountAggregate;

namespace ApiLearning.UseCases.Accounts.Create;
public class CreateUserCommand : ICommand<Result<UserDto>>
{
    public RegisterDto _registerUserDto { get; set; }
    public CreateUserCommand(RegisterDto userDto)
    {
    _registerUserDto = userDto;
  }
}
