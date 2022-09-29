using Microsoft.AspNetCore.Mvc;
using NSI6.Models;
using NSI6.Service;
using NSI6.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSI6.Web.Areas.User.Controllers
{
    [Area("User")]
    [Route("User/[controller]/[action]/{id?}")]
    public class AuthController : BaseController
    {
        private readonly IUserService userService;

        public AuthController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Users()
        {
            var users = userService.ReadAll();

            return View(users);
        }

        [HttpPost]
        public IActionResult Registration(UserModel userModel)
        {
            if (ModelState.IsValid)
            {
                this.userService.Create(userModel);
                return View(userModel);
            }

            //Logic for registration

            return View();
        }
    }
}