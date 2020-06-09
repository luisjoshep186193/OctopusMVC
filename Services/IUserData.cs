using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Octopus.Models;

namespace Octopus.Services
{
    public interface IUserData
    {

        string getCurrentUserId(SignInManager<User> attr);
        string getCurrentUserName(string attr);
    }
}
