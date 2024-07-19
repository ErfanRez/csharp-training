using CoreLayer.DTOs.Users;
using CoreLayer.Utilities;

namespace CoreLayer.Services.Users
{
    public interface IUserService
    {
        OperationResult RegisterUser(UserRegisterDto registerDto);

        UserDto? LoginUser(LoginUserDto loginUserDto);
    }
}
