using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiLearning.Core.AccountAggregate;
using ApiLearning.Core.Interfaces;

namespace ApiLearning.UseCases.Users.GetByEmail;
public class GetUserByEmailHadler : IQueryHandler<GetUserByEmailQuery, Result<UserDto>>
{
  private readonly IUserService _userService;
  public GetUserByEmailHadler(IUserService userService)
  {
    _userService = userService;
  }
  public async Task<Result<UserDto>> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
  {
    try
    {
      var user = await _userService.GetUserByEmailAsync(request._userByEmailDto.Email);
      if(user == null)
      {
        return Result.NotFound();
      }
      return Result<UserDto>.Success(user);
    }
    catch(Exception ex)
    {
      throw new Exception(ex.Message);
    }
  }
}
