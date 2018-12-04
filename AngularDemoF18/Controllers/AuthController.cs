using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AngularDemoF18.Data;
using AngularDemoF18.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

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

        [HttpPost()]
        public async Task<IActionResult> Login(LoginDTO user)
        {
            if (ModelState.IsValid)
            {
                var userInfo = await _userManager.FindByNameAsync(user.UserName);
                if (userInfo == null)
                {
                    return Unauthorized();
                }
                var result = await _signinManager.CheckPasswordSignInAsync(userInfo, user.Password, false);      // user.UserName, user.Password, false, false);
                if (result.Succeeded)
                {
                    var tokenString = BuildToken(user);
                    return Ok(new { tokenString, User = userInfo });
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                }
            }

            return Unauthorized();

        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserVM user)
        {

            User newUser = new User { UserName = user.UserName };
            var result = await _userManager.CreateAsync(newUser, user.Password);
           
            if (result.Succeeded)
            {
                return Ok(new { Msg = "Registration succeeded", User = newUser.UserName, ID = newUser.Id });
            }
            return BadRequest(result);

        }

        private string BuildToken(LoginDTO user)
        {
            var claims = new[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.UserName),
                        new Claim(ClaimTypes.Name, user.UserName)
                    };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Bogus Secret Key"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(null, null, claims,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}