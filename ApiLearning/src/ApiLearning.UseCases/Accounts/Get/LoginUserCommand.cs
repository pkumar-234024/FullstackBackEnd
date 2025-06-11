using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiLearning.Core.AccountAggregate;

namespace ApiLearning.UseCases.Accounts.Get;
public class LoginUserCommand :ICommand<Result<TokenResponse>>
{
  public LoginDto _loginUserDto { get; set; }
  public LoginUserCommand(LoginDto loginUserDto)
  {
    _loginUserDto = loginUserDto;
  }
}
