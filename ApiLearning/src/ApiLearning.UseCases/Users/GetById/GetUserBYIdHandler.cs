using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiLearning.Core.AccountAggregate;
using ApiLearning.Core.Interfaces;

namespace ApiLearning.UseCases.Users.GetById;
public class GetUserBYIdHandler : IQueryHandler<GetUserByIdQuery, Result<UserDto>>
{
  private readonly IUserService _userService;
  public GetUserBYIdHandler(IUserService userService)
  {
    _userService = userService;
  }
  public async Task<Result<UserDto>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
  {
    var user = await _userService.GetUserByIdAsync(request._userByIdDto.Id);
    if(user == null)
    {
      throw new Exception("User not found");
    }
    return Result<UserDto>.Success(user);
  }
}
