using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Octopus.Data;
using Octopus.Models;

namespace Octopus.Services
{
    public class UserData: ControllerBase, IUserData
    {

        private readonly ApplicationDbContext _context;
        private readonly SignInManager<User> _SignInManager;
        private readonly UserManager<User> _UserManager;
        public const string SessionKeyName = "UserData";

        public UserData(ApplicationDbContext context,
            SignInManager<User> SignInManager,
            UserManager<User> UserManager)
        {
            _context = context;
            _SignInManager = SignInManager;
            _UserManager = UserManager;

        }

        public UserData()
        {
        }

        public string getCurrentUserName(string attr)
        {
            return _SignInManager.IsSignedIn(User) ? User.FindFirstValue(ClaimTypes.Name) : "";
        }

        public string getCurrentUserId(SignInManager<User> attr)
        {
            return _SignInManager.IsSignedIn(User) ? User.FindFirstValue(ClaimTypes.NameIdentifier) : "";
        }
    }
}
