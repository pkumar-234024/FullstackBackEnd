namespace ApiLearning.Core.Interfaces;
public interface ITokenService
{
  public Task<string> CreateTokenAsync(string userId, string userName, string email, string role = "User", int expirationMinutes = 60); 
  public Task<string> CreateRefreshTokenAsync(string userId, string userName, string email, int expirationMinutes = 60);  
  public Task<bool> ValidateTokenAsync(string token); 
  public Task<bool> ValidateRefreshTokenAsync(string refreshToken);
  public Task<bool> ValidateRefreshTokenAsync(string refreshToken, string userId);
}
