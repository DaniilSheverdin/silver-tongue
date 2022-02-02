using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SilverTongue.Web.ViewModels;
using SilverTongue.Web.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SilverTongue.Web.Controllers
{
    public class SymSpellController : ControllerBase
    {
        private readonly ILogger<SymSpellController> _logger;
        private readonly Services.Checker.ISymSpellCheckerService _SpellCheckerService;

        public SymSpellController(ILogger<SymSpellController> logger, Services.Checker.ISymSpellCheckerService SpellCheckerService)
        {
            _logger = logger;
            _SpellCheckerService = SpellCheckerService;
        }
        [HttpPost("/api/spellcheck")]
        public ActionResult AddUser([FromBody] SpellCheckModel model)
        {
            _logger.LogInformation("Checking...");

            var check = _SpellCheckerService.SpellCheck(SpellMapper.SerializeSpellModel(model));
            return Ok(check);
        }
    }
}
