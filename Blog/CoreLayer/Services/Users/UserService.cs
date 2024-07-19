using CoreLayer.DTOs.Users;
using CoreLayer.Utilities;
using DAL.Context;
using DAL.Entities;

namespace CoreLayer.Services.Users
{
    public class UserService : IUserService
    {
        private readonly DB _context;

        public UserService(DB context)
        {
            _context = context;
        }

        public OperationResult RegisterUser(UserRegisterDto registerDto)
        {
            var Duplicate = _context.Users.Any(u => u.Username == registerDto.Username);
            if (Duplicate) return OperationResult.Error("نام کاربری تکراری است");

            var hashedPwd = registerDto.Password.EncodeToMd5();
            var newUser = _context.Users.Add(new User()
            {
                Fullname = registerDto.Fullname,
                Username = registerDto.Username,
                IsDeleted = false,
                Role = UserRole.User,
                CreatedAt = DateTime.Now,
                Password = hashedPwd,

            });

            _context.SaveChanges();

            return OperationResult.Success();
        }

        public UserDto? LoginUser(LoginUserDto loginDto)
        {
            var hashedPwd = loginDto.Password.EncodeToMd5();
            var user = _context.Users.FirstOrDefault(u => u.Username == loginDto.UserName && u.Password == hashedPwd);

            if(user == null) return null;

            UserDto userDto = new()
            {
                Id = user.Id,
                Fullname = user.Fullname,
                Password = user.Password,
                Role = user.Role,
                Username = user.Username,
                CreatedAt = user.CreatedAt,
            };

            return userDto;


        }
    }
}
