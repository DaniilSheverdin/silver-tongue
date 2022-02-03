using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SilverTongue.Web.Serialization;
using SilverTongue.Web.ViewModels;

namespace SilverTongue.Web.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class DictionaryController : ControllerBase
    {
        private readonly ILogger<DictionaryController> _logger;
        private readonly Services.Dictionary.IDictionaryService _dictionaryService;

        public DictionaryController(ILogger<DictionaryController> logger, Services.Dictionary.IDictionaryService dictionaryService)
        {
            _logger = logger;
            _dictionaryService = dictionaryService;
        }

        [HttpGet("my")]
        public ActionResult GetDictionaryByUserId()
        {
            _logger.LogInformation("Getting all notes");
            var userId = int.Parse(User.Identity.Name);
            var notes = _dictionaryService.GetByUserId(userId);
            return Ok(notes);
        }
        [HttpPost("add")]
        public ActionResult AddNote([FromBody] DictionaryModel model)
        {
            _logger.LogInformation("adding note");
            var userId = int.Parse(User.Identity.Name);
            var notes = _dictionaryService.AddNote(DictionaryMapper.SerializeDictionaryModel(model), userId);
            return Ok(notes);
        }
        [HttpDelete("del")]
        public ActionResult DeleteNote([FromBody] string word)
        {
            _logger.LogInformation("deliting note");
            var userId = int.Parse(User.Identity.Name);
            var notes = _dictionaryService.DeleteNote(word, userId);
            return Ok(notes);
        }
    }
}
