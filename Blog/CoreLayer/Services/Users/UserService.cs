using CoreLayer.Utilities;
using CoreLayer.DTOs.Users;
using DAL.Context;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public OperationResult LoginUser(LoginUserDto loginDto)
        {
            var hashedPwd = loginDto.Password.EncodeToMd5();
            var user = _context.Users.Any(u => u.Username == loginDto.UserName && u.Password == hashedPwd);
            

            return user == false ? OperationResult.NotFound() : OperationResult.Success();

            
        }
    }
}
