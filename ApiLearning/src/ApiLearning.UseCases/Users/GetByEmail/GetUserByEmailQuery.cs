using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiLearning.Core.AccountAggregate;

namespace ApiLearning.UseCases.Users.GetByEmail;
public class GetUserByEmailQuery : IQuery<Result<UserDto>>
{
  public UserByEmailDto _userByEmailDto { get; set; }
  public GetUserByEmailQuery(UserByEmailDto userByEmailDto)
    {
    _userByEmailDto = userByEmailDto;
    }
    
}
