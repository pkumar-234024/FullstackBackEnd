using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiLearning.Core.AccountAggregate;

namespace ApiLearning.Core.Interfaces;
public interface IUserService
{
  public Task<UserDto> GetUserByEmailAsync(string email);
  public Task<UserDto> GetUserByIdAsync(string id);
}
