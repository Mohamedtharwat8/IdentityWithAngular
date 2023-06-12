using API.DTOs.Account;
using API.Models;
using API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private readonly JWTService _jwtService;

        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        public AccountController(
            JWTService jwtService, 
            SignInManager<User> signInManager,
            UserManager<User> userManager)
        {
            _jwtService = jwtService;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);  
            if (user == null) return Unauthorized("Invalid UserName or Password");

            if (user.EmailConfirmed == false) return Unauthorized("Please Confirm You Email!");

            var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);
            if (!result.Succeeded) return Unauthorized("Invalid Username or Password");

            return CreateApplicationUserDto(user);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDto model)
        {
            if (await CheckEmailExistsASync(model.Email))
            {
                return BadRequest($"An Existing Account is Using {model.Email} , Email Address , Please Try Again !");
            }

            var userToAdd = new User
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName = model.Email.ToLower(),
                Email = model.Email.ToLower(),
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(userToAdd, model.Password);

            if (!result.Succeeded) return BadRequest(result.Errors);

            return Ok("Your Account has been Created , You Can Login ");
        }





        #region Private Helper Methods

        private UserDto CreateApplicationUserDto(User user)
        {

            return new UserDto
            {
                FirstName = user.FirstName,
                LastName    = user.LastName,
                JWT = _jwtService.CreateJWT(user)

            };
        }

        private async Task<bool> CheckEmailExistsASync(string email)
        {
            return await _userManager.Users.AnyAsync(x => x.Email == email.ToLower());    
        }

        #endregion

    }
}
