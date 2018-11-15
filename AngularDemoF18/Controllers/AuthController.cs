using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngularDemoF18.Data;
using AngularDemoF18.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AngularDemoF18.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signinManager;

        public AuthController(UserManager<User> userManager, SignInManager<User> signinman)
        {
            _userManager = userManager;
            _signinManager = signinman;
        }

        [HttpGet]
        public string Get()
        {
            return "Test succeeded";
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserVM user)
        {

            User newUser = new User { UserName = user.UserName };
            var result = await _userManager.CreateAsync(newUser, user.Password);
            var signinResult = await _signinManager.PasswordSignInAsync(newUser, user.Password, false, false);
            var user2 = new User { UserName = user.UserName };
            var test = await _signinManager.UserManager.FindByNameAsync(user.UserName);
            if (result.Succeeded)
            {
                return Ok(new { Msg = "Registration succeeded", User = newUser.UserName, ID = newUser.Id });
            }
            return BadRequest(result);

        }


    }
}