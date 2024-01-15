using Microsoft.AspNetCore.Mvc;
using Test.Extentions;

namespace Test.Controllers
{
    [ApiController, Route("api/[controller]/[action]")]
    public class StringExtentionController : Controller
    {
        [HttpGet]
        public IActionResult StringExtention(string str) {
        
            return Ok(new
            {
                Int=str.AcceptInt(),
                charOnly=str.AcceptString(),
                charAndSpecial=str.AcceptStringAndSpecialChar(),
                Max=str.MaxLength(5),
                Min=str.MinLength(2),
                MinMax=str.MinMaxLength(2,5),
            });
        }
    }
}
