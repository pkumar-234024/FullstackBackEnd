using ApiLearning.Core.AccountAggregate;
using ApiLearning.Core.Interfaces;
using ApiLearning.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace ApiLearning.Core.Services;
public class AccountService : IAccountService
{
  private readonly UserManager<AppUser> _userManager;
  private readonly ITokenService _tokenService;

  public AccountService(UserManager<AppUser> userManager, ITokenService tokenService)
  {
    _userManager = userManager;
    _tokenService = tokenService;
  }

  public async Task<UserDto> RegisterAsync(RegisterDto registerDto)
  {
    try
    {
      var userDto = new UserDto();
      var user = new AppUser
      {
        UserName = registerDto.Email,
        Email = registerDto.Email,
        FirstName = registerDto.FirstName,
        LastName = registerDto.LastName,
        Address = registerDto.Address,
      };

      var result = await _userManager.CreateAsync(user, registerDto.Password);
      if (!result.Succeeded)
      {
        throw new Exception("User creation failed. Errors: " + string.Join(", ", result.Errors.Select(e => e.Description)));
      }

      var role = string.IsNullOrWhiteSpace(registerDto.UserRole) ? "User" : registerDto.UserRole;
      var roleResult = await _userManager.AddToRoleAsync(user, role);
      if (!roleResult.Succeeded)
      {
        throw new Exception("Role assignment failed. Errors: " + string.Join(", ", roleResult.Errors.Select(e => e.Description)));
      }

      userDto.UserName = user.UserName;
      userDto.Email = user.Email;
      userDto.FirtsName = user.FirstName;
      userDto.LastName = user.LastName;
      userDto.Id = user.Id;

      return userDto;
    }
    catch (Exception ex)
    {
      throw new Exception("An error occurred during registration.", ex);
    }
  }

  [Authorize(Roles = "Admin,User")]
  public async Task<UserDto> GetUserByIdAsync(string id)
  {
    try
    {
      var user = await _userManager.FindByIdAsync(id);
      if (user == null)
      {
        throw new Exception($"User with ID {id} not found.");
      }

      return new UserDto
      {
        UserName = user.UserName!,
        Email = user.Email!
      };
    }
    catch (Exception ex)
    {
      throw new Exception("An error occurred while getting the user by ID.", ex);
    }
  }

  public async Task<TokenResponse> LoginAsync(LoginDto loginDto)
  {
    try
    {
      var user = await _userManager.FindByEmailAsync(loginDto.Email);
      if (user == null)
      {
        throw new Exception("Invalid email or password.");
      }

      var isPasswordValid = await _userManager.CheckPasswordAsync(user, loginDto.Password);
      if (!isPasswordValid)
      {
        throw new Exception("Invalid email or password.");
      }
      var roles = await _userManager.GetRolesAsync(user);
      var role = roles.FirstOrDefault() ?? "User"; // Default to User if no roles assigned  
      string token = await _tokenService.CreateTokenAsync(user.Id, user.UserName!, user.Email!, role!);
      string refreshToken = await _tokenService.CreateRefreshTokenAsync(user.Id, user.UserName!, user.Email!);
      return new TokenResponse
      {
        TokenType = "Bearer",
        AccessToken = token,
        ExpiresAt = DateTime.Now.AddMinutes(60),
        RefreshToken = refreshToken
      };
    }
    catch (Exception ex)
    {
      throw new Exception("An error occurred during login.", ex);
    }
  }

  [Authorize(Roles = "Admin,User")]
  public async Task<UserDto> LogoutAsync(string id)
  {
    try
    {
      var user = await _userManager.FindByIdAsync(id);
      if (user == null)
      {
        throw new Exception($"User with ID {id} not found.");
      }

      return new UserDto
      {
        UserName = user.UserName!,
        Email = user.Email!
      };
    }
    catch (Exception ex)
    {
      throw new Exception("An error occurred during logout.", ex);
    }
  }

  [Authorize(Roles = "Admin,User")]
  public async Task<UserDto> GetUserByEmailAsync(string email)
  {
    try
    {
      var user = await _userManager.FindByEmailAsync(email);
      if (user == null)
      {
        throw new Exception($"User with email {email} not found.");
      }

      return new UserDto
      {
        UserName = user.UserName!,
        Email = user.Email!
      };
    }
    catch (Exception ex)
    {
      throw new Exception("An error occurred while getting the user by email.", ex);
    }
  }

  [Authorize(Roles = "Admin,User")]
  public async Task<UserDto> UpdateUserAsync(UserDtoWithId userDtoWithId)
  {
    try
    {
      var user = await _userManager.FindByIdAsync(userDtoWithId.Id);
      if (user == null)
      {
        throw new Exception($"User with ID {userDtoWithId.Id} not found.");
      }

      user.UserName = userDtoWithId.UserName;
      user.Email = userDtoWithId.Email;

      var result = await _userManager.UpdateAsync(user);
      if (!result.Succeeded)
      {
        throw new Exception("User update failed. Errors: " + string.Join(", ", result.Errors.Select(e => e.Description)));
      }

      return new UserDto
      {
        UserName = user.UserName,
        Email = user.Email
      };
    }
    catch (Exception ex)
    {
      throw new Exception("An error occurred while updating the user.", ex);
    }
  }

  [Authorize(Roles = "Admin,User")]
  public async Task<UserDto> UpdateUserWithIdAsync(string id, UserDtoWithId userDtoWithId)
  {
    try
    {
      if (id != userDtoWithId.Id)
      {
        throw new Exception("ID mismatch between path and body.");
      }

      var user = await _userManager.FindByIdAsync(id);
      if (user == null)
      {
        throw new Exception($"User with ID {id} not found.");
      }

      user.UserName = userDtoWithId.UserName;
      user.Email = userDtoWithId.Email;

      var result = await _userManager.UpdateAsync(user);
      if (!result.Succeeded)
      {
        throw new Exception("User update failed. Errors: " + string.Join(", ", result.Errors.Select(e => e.Description)));
      }

      return new UserDto
      {
        UserName = user.UserName,
        Email = user.Email
      };
    }
    catch (Exception ex)
    {
      throw new Exception("An error occurred while updating the user.", ex);
    }
  }
}
