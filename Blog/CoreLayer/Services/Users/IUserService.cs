using CoreLayer.Utilities;
using CoreLayer.DTOs.Users;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Services.Users
{
    public interface IUserService
    {
        OperationResult RegisterUser(UserRegisterDto registerDto);
    }
}
