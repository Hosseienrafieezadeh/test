using Apps.Services.ApplicationUsers.Contracts.Dtos;
using System.Threading.Tasks;

namespace Apps.Services.ApplicationUsers.Contracts
{
    public interface AuthService
    {
  
        Task<AuthServiceResponseDto> SeedRolesAsync();
        Task<AuthServiceResponseDto> RegisterAsync(RegisterDto registerDto);
        Task<AuthServiceResponseDto> LoginAsync(LoginDto loginDto);
        Task<AuthServiceResponseDto> MakeAdminAsync(UpdatePermissionDto updatePermissionDto);
        Task<AuthServiceResponseDto> MakeOwnerAsync(UpdatePermissionDto updatePermissionDto);
        Task<AuthServiceResponseDto> GetUserByIdAsync(string userId);
        Task<AuthServiceResponseDto> UpdateUserAsync(UpdateUserDto updateUserDto);
        Task<AuthServiceResponseDto> DeleteUserAsync(string userName);
    }
}
