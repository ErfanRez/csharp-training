using CoreLayer.DTOs.Users;
using CoreLayer.Utilities;
using DataLayer.Entities;

namespace CoreLayer.Services.Users
{
    public interface IUserService
    {
        OperationResult EditUser(EditUserDto command);
        OperationResult RegisterUser(UserRegisterDto registerDto);
        UserDto LoginUser(LoginUserDto loginDto);
        UserDto GetUserById(int userId);
        UserFilterDto GetUsersByFilter(int pageId, int take);
    }
}