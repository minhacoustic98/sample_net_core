using Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interface
{
    public interface IUserManager
    {
        Task<(Result result, string UserId)> CreateUserAsync(string username, string password);
        Task<Result> DeleteUserAsync(string userId);
    }
}
