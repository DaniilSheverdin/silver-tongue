using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SilverTongue.Services.User;
using SilverTongue.Web.Helpers;
using SilverTongue.Web.Serialization;
using SilverTongue.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SilverTongue.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private IMapper _mapper;
        private readonly AppSettings _appSettings;

        public UserController(
            IUserService userService,
            IMapper mapper,
            IOptions<AppSettings> appSettings)
        {
            _userService = userService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }
        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var user = _userService.Authenticate(model.Username, model.Password);

            if (user == null)
                return BadRequest(new { message = "Пользователя с таким логином и паролем не существует" });

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            // return basic user info and authentication token
            return Ok(new
            {
                Id = user.Id,
                Name = user.Name,
                Token = tokenString
            });
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterModel model)
        {
            // map model to entity
            var user = UserMapper.SerializeUserModel(model);

            try
            {
                // create user
                var status = _userService.Create(user, model.Password);
                return Ok(status);
            }
            catch (Exception ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
        //later need to comment 
        [Authorize]
        [HttpGet("rating")]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            var model = _mapper.Map<IList<UserModel>>(users);
            return Ok(model);
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetById()
        {
            var userId = int.Parse(User.Identity.Name);
            var user = _userService.GetById(userId);
            var model = _mapper.Map<UserModel>(user);
            return Ok(model);
        }
        [Authorize]
        [HttpDelete("del")]
        public IActionResult Delete()
        {
            var userId = int.Parse(User.Identity.Name);
            _userService.Delete(userId);
            return Ok();
        }
    }
}
