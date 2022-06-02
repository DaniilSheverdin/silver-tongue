using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SilverTongue.Web.Serialization;
using SilverTongue.Web.ViewModels;
using System.Collections.Generic;

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
        public ActionResult check(ForCheckModel phrase)
        {

            var userId = int.Parse(User.Identity.Name);
            _logger.LogInformation("Checking...");
            var check = _CheckerService.Check(phrase.word.ToLower(), userId);
            if (check.IsSucces)
                return Ok(CheckMapper.SerializeCheckModel(check.Data));
            else
                return Ok(check);
        }
        [Authorize]
        [HttpGet("archive")]
        public ActionResult archive()
        {
            var userId = int.Parse(User.Identity.Name);
            _logger.LogInformation("getting archive...");
            var archive = _CheckerService.getArchive(userId);
            if (archive.IsSucces)
                return Ok(CheckMapper.SerializeArchiveModel(archive.Data));
            else
                return Ok(archive);
        }
    }
}