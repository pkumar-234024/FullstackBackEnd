using ApiLearning.Core.AccountAggregate;

namespace ApiLearning.UseCases.Users.GetById;
public class GetUserByIdQuery : IQuery<Result<UserDto>>
{
  public GetUserByIdDto _userByIdDto { get; set; }
    public GetUserByIdQuery(GetUserByIdDto userByIdDto)
    {
        _userByIdDto = userByIdDto;
  }
}
