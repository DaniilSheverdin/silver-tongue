/*using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace SilverTongue.Web.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class SSConroller : ControllerBase
    {
        private readonly ILogger<SSConroller> _logger;
        private readonly Services.Checker.ISymSpellCheckerService _SpellCheckerService;

        public SSConroller(ILogger<SSConroller> logger, Services.Checker.ISymSpellCheckerService SpellCheckerService)
        {
            _logger = logger;
            _SpellCheckerService = SpellCheckerService;
        }
        [HttpPost]
        public ActionResult AddCheck([FromBody] string word)
        {
            _logger.LogInformation("Checking...");
            var userId = int.Parse(User.Identity.Name);
            var check = _SpellCheckerService.SpellCheck(word, userId);
            return Ok(check);
        }
    }
}
*/