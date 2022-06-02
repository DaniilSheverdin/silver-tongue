using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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
    [Route("[controller]")]
    [ApiController]
    public class UserTestController : ControllerBase
    {
        private readonly ILogger<UserTestController> _logger;
        private readonly Services.UserTests.IUserTestService _TestService;
        private IMapper _mapper;

        public UserTestController(ILogger<UserTestController> logger,
        Services.UserTests.IUserTestService TestService, IMapper mapper)
        {
            _logger = logger;
            _TestService = TestService;
            _mapper = mapper;
        }

        [Authorize]
        [HttpGet("all")]
        public ActionResult all()
        {
            try
            {
                var tests = _TestService.GetAllTests();
                var model = _mapper.Map<IList<TestModel>>(tests);
                return Ok(model);
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }
        [Authorize]
        [HttpPost("one")]
        public ActionResult one(ModelOne model)
        {
            try
            {
                var test = _TestService.GetOneTest(model.id);
                return Ok(TestMapper.SerializeOneTest(test));
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }
        [Authorize]
        [HttpGet("result")]
        public ActionResult result(Answer answers)
        {
            try
            {
                var userId = int.Parse(User.Identity.Name);
                var res = _TestService.GetResult(answers.answers, answers.TestID, userId);
                return Ok(res);
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }
    }

    public class ModelOne
    {
        public int id { get; set; }
    }
}
