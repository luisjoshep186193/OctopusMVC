using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Octopus.Models;

namespace Octopus.Services
{
    public interface IUserData
    {

         Task<User> GetCurrentUserId(string userId);
         string getCurrentUserName(string attr);
    }
}
