using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiLearning.Core.AccountAggregate;
using ApiLearning.Core.Interfaces;
using ApiLearning.Core.Models;
using Microsoft.AspNetCore.Identity;

namespace ApiLearning.Core.Services;
public class UserService : IUserService
{
  private readonly UserManager<AppUser> _userManager;

  public UserService(UserManager<AppUser> userManager)
  {
    _userManager = userManager;
  }
  public async Task<UserDto> GetUserByEmailAsync(string email)
  {
    try
    {
      var user = await _userManager.FindByEmailAsync(email);
      if (user == null)
      {
        throw new Exception($"User with email {email} not found.");
      }
      UserDto userDto = new UserDto();
      userDto.Id = user.Id ?? string.Empty; 
      userDto.UserName = user.UserName ?? string.Empty;
      userDto.Email = user.Email ?? string.Empty;
      userDto.FirtsName = user.FirstName ?? string.Empty;
      userDto.LastName = user.LastName ?? string.Empty;
      return userDto;
    }
    catch (Exception ex)
    {
      throw new Exception("An error occurred while getting the user by email.", ex);
    }
  }

  public async Task<UserDto> GetUserByIdAsync(string id)
  {

    try
    {
      var user = await _userManager.FindByIdAsync(id);
      if (user == null)
      {
        throw new Exception($"User with email {id} not found.");
      }
      UserDto userDto = new UserDto();
      userDto.Id = user.Id ?? string.Empty;
      userDto.UserName = user.UserName ?? string.Empty;
      userDto.Email = user.Email ?? string.Empty;
      userDto.FirtsName = user.FirstName ?? string.Empty;
      userDto.LastName = user.LastName ?? string.Empty;
      return userDto;
    }
    catch (Exception ex)
    {
      throw new Exception("An error occurred while getting the user by email.", ex);
    }
  }
}
