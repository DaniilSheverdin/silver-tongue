using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SilverTongue.Web.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SilverTongue.Web.Controllers
{
    [ApiController]
    public class DictionaryController : ControllerBase
    {
        private readonly ILogger<DictionaryController> _logger;
        private readonly Services.Dictionary.IDictionaryService _dictionaryService;

        public DictionaryController(ILogger <DictionaryController> logger, Services.Dictionary.IDictionaryService dictionaryService)
        {
            _logger = logger;
            _dictionaryService = dictionaryService;
        }

        [HttpPost("/api/dictionary")]
        public ActionResult GetDictionaryById([FromBody]int id)
        {
            _logger.LogInformation("Getting all notes");
            var notes = _dictionaryService.GetByUserId(id);
            return Ok(notes);
        }
    }
}
