using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SilverTongue.Web.Serialization;
using SilverTongue.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SilverTongue.Web.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly Services.User.IUserService _UserService;

        public UserController(ILogger<UserController> logger, Services.User.IUserService UserService)
        {
            _logger = logger;
            _UserService = UserService;
        }

        [HttpGet("/api/user")]
        public ActionResult GetUser()
        {
            _logger.LogInformation("Getting all notes");
            var notes = _UserService.GetAllUser();
            var notesViewModels = notes
                .Select(note => UserMapper.SerializeUserModel(note));
            return Ok(notes);
        }
        [HttpPost("/api/registration")]
        public ActionResult AddUser([FromBody]UserModel user)
        {
            _logger.LogInformation("Getting all notes");

            var new_user = _UserService.AddUser(UserMapper.SerializeUserModel(user));
            return Ok(new_user);
        }
    }
}
