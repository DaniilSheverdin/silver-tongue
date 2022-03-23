using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;

namespace SilverTongue.Web.Controllers
{
    [Authorize]
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
        [HttpPost("check")]
        public ActionResult check([FromBody] string phrase)
        {

            var userId = int.Parse(User.Identity.Name);
            _logger.LogInformation("Checking...");
            var check = _CheckerService.Check(phrase, userId);

            return Ok(check);
        }
    }
}