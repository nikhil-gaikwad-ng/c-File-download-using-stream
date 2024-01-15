using Microsoft.AspNetCore.Mvc;

namespace Test.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class LockkController : ControllerBase
    {
        private static readonly SemaphoreSlim semaphore = new SemaphoreSlim(1, 1); // Initial count and max count both set to 1
        public static int num = 1;

        public LockkController()
        {
        }

        [HttpGet]
        [ActionName("EditetAction")]
        [Route("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            try
            {
                await semaphore.WaitAsync();
                await Task.Delay(TimeSpan.FromSeconds(10));
                var a = id;
                return Ok(num++);
            }
            catch
            {
                return BadRequest("Failed");
            }
            finally
            {
                semaphore.Release();
            }
        }
    }
}
