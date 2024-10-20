using System.Collections.Generic;
using CoreLayer.Utilities;

namespace CoreLayer.DTOs.Users
{
    public class UserFilterDto:BasePagination
    {
        public List<UserDto> Users { get; set; }
    }

}