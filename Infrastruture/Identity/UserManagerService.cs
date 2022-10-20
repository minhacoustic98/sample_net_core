using Application.Common.Interface;
using Application.Common.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastruture.Identity
{
    public class UserManagerService : IUserManager
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public UserManagerService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<(Result result, string UserId)> CreateUserAsync(string username, string password)
        {
            var user = new ApplicationUser
            {
                UserName = username,
                Email = username
            };

            var result = await _userManager.CreateAsync(user, password);
            return (result.ToApplicationResult(), user.Id);
        }

        public async Task<Result> DeleteUserAsync(string userId)
        {
            var user = _userManager.Users.SingleOrDefault(u => u.Id == userId);
            if(user!=null)
            {
                var result = await _userManager.DeleteAsync(user);
                return result.ToApplicationResult();
            }
            return Result.Failure(new string[] { "Not found", "May be due to internet connectivity" });
        }
    }
}
