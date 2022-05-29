﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SilverTongue.Web.Serialization;

namespace SilverTongue.Web.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SSController : ControllerBase
    {
        private readonly ILogger<SSController> _logger;
        private readonly Services.Checker.ICheckerService _CheckerService;

        public SSController(ILogger<SSController> logger, Services.Checker.ICheckerService CheckerService)
        {
            _logger = logger;
            _CheckerService = CheckerService;
        }
        [Authorize]
        [HttpPost("check")]
        public ActionResult check([FromBody] string phrase)
        {

            var userId = int.Parse(User.Identity.Name);
            _logger.LogInformation("Checking...");
            var check = _CheckerService.Check(phrase, userId);
            return Ok(CheckMapper.SerializeCheckModel(check.Data));
        }
    }
}