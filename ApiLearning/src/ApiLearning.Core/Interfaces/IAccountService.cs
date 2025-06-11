using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiLearning.Core.AccountAggregate;

namespace ApiLearning.Core.Interfaces;
public interface IAccountService
{
  public Task<UserDto> GetUserByIdAsync(string id);
  public Task<UserDto> GetUserByEmailAsync(string email);
  public Task<UserDto> RegisterAsync(RegisterDto registerDto);
  public Task<TokenResponse> LoginAsync(LoginDto loginDto);
  public Task<UserDto> LogoutAsync(string id);
  public Task<UserDto> UpdateUserWithIdAsync(string id, UserDtoWithId userDtoWithId);
  public Task<UserDto> UpdateUserAsync(UserDtoWithId userDtoWithId);
}
