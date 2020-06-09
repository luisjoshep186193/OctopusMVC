using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Octopus.Data;
using Octopus.Models;
using Microsoft.AspNetCore.Http;

namespace Octopus.Helpers
{
    public class StaticResources
    {
        private readonly SignInManager<User> _SignInManager;
        private readonly UserManager<User> _UserManager;
        public StaticResources(SignInManager<User> SignInManager,
            UserManager<User> UserManager)
        {
        }

    }
}
